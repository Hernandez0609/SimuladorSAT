using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public enum TipoCapturaEnum
    {
        Compensacion,
        Estimulo
    }

    public partial class fmCapturaDetalleGenerico : Form
    {
        public string TipoSeleccionado { get; private set; } = "";
        public decimal MontoCapturado { get; private set; } = 0;
        private TipoCapturaEnum _modo;
        private decimal _limiteAplicar;

        public fmCapturaDetalleGenerico(TipoCapturaEnum modo, decimal limiteAplicar)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            _modo = modo;
            _limiteAplicar = limiteAplicar;
            this.SuspendLayout();
            ConfigurarSegunModo();
            AsignarEventosFormulario();
            this.ResumeLayout(true);
        }

        // ====================================================================
        // FUERZA EL EFECTO FLOTANTE DE WINDOWS (Proyección Drop Shadow)
        // ====================================================================
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int CS_DROPSHADOW = 0x20000;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        /// <summary>
        /// Vincula de forma elástica y segura los eventos de la nueva interfaz de Figma.
        /// </summary>
        private void AsignarEventosFormulario()
        {
            if (btnAgregar != null)
            {
                btnAgregar.Click += (s, e) => {
                    if (pnlFormularioCaptura != null) pnlFormularioCaptura.Visible = true;
                };
            }
            if (btnTerminar != null) btnTerminar.Click += BtnTerminar_Click;
            if (btnContinuar != null) btnContinuar.Click += BtnContinuar_Click;
            if (btnEliminar != null) btnEliminar.Click += BtnEliminar_Click;
            if (btnCancelar != null)
            {
                btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            }
            if (txtSaldoAplicar != null)
            {
                txtSaldoAplicar.BackColor = Color.FromArgb(254, 243, 243);
                txtSaldoAplicar.TextChanged += (s, e) => ValidarColorCampo(txtSaldoAplicar);
            }
        }

        private void ConfigurarSegunModo()
        {
            bool esEstimulo = (_modo == TipoCapturaEnum.Estimulo);
            if (pnlFormularioCaptura != null)
            {
                pnlFormularioCaptura.Visible = false;
            }
            if (lblTipoEstimulo != null) lblTipoEstimulo.Visible = esEstimulo;
            if (cmbTipoEstimulo != null) cmbTipoEstimulo.Visible = esEstimulo;
            if (lblPorAplicar != null) lblPorAplicar.Visible = esEstimulo;
            if (txtPorAplicar != null) txtPorAplicar.Visible = esEstimulo;
            string titulo = esEstimulo ? "Estímulos al impuesto a cargo" : "Compensaciones";
            if (lblTitulo != null) lblTitulo.Text = titulo;
            if (lblTotalMonto != null) lblTotalMonto.Text = "Total: $0";
            this.Text = "";
        }

        private void ValidarColorCampo(TextBox textBox)
        {
            if (textBox == null) return;
            bool esValido = decimal.TryParse(textBox.Text, out decimal val) && val > 0;
            textBox.BackColor = esValido ? Color.White : Color.FromArgb(254, 243, 243);
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            if (cmbTipo != null && cmbTipo.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar un 'Tipo' de impuesto válido para continuar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Primera sección validada con éxito. Proceda a llenar la información del Saldo a Favor original.", "Sección completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbTipo != null) cmbTipo.SelectedIndex = 0;
            if (txtPeriodicidad != null) txtPeriodicidad.Clear();
            if (txtPeriodo != null) txtPeriodo.Clear();
            if (txtEjercicio != null) txtEjercicio.Clear();
            if (txtFechaCausacion != null) txtFechaCausacion.Clear();
            if (txtNumOp1 != null) txtNumOp1.Clear();
            if (txtSaldoAplicar != null) txtSaldoAplicar.Clear();
            if (txtTipoDecl != null) txtTipoDecl.Clear();
            if (txtNumOp2 != null) txtNumOp2.Clear();
            if (txtMontoSaldo != null) txtMontoSaldo.Clear();
            if (txtRemanHist != null) txtRemanHist.Clear();
            if (txtFechaDecl != null) txtFechaDecl.Clear();
            if (txtRemanAct != null) txtRemanAct.Clear();
            if (cmbTipoEstimulo != null) cmbTipoEstimulo.SelectedIndex = 0;
            if (txtPorAplicar != null) txtPorAplicar.Clear();
        }

        /// <summary>
        /// Procesa la lógica final de guardado al hacer clic en el botón Terminar.
        /// </summary>
        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (pnlFormularioCaptura != null && !pnlFormularioCaptura.Visible)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            if (cmbTipo != null && cmbTipo.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione el Tipo de impuesto de la compensación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string txt = txtSaldoAplicar != null ? txtSaldoAplicar.Text : "0";
            if (!decimal.TryParse(txt, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un Saldo a aplicar válido.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (monto > _limiteAplicar)
            {
                MessageBox.Show($"El saldo a aplicar no puede exceder el remanente del impuesto disponible (${_limiteAplicar:N0}).", "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TipoSeleccionado = cmbTipo.SelectedItem?.ToString() ?? "Compensación IVA";
            MontoCapturado = monto;
            if (lblTotalMonto != null)
            {
                lblTotalMonto.Text = $"Total: ${MontoCapturado:N0}";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}