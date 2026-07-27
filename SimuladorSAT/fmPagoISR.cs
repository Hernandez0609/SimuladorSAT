using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmPagoISR : Form, IInfoDeclaracion
    {
        public fmPagoISR()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarImagenesCabecera();
            AsignarEventosNavegacion();
        }
        public void ActualizarInfoDeclaracion()
        {
            if (Program.declaracionActual == null) return;

            var d = Program.declaracionActual;
            DateTime vencimiento = d.CalcularVencimiento();

            lblDatosDerecha.Text =
                $"Ejercicio: {d.Ejercicio} / periodo: {d.Periodo}\r\n" +
                $"Declaración: {d.TipoDeclaracion}\r\n" +
                $"Vencimiento: {vencimiento:dd/MM/yy}";
        }
        private void CargarImagenesCabecera()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string rutaEscudo = Path.Combine(baseDir, "escudo.png");
                string rutaLogo = Path.Combine(baseDir, "logouthh.png");
                if (File.Exists(rutaLogo)) picLogoUthh.Image = Image.FromFile(rutaLogo);
                if (File.Exists(rutaEscudo)) picEscudoUthh.Image = Image.FromFile(rutaEscudo);
            }
            catch { /* Evita interrupciones en tiempo de diseño */ }
        }

        private void AsignarEventosNavegacion()
        {
            // Primero desvinculamos para evitar que los eventos se acumulen si se llama más de una vez
            btnTabDeterminacion.Click -= BtnTabDeterminacion_Click;

            // Asignación de eventos limpia
            btnTabDeterminacion.Click += BtnTabDeterminacion_Click;
            btnInicio.Click += (s, e) => IrAPresentarDeclaracion();
            btnCerrar.Click += (s, e) => IrAAdminDeclaracion();
            btnAdministracion.Click += (s, e) => IrAAdminDeclaracion();
        }

        private void BtnTabDeterminacion_Click(object sender, EventArgs e)
        {
            if (Program.formIsrSalarios == null || Program.formIsrSalarios.IsDisposed)
            {
                Program.formIsrSalarios = new fmIsrRetencionesSalarios();
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrSalarios, this);
        }

        private void IrAAdminDeclaracion()
        {
            if (Program.formAdmin == null || Program.formAdmin.IsDisposed)
            {
                Program.formAdmin = new fmAdminDeclaracion();
            }

            Program.formAdmin.WindowState = FormWindowState.Maximized;

            // CORRECCIÓN CLAVE: Pasamos 'this' en lugar de 'null'.
            // NavegacionHelper se encarga de mostrar 'formAdmin' y ocultar 'this' sin parpadeos ni NullReferenceException.
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void IrAPresentarDeclaracion()
        {
            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            }

            Program.formPresentar.WindowState = FormWindowState.Maximized;

            // CORRECCIÓN CLAVE: Pasamos 'this' en lugar de 'null'.
            // Mantiene el Maximized correctamente y oculta la ventana actual de forma segura.
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void GuardarYMarcarCompletado()
        {
            if (Program.declaracionActual == null) return;

            var conexion = new clsConexion();
            conexion.MarcarModuloCompletado(Program.declaracionActual.Id, "modulo_isr_salarios_completado");
            Program.declaracionActual.ModuloIsrSalariosCompletado = true;
            Program.formAdmin.AplicarModulosDeclaracionActual();
            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}