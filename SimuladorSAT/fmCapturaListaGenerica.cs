using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    // Declarado aquí mismo para NO crear más archivos en tu proyecto
    public enum TipoCapturaEnum
    {
        Compensacion,
        Estimulo
    }

    public partial class fmCapturaListaGenerica : Form
    {
        public decimal TotalCapturado { get; private set; } = 0;

        private string _titulo;
        private decimal _limiteAplicar;
        private TipoCapturaEnum _modo;

        public fmCapturaListaGenerica(string titulo, decimal limiteAplicar, TipoCapturaEnum modo)
        {
            InitializeComponent();

            _titulo = titulo;
            _limiteAplicar = limiteAplicar;
            _modo = modo;

            ConfigurarSegunModo();

            btnAgregar.Click += BtnAgregar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnTerminar.Click += BtnTerminar_Click;
            dgvRegistros.CellClick += DgvRegistros_CellClick;
        }

        private void ConfigurarSegunModo()
        {
            lblTitulo.Text = _titulo;
            this.Text = _titulo;

            if (_modo == TipoCapturaEnum.Estimulo)
            {
                lblLimite.Visible = true;
                txtLimite.Visible = true;
                txtLimite.Text = _limiteAplicar.ToString("N0");
                btnAgregar.Location = new System.Drawing.Point(25, 55);
                dgvRegistros.Location = new System.Drawing.Point(25, 100);
                lblTotalRegistros.Location = new System.Drawing.Point(25, 395);
                lblPagina.Location = new System.Drawing.Point(380, 395);
                lblMensaje.Location = new System.Drawing.Point(25, 425);
            }
            else
            {
                lblLimite.Visible = false;
                txtLimite.Visible = false;
            }

            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            TotalCapturado = 0;
            foreach (DataGridViewRow row in dgvRegistros.Rows)
            {
                if (row.Cells["colPorAplicar"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["colPorAplicar"].Value.ToString()
                        .Replace(",", "").Replace("$", ""), out decimal val))
                    {
                        TotalCapturado += val;
                    }
                }
            }
            lblTotal.Text = $"Total: ${TotalCapturado:N0}";
            ActualizarConteoRegistros();
        }

        private void ActualizarConteoRegistros()
        {
            int total = dgvRegistros.Rows.Count;
            lblTotalRegistros.Text = $"Total de registros     {total}";
            int paginas = total == 0 ? 0 : 1;
            lblPagina.Text = $"< Pagina 1 de {paginas} >";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;

            using (var frmDetalle = new fmCapturaDetalleGenerico(_modo, _limiteAplicar))
            {
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    int idx = dgvRegistros.Rows.Add();
                    dgvRegistros.Rows[idx].Cells["colTipo"].Value = frmDetalle.TipoSeleccionado;
                    dgvRegistros.Rows[idx].Cells["colPorAplicar"].Value = frmDetalle.MontoCapturado.ToString("N0");

                    ActualizarTotal();
                }
            }
        }

        private void DgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvRegistros.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var res = MessageBox.Show(
                    "¿Deseas eliminar este registro?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    dgvRegistros.Rows.RemoveAt(e.RowIndex);
                    ActualizarTotal();
                }
            }
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.Rows.Count == 0)
            {
                lblMensaje.Visible = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
