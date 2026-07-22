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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Program.formAdmin == null || Program.formAdmin.IsDisposed)
            {
                Program.formAdmin = new fmAdminDeclaracion();
            }

            // Transición limpia utilizando el Helper
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            }

            // Transición limpia utilizando el Helper
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
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