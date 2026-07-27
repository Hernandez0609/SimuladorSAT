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

            // Total de ingresos percibidos viene directo de lo capturado en Ingresos
            txtTotalPercibidos.Text = modelo.TotalIngresosPercibidos.ToString("N0");
            txtTasaAplicable.Text = modelo.TasaAplicable.ToString("N2");
            txtImpuestoMensual.Text = modelo.ImpuestoMensual.ToString("N0");
            txtIsrRetenido.Text = modelo.IsrRetenidoPersonasMorales.ToString("N0");
            txtImpuestoACargo.Text = modelo.ImpuestoACargo.ToString("N0");
            btnTabDatosAdicionales.Visible = modelo.EsCopropiedad;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            // 1. Creamos el formulario que servirá de cortina oscura
            using (Form cortinaOcursa = new Form())
            {
                cortinaOcursa.StartPosition = FormStartPosition.Manual;
                cortinaOcursa.FormBorderStyle = FormBorderStyle.None;
                cortinaOcursa.Opacity = 0.50d; // Oscurece al 50%
                cortinaOcursa.BackColor = System.Drawing.Color.Black;

                // Sincronizamos el tamaño y posición exactos con el formulario actual
                cortinaOcursa.Bounds = this.Bounds;
                cortinaOcursa.ShowInTaskbar = false;
                cortinaOcursa.Show(this); // Se muestra encima de Determinación

                // 2. Instanciamos el verdadero cuadro de diálogo de Detalle
                using (fmDetalleIsrRetenido dialogoDetalle = new fmDetalleIsrRetenido())
                {
                    // Pasamos los datos del modelo actual si se requieren prellenar
                    // dialogoDetalle.CargarDatos(Program.modeloIsrFisicas);

                    // Se abre de forma MODAL, deteniendo el flujo y centrándose sobre la cortina
                    dialogoDetalle.ShowDialog(cortinaOcursa);
                }

                // Al cerrar el diálogo, el bloque 'using' destruye automáticamente la cortina oscura
                cortinaOcursa.Close();
            }
        }

        // ====================================================================
        // Navegación de pestañas
        // ====================================================================
        private void btnTabIngresos_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasIngresos.ActualizarDesdeModelo(); // ← NUEVO
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasIngresos, this);
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
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
