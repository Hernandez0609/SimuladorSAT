using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturaCompensaciones : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;
        private System.Collections.Generic.List<Panel> tarjetasCongeladas = new System.Collections.Generic.List<Panel>();
        private System.Collections.Generic.List<decimal> montosAgregados = new System.Collections.Generic.List<decimal>();
        private int contadorTarjetas = 0;
        private const int MAX_TARJETAS = 3;

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
            if (!pnlFormularioCaptura.Visible)
            {
                pnlFormularioCaptura.Visible = true;
                this.ClientSize = new System.Drawing.Size(1400, 750);
                CentrarEnPantalla();
                return;
            }

            if (contadorTarjetas >= MAX_TARJETAS)
            {
                MessageBox.Show("Solo puedes agregar hasta 3 compensaciones.", "Límite alcanzado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarFormularioCompleto(out decimal monto))
            {
                MessageBox.Show("Completa todos los campos antes de agregar otra compensación.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CongelarTarjetaActual(monto);
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

            decimal sumaPrevia = 0;
            foreach (var m in montosAgregados) sumaPrevia += m;
            lblTotalHeader.Text = $"Total: ${(sumaPrevia + saldo):N0}";
        }

        // ====================================================================
        // Botón Eliminar — limpia y colapsa la pantalla
        // ====================================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ResetFormularioCompleto();

            if (contadorTarjetas == 0)
            {
                ColapsarAInterfazChica();
            }
        }
        private bool ValidarFormularioCompleto(out decimal monto)
        {
            monto = 0;

            if (cmbTipo.SelectedIndex <= 0 || cmbPeriocidad.SelectedIndex <= 0 ||
                cmbPeriodo.SelectedIndex <= 0 || cmbEjercicio.SelectedIndex <= 0 ||
                cmbConcepto.SelectedIndex <= 0)
                return false;

            string textoLimpio = txtSaldoAplicar.Text.Replace("$", "").Replace(",", "").Trim();
            if (!decimal.TryParse(textoLimpio, out monto) || monto <= 0)
                return false;

            if (!cmbTipoDeclaracion.Enabled || cmbTipoDeclaracion.SelectedIndex <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(txtNumOperacion2.Text) ||
                string.IsNullOrWhiteSpace(txtMontoSaldoOriginal.Text) ||
                string.IsNullOrWhiteSpace(txtRemanenteHistorico.Text) ||
                string.IsNullOrWhiteSpace(txtFechaPresentoDeclaracion.Text) ||
                string.IsNullOrWhiteSpace(txtRemanenteActualizado.Text))
                return false;

            return true;
        }
        private void ResetFormularioCompleto()
        {
            cmbTipo.SelectedIndex = 0;
            cmbPeriocidad.SelectedIndex = 0;
            cmbPeriodo.SelectedIndex = 0;
            cmbEjercicio.SelectedIndex = 0;
            HabilitarBloqueDatos(false);

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
        }
        private void CongelarTarjetaActual(decimal monto)
        {
            var card = new Panel
            {
                Location = new Point(50, pnlFormularioCaptura.Top + (contadorTarjetas + 1) * 0), // se ajusta abajo
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

            // Fila 1
            AddCampo("Tipo", cmbTipo.Text, 15, 45, 290);
            AddCampo("Periocidad", cmbPeriocidad.Text, 345, 45, 290);
            AddCampo("Período", cmbPeriodo.Text, 675, 45, 290);
            AddCampo("Ejercicio", cmbEjercicio.Text, 1005, 45, 290);

            // Fila 2
            AddCampo("Fecha de causación (dd-mm-aaaa)", txtFechaCausacion.Text, 15, 115, 290);
            AddCampo("Número de operación", txtNumOperacion1.Text, 345, 115, 290);
            AddCampo("Concepto", cmbConcepto.Text, 675, 115, 290);
            AddCampo("Saldo a aplicar", monto.ToString("N0"), 1005, 115, 290);

            // Divisor
            var divisor = new Panel
            {
                Location = new Point(15, 185),
                Size = new Size(1270, 1),
                BackColor = Color.FromArgb(220, 220, 220)
            };
            card.Controls.Add(divisor);

            // Fila 3
            AddCampo("Tipo de declaración", cmbTipoDeclaracion.Text, 15, 210, 370);
            AddCampo("Número de operación", txtNumOperacion2.Text, 735, 210, 320);

            // Fila 4
            AddCampo("Monto del saldo a favor original", txtMontoSaldoOriginal.Text, 15, 280, 370);
            AddCampo("Remanente histórico antes de la aplicación", txtRemanenteHistorico.Text, 735, 280, 320);

            // Fila 5
            AddCampo("Fecha en que se presentó la declaración del saldo a favor (dd-mm-aaaa)", txtFechaPresentoDeclaracion.Text, 15, 355, 370);
            AddCampo("Remanente actualizado antes de la aplicación", txtRemanenteActualizado.Text, 735, 355, 320);

            // Posicionamiento: se acomoda debajo de la última tarjeta congelada (o del formulario si es la primera)
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

            ActualizarTotal();
            ResetFormularioCompleto();

            if (contadorTarjetas >= MAX_TARJETAS)
            {
                btnAgregar.Enabled = false;
                DeshabilitarFormularioCaptura();
                MessageBox.Show("Has alcanzado el máximo de 3 compensaciones.", "Límite alcanzado",
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
        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (var m in montosAgregados) total += m;
            lblTotalHeader.Text = $"Total: ${total:N0}";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            // Si quedó una captura llena pero sin presionar "Agregar", la incluimos automáticamente
            if (pnlFormularioCaptura.Visible && contadorTarjetas < MAX_TARJETAS &&
                ValidarFormularioCompleto(out decimal montoPendiente))
            {
                CongelarTarjetaActual(montoPendiente);
            }

            decimal total = 0;
            foreach (var m in montosAgregados) total += m;

            MontoCapturado = total;
            Program.modeloIsrFisicas.Compensaciones = total;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}