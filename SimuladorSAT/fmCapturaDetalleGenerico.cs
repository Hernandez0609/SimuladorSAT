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
        private System.Collections.Generic.List<Panel> tarjetasCongeladas = new System.Collections.Generic.List<Panel>();
        private System.Collections.Generic.List<decimal> montosAgregados = new System.Collections.Generic.List<decimal>();
        private int contadorTarjetas = 0;
        private const int MAX_TARJETAS = 3;

        public fmCapturaDetalleGenerico(TipoCapturaEnum modo, decimal limiteAplicar)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            _modo = modo;
            _limiteAplicar = limiteAplicar;
            lblTitulo.Text = _modo == TipoCapturaEnum.Compensacion ? "Compensaciones" : "Estímulos";
            CargarAnios();
            InicializarComboPeriodo(); // <--- AJUSTE 1: Carga "-Seleccione-" desde el inicio para evitar caja en blanco

            // 1. ESTADO COLAPSADO INICIAL
            ColapsarAInterfazChica();

            // Eventos
            btnAgregar.Click += BtnAgregar_Click;
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
            CentrarEnPantalla();
        }
        private void ColapsarAInterfazChica()
        {
            pnlFormularioCaptura.Visible = false;
            this.ClientSize = new System.Drawing.Size(1400, 150);
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
            string textoLimpio = txtSaldoAplicar.Text.Replace("$", "").Replace(",", "").Trim();
            if (!decimal.TryParse(textoLimpio, out decimal saldo) || saldo <= 0)
            {
                MessageBox.Show("Ingresa un saldo a aplicar válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _montoValidado = saldo;
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

            decimal sumaPrevia = 0;
            foreach (var m in montosAgregados) sumaPrevia += m;
            lblTotalMonto.Text = $"Total: ${(sumaPrevia + saldo):N0}";
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ResetFormularioCompleto();
            decimal sumaPrevia = 0;
            foreach (var m in montosAgregados) sumaPrevia += m;
            lblTotalMonto.Text = $"Total: ${sumaPrevia:N0}";

            if (contadorTarjetas == 0)
            {
                ColapsarAInterfazChica();
            }
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (pnlFormularioCaptura.Visible && contadorTarjetas < MAX_TARJETAS && BloqueCompletoValido())
            {
                decimal sumaPrevia = 0;
                foreach (var m in montosAgregados) sumaPrevia += m;
                if (sumaPrevia + _montoValidado <= _limiteAplicar)
                {
                    CongelarTarjetaActual(_montoValidado);
                }
            }

            decimal total = 0;
            foreach (var m in montosAgregados) total += m;

            if (total <= 0)
            {
                MessageBox.Show("Ingresa y agrega al menos una captura válida.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (total > _limiteAplicar)
            {
                MessageBox.Show($"El total no puede exceder el remanente disponible (${_limiteAplicar:N0}).",
                    "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TipoSeleccionado = _modo == TipoCapturaEnum.Compensacion ? "Compensación" : "Estímulo";
            MontoCapturado = total;
            lblTotalMonto.Text = $"Total: ${MontoCapturado:N0}";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool BloqueCompletoValido()
        {
            if (_montoValidado <= 0) return false;
            if (cmbTipoDecl.SelectedIndex <= 0) return false;
            if (string.IsNullOrWhiteSpace(txtNumOp2.Text) ||
                string.IsNullOrWhiteSpace(txtMontoSaldo.Text) ||
                string.IsNullOrWhiteSpace(txtRemanHist.Text) ||
                string.IsNullOrWhiteSpace(txtFechaDecl.Text) ||
                string.IsNullOrWhiteSpace(txtRemanAct.Text))
                return false;
            return true;
        }
        private void ResetFormularioCompleto()
        {
            _montoValidado = 0;
            cmbTipo.Enabled = true;
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
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
        }
        private void CongelarTarjetaActual(decimal monto)
        {
            var card = new Panel
            {
                Size = new Size(1300, 460),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            var lblHeader = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(13, 78, 92),
                Location = new Point(15, 10),
                Text = $"Compensación {contadorTarjetas + 1}"
            };
            card.Controls.Add(lblHeader);

            void AddCampo(string etiqueta, string valor, int x, int posY, int width)
            {
                var lbl = new Label
                {
                    AutoSize = true,
                    Font = new Font("Arial", 10F),
                    Location = new Point(x, posY),
                    Text = etiqueta
                };
                var val = new Label
                {
                    AutoSize = false,
                    Font = new Font("Arial", 10F),
                    Location = new Point(x, posY + 25),
                    Size = new Size(width, 28),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(238, 238, 238),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(6, 0, 0, 0),
                    Text = valor
                };
                card.Controls.Add(lbl);
                card.Controls.Add(val);
            }

            AddCampo("Tipo", cmbTipo.Text, 15, 45, 290);
            AddCampo("Periodicidad", cmbPeriodicidad.Text, 345, 45, 290);
            AddCampo("Período", cmbPeriodo.Text, 675, 45, 290);
            AddCampo("Ejercicio", cmbEjercicio.Text, 1005, 45, 290);

            AddCampo("Fecha de causación (dd-mm-aaaa)", txtFechaCausacion.Text, 15, 115, 290);
            AddCampo("Número de operación", txtNumOp1.Text, 345, 115, 290);
            AddCampo("Concepto", cmbConcepto.Text, 675, 115, 290);
            AddCampo("Saldo a aplicar", monto.ToString("N0"), 1005, 115, 290);

            var divisor = new Panel
            {
                Location = new Point(15, 185),
                Size = new Size(1270, 1),
                BackColor = Color.FromArgb(220, 220, 220)
            };
            card.Controls.Add(divisor);

            AddCampo("Tipo de declaración", cmbTipoDecl.Text, 15, 210, 370);
            AddCampo("Número de operación", txtNumOp2.Text, 735, 210, 320);
            AddCampo("Monto del saldo a favor original", txtMontoSaldo.Text, 15, 280, 370);
            AddCampo("Remanente histórico antes de la aplicación", txtRemanHist.Text, 735, 280, 320);
            AddCampo("Fecha en que se presentó la declaración del saldo a favor (dd-mm-aaaa)", txtFechaDecl.Text, 15, 355, 370);
            AddCampo("Remanente actualizado antes de la aplicación", txtRemanAct.Text, 735, 355, 320);

            int y = pnlFormularioCaptura.Bottom + 20;
            foreach (var t in tarjetasCongeladas)
            {
                y = t.Bottom + 20;
            }
            card.Location = new Point(50, y);

            pnlCuerpo.Controls.Add(card);
            tarjetasCongeladas.Add(card);
            montosAgregados.Add(monto);
            contadorTarjetas++;

            ActualizarTotalAcumulado();
            ResetFormularioCompleto();

            if (contadorTarjetas >= MAX_TARJETAS)
            {
                btnAgregar.Enabled = false;
                DeshabilitarFormularioCaptura();
                MessageBox.Show($"Has alcanzado el máximo de {MAX_TARJETAS}.", "Límite alcanzado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeshabilitarFormularioCaptura()
        {
            foreach (Control c in pnlFormularioCaptura.Controls)
            {
                c.Enabled = false;
            }
        }

        private void ActualizarTotalAcumulado()
        {
            decimal total = 0;
            foreach (var m in montosAgregados) total += m;
            lblTotalMonto.Text = $"Total: ${total:N0}";
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!pnlFormularioCaptura.Visible)
            {
                Expandir();
                return;
            }

            if (contadorTarjetas >= MAX_TARJETAS)
            {
                MessageBox.Show($"Solo puedes agregar hasta {MAX_TARJETAS}.", "Límite alcanzado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!BloqueCompletoValido())
            {
                MessageBox.Show("Completa todos los campos antes de agregar otra captura.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Valida el límite acumulado ANTES de congelar
            decimal sumaPrevia = 0;
            foreach (var m in montosAgregados) sumaPrevia += m;
            if (sumaPrevia + _montoValidado > _limiteAplicar)
            {
                MessageBox.Show($"El total no puede exceder el remanente disponible (${_limiteAplicar:N0}).",
                    "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CongelarTarjetaActual(_montoValidado);
        }
    }
}