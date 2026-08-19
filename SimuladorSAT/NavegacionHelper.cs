using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public static class NavegacionHelper
    {
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
                
            }
        }

        public static void MostrarSinParpadeo(Form destino, Form origen)
        {
            if (destino == null || origen == null) return;

            var area = Screen.FromControl(origen).WorkingArea;
            destino.StartPosition = FormStartPosition.Manual;
            destino.WindowState = FormWindowState.Normal;
            destino.Opacity = 0;
            destino.Bounds = area;

            destino.Show();
            DesactivarAnimacionVentana(destino);

            ResponsiveHelper.Aplicar(destino);   // <-- se agrega aquí, una sola línea

            if (destino is IInfoDeclaracion formConInfo)
                formConInfo.ActualizarInfoDeclaracion();

            destino.Bounds = area;
            destino.Activate();
            destino.BringToFront();
            destino.Refresh();
            destino.Opacity = 1;

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

        public static void AplicarMaximizadoConBarra(Form f)
        {
            var area = Screen.FromControl(f).WorkingArea;
            f.StartPosition = FormStartPosition.Manual;
            f.WindowState = FormWindowState.Normal;
            f.Bounds = area;
        }
    }
}