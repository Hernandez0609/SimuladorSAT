using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrFisicasIngresos : Form, IInfoDeclaracion
    {
        private bool _cargandoDesdeModelo = false;
        public fmIsrFisicasIngresos()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            txtTotalCobrados.TextChanged += (s, e) => { GuardarTotalCobradosDesdeTexto(); RecalcularTotalPercibidos(); ActualizarEstadoPestañas(); };   // ← ESTA LÍNEA TE FALTÓ
            txtTotalCobrados.Enter += SeleccionarTextoAlEntrar;

            CargarValoresDesdeModelo();

            txtTotalCobrados.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtDescuentos.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtIngresosDisminuirValor.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtIngresosAdicionalesValor.KeyPress += clsValidacionNumerica.SoloNumeros;


        }
        private void GuardarTotalCobradosDesdeTexto()
        {
            string limpio = txtTotalCobrados.Text.Replace("$", "").Replace(",", "").Trim();
            Program.modeloIsrFisicas.TotalIngresosCobrados = decimal.TryParse(limpio, out decimal v) ? v : 0;
        }

        private void SeleccionarTextoAlEntrar(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BeginInvoke((MethodInvoker)delegate { txt.SelectAll(); });
            }
        }
        public void ActualizarInfoDeclaracion()
        {
            if (Program.declaracionActual == null) return;

            var d = Program.declaracionActual;
            DateTime vencimiento = d.CalcularVencimiento();

            lblDatosDerecha.Text =
                $"Ejercicio: {d.Ejercicio} / periodo: {d.Periodo}\r\n" +
                $"Declaración: {d.TipoDeclaracion}\r\n" +
                $"Vencimiento: {vencimiento:dd/MM/yy}";
        }
        private Form _overlayForm;
        public void ActualizarDesdeModelo()
        {
            CargarValoresDesdeModelo();
        }

        // ====================================================================
        // Carga el estado guardado en el modelo compartido (por si regresas a esta pantalla)
        // ====================================================================
        private void CargarValoresDesdeModelo()
        {
            _cargandoDesdeModelo = true;
            var modelo = Program.modeloIsrFisicas;

            cmbCopropiedad.SelectedIndex = modelo.EsCopropiedad ? 1 : 0;
            cmbIngresosDisminuir.SelectedIndex = modelo.TieneIngresosADisminuir ? 1 : 0;
            cmbIngresosAdicionales.SelectedIndex = modelo.TieneIngresosAdicionales ? 1 : 0;

            txtTotalCobrados.Text = modelo.TotalIngresosCobrados.ToString("N0");
            txtDescuentos.Text = modelo.Descuentos.ToString("N0");
            txtIngresosDisminuirValor.Text = modelo.IngresosADisminuir.ToString("N0");
            txtIngresosAdicionalesValor.Text = modelo.IngresosAdicionales.ToString("N0");
            txtTotalPercibidos.Text = modelo.TotalIngresosPercibidos.ToString("N0");

            AplicarEstadoCopropiedad(modelo.EsCopropiedad);
            AplicarEstadoFila(4, modelo.TieneIngresosADisminuir,
                lblIngresosDisminuirValor, lblSignoIngresosDisminuir, txtIngresosDisminuirValor, btnCapturarIngresosDisminuir);
            AplicarEstadoFila(6, modelo.TieneIngresosAdicionales,
                lblIngresosAdicionalesValor, lblSignoIngresosAdicionales, txtIngresosAdicionalesValor, btnCapturarIngresosAdicionales);
            RecalcularTotalPercibidos();
            ActualizarEstadoPestañas();
            _cargandoDesdeModelo = false;
        }

        // ====================================================================
        // Combo 1: Copropiedad → muestra/oculta la pestaña "Datos adicionales"
        // ====================================================================
        private void cmbCopropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbCopropiedad.SelectedIndex == 1;
            Program.modeloIsrFisicas.EsCopropiedad = esSi;
            AplicarEstadoCopropiedad(esSi);
        }

        private void AplicarEstadoCopropiedad(bool esSi)
        {
            btnTabDatosAdicionales.Visible = esSi;
        }

        // ====================================================================
        // Combo 2: ¿Tienes ingresos a disminuir? → expande/colapsa fila 4
        // ====================================================================
        private void cmbIngresosDisminuir_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbIngresosDisminuir.SelectedIndex == 1;
            Program.modeloIsrFisicas.TieneIngresosADisminuir = esSi;
            AplicarEstadoFila(4, esSi,
                lblIngresosDisminuirValor, lblSignoIngresosDisminuir, txtIngresosDisminuirValor, btnCapturarIngresosDisminuir);
            RecalcularTotalPercibidos();
            ActualizarEstadoPestañas();
        }

        // ====================================================================
        // Combo 3: ¿Tienes ingresos adicionales? → expande/colapsa fila 6
        // ====================================================================
        private void cmbIngresosAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbIngresosAdicionales.SelectedIndex == 1;
            Program.modeloIsrFisicas.TieneIngresosAdicionales = esSi;
            AplicarEstadoFila(6, esSi,
                lblIngresosAdicionalesValor, lblSignoIngresosAdicionales, txtIngresosAdicionalesValor, btnCapturarIngresosAdicionales);
            RecalcularTotalPercibidos();
            ActualizarEstadoPestañas();
        }

        // ====================================================================
        // Método genérico: expande o colapsa UNA fila específica del TableLayoutPanel,
        // sin afectar ninguna otra fila ni borrar el valor que ya tenía el campo.
        // ====================================================================
        private void AplicarEstadoFila(int indiceFila, bool mostrar,
            Label lbl, Label lblSigno, TextBox txt, Button btnCapturar)
        {
            this.SuspendLayout();

            tlpCamposSat.RowStyles[indiceFila] = mostrar
                ? new RowStyle(SizeType.Absolute, 52F)
                : new RowStyle(SizeType.Absolute, 0F);

            lbl.Visible = mostrar;
            lblSigno.Visible = mostrar;
            txt.Visible = mostrar;
            btnCapturar.Visible = mostrar;

            this.ResumeLayout(true);
        }
        private void RecalcularTotalPercibidos()
        {
            var m = Program.modeloIsrFisicas;
            decimal disminuir = m.TieneIngresosADisminuir ? m.IngresosADisminuir : 0;
            decimal adicionales = m.TieneIngresosAdicionales ? m.IngresosAdicionales : 0;
            decimal total = m.TotalIngresosCobrados - m.Descuentos - disminuir + adicionales;
            if (total < 0) total = 0;
            m.TotalIngresosPercibidos = total;
            txtTotalPercibidos.Text = total.ToString("N0");

            if (!_cargandoDesdeModelo)
            {
                m.TotalPercibidosCapturado = false;
                m.IsrRetenidoPersonasMorales = 0;
                m.IsrRetenidoCapturado = false;
                m.DeterminacionCompleta = false;
                m.EsImpuestoAFavor = false;
                m.ImpuestoACargo = 0;
                m.ImpuestoAFavor = 0;
                m.TieneCompensaciones = false;
                m.CompensacionesCapturado = false;
                m.Compensaciones = 0;
                m.TieneEstimulos = false;
                m.EstimulosCapturado = false;
                m.Estimulos = 0;
                m.CantidadACargo = 0;
                m.CantidadAPagar = 0;
            }
        }
        public bool IngresosCompleto()
        {
            var m = Program.modeloIsrFisicas;
            if (!m.DescuentosCapturado) return false;
            if (m.TieneIngresosADisminuir && !m.IngresosADisminuirCapturado) return false;
            if (m.TieneIngresosAdicionales && !m.IngresosAdicionalesCapturado) return false;
            if (!m.TotalPercibidosCapturado) return false;
            return true;
        }

        public void ActualizarEstadoPestañas()
        {
            var m = Program.modeloIsrFisicas;
            bool ingresosOk = IngresosCompleto();

            EstadoPestanasHelper.Aplicar(btnTabIngresos, "Ingresos", true, ingresosOk, esPaginaActual: true);
            EstadoPestanasHelper.Aplicar(btnTabDeterminacion, "Determinación", ingresosOk, m.DeterminacionCompleta, esPaginaActual: false);
            EstadoPestanasHelper.Aplicar(btnTabPago, "Pago", ingresosOk && m.DeterminacionCompleta, false, esPaginaActual: false);
        }
        private void btnCapturarDescuentos_Click(object sender, EventArgs e)
        {
            try
            {
                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50;
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds;
                _overlayForm.Owner = this;
                _overlayForm.Show();
                using (var dlg = new fmDetalleDescuentosIngresos())
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIsrFisicas.Descuentos = dlg.MontoCapturado;
                        Program.modeloIsrFisicas.DescuentosCapturado = true;
                        txtDescuentos.Text = dlg.MontoCapturado.ToString("N0");
                        RecalcularTotalPercibidos();
                        ActualizarEstadoPestañas();
                    }
                }
            }
            finally
            {
                if (_overlayForm != null)
                {
                    _overlayForm.Close();
                    _overlayForm.Dispose();
                    _overlayForm = null;
                }
            }
        }

        private void btnCapturarIngresosDisminuir_Click(object sender, EventArgs e)
        {
            try
            {
                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50;
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds;
                _overlayForm.Owner = this;
                _overlayForm.Show();

                decimal montoMaximo = Program.modeloIsrFisicas.TotalIngresosCobrados - Program.modeloIsrFisicas.Descuentos;   // ← LÍNEA NUEVA
                using (var dlg = new fmDetalleIngresosADisminuir(montoMaximo))   // ← CAMBIO: pasa el límite
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIsrFisicas.IngresosADisminuir = dlg.MontoCapturado;
                        Program.modeloIsrFisicas.IngresosADisminuirCapturado = true;
                        txtIngresosDisminuirValor.Text = dlg.MontoCapturado.ToString("N0");
                        RecalcularTotalPercibidos();
                        ActualizarEstadoPestañas();
                    }
                }
            }
            finally
            {
                if (_overlayForm != null)
                {
                    _overlayForm.Close();
                    _overlayForm.Dispose();
                    _overlayForm = null;
                }
            }
        }

        private void btnCapturarIngresosAdicionales_Click(object sender, EventArgs e)
        {
            try
            {
                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50;
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds;
                _overlayForm.Owner = this;
                _overlayForm.Show();
                using (var dlg = new fmDetalleIngresosAdicionales())
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIsrFisicas.IngresosAdicionales = dlg.MontoCapturado;
                        Program.modeloIsrFisicas.IngresosAdicionalesCapturado = true;
                        txtIngresosAdicionalesValor.Text = dlg.MontoCapturado.ToString("N0");
                        RecalcularTotalPercibidos();
                        ActualizarEstadoPestañas();
                    }
                }
            }
            finally
            {
                if (_overlayForm != null)
                {
                    _overlayForm.Close();
                    _overlayForm.Dispose();
                    _overlayForm = null;
                }
            }
        }

        private void btnCapturarTotalPercibidos_Click(object sender, EventArgs e)
        {
            try
            {
                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50;
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds;
                _overlayForm.Owner = this;
                _overlayForm.Show();
                using (var dlg = new fmDetalleTotalIngresosPercibidos(Program.modeloIsrFisicas.TotalIngresosPercibidos))  
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        ActualizarEstadoPestañas();
                    }
                }
            }
            finally
            {
                if (_overlayForm != null)
                {
                    _overlayForm.Close();
                    _overlayForm.Dispose();
                    _overlayForm = null;
                }
            }
        }

        // ====================================================================
        // Navegación de pestañas
        // ====================================================================
        private void btnTabDeterminacion_Click(object sender, EventArgs e)
        {
            if (!IngresosCompleto())
            {
                MessageBox.Show("Completa todos los campos obligatorios de Ingresos antes de continuar (Descuentos, y si aplica, Ingresos a disminuir/adicionales).",
                    "Sección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Program.formIsrFisicasDeterminacion == null || Program.formIsrFisicasDeterminacion.IsDisposed)
            {
                Program.formIsrFisicasDeterminacion = new fmIsrFisicasDeterminacion();
            }
            Program.formIsrFisicasDeterminacion.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasDeterminacion, this);
        }
        private void GuardarProgreso()
        {
            if (Program.declaracionActual == null) return;
            new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
        }
        private void btnTabPago_Click(object sender, EventArgs e)
        {
            if (!IngresosCompleto() || !Program.modeloIsrFisicas.DeterminacionCompleta)
            {
                MessageBox.Show("Completa Ingresos y Determinación antes de continuar a Pago.",
                    "Sección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Program.formIsrFisicasPago.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasPago, this);
        }

        private void btnTabDatosAdicionales_Click(object sender, EventArgs e)
        {
            // Se conectará cuando exista fmIsrFisicasDatosAdicionales
        }

        // ====================================================================
        // Navegación general
        // ====================================================================
        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            GuardarProgreso();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            GuardarProgreso();
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            GuardarProgreso();
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }
    }
}