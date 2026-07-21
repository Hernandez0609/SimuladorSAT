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
        private decimal _montoValidado = 0;

        public fmCapturaDetalleGenerico(TipoCapturaEnum modo, decimal limiteAplicar)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            _modo = modo;
            _limiteAplicar = limiteAplicar;

            CargarAnios();
            InicializarComboPeriodo(); // <--- AJUSTE 1: Carga "-Seleccione-" desde el inicio para evitar caja en blanco

            // 1. ESTADO COLAPSADO INICIAL
            ColapsarAInterfazChica();

            // Eventos
            btnAgregar.Click += (s, e) => Expandir();
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnContinuar.Click += BtnContinuar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnTerminar.Click += BtnTerminar_Click;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
        }

        private void CentrarEnPantalla()
        {
            var pantalla = Screen.FromControl(this.Owner ?? this).Bounds;
            this.Location = new Point(
                pantalla.Left + (pantalla.Width - this.Width) / 2,
                pantalla.Top + (pantalla.Height - this.Height) / 2);
        }

        private void CargarAnios()
        {
            cmbEjercicio.Items.Clear();
            cmbEjercicio.Items.Add("-Seleccione-");

            int anioActual = DateTime.Now.Year;
            for (int anio = anioActual; anio >= 2002; anio--)
            {
                cmbEjercicio.Items.Add(anio.ToString());
            }

            cmbEjercicio.SelectedIndex = 0;
        }

        // Método auxiliar para precargar "-Seleccione-" en cmbPeriodo
        private void InicializarComboPeriodo()
        {
            cmbPeriodo.SelectedIndexChanged -= cmbPeriodo_SelectedIndexChanged;
            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.Add("-Seleccione-");
            cmbPeriodo.SelectedIndex = 0;
            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;
        }

        private void Expandir()
        {
            pnlFormularioCaptura.Visible = true;
            this.ClientSize = new System.Drawing.Size(1400, 650);

            // Reposicionar botones abajo del panel de captura (Y = 580)
            AjustarPosicionBotones(580);
            CentrarEnPantalla();
        }

        private void ColapsarAInterfazChica()
        {
            pnlFormularioCaptura.Visible = false;
            this.ClientSize = new System.Drawing.Size(1400, 150);
            AjustarPosicionBotones(100);
            CentrarEnPantalla();
        }

        private void AjustarPosicionBotones(int posY)
        {
            btnCancelar.Location = new System.Drawing.Point(970, posY);
            btnAgregar.Location = new System.Drawing.Point(1110, posY);
            btnTerminar.Location = new System.Drawing.Point(1250, posY);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbTipo.SelectedIndex > 0;
            cmbPeriodicidad.Enabled = hay;
            if (!hay) ColapsarDesdePeriodicidad();
        }

        private void cmbPeriodicidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbPeriodicidad.SelectedIndex > 0;
            cmbPeriodo.Enabled = hay;
            if (hay)
            {
                CargarMeses();
            }
            else
            {
                ColapsarDesdePeriodo();
            }
        }

        private void CargarMeses()
        {
            cmbPeriodo.SelectedIndexChanged -= cmbPeriodo_SelectedIndexChanged;

            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.Add("-Seleccione-");
            foreach (var m in meses) cmbPeriodo.Items.Add(m);
            cmbPeriodo.SelectedIndex = 0;

            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbPeriodo.SelectedIndex > 0;
            cmbEjercicio.Enabled = hay;
            if (!hay) ColapsarDesdeEjercicio();
        }

        private void cmbEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbEjercicio.SelectedIndex > 0;
            HabilitarBloqueDatos(hay);
        }

        private void HabilitarBloqueDatos(bool habilitar)
        {
            txtFechaCausacion.Enabled = habilitar;
            txtFechaCausacion.BackColor = habilitar ? Color.White : Color.FromArgb(235, 235, 235);
            txtNumOp1.Enabled = habilitar;
            txtNumOp1.BackColor = habilitar ? Color.White : Color.FromArgb(235, 235, 235);
            cmbConcepto.Enabled = habilitar;

            if (!habilitar)
            {
                txtFechaCausacion.Text = "";
                txtNumOp1.Text = "";
                cmbConcepto.SelectedIndex = 0;
                HabilitarSaldoAplicar(false);
            }
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbConcepto.SelectedIndex > 0;
            HabilitarSaldoAplicar(hay);
        }

        private void HabilitarSaldoAplicar(bool habilitar)
        {
            txtSaldoAplicar.Enabled = habilitar;
            txtSaldoAplicar.BackColor = habilitar ? Color.White : Color.FromArgb(235, 235, 235);
            if (!habilitar) txtSaldoAplicar.Text = "";
        }

        private void ColapsarDesdePeriodicidad()
        {
            if (cmbPeriodicidad.Items.Count > 0) cmbPeriodicidad.SelectedIndex = 0;
            cmbPeriodo.Enabled = false;
            ColapsarDesdePeriodo();
        }

        private void ColapsarDesdePeriodo()
        {
            InicializarComboPeriodo();
            cmbEjercicio.Enabled = false;
            ColapsarDesdeEjercicio();
        }

        private void ColapsarDesdeEjercicio()
        {
            if (cmbEjercicio.Items.Count > 0) cmbEjercicio.SelectedIndex = 0;
            HabilitarBloqueDatos(false);
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex <= 0 || cmbPeriodicidad.SelectedIndex <= 0 ||
                cmbPeriodo.SelectedIndex <= 0 || cmbEjercicio.SelectedIndex <= 0 ||
                cmbConcepto.SelectedIndex <= 0)
            {
                MessageBox.Show("Completa todos los campos antes de continuar.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Quita signos comunes por si el usuario los mete de forma manual
            string textoLimpio = txtSaldoAplicar.Text.Replace("$", "").Replace(",", "").Trim();

            if (!decimal.TryParse(textoLimpio, out decimal saldo) || saldo <= 0)
            {
                MessageBox.Show("Ingresa un saldo a aplicar válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _montoValidado = saldo; // Almacenamos el valor numérico limpio y seguro

            cmbTipo.Enabled = false;
            cmbPeriodicidad.Enabled = false;
            cmbPeriodo.Enabled = false;
            cmbEjercicio.Enabled = false;
            txtFechaCausacion.Enabled = false;
            txtNumOp1.Enabled = false;
            cmbConcepto.Enabled = false;
            txtSaldoAplicar.Enabled = false;

            cmbTipoDecl.Enabled = true;
            txtNumOp2.Enabled = true;
            txtNumOp2.BackColor = Color.White;
            txtMontoSaldo.Enabled = true;
            txtMontoSaldo.BackColor = Color.White;
            txtRemanHist.Enabled = true;
            txtRemanHist.BackColor = Color.White;
            txtFechaDecl.Enabled = true;
            txtFechaDecl.BackColor = Color.White;
            txtRemanAct.Enabled = true;
            txtRemanAct.BackColor = Color.White;

            lblTotalMonto.Text = $"Total: ${saldo:N0}";
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            _montoValidado = 0;
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            cmbTipo.Enabled = true;
            cmbPeriodicidad.Enabled = false;
            ColapsarDesdePeriodicidad();

            if (cmbTipoDecl.Items.Count > 0) cmbTipoDecl.SelectedIndex = 0;
            cmbTipoDecl.Enabled = false;
            txtNumOp2.Text = "";
            txtNumOp2.Enabled = false;
            txtNumOp2.BackColor = Color.FromArgb(235, 235, 235);
            txtMontoSaldo.Text = "";
            txtMontoSaldo.Enabled = false;
            txtMontoSaldo.BackColor = Color.FromArgb(235, 235, 235);
            txtRemanHist.Text = "";
            txtRemanHist.Enabled = false;
            txtRemanHist.BackColor = Color.FromArgb(235, 235, 235);
            txtFechaDecl.Text = "";
            txtFechaDecl.Enabled = false;
            txtFechaDecl.BackColor = Color.FromArgb(235, 235, 235);
            txtRemanAct.Text = "";
            txtRemanAct.Enabled = false;
            txtRemanAct.BackColor = Color.FromArgb(235, 235, 235);

            lblTotalMonto.Text = "Total: $0";

            // <--- AJUSTE 2: Oculta el panel y regresa la pantalla al estado colapsado (interfaz chica)
            ColapsarAInterfazChica();
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (!pnlFormularioCaptura.Visible)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (cmbTipo.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione el Tipo de impuesto de la compensación.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_montoValidado <= 0)
            {
                MessageBox.Show("Ingrese y procese un Saldo a aplicar válido mediante el botón CONTINUAR.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_montoValidado > _limiteAplicar)
            {
                MessageBox.Show($"El saldo a aplicar no puede exceder el remanente del impuesto disponible (${_limiteAplicar:N0}).",
                    "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TipoSeleccionado = cmbTipo.SelectedItem?.ToString() ?? "Compensación";
            MontoCapturado = _montoValidado;
            lblTotalMonto.Text = $"Total: ${MontoCapturado:N0}";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}