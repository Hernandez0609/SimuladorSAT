using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturaDetalleGenerico : Form
    {
        public string TipoSeleccionado { get; private set; } = "";
        public decimal MontoCapturado { get; private set; } = 0;

        private TipoCapturaEnum _modo;
        private decimal _limiteAplicar;

        public fmCapturaDetalleGenerico(TipoCapturaEnum modo, decimal limiteAplicar)
        {
            InitializeComponent();
            _modo = modo;
            _limiteAplicar = limiteAplicar;

            ConfigurarSegunModo();

            btnContinuar.Click += BtnContinuar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            txtSaldoAplicar.BackColor = Color.FromArgb(254, 243, 243);
            txtPorAplicar.BackColor = Color.FromArgb(254, 243, 243);

            txtSaldoAplicar.TextChanged += (s, e) => ValidarColorCampo(txtSaldoAplicar);
            txtPorAplicar.TextChanged += (s, e) => ValidarColorCampo(txtPorAplicar);
        }

        private void ConfigurarSegunModo()
        {
            if (_modo == TipoCapturaEnum.Estimulo)
            {
                SetVisibilidadCompensacion(false);

                lblTipoEstimulo.Visible = true;
                cmbTipoEstimulo.Visible = true;
                lblPorAplicar.Visible = true;
                txtPorAplicar.Visible = true;

                lblTitulo.Text = "Estímulos al impuesto a cargo";
                this.Text = "Estímulos al impuesto a cargo";
            }
            else
            {
                lblTipoEstimulo.Visible = false;
                cmbTipoEstimulo.Visible = false;
                lblPorAplicar.Visible = false;
                txtPorAplicar.Visible = false;

                SetVisibilidadCompensacion(true);

                lblTitulo.Text = "Compensaciones";
                this.Text = "Compensaciones";
            }
        }

        private void SetVisibilidadCompensacion(bool visible)
        {
            lblTipo.Visible = visible; cmbTipo.Visible = visible;
            lblPeriodicidad.Visible = visible; txtPeriodicidad.Visible = visible;
            lblPeriodo.Visible = visible; txtPeriodo.Visible = visible;
            lblEjercicio.Visible = visible; txtEjercicio.Visible = visible;
            lblFechaCausacion.Visible = visible; txtFechaCausacion.Visible = visible;
            lblNumOp1.Visible = visible; txtNumOp1.Visible = visible;
            lblConcepto.Visible = visible; txtConcepto.Visible = visible;
            lblSaldoAplicar.Visible = visible; txtSaldoAplicar.Visible = visible;
            btnContinuar.Visible = visible; btnEliminar.Visible = visible;
            pnlSep.Visible = visible;
            lblTipoDecl.Visible = visible; txtTipoDecl.Visible = visible;
            lblNumOp2.Visible = visible; txtNumOp2.Visible = visible;
            lblMontoSaldo.Visible = visible; txtMontoSaldo.Visible = visible;
            lblRemanHist.Visible = visible; txtRemanHist.Visible = visible;
            lblFechaDecl.Visible = visible; txtFechaDecl.Visible = visible;
            lblRemanAct.Visible = visible; txtRemanAct.Visible = visible;
        }

        private void ValidarColorCampo(TextBox textBox)
        {
            if (decimal.TryParse(textBox.Text, out decimal val) && val > 0)
                textBox.BackColor = Color.White;
            else
                textBox.BackColor = Color.FromArgb(254, 243, 243);
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un 'Tipo' de impuesto válido para continuar.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Primera sección validada con éxito. Proceda a llenar la información del Saldo a Favor original.",
                "Sección completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            txtPeriodicidad.Clear();
            txtPeriodo.Clear();
            txtEjercicio.Clear();
            txtFechaCausacion.Clear();
            txtNumOp1.Clear();
            txtConcepto.Clear();
            txtSaldoAplicar.Clear();
            txtTipoDecl.Clear();
            txtNumOp2.Clear();
            txtMontoSaldo.Clear();
            txtRemanHist.Clear();
            txtFechaDecl.Clear();
            txtRemanAct.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_modo == TipoCapturaEnum.Estimulo)
            {
                if (cmbTipoEstimulo.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un Tipo de estímulo.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPorAplicar.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido mayor a 0 en 'Por aplicar en el periodo'.", "Monto Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (monto > _limiteAplicar)
                {
                    MessageBox.Show($"El estímulo fiscal no puede exceder el impuesto a cargo disponible (${_limiteAplicar:N0}).", "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TipoSeleccionado = cmbTipoEstimulo.SelectedItem.ToString();
                MontoCapturado = monto;
            }
            else
            {
                if (cmbTipo.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione el Tipo de impuesto de la compensación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtSaldoAplicar.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Ingrese un Saldo a aplicar válido.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (monto > _limiteAplicar)
                {
                    MessageBox.Show($"El saldo a aplicar no puede exceder el remanente del impuesto disponible (${_limiteAplicar:N0}).", "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TipoSeleccionado = cmbTipo.SelectedItem.ToString();
                MontoCapturado = monto;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}