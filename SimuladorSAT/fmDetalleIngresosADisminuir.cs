using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleIngresosADisminuir : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;
        private readonly decimal _montoMaximo;
        public fmDetalleIngresosADisminuir(decimal montoMaximo)
        {
            InitializeComponent();
            _montoMaximo = montoMaximo;
            this.ShowInTaskbar = false;
            var area = Screen.PrimaryScreen.WorkingArea;
            this.ClientSize = new System.Drawing.Size((int)(area.Width * 0.80), (int)(area.Height * 0.60));
            CentrarPaginacion();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarRegistrosDesdeModelo();
            ActualizarEstadoLista();
        }
        private void CargarRegistrosDesdeModelo()  
        {
            dgvRegistros.Rows.Clear();
            foreach (var registro in Program.modeloIsrFisicas.ListaIngresosADisminuir)
            {
                dgvRegistros.Rows.Add(registro.Concepto, registro.Importe.ToString("N0"));
            }
        }
        private void CentrarPaginacion()
        {
            int centroX = (this.ClientSize.Width - lblPagina.Width) / 2;
            lblPagina.Location = new System.Drawing.Point(centroX, lblTotalRegistros.Location.Y);
        }
        // ====================================================================
        // Botón Agregar → despliega el panel de captura
        // ====================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlFormularioCaptura.Visible = true;
            btnAgregar.Visible = false;
        }

        // ====================================================================
        // Combo Concepto → habilita/deshabilita Importe según selección
        // ====================================================================
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

        // ====================================================================
        // Guardar captura → valida y agrega fila a la tabla
        // ====================================================================
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

            decimal totalActual = ObtenerTotalActual();
            if (totalActual + importe > _montoMaximo)
            {
                MessageBox.Show("No puedes disminuir más de lo que cobraste.", "Monto excedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvRegistros.Rows.Add(cmbConcepto.SelectedItem.ToString(), importe.ToString("N0"));
            Program.modeloIsrFisicas.ListaIngresosADisminuir.Add((cmbConcepto.SelectedItem.ToString(), importe));   
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

        // ====================================================================
        // Eliminar fila (botón dentro de la columna Eliminar)
        // ====================================================================
        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
            {
                Program.modeloIsrFisicas.ListaIngresosADisminuir.RemoveAt(e.RowIndex);   
                dgvRegistros.Rows.RemoveAt(e.RowIndex);
                ActualizarEstadoLista();
            }
        }
        private decimal ObtenerTotalActual()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvRegistros.Rows)
            {
                if (decimal.TryParse(fila.Cells[colImporte.Index].Value?.ToString(), out decimal valorFila))
                    total += valorFila;
            }
            return total;
        }
        // ====================================================================
        // Actualiza contador, paginación, mensaje de alerta y total
        // ====================================================================
        private void ActualizarEstadoLista()
        {
            int totalRegistros = dgvRegistros.Rows.Count;
            lblTotalRegistros.Text = $"Total de registros            {totalRegistros}";
            lblPagina.Text = totalRegistros > 0 ? "< Página 1 de 1 >" : "< Página 1 de 0 >";
            CentrarPaginacion();
            lblMensajeAlerta.Visible = totalRegistros == 0;
            txtTotalIngresosADisminuir.Text = ObtenerTotalActual().ToString("N0");
        }

        // ====================================================================
        // Cerrar — guarda el total en el modelo compartido
        // ====================================================================
        private void GuardarYCerrar()
        {
            decimal.TryParse(txtTotalIngresosADisminuir.Text, out decimal total);
            MontoCapturado = total;
            Program.modeloIsrFisicas.IngresosADisminuir = total;
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