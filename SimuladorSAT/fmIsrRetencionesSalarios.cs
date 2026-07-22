using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrRetencionesSalarios : Form
    {
        public fmIsrRetencionesSalarios()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            AsignarEventosNavegacion();
        }

        private void AsignarEventosNavegacion()
        {
            btnCerrar.Click += BtnCerrar_Click;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (Program.formAdmin == null || Program.formAdmin.IsDisposed)
            {
                Program.formAdmin = new fmAdminDeclaracion();
            }

            // Copiamos el WindowState manualmente antes de navegar
            Program.formAdmin.WindowState = this.WindowState;
            Program.formAdmin.Show();
            this.Hide();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            }

            // Copiamos el WindowState manualmente antes de navegar
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
            if (Program.formPagoIsr == null || Program.formPagoIsr.IsDisposed)
            {
                Program.formPagoIsr = new fmPagoISR();
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formPagoIsr, this);
        }
    }
}