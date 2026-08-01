using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturar : Form
    {
        private Color grisFigma = Color.FromArgb(238, 238, 238);
        private Color blanco = Color.White;
        private string _modo;
        private System.Windows.Forms.Timer _debounceTimer;
        public decimal MontoCapturado { get; private set; } = 0;
        public decimal SubValor1Capturado { get; private set; } = 0;
        public decimal SubValor2Capturado { get; private set; } = 0;
        public fmCapturar(string modoPantalla, decimal valorPrefil = 0, decimal subValor1 = 0, decimal subValor2 = 0)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.SuspendLayout();
            _modo = modoPantalla;
            ConfigurarPantalla(modoPantalla, valorPrefil, subValor1, subValor2);
            this.ResumeLayout(true);
        }
        private void SeleccionarTextoAlEntrar(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BeginInvoke((MethodInvoker)delegate { txt.SelectAll(); });
            }
        }
        private void ConfigurarPantalla(string modo, decimal valorPrefil, decimal subValor1, decimal subValor2)
        {
            if (modo == "Tasa0")
            {
                this.Text = "Actividades gravadas a la tasa del 0%";
                this.lblTitulo.Text = "Actividades gravadas a la tasa del 0%";
                this.lblDescripcion.Text = "Detalla el importe de las actividades gravadas a la tasa del 0%";
                this.lblCampo1.Text = "Actividades gravadas a la tasa del 0%";
                this.lblCampo2.Text = "Monto por detallar";
                this.lblCampo3.Text = "Monto detallado";
                this.lblCampo4.Text = "Actividades nacionales gravadas a la tasa del 0%";
                this.lblCampo5.Text = "Actividades de exportación gravadas a la tasa del 16%";
                this.btnDetalleCampo1.Visible = true;

                ConfigurarEstiloCampo(txtCampo1, true, valorPrefil.ToString("N0"));
                ConfigurarEstiloCampo(txtCampo2, true, valorPrefil.ToString("N0"));
                ConfigurarEstiloCampo(txtCampo3, true, "0");
                ConfigurarEstiloCampo(txtCampo4, false, subValor1 > 0 ? subValor1.ToString("N0") : "");
                ConfigurarEstiloCampo(txtCampo5, false, subValor2 > 0 ? subValor2.ToString("N0") : "");
                RecalcularTasa0();

                txtCampo4.TextChanged += (s, e) => ReiniciarDebounce(RecalcularTasa0);
                txtCampo5.TextChanged += (s, e) => ReiniciarDebounce(RecalcularTasa0);
                txtCampo4.Enter += SeleccionarTextoAlEntrar;
                txtCampo5.Enter += SeleccionarTextoAlEntrar;
            }
            else if (modo == "IvaAcreditable")
            {
                this.Text = "IVA acreditable del periodo";
                this.lblTitulo.Text = "IVA acreditable del periodo";
                this.lblDescripcion.Text = "";
                this.lblCampo1.Text = "IVA pagado en gastos y adquisiciones";
                this.lblCampo2.Text = "*IVA acreditable por actividades gravadas a tasa 16% u 8% y tasa 0%";
                this.lblCampo3.Text = "*IVA acreditable por actividades mixtas";
                this.lblCampo4.Text = "IVA acreditable del periodo";
                this.lblCampo5.Text = "IVA no acreditable";
                this.btnDetalleCampo1.Visible = false;

                ConfigurarEstiloCampo(txtCampo1, true, "0");
                ConfigurarEstiloCampo(txtCampo2, false, subValor1 > 0 ? subValor1.ToString("N0") : "");
                ConfigurarEstiloCampo(txtCampo3, false, subValor2 > 0 ? subValor2.ToString("N0") : "");
                RecalcularAcreditable();
                ConfigurarEstiloCampo(txtCampo4, true, "0");
                ConfigurarEstiloCampo(txtCampo5, false, "");

                txtCampo2.TextChanged += (s, e) => ReiniciarDebounce(RecalcularAcreditable);
                txtCampo3.TextChanged += (s, e) => ReiniciarDebounce(RecalcularAcreditable);
                txtCampo2.Enter += SeleccionarTextoAlEntrar;
                txtCampo3.Enter += SeleccionarTextoAlEntrar;
            }
        }
        private void ReiniciarDebounce(Action accion)
        {
            if (_debounceTimer == null)
            {
                _debounceTimer = new System.Windows.Forms.Timer();
                _debounceTimer.Interval = 600;
            }
            _debounceTimer.Stop();
            _debounceTimer.Tick -= _debounceTimer.Tag as EventHandler;

            EventHandler handler = null;
            handler = (s, e) => { _debounceTimer.Stop(); accion(); };
            _debounceTimer.Tag = handler;
            _debounceTimer.Tick += handler;
            _debounceTimer.Start();
        }
        private decimal Parsear(string texto)
        {
            string limpio = texto.Replace("$", "").Replace(",", "").Trim();
            return decimal.TryParse(limpio, out decimal v) ? v : 0;
        }

        private void RecalcularTasa0()
        {
            decimal total = Parsear(txtCampo1.Text);
            decimal nacional = Parsear(txtCampo4.Text);
            decimal exportacion = Parsear(txtCampo5.Text);
            decimal detallado = nacional + exportacion;
            decimal porDetallar = total - detallado;

            txtCampo3.Text = detallado.ToString("N0");
            txtCampo2.Text = porDetallar.ToString("N0");
        }

        private void RecalcularAcreditable()
        {
            decimal acreditable16 = Parsear(txtCampo2.Text);
            decimal acreditableMixtas = Parsear(txtCampo3.Text);
            txtCampo4.Text = (acreditable16 + acreditableMixtas).ToString("N0");
        }

        private void ConfigurarEstiloCampo(TextBox txt, bool esGris, string valorInicial)
        {
            txt.Text = valorInicial;
            if (esGris)
            {
                txt.BackColor = grisFigma;
                txt.ReadOnly = true;
            }
            else
            {
                txt.BackColor = blanco;
                txt.ReadOnly = false;
            }
        }

        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (_modo == "Tasa0")
            {
                MontoCapturado = Parsear(txtCampo1.Text);
                SubValor1Capturado = Parsear(txtCampo4.Text);
                SubValor2Capturado = Parsear(txtCampo5.Text);
            }
            else if (_modo == "IvaAcreditable")
            {
                if (string.IsNullOrWhiteSpace(txtCampo2.Text) || string.IsNullOrWhiteSpace(txtCampo3.Text))
                {
                    MessageBox.Show("Completa los campos obligatorios antes de cerrar.", "Campos requeridos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MontoCapturado = Parsear(txtCampo4.Text);
                SubValor1Capturado = Parsear(txtCampo2.Text);
                SubValor2Capturado = Parsear(txtCampo3.Text);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDetalleCampo1_Click(object sender, EventArgs e)
        {
            using (fmDetalle ventanaDetalle = new fmDetalle("Actividades gravadas a la tasa del 0%", "Junio"))
            {
                ventanaDetalle.ShowDialog(this);
            }
        }
    }
}