using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturaCompensaciones : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;

        public fmCapturaCompensaciones()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            CargarAniosDinamicos();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.Load += (s, e) => CentrarEnPantalla();
        }

        // ====================================================================
        // Centra la ventana respecto al Owner (la cortina, que cubre toda la pantalla)
        // ====================================================================
        private void CentrarEnPantalla()
        {
            var area = this.Owner != null ? this.Owner.Bounds : Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(
                area.Left + (area.Width - this.Width) / 2,
                area.Top + (area.Height - this.Height) / 2);
        }

        private void CargarAniosDinamicos()
        {
            cmbEjercicio.Items.Add("-Seleccione-");
            int anioActual = DateTime.Now.Year;
            for (int anio = anioActual; anio >= 2002; anio--)
            {
                cmbEjercicio.Items.Add(anio.ToString());
            }
            cmbEjercicio.SelectedIndex = 0;
        }

        // ====================================================================
        // Cascada de habilitación
        // ====================================================================
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbTipo.SelectedIndex > 0;
            cmbPeriocidad.Enabled = haySeleccion;
            if (!haySeleccion) ColapsarDesde();
        }

        private void cmbPeriocidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbPeriocidad.SelectedIndex > 0;
            cmbPeriodo.Enabled = haySeleccion;
            cmbEjercicio.Enabled = haySeleccion;
            if (!haySeleccion)
            {
                cmbPeriodo.SelectedIndex = 0;
                cmbEjercicio.SelectedIndex = 0;
                VerificarPeriodoYEjercicio();
            }
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e) => VerificarPeriodoYEjercicio();
        private void cmbEjercicio_SelectedIndexChanged(object sender, EventArgs e) => VerificarPeriodoYEjercicio();

        private void VerificarPeriodoYEjercicio()
        {
            bool ambosCompletos = cmbPeriodo.SelectedIndex > 0 && cmbEjercicio.SelectedIndex > 0;
            txtFechaCausacion.Enabled = ambosCompletos;
            txtFechaCausacion.BackColor = ambosCompletos ? Color.White : Color.FromArgb(238, 238, 238);
            txtNumOperacion1.Enabled = ambosCompletos;
            txtNumOperacion1.BackColor = ambosCompletos ? Color.White : Color.FromArgb(238, 238, 238);
            cmbConcepto.Enabled = ambosCompletos;

            if (!ambosCompletos)
            {
                txtFechaCausacion.Text = "";
                txtNumOperacion1.Text = "";
                cmbConcepto.SelectedIndex = 0;
                txtSaldoAplicar.Enabled = false;
                txtSaldoAplicar.Text = "";
                txtSaldoAplicar.BackColor = Color.FromArgb(238, 238, 238);
            }
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbConcepto.SelectedIndex > 0;
            txtSaldoAplicar.Enabled = haySeleccion;
            txtSaldoAplicar.BackColor = haySeleccion ? Color.White : Color.FromArgb(238, 238, 238);
            if (!haySeleccion) txtSaldoAplicar.Text = "";
        }

        private void ColapsarDesde()
        {
            cmbPeriocidad.SelectedIndex = 0;
            cmbPeriodo.SelectedIndex = 0;
            cmbPeriodo.Enabled = false;
            cmbEjercicio.SelectedIndex = 0;
            cmbEjercicio.Enabled = false;
            VerificarPeriodoYEjercicio();
        }

        // ====================================================================
        // Botón Agregar — expande el formulario y lo recentra
        // ====================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (pnlFormularioCaptura.Visible) return;

            pnlFormularioCaptura.Visible = true;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            CentrarEnPantalla(); // reposiciona para que quede centrado con el nuevo tamaño
        }

        // ====================================================================
        // Botón Continuar — valida y HABILITA (no oculta) la sección de abajo
        // ====================================================================
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex <= 0 || cmbPeriocidad.SelectedIndex <= 0 ||
                cmbPeriodo.SelectedIndex <= 0 || cmbEjercicio.SelectedIndex <= 0 ||
                cmbConcepto.SelectedIndex <= 0)
            {
                MessageBox.Show("Completa todos los campos antes de continuar.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSaldoAplicar.Text, out decimal saldo) || saldo <= 0)
            {
                MessageBox.Show("Ingresa un saldo a aplicar válido.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Habilita los 6 campos de la sección gris
            cmbTipoDeclaracion.Enabled = true;
            txtNumOperacion2.Enabled = true;
            txtNumOperacion2.BackColor = Color.White;
            txtMontoSaldoOriginal.Enabled = true;
            txtMontoSaldoOriginal.BackColor = Color.White;
            txtRemanenteHistorico.Enabled = true;
            txtRemanenteHistorico.BackColor = Color.White;
            txtFechaPresentoDeclaracion.Enabled = true;
            txtFechaPresentoDeclaracion.BackColor = Color.White;
            txtRemanenteActualizado.Enabled = true;
            txtRemanenteActualizado.BackColor = Color.White;

            lblTotalHeader.Text = $"Total: ${saldo:N0}";
        }

        // ====================================================================
        // Botón Eliminar — limpia todo el formulario de captura
        // ====================================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            cmbPeriocidad.Enabled = false;
            ColapsarDesde();

            cmbTipoDeclaracion.SelectedIndex = 0;
            cmbTipoDeclaracion.Enabled = false;
            txtNumOperacion2.Text = "";
            txtNumOperacion2.Enabled = false;
            txtNumOperacion2.BackColor = Color.FromArgb(238, 238, 238);
            txtMontoSaldoOriginal.Text = "";
            txtMontoSaldoOriginal.Enabled = false;
            txtMontoSaldoOriginal.BackColor = Color.FromArgb(238, 238, 238);
            txtRemanenteHistorico.Text = "";
            txtRemanenteHistorico.Enabled = false;
            txtRemanenteHistorico.BackColor = Color.FromArgb(238, 238, 238);
            txtFechaPresentoDeclaracion.Text = "";
            txtFechaPresentoDeclaracion.Enabled = false;
            txtFechaPresentoDeclaracion.BackColor = Color.FromArgb(238, 238, 238);
            txtRemanenteActualizado.Text = "";
            txtRemanenteActualizado.Enabled = false;
            txtRemanenteActualizado.BackColor = Color.FromArgb(238, 238, 238);

            lblTotalHeader.Text = "Total: $0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtSaldoAplicar.Text, out decimal saldo);
            MontoCapturado = saldo;
            Program.modeloIsrFisicas.Compensaciones = saldo;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}