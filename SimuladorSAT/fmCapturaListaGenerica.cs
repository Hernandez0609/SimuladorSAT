using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturaListaGenerica : Form
    {
        public string ModoCaptura { get; set; } = "Estímulos";
        public decimal MontoCapturado { get; private set; } = 0;
        private decimal _limiteAplicar = 0;

        public fmCapturaListaGenerica()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            AjustarPosicionesUI(false);
            this.Owner = null;
            ActualizarEstadoLista();

            txtMontoPorAplicar.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtLimite.KeyPress += clsValidacionNumerica.SoloNumeros;
        }

        public void ConfigurarInterfaz(string modo, string titulo, string montoLimite = "")
        {
            this.ModoCaptura = modo;
            if (this.lblTitulo != null) this.lblTitulo.Text = titulo;

            decimal.TryParse(montoLimite, out _limiteAplicar);
            if (this.txtLimite != null) this.txtLimite.Text = _limiteAplicar.ToString("N0");
        }

        private void AjustarPosicionesUI(bool panelVisible)
        {
            this.SuspendLayout();
            pnlCapturaDesplegable.Visible = panelVisible;
            btnAgregar.Visible = !panelVisible;

            if (panelVisible)
            {
                dgvRegistros.Location = new Point(25, 205);
                dgvRegistros.Size = new Size(900, 96);
            }
            else
            {
                dgvRegistros.Location = new Point(25, 95);
                dgvRegistros.Size = new Size(900, 96);
            }

            lblTotalRegistros.Location = new Point(25, dgvRegistros.Top + dgvRegistros.Height + 20);
            lblPagina.Location = new Point(400, lblTotalRegistros.Top);
            lblMensajeAlerta.Location = new Point(25, lblTotalRegistros.Top + 35);
            lblIconoAlerta.Location = new Point(lblMensajeAlerta.Left + lblMensajeAlerta.Width + 10, lblMensajeAlerta.Top);

            this.ResumeLayout(true);
        }

        // ====================================================================
        // Combo Tipo de estímulo → habilita/deshabilita el importe
        // ====================================================================
        private void cmbTipoEstimulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbTipoEstimulo.SelectedIndex > 0;
            txtMontoPorAplicar.Enabled = haySeleccion;
            txtMontoPorAplicar.BackColor = haySeleccion
                ? Color.White
                : Color.FromArgb(235, 235, 235);

            if (!haySeleccion) txtMontoPorAplicar.Text = "";
        }

        // ====================================================================
        // Botones principales
        // ====================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AjustarPosicionesUI(true);
        }

        private void btnCancelarCaptura_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCaptura();
            AjustarPosicionesUI(false);
        }

        private void btnGuardarCaptura_Click(object sender, EventArgs e)
        {
            if (cmbTipoEstimulo.SelectedIndex <= 0)
            {
                MessageBox.Show("Por favor, selecciona un tipo de estímulo válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMontoPorAplicar.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("Ingresa un importe válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalActual = SumarRegistros();
            if (_limiteAplicar > 0 && totalActual + importe > _limiteAplicar)
            {
                MessageBox.Show($"El total no puede exceder el límite disponible (${_limiteAplicar:N0}).",
                    "Límite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvRegistros.Rows.Add(cmbTipoEstimulo.SelectedItem.ToString(), importe.ToString("N0"));

            LimpiarFormularioCaptura();
            AjustarPosicionesUI(false);
            ActualizarEstadoLista();
        }

        private void LimpiarFormularioCaptura()
        {
            cmbTipoEstimulo.SelectedIndex = 0;
            txtMontoPorAplicar.Clear();
            txtMontoPorAplicar.Enabled = false;
            txtMontoPorAplicar.BackColor = Color.FromArgb(235, 235, 235);
        }

        // ====================================================================
        // Eliminar fila
        // ====================================================================
        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
            {
                dgvRegistros.Rows.RemoveAt(e.RowIndex);
                ActualizarEstadoLista();
            }
        }

        // ====================================================================
        // Suma total, contador de registros, paginación, mensaje de alerta
        // ====================================================================
        private decimal SumarRegistros()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvRegistros.Rows)
            {
                if (decimal.TryParse(fila.Cells[colPorAplicar.Index].Value?.ToString(), out decimal valorFila))
                {
                    total += valorFila;
                }
            }
            return total;
        }

        private void ActualizarEstadoLista()
        {
            int totalRegistros = dgvRegistros.Rows.Count;
            lblTotalRegistros.Text = $"Total de registros            {totalRegistros}";
            lblPagina.Text = totalRegistros > 0 ? "< Página 1 de 1 >" : "< Página 1 de 0 >";

            bool sinRegistros = totalRegistros == 0;
            lblMensajeAlerta.Visible = sinRegistros;
            lblIconoAlerta.Visible = sinRegistros;
        }

        // ====================================================================
        // Cerrar
        // ====================================================================
        private void GuardarYCerrar()
        {
            MontoCapturado = SumarRegistros();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblBotonCerrarX_Click(object sender, EventArgs e)
        {
            GuardarYCerrar();
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            GuardarYCerrar();
        }
    }
}