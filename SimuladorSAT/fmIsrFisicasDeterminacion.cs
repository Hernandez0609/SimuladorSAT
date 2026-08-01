using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrFisicasDeterminacion : Form, IInfoDeclaracion
    {
        public fmIsrFisicasDeterminacion()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarValoresDesdeModelo();
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

        public void ActualizarDesdeModelo()
        {
            CargarValoresDesdeModelo();
        }

        private void CargarValoresDesdeModelo()
        {
            var modelo = Program.modeloIsrFisicas;
            txtTotalPercibidos.Text = modelo.TotalIngresosPercibidos.ToString("N0");

            RecalcularDeterminacion();
            btnTabDatosAdicionales.Visible = modelo.EsCopropiedad;
            ActualizarEstadoPestañas();
        }

        // ====================================================================
        // Tabla mensual RESICO (confirmada con el contador y el Excel real)
        // ====================================================================
        private decimal ObtenerTasaAplicable(decimal ingresos)
        {
            if (ingresos <= 25000m) return 1.0m;
            if (ingresos <= 50000m) return 1.1m;
            if (ingresos <= 83333.33m) return 1.5m;
            if (ingresos <= 208333.33m) return 2.0m;
            return 2.5m; // 208,333.34 en adelante
        }

        private void RecalcularDeterminacion()
        {
            var m = Program.modeloIsrFisicas;

            m.TasaAplicable = ObtenerTasaAplicable(m.TotalIngresosPercibidos);
            m.ImpuestoMensual = Math.Round(m.TotalIngresosPercibidos * (m.TasaAplicable / 100m), 2);
            m.ImpuestoACargo = m.ImpuestoMensual - m.IsrRetenidoPersonasMorales;

            txtTasaAplicable.Text = m.TasaAplicable.ToString("N2") + "%";
            txtImpuestoMensual.Text = m.ImpuestoMensual.ToString("N0");
            txtIsrRetenido.Text = m.IsrRetenidoPersonasMorales.ToString("N0");
            txtImpuestoACargo.Text = m.ImpuestoACargo.ToString("N0");

            m.DeterminacionCompleta = m.IsrRetenidoCapturado;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            using (Form cortinaOcursa = new Form())
            {
                cortinaOcursa.StartPosition = FormStartPosition.Manual;
                cortinaOcursa.FormBorderStyle = FormBorderStyle.None;
                cortinaOcursa.Opacity = 0.50d;
                cortinaOcursa.BackColor = System.Drawing.Color.Black;
                cortinaOcursa.Bounds = this.Bounds;
                cortinaOcursa.ShowInTaskbar = false;
                cortinaOcursa.Show(this);

                using (fmDetalleIsrRetenido dialogoDetalle = new fmDetalleIsrRetenido())
                {
                    if (dialogoDetalle.ShowDialog(cortinaOcursa) == DialogResult.OK)
                    {
                        Program.modeloIsrFisicas.IsrRetenidoPersonasMorales = dialogoDetalle.MontoCapturado;
                        Program.modeloIsrFisicas.IsrRetenidoCapturado = true;
                        RecalcularDeterminacion();
                        ActualizarEstadoPestañas();
                    }
                }
                cortinaOcursa.Close();
            }
        }

        public bool DeterminacionCompleto()
        {
            return Program.modeloIsrFisicas.IsrRetenidoCapturado;
        }

        public void ActualizarEstadoPestañas()
        {
            var m = Program.modeloIsrFisicas;
            string textoDeterminacion = m.DeterminacionCompleta ? "✓ Determinación" : "Determinación";

            EstadoPestanasHelper.Aplicar(btnTabIngresos, "Ingresos", true, true, esPaginaActual: false);

            btnTabDeterminacion.Text = textoDeterminacion;
            btnTabDeterminacion.FlatAppearance.BorderSize = 0;
            btnTabDeterminacion.Enabled = true;
            // esta es la página actual: se deja el color teal del Designer, solo tocamos el texto

            EstadoPestanasHelper.Aplicar(btnTabPago, "Pago", m.DeterminacionCompleta, false, esPaginaActual: false);
        }
        private void btnTabIngresos_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasIngresos.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasIngresos, this);
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
            if (!DeterminacionCompleto())
            {
                MessageBox.Show("Completa el detalle de ISR retenido antes de continuar a Pago.",
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

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }
    }
}