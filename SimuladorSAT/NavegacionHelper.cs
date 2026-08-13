using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public static class NavegacionHelper
    {
        // Desactiva la animación de transición de DWM para esta ventana (por si acaso
        // algún control interno o Windows intenta animar igual).
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;

        private static void DesactivarAnimacionVentana(Form f)
        {
            try
            {
                int valor = 1;
                DwmSetWindowAttribute(f.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref valor, sizeof(int));
            }
            catch
            {
                // Si falla (SO viejo, etc.) seguimos sin romper nada.
            }
        }

        public static void MostrarSinParpadeo(Form destino, Form origen)
        {
            if (destino == null || origen == null) return;

            // Área de trabajo real (excluye la barra de tareas), tomada de la pantalla
            // donde está la ventana de origen (soporta multi-monitor).
            var area = Screen.FromControl(origen).WorkingArea;

            destino.StartPosition = FormStartPosition.Manual;

            // IMPORTANTE: nunca usamos FormWindowState.Maximized aquí.
            // Maximized dispara la animación nativa de Windows, que es la causante
            // del "pantallazo". En vez de eso, fijamos el tamaño/posición directamente.
            destino.WindowState = FormWindowState.Normal;
            destino.Opacity = 0; // invisible mientras se prepara
            destino.Bounds = area;

            destino.Show(); // crea el handle nativo y dispara Load
            DesactivarAnimacionVentana(destino);

            if (destino is IInfoDeclaracion formConInfo)
            {
                formConInfo.ActualizarInfoDeclaracion();
            }

            // Por si algún control del Load reajustó el tamaño, lo reafirmamos.
            destino.Bounds = area;

            destino.Activate();
            destino.BringToFront();
            destino.Refresh();
            destino.Opacity = 1; // aparece de golpe, ya completamente dibujado y activo

            origen.Hide();
        }

        public static void CargarEncabezadoUsuario(Label lblDatosIzq)
        {
            if (lblDatosIzq == null) return;
            try
            {
                var conexion = new clsConexion();
                var (matricula, nombre) = conexion.ObtenerDatosContribuyente(Program.contribuyenteId);
                if (!string.IsNullOrEmpty(matricula) || !string.IsNullOrEmpty(nombre))
                {
                    lblDatosIzq.Text = $"Matricula: {matricula} | {nombre.ToUpper()}";
                }
                else
                {
                    lblDatosIzq.Text = $"SIN DATOS (ID Actual: {Program.contribuyenteId})";
                }
            }
            catch (Exception ex)
            {
                lblDatosIzq.Text = $"ERROR: {ex.Message}";
            }
        }

        // Se conserva por si algo más la referencia, aunque MostrarSinParpadeo ya no
        // la necesita.
        public static void AplicarMaximizadoConBarra(Form f)
        {
            var area = Screen.FromControl(f).WorkingArea;
            f.StartPosition = FormStartPosition.Manual;
            f.WindowState = FormWindowState.Normal;
            f.Bounds = area;
        }
    }
}