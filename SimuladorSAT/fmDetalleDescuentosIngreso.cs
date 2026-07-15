using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleDescuentosIngresos : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;

        public fmDetalleDescuentosIngresos()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.SuspendLayout();
            CargarDatosTabla();
            CargarValorExistente();
            this.ResumeLayout(true);
        }

        private void CargarDatosTabla()
        {
            dgvTabla.Rows.Add("Abril", "0", "1", "", "", "");
        }

        private void CargarValorExistente()
        {
            decimal valorPrevio = Program.modeloIsrFisicas.Descuentos;
            txtCampo2.Text = valorPrevio > 0 ? valorPrevio.ToString("N0") : "";
            RecalcularTotal();
        }

        private void txtCampo2_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            decimal.TryParse(txtCampo1.Text, out decimal comprobantes);
            decimal.TryParse(txtCampo2.Text, out decimal integrantes);
            decimal total = comprobantes + integrantes;
            txtCampo3.Text = total.ToString("N0");
        }

        private void GuardarYCerrar()
        {
            decimal.TryParse(txtCampo2.Text, out decimal valor);
            MontoCapturado = valor;
            Program.modeloIsrFisicas.Descuentos = valor;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            GuardarYCerrar();
        }

        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            GuardarYCerrar();
        }
    }
}