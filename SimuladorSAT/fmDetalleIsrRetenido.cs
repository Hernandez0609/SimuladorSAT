using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleIsrRetenido : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;
        private readonly decimal _montoMaximo;

        public fmDetalleIsrRetenido(decimal montoMaximo)
        {
            InitializeComponent();
            _montoMaximo = montoMaximo;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;

            txtCampo2.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtCampo3.KeyPress += clsValidacionNumerica.SoloNumeros;

            // Cargar datos previos desde el modelo
            txtCampo1.Text = Program.modeloIsrFisicas.IsrRetenidoFacturas.ToString("N0");
            txtCampo2.Text = Program.modeloIsrFisicas.IsrRetenidoAdicional.ToString("N0");
            txtCampo3.Text = Program.modeloIsrFisicas.IsrRetenidoDisminuir.ToString("N0");

            txtCampo2.TextChanged += (s, e) => RecalcularTotal();
            txtCampo3.TextChanged += (s, e) => RecalcularTotal();
        }
        private void fmDetalleIsrRetenido_Load(object sender, EventArgs e)
        {
            InicializarEsqueletoTablas();
            RecalcularTotal();
        }

        private void InicializarEsqueletoTablas()
        {
            dgvTabla1.Rows.Clear();
            int fila1Index = dgvTabla1.Rows.Add();
            DataGridViewRow fila1 = dgvTabla1.Rows[fila1Index];
            fila1.Cells[0].Value = "Abril";
            for (int i = 0; i < dgvTabla1.ColumnCount; i++)
            {
                fila1.Cells[i].Style.BackColor = Color.FromArgb(238, 238, 238);
            }
            for (int i = 1; i < dgvTabla1.ColumnCount; i++)
            {
                fila1.Cells[i].Value = "";
            }

            dgvTabla2.Rows.Clear();
            int fila2Index = dgvTabla2.Rows.Add();
            DataGridViewRow fila2 = dgvTabla2.Rows[fila2Index];
            fila2.Cells[0].Value = "Abril";
            for (int i = 0; i < dgvTabla2.ColumnCount; i++)
            {
                fila2.Cells[i].Style.BackColor = Color.FromArgb(238, 238, 238);
            }
            for (int i = 1; i < dgvTabla2.ColumnCount; i++)
            {
                fila2.Cells[i].Value = "";
            }
        }

        private decimal ParsearMonto(string texto)
        {
            string limpio = texto.Replace("$", "").Replace(",", "").Trim();
            return decimal.TryParse(limpio, out decimal valor) ? valor : 0;
        }

        private void RecalcularTotal()
        {
            decimal campo1 = ParsearMonto(txtCampo1.Text);
            decimal campo2 = ParsearMonto(txtCampo2.Text);
            decimal campo3 = ParsearMonto(txtCampo3.Text);
            decimal total = campo1 + campo2 - campo3;
            if (total < 0) total = 0;
            if (total > _montoMaximo) total = _montoMaximo;   
            txtCampo4.Text = total.ToString("N0");
        }

        private void btnIconoCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            RecalcularTotal();
            MontoCapturado = ParsearMonto(txtCampo4.Text);

            // Guardar valores desglosados y total en el modelo global
            Program.modeloIsrFisicas.IsrRetenidoFacturas = ParsearMonto(txtCampo1.Text);
            Program.modeloIsrFisicas.IsrRetenidoAdicional = ParsearMonto(txtCampo2.Text);
            Program.modeloIsrFisicas.IsrRetenidoDisminuir = ParsearMonto(txtCampo3.Text);
            Program.modeloIsrFisicas.IsrRetenido = MontoCapturado;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}