using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturar : Form
    {
        private Color grisFigma = Color.FromArgb(238, 238, 238);
        private Color blanco = Color.White;

        public fmCapturar(string modoPantalla)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.SuspendLayout();
            ConfigurarPantalla(modoPantalla);
            this.ResumeLayout(true);
        }

        private void ConfigurarPantalla(string modo)
        {
            if (modo == "Tasa0")
            {
                this.Text = "Actividades gravadas a la tasa del 0%";
                this.lblTitulo.Text = "Actividades gravadas a la tasa del 0%";
                this.lblDescripcion.Text = "Detalla el importe de las actividades gravadas a la tasa del 0%";
                this.lblCampo1.Text = "Actividades gravadas a la tasa del 0%";
                this.lblCampo2.Text = "Monto por detallar";
                this.lblCampo3.Text = "Monto detallado";
                this.lblCampo4.Text = "Actividades nacionales gravadas a la tasa del 0%";
                this.lblCampo5.Text = "Actividades de exportación gravadas a la tasa del 16%";
                this.btnDetalleCampo1.Visible = true;
                ConfigurarEstiloCampo(txtCampo1, true, "0");
                ConfigurarEstiloCampo(txtCampo2, true, "0");
                ConfigurarEstiloCampo(txtCampo3, true, "0");
                ConfigurarEstiloCampo(txtCampo4, true, "0");
                ConfigurarEstiloCampo(txtCampo5, true, "0");
            }
            else if (modo == "IvaAcreditable")
            {
                this.Text = "IVA acreditable del periodo";
                this.lblTitulo.Text = "IVA acreditable del periodo";
                this.lblDescripcion.Text = "";
                this.lblCampo1.Text = "IVA pagado en gastos y adquisiciones";
                this.lblCampo2.Text = "*IVA acreditable por actividades gravadas a tasa 16% u 8% y tasa 0%";
                this.lblCampo3.Text = "*IVA acreditable por actividades mixtas";
                this.lblCampo4.Text = "IVA acreditable del periodo";
                this.lblCampo5.Text = "IVA no acreditable";
                this.btnDetalleCampo1.Visible = false;
                ConfigurarEstiloCampo(txtCampo1, true, "0");
                ConfigurarEstiloCampo(txtCampo2, false, "");
                ConfigurarEstiloCampo(txtCampo3, false, "");
                ConfigurarEstiloCampo(txtCampo4, true, "0");
                ConfigurarEstiloCampo(txtCampo5, false, "0");
            }
        }

        private void ConfigurarEstiloCampo(TextBox txt, bool esGris, string valorInicial)
        {
            txt.Text = valorInicial;
            if (esGris)
            {
                txt.BackColor = grisFigma;
                txt.ReadOnly = true;
            }
            else
            {
                txt.BackColor = blanco;
                txt.ReadOnly = false;
            }
        }

        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalleCampo1_Click(object sender, EventArgs e)
        {
            using (fmDetalle ventanaDetalle = new fmDetalle("Actividades gravadas a la tasa del 0%", "Junio"))
            {
                ventanaDetalle.ShowDialog(this);
            }
        }
    }
}
