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
            // 'Cerrar' regresa un paso atrás a fmAdminDeclaracion
            Program.formAdmin.WindowState = this.WindowState;
            Program.formAdmin.Show();
            this.Hide();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // 'Inicio' siempre regresa a la base fija: fmPresentarDeclaracion
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
            Program.formPagoIsr.WindowState = FormWindowState.Maximized;
            Program.formPagoIsr.Show();
            this.Hide();
        }
    }
}