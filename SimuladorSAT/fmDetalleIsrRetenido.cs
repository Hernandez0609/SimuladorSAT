using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleIsrRetenido : Form
    {
        public fmDetalleIsrRetenido()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;
        }

        private void fmDetalleIsrRetenido_Load(object sender, EventArgs e)
        {
            InicializarEsqueletoTablas();
        }

        private void InicializarEsqueletoTablas()
        {
            // --- TABLA 1 ---
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

            // --- TABLA 2 ---
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

            // --- CAMPOS DE TEXTO INFERIORES ---
            txtCampo1.Text = "";
            txtCampo2.Text = "";
            txtCampo3.Text = "";
            txtCampo4.Text = "";
        }

        private void btnIconoCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}