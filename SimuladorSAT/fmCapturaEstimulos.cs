using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturaEstimulos : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;
        private decimal _limiteAplicar;

        public fmCapturaEstimulos(decimal limiteAplicar)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            _limiteAplicar = limiteAplicar;

            txtLimiteAplicar.Text = _limiteAplicar.ToString("N0");

            // Reposiciona btnCerrar a la esquina inferior derecha real
            btnCerrar.Location = new Point(
                this.ClientSize.Width - btnCerrar.Width - 30,
                this.ClientSize.Height - btnCerrar.Height - 30
            );

            CentrarPaginacion();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.Load += (s, e) => CentrarEnPantalla();

            ActualizarEstadoLista();

            txtPorAplicar.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtLimiteAplicar.KeyPress += clsValidacionNumerica.SoloNumeros;
        }

        private void CentrarEnPantalla()
        {
            var pantalla = Screen.FromControl(this.Owner ?? this).Bounds;
            this.Location = new Point(
                pantalla.Left + (pantalla.Width - this.Width) / 2,
                pantalla.Top + (pantalla.Height - this.Height) / 2);
        }

        private void CentrarPaginacion()
        {
            int centroX = (this.ClientSize.Width - lblPagina.Width) / 2;
            lblPagina.Location = new Point(centroX, lblTotalRegistros.Location.Y);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlFormularioCaptura.Visible = true;
            btnAgregar.Visible = false;
        }

        private void cmbTipoEstimulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbTipoEstimulo.SelectedIndex > 0;
            txtPorAplicar.Enabled = haySeleccion;
            txtPorAplicar.BackColor = haySeleccion ? Color.White : Color.FromArgb(238, 238, 238);
            if (!haySeleccion) txtPorAplicar.Text = "";
        }

        private void btnGuardarCaptura_Click(object sender, EventArgs e)
        {
            if (cmbTipoEstimulo.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecciona un tipo de estímulo válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPorAplicar.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("Ingresa un importe válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalActual = SumarRegistros();
            if (totalActual + importe > _limiteAplicar)
            {
                MessageBox.Show($"El total no puede exceder el límite disponible (${_limiteAplicar:N0}).",
                    "Límite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvRegistros.Rows.Add(cmbTipoEstimulo.SelectedItem.ToString(), importe.ToString("N0"));

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
            cmbTipoEstimulo.SelectedIndex = 0;
            txtPorAplicar.Text = "";
            txtPorAplicar.Enabled = false;
            txtPorAplicar.BackColor = Color.FromArgb(238, 238, 238);
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
            {
                dgvRegistros.Rows.RemoveAt(e.RowIndex);
                ActualizarEstadoLista();
            }
        }

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
            CentrarPaginacion();
            lblMensajeAlerta.Visible = totalRegistros == 0;
        }

        private void GuardarYCerrar()
        {
            MontoCapturado = SumarRegistros();
            Program.modeloIsrFisicas.Estimulos = MontoCapturado;
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