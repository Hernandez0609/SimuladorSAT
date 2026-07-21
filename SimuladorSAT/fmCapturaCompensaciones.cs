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
        // Centra la ventana respecto al Owner
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
            cmbEjercicio.Items.Clear();
            cmbEjercicio.Items.Add("-Seleccione-");
            int anioActual = DateTime.Now.Year;
            for (int anio = anioActual; anio >= 2002; anio--)
            {
                cmbEjercicio.Items.Add(anio.ToString());
            }
            cmbEjercicio.SelectedIndex = 0;
        }

        // ====================================================================
        // CASCADA DE HABILITACIÓN 1 A 1 (CORREGIDA)
        // ====================================================================

        // 1. Tipo -> Habilita Periodicidad
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbTipo.SelectedIndex > 0;
            cmbPeriocidad.Enabled = haySeleccion;
            if (!haySeleccion) ColapsarDesdePeriodicidad();
        }

        // 2. Periodicidad -> Habilita ÚNICAMENTE Período (Ejercicio se mantiene disabled)
        private void cmbPeriocidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbPeriocidad.SelectedIndex > 0;
            cmbPeriodo.Enabled = haySeleccion;
            if (!haySeleccion)
            {
                ColapsarDesdePeriodo();
            }
        }

        // 3. Período -> Habilita ÚNICAMENTE Ejercicio
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbPeriodo.SelectedIndex > 0;
            cmbEjercicio.Enabled = haySeleccion;
            if (!haySeleccion)
            {
                ColapsarDesdeEjercicio();
            }
        }

        // 4. Ejercicio -> Habilita el bloque de datos posterior
        private void cmbEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haySeleccion = cmbEjercicio.SelectedIndex > 0;
            HabilitarBloqueDatos(haySeleccion);
        }

        private void HabilitarBloqueDatos(bool habilitar)
        {
            txtFechaCausacion.Enabled = habilitar;
            txtFechaCausacion.BackColor = habilitar ? Color.White : Color.FromArgb(238, 238, 238);
            txtNumOperacion1.Enabled = habilitar;
            txtNumOperacion1.BackColor = habilitar ? Color.White : Color.FromArgb(238, 238, 238);
            cmbConcepto.Enabled = habilitar;

            if (!habilitar)
            {
                txtFechaCausacion.Text = "";
                txtNumOperacion1.Text = "";
                if (cmbConcepto.Items.Count > 0) cmbConcepto.SelectedIndex = 0;
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

        // ====================================================================
        // Métodos de colapso/limpieza en cascada
        // ====================================================================
        private void ColapsarDesdePeriodicidad()
        {
            if (cmbPeriocidad.Items.Count > 0) cmbPeriocidad.SelectedIndex = 0;
            cmbPeriodo.Enabled = false;
            ColapsarDesdePeriodo();
        }

        private void ColapsarDesdePeriodo()
        {
            if (cmbPeriodo.Items.Count > 0) cmbPeriodo.SelectedIndex = 0;
            cmbEjercicio.Enabled = false;
            ColapsarDesdeEjercicio();
        }

        private void ColapsarDesdeEjercicio()
        {
            if (cmbEjercicio.Items.Count > 0) cmbEjercicio.SelectedIndex = 0;
            HabilitarBloqueDatos(false);
        }

        private void ColapsarAInterfazChica()
        {
            pnlFormularioCaptura.Visible = false;
            this.ClientSize = new System.Drawing.Size(1400, 150);
            CentrarEnPantalla();
        }

        // ====================================================================
        // Botón Agregar — expande el formulario
        // ====================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (pnlFormularioCaptura.Visible) return;

            pnlFormularioCaptura.Visible = true;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            CentrarEnPantalla();
        }

        // ====================================================================
        // Botón Continuar
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

            string textoLimpio = txtSaldoAplicar.Text.Replace("$", "").Replace(",", "").Trim();

            if (!decimal.TryParse(textoLimpio, out decimal saldo) || saldo <= 0)
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
        // Botón Eliminar — limpia y colapsa la pantalla
        // ====================================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            cmbPeriocidad.Enabled = false;
            ColapsarDesdePeriodicidad();

            if (cmbTipoDeclaracion.Items.Count > 0) cmbTipoDeclaracion.SelectedIndex = 0;
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

            // Regresa la interfaz al estado chico colapsado
            ColapsarAInterfazChica();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            string textoLimpio = txtSaldoAplicar.Text.Replace("$", "").Replace(",", "").Trim();
            decimal.TryParse(textoLimpio, out decimal saldo);
            MontoCapturado = saldo;
            Program.modeloIsrFisicas.Compensaciones = saldo;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}