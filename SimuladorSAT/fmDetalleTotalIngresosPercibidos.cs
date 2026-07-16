using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleTotalIngresosPercibidos : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;

        public fmDetalleTotalIngresosPercibidos()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            var area = Screen.PrimaryScreen.WorkingArea;
            this.ClientSize = new System.Drawing.Size((int)(area.Width * 0.80), (int)(area.Height * 0.60));

            // NUEVO — btnCerrar se posiciona debajo del contenido real, no solo pegado al fondo de la ventana
            int yBtnCerrar = lblTotalRegistros.Location.Y + lblTotalRegistros.Height + 40; // 40px de margen
            int yMinimo = this.ClientSize.Height - btnCerrar.Height - 30; // nunca más abajo que esto (esquina)
            int yFinal = Math.Max(yBtnCerrar, this.ClientSize.Height - btnCerrar.Height - 30);

            btnCerrar.Location = new System.Drawing.Point(
                this.ClientSize.Width - btnCerrar.Width - 30,
                Math.Min(yFinal, this.ClientSize.Height - btnCerrar.Height - 20) // no se sale de la ventana
            );

            CentrarPaginacion();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            ActualizarEstadoLista();
        }

        private void CentrarPaginacion()
        {
            int centroX = (this.ClientSize.Width - lblPagina.Width) / 2;
            lblPagina.Location = new System.Drawing.Point(centroX, lblTotalRegistros.Location.Y);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlFormularioCaptura.Visible = true;
            btnAgregar.Visible = false;
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbConcepto.SelectedIndex > 0;
            txtImporte.Enabled = haySeleccion;
            txtImporte.BackColor = haySeleccion
                ? System.Drawing.Color.White
                : System.Drawing.Color.FromArgb(238, 238, 238);

            if (!haySeleccion)
                txtImporte.Text = "";
        }

        private void btnGuardarCaptura_Click(object sender, EventArgs e)
        {
            if (cmbConcepto.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecciona un concepto válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtImporte.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("Ingresa un importe válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvRegistros.Rows.Add(cmbConcepto.SelectedItem.ToString(), importe.ToString("N0"));

            LimpiarFormularioCaptura();
            pnlFormularioCaptura.Visible = false;
            btnAgregar.Visible = true;

            ActualizarEstadoLista();
        }

        private void btnCancelarCaptura_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCaptura();
            pnlFormularioCaptura.Visible = false;
            btnAgregar.Visible = true;
        }

        private void LimpiarFormularioCaptura()
        {
            cmbConcepto.SelectedIndex = 0;
            txtImporte.Text = "";
            txtImporte.Enabled = false;
            txtImporte.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
            {
                dgvRegistros.Rows.RemoveAt(e.RowIndex);
                ActualizarEstadoLista();
            }
        }

        // ====================================================================
        // Actualiza contador, paginación, y la fila de Total (siempre visible)
        // ====================================================================
        private void ActualizarEstadoLista()
        {
            int totalRegistros = dgvRegistros.Rows.Count;
            lblTotalRegistros.Text = $"Total de registros            {totalRegistros}";
            lblPagina.Text = totalRegistros > 0 ? "< Página 1 de 1 >" : "< Página 1 de 0 >";
            CentrarPaginacion();

            decimal total = 0;
            foreach (DataGridViewRow fila in dgvRegistros.Rows)
            {
                if (decimal.TryParse(fila.Cells[colImporte.Index].Value?.ToString(), out decimal valorFila))
                {
                    total += valorFila;
                }
            }

            lblTotalImporteCell.Text = total.ToString("N0");
            txtMontoDetallado.Text = total.ToString("N0");
        }

        private void GuardarYCerrar()
        {
            decimal total = decimal.Parse(lblTotalImporteCell.Text.Replace(",", ""));
            MontoCapturado = total;
            Program.modeloIsrFisicas.TotalIngresosPercibidos = total;
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