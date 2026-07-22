using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmPagoISR : Form
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

        private void CargarImagenesCabecera()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string rutaEscudo = Path.Combine(baseDir, "escudo.png");
                string rutaLogo = Path.Combine(baseDir, "logouthh.png");
                if (File.Exists(rutaEscudo)) picLogoUthh.Image = Image.FromFile(rutaEscudo);
                if (File.Exists(rutaLogo)) picEscudoUthh.Image = Image.FromFile(rutaLogo);
            }
            catch { /* Evita interrupciones en tiempo de diseño */ }
        }

        private void AsignarEventosNavegacion()
        {
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
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, null); // Se pasa null para mantener su FormWindowState.Maximized explícito
            if (!this.IsDisposed) this.Hide();
        }

        private void IrAPresentarDeclaracion()
        {
            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            }
            Program.formPresentar.WindowState = FormWindowState.Maximized;
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, null); // Se pasa null para mantener su FormWindowState.Maximized explícito
            if (!this.IsDisposed) this.Hide();
        }
    }
}