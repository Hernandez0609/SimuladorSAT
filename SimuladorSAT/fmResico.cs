using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmResico : Form, IInfoDeclaracion
    {
        private Form _ventanaAnterior;
        private Form _overlayForm;
        private bool _sincronizandoTxt7 = false;
        private System.Windows.Forms.Timer _debounceTimer;
        public fmResico()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += (s, e) => ActualizarInfoDeclaracion();
            NavegacionHelper.CargarEncabezadoUsuario(lblDatosIzquierda);
            this.txtAcreditamiento.TextChanged += (s, e) => RecalcularDeterminacion();
            txt1.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt2.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt3.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt4.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt5.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt6.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt7.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt8.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt9.KeyPress += clsValidacionNumerica.SoloNumeros;
            txt10.KeyPress += clsValidacionNumerica.SoloNumeros;
        }

        public fmResico(Form ventanaAnterior)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            this.Load += (s, e) =>
            {
                ActualizarInfoDeclaracion();
            };

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            _ventanaAnterior = ventanaAnterior;
            AumentarFuentes();
            WirearEventos();
            CargarValoresDesdeModelo();
        }

        private void AumentarFuentes()
        {
            var fontLabel = new Font("Arial", 10F);
            var fontTexto = new Font("Arial", 10F);

            foreach (Control c in tlpCamposSat.Controls)
            {
                if (c is Label lbl && lbl.Font.Bold == false) lbl.Font = fontLabel;
                if (c is TextBox txt) txt.Font = fontTexto;
                if (c is Button btn) btn.Font = fontTexto;
            }
        }
        private void WirearEventos()
        {
            _debounceTimer = new System.Windows.Forms.Timer();
            _debounceTimer.Interval = 600;
            _debounceTimer.Tick += (s, e) =>
            {
                _debounceTimer.Stop();
                RecalcularDeterminacion();
            };

            EventHandler reiniciarTimer = (s, e) => { _debounceTimer.Stop(); _debounceTimer.Start(); };

            txt1.TextChanged += reiniciarTimer;
            txt3.TextChanged += reiniciarTimer;
            txt4.TextChanged += reiniciarTimer;
            txt7.TextChanged += reiniciarTimer;
            txt7.TextChanged += Txt7_TextChanged_Manual;
            txt8.TextChanged += reiniciarTimer;
            txt10.TextChanged += reiniciarTimer;
            txtAcreditamiento.TextChanged += reiniciarTimer;
            txt1.Enter += SeleccionarTextoAlEntrar;
            txt3.Enter += SeleccionarTextoAlEntrar;
            txt4.Enter += SeleccionarTextoAlEntrar;
            txt7.Enter += SeleccionarTextoAlEntrar;
            txt8.Enter += SeleccionarTextoAlEntrar;
            txt10.Enter += SeleccionarTextoAlEntrar;
            txtAcreditamiento.Enter += SeleccionarTextoAlEntrar;

            btnTabPago.Click += btnTabPago_Click;
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
            NavegacionHelper.CargarEncabezadoUsuario(lblDatosIzquierda);
        }

        public void ActualizarDesdeModelo()
        {
            ActualizarInfoDeclaracion();
            CargarValoresDesdeModelo();
        }

        private decimal Parsear(string texto)
        {
            string limpio = texto.Replace("$", "").Replace(",", "").Trim();
            return decimal.TryParse(limpio, out decimal v) ? v : 0;
        }
        private void SeleccionarTextoAlEntrar(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BeginInvoke((MethodInvoker)delegate { txt.SelectAll(); });
            }
        }
        private void CargarValoresDesdeModelo()
        {
            var m = Program.modeloIva;
            txt1.Text = m.ActividadesGravadas16.ToString("N0");
            txt2.Text = m.ActividadesGravadas0.ToString("N0");
            txt3.Text = m.ActividadesExentas.ToString("N0");
            txt4.Text = m.ActividadesNoObjeto.ToString("N0");

            _sincronizandoTxt7 = true;
            txt7.Text = m.IvaNoCobradoDevoluciones.ToString("N0");
            _sincronizandoTxt7 = false;

            txt8.Text = m.IvaRetenido.ToString("N0");
            txt9.Text = m.IvaAcreditablePeriodoCapturado ? m.IvaAcreditablePeriodo.ToString("N0") : "0";
            txt10.Text = m.IvaPorDevolucionesGastos.ToString("N0");
            RecalcularDeterminacion();
        }

        private void RecalcularDeterminacion()
        {
            var m = Program.modeloIva;

            m.ActividadesGravadas16 = Parsear(txt1.Text);
            m.ActividadesGravadas0 = Parsear(txt2.Text);
            m.ActividadesExentas = Parsear(txt3.Text);
            m.ActividadesNoObjeto = Parsear(txt4.Text);
            m.IvaNoCobradoDevoluciones = Parsear(txt7.Text);
            m.IvaRetenido = Parsear(txt8.Text);
            m.IvaPorDevolucionesGastos = Parsear(txt10.Text);

            m.IvaACargo16 = Math.Round(m.ActividadesGravadas16 * 0.16m, 2);
            m.TotalIvaACargo = m.IvaACargo16;

            m.CantidadACargo = m.TotalIvaACargo
                                - m.IvaNoCobradoDevoluciones
                                - m.IvaRetenido
                                - m.IvaAcreditablePeriodo
                                + m.IvaPorDevolucionesGastos;

            txt5.Text = m.IvaACargo16.ToString("N0");
            txt6.Text = m.TotalIvaACargo.ToString("N0");

            decimal cantidadCargoCruda = m.CantidadACargo; // sin truncar, puede ser negativo

            if (cantidadCargoCruda >= 0)
            {
                m.EsImpuestoAFavor = false;
                txt11.Text = cantidadCargoCruda.ToString("N0");
                lbl12.Text = "Impuesto a cargo";
                MostrarAcreditamiento(true);
                decimal acreditamiento = Parsear(txtAcreditamiento.Text);
                m.AcreditamientoSaldoFavorAnterior = acreditamiento;
                m.ImpuestoFinal = cantidadCargoCruda - acreditamiento;
                if (m.ImpuestoFinal < 0) m.ImpuestoFinal = 0;
                txt12.Text = m.ImpuestoFinal.ToString("N0");
            }
            else
            {
                m.EsImpuestoAFavor = true;
                txt11.Text = "0"; // nunca se muestra negativo
                lbl12.Text = "Impuesto a favor";
                MostrarAcreditamiento(false);
                m.ImpuestoFinal = Math.Abs(cantidadCargoCruda);
                txt12.Text = m.ImpuestoFinal.ToString("N0");
            }

            m.DeterminacionCompleta = m.ActividadesGravadas0Capturado && m.IvaAcreditablePeriodoCapturado;
            ActualizarEstadoPestañas();
        }

        private void lblCantACargoAplicaciones() { /* placeholder, no-op */ }

        private void MostrarAcreditamiento(bool mostrar)
        {
            lblAcreditamiento.Visible = mostrar;
            lblSignoAcreditamiento.Visible = mostrar;
            txtAcreditamiento.Visible = mostrar;
        }

        public void ActualizarEstadoPestañas()
        {
            var m = Program.modeloIva;
            EstadoPestanasHelper.Aplicar(btnTabDeterminacion, "Determinación", true, m.DeterminacionCompleta, esPaginaActual: true);
            EstadoPestanasHelper.Aplicar(btnTabPago, "Pago", m.DeterminacionCompleta, false, esPaginaActual: false);
        }

        private void ActivarCortinaOscura()
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
        }

        private void DesactivarCortinaOscura()
        {
            if (_overlayForm != null)
            {
                _overlayForm.Close();
                _overlayForm.Dispose();
                _overlayForm = null;
            }
        }

        private void RegresarAAdmin()
        {
            if (_ventanaAnterior != null)
            {
                NavegacionHelper.MostrarSinParpadeo((Form)_ventanaAnterior, this);
            }
        }

        private void btnRegresarAdmin_Click(object sender, EventArgs e) { RegresarAAdmin(); }

        private void btn1_Click(object sender, EventArgs e)
        {
            try { ActivarCortinaOscura(); new fmDetalle("Actividades gravadas a la tasa del 16%", "Junio").ShowDialog(_overlayForm); }
            finally { DesactivarCortinaOscura(); }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            try { ActivarCortinaOscura(); new fmDetalle("Actividades exentas", "Abril").ShowDialog(_overlayForm); }
            finally { DesactivarCortinaOscura(); }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            try { ActivarCortinaOscura(); new fmDetalle("Actividades no objeto del impuesto", "Junio").ShowDialog(_overlayForm); }
            finally { DesactivarCortinaOscura(); }
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                using (var dlg = new fmDetalle("IVA no cobrado por devoluciones, descuentos y bonificaciones de ventas", "Junio", Program.modeloIva.TotalIvaACargo))
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        _sincronizandoTxt7 = true;
                        txt7.Text = Program.modeloIva.IvaNoCobradoDevoluciones.ToString("N0");
                        _sincronizandoTxt7 = false;
                        RecalcularDeterminacion();
                    }
                }
            }
            finally { DesactivarCortinaOscura(); }
        }
        private void Txt7_TextChanged_Manual(object sender, EventArgs e)
        {
            if (_sincronizandoTxt7) return; 

            var m = Program.modeloIva;
            m.DetalleDevolucionesFacturasCanceladas = 0;
            m.DetalleDevolucionesFacturasVigentes = 0;
            m.DetalleDevolucionesSubtotal = 0;
            m.DetalleDevolucionesDescuento = 0;
            m.Iva8PorcentoEgresos = 0;
            m.Iva16PorcentoEgresos = 0;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            try { ActivarCortinaOscura(); new fmDetalle("IVA retenido", "Junio").ShowDialog(_overlayForm); }
            finally { DesactivarCortinaOscura(); }
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            try { ActivarCortinaOscura(); new fmDetalle("IVA por devoluciones, descuentos y bonificaciones en gastos", "Junio").ShowDialog(_overlayForm); }
            finally { DesactivarCortinaOscura(); }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                decimal valorActual = Parsear(txt2.Text);
                var m = Program.modeloIva;
                using (var ventana = new fmCapturar("Tasa0", valorActual, m.Tasa0Nacional, m.Tasa0Exportacion))
                {
                    if (ventana.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        txt2.Text = ventana.MontoCapturado.ToString("N0");
                        m.ActividadesGravadas0Capturado = true;
                        m.Tasa0Nacional = ventana.SubValor1Capturado;
                        m.Tasa0Exportacion = ventana.SubValor2Capturado;
                        RecalcularDeterminacion();
                    }
                }
            }
            finally { DesactivarCortinaOscura(); }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                var m = Program.modeloIva;
                using (var ventana = new fmCapturar("IvaAcreditable", 0, m.AcreditableGravado16, m.AcreditableMixtas))
                {
                    if (ventana.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        txt9.Text = ventana.MontoCapturado.ToString("N0");
                        m.IvaAcreditablePeriodo = ventana.MontoCapturado;
                        m.IvaAcreditablePeriodoCapturado = true;
                        m.AcreditableGravado16 = ventana.SubValor1Capturado;
                        m.AcreditableMixtas = ventana.SubValor2Capturado;
                        RecalcularDeterminacion();
                    }
                }
            }
            finally { DesactivarCortinaOscura(); }
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
        private void btnTabPago_Click(object sender, EventArgs e)
        {
            if (!Program.modeloIva.DeterminacionCompleta)
            {
                MessageBox.Show("Completa las capturas obligatorias de Determinación antes de continuar a Pago.",
                    "Sección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Program.formPagoIva == null || Program.formPagoIva.IsDisposed)
            {
                Program.formPagoIva = new fmPagoIVA();
            }
            Program.formPagoIva.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formPagoIva, this);
        }
        private void GuardarProgreso()
        {
            if (Program.declaracionActual == null) return;
            new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProgreso();
            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdminDeclaracion_Click(object sender, EventArgs e)
        {
            GuardarProgreso();
            RegresarAAdmin();
        }
        private void pnlContenedorPrincipal_Paint(object sender, PaintEventArgs e) { }
        private void picEscudoUthh_Click(object sender, EventArgs e) { }
    }
}