using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleIngresosAdicionales : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;

        public fmDetalleIngresosAdicionales()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            var area = Screen.PrimaryScreen.WorkingArea;
            this.ClientSize = new System.Drawing.Size((int)(area.Width * 0.80), (int)(area.Height * 0.60));
            btnCerrar.Location = new System.Drawing.Point(
            this.ClientSize.Width - btnCerrar.Width - 30,   // 30px de margen desde el borde derecho
            this.ClientSize.Height - btnCerrar.Height - 30  // 30px de margen desde el borde inferior
            );


           CentrarPaginacion();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarRegistrosDesdeModelo();
            ActualizarEstadoLista();
            txtImporte.KeyPress += clsValidacionNumerica.SoloNumeros;
        }
        private void CargarRegistrosDesdeModelo()   
        {
            dgvRegistros.Rows.Clear();
            foreach (var registro in Program.modeloIsrFisicas.ListaIngresosAdicionales)
            {
                dgvRegistros.Rows.Add(registro.Concepto, registro.Importe.ToString("N0"));
            }
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

            string conceptoElegido = cmbConcepto.SelectedItem.ToString();
            foreach (DataGridViewRow fila in dgvRegistros.Rows)
            {
                if (fila.Cells[0].Value?.ToString() == conceptoElegido)
                {
                    MessageBox.Show("Captura la cantidad requerida.", "Concepto repetido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!decimal.TryParse(txtImporte.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("Ingresa un importe válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvRegistros.Rows.Add(conceptoElegido, importe.ToString("N0"));
            Program.modeloIsrFisicas.ListaIngresosAdicionales.Add((conceptoElegido, importe));
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
                Program.modeloIsrFisicas.ListaIngresosAdicionales.RemoveAt(e.RowIndex);
                dgvRegistros.Rows.RemoveAt(e.RowIndex);
                ActualizarEstadoLista();
            }
        }

        private void ActualizarEstadoLista()
        {
            int totalRegistros = dgvRegistros.Rows.Count;
            lblTotalRegistros.Text = $"Total de registros            {totalRegistros}";
            lblPagina.Text = totalRegistros > 0 ? "< Página 1 de 1 >" : "< Página 1 de 0 >";
            CentrarPaginacion();
            lblMensajeAlerta.Visible = totalRegistros == 0;

            decimal total = 0;
            foreach (DataGridViewRow fila in dgvRegistros.Rows)
            {
                if (decimal.TryParse(fila.Cells[colImporte.Index].Value?.ToString(), out decimal valorFila))
                {
                    total += valorFila;
                }
            }
            txtTotalIngresosAdicionales.Text = total.ToString("N0");
        }

        private void GuardarYCerrar()
        {
            decimal.TryParse(txtTotalIngresosAdicionales.Text, out decimal total);
            MontoCapturado = total;
            Program.modeloIsrFisicas.IngresosAdicionales = total;
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