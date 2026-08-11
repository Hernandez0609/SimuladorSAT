using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrRetencionesSalarios : Form, IInfoDeclaracion
    {
        public fmIsrRetencionesSalarios()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            txtTrabajadores.TextChanged += (s, e) => { GuardarTrabajadoresDesdeTexto(); ActualizarEstadoPestañas(); };
            txtPagoSueldos.TextChanged += (s, e) => { GuardarPagoSueldosDesdeTexto(); ActualizarEstadoPestañas(); };
            txtPagosExentos.TextChanged += (s, e) => { GuardarPagosExentosDesdeTexto(); ActualizarEstadoPestañas(); };
            txtIsrRetenido.TextChanged += (s, e) => { GuardarIsrRetenidoSueldosDesdeTexto(); ActualizarEstadoPestañas(); };

            txtTrabajadores.Enter += SeleccionarTextoAlEntrar;
            txtPagoSueldos.Enter += SeleccionarTextoAlEntrar;
            txtPagosExentos.Enter += SeleccionarTextoAlEntrar;
            txtIsrRetenido.Enter += SeleccionarTextoAlEntrar;

            txtIsrRegistro.TextChanged += (s, e) => { GuardarIsrRegistroDesdeTexto(); RecalcularDeterminacion(); ActualizarEstadoPestañas(); };
            txtIsrRegistro.Enter += SeleccionarTextoAlEntrar;
            txtTrabajadores.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtPagoSueldos.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtPagosExentos.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtIsrRetenido.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtIsrRegistro.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtImpuestoCargo.KeyPress += clsValidacionNumerica.SoloNumeros;

            CargarValoresDesdeModelo();
            this.FormBorderStyle = FormBorderStyle.None;
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

        public void ActualizarDesdeModelo()
        {
            CargarValoresDesdeModelo();
        }

        private void CargarValoresDesdeModelo()
        {
            var m = Program.modeloIsrSalarios;

            txtTrabajadores.Text = m.NumeroTrabajadores.ToString();
            txtPagoSueldos.Text = m.PagoSueldos.ToString("N0");
            txtPagosExentos.Text = m.PagosExentos.ToString("N0");
            txtIsrRetenido.Text = m.IsrRetenidoSueldos.ToString("N0");

            // Solo escribe el valor si ya fue capturado antes; si no, se queda vacío
            txtIsrRegistro.Text = m.IsrRetenidoRegistroCapturado
                ? m.IsrRetenidoRegistroContribuyente.ToString("N0")
                : "";

            RecalcularDeterminacion();
            ActualizarEstadoPestañas();
        }
        private void GuardarIsrRegistroDesdeTexto()
        {
            string limpio = txtIsrRegistro.Text.Replace("$", "").Replace(",", "").Trim();

            if (string.IsNullOrEmpty(limpio))
            {
                Program.modeloIsrSalarios.IsrRetenidoRegistroContribuyente = 0;
                Program.modeloIsrSalarios.IsrRetenidoRegistroCapturado = false;
                return;
            }

            Program.modeloIsrSalarios.IsrRetenidoRegistroContribuyente = decimal.TryParse(limpio, out decimal v) ? v : 0;
            Program.modeloIsrSalarios.IsrRetenidoRegistroCapturado = true;
        }
        private void GuardarTrabajadoresDesdeTexto()
        {
            string limpio = txtTrabajadores.Text.Trim();
            Program.modeloIsrSalarios.NumeroTrabajadores = int.TryParse(limpio, out int v) ? v : 0;
        }

        private void GuardarPagoSueldosDesdeTexto()
        {
            string limpio = txtPagoSueldos.Text.Replace("$", "").Replace(",", "").Trim();
            Program.modeloIsrSalarios.PagoSueldos = decimal.TryParse(limpio, out decimal v) ? v : 0;
        }

        private void GuardarPagosExentosDesdeTexto()
        {
            string limpio = txtPagosExentos.Text.Replace("$", "").Replace(",", "").Trim();
            Program.modeloIsrSalarios.PagosExentos = decimal.TryParse(limpio, out decimal v) ? v : 0;
        }

        private void GuardarIsrRetenidoSueldosDesdeTexto()
        {
            string limpio = txtIsrRetenido.Text.Replace("$", "").Replace(",", "").Trim();
            Program.modeloIsrSalarios.IsrRetenidoSueldos = decimal.TryParse(limpio, out decimal v) ? v : 0;
        }
        private void RecalcularDeterminacion()
        {
            var m = Program.modeloIsrSalarios;
            m.ImpuestoACargo = m.IsrRetenidoRegistroContribuyente;
            txtImpuestoCargo.Text = m.ImpuestoACargo.ToString("N0");
            m.DeterminacionCompleta = m.IsrRetenidoRegistroCapturado;
        }

        public bool DeterminacionCompleto()
        {
            return Program.modeloIsrSalarios.DeterminacionCompleta;
        }

        public void ActualizarEstadoPestañas()
        {
            var m = Program.modeloIsrSalarios;
            EstadoPestanasHelper.Aplicar(btnTabDeterminacion, "Determinación", true, m.DeterminacionCompleta, esPaginaActual: true);
            EstadoPestanasHelper.Aplicar(btnTabPago, "Pago", m.DeterminacionCompleta, false, esPaginaActual: false);
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
            if (!DeterminacionCompleto())
            {
                MessageBox.Show("Captura el ISR retenido de acuerdo a los registros del contribuyente antes de continuar a Pago.",
                    "Sección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Program.formPagoIsr == null || Program.formPagoIsr.IsDisposed)
            {
                Program.formPagoIsr = new fmPagoISR();
            }
            Program.formPagoIsr.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formPagoIsr, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);

            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void GuardarYMarcarCompletado()
        {
            if (!DeterminacionCompleto())
            {
                MessageBox.Show("Completa el detalle de ISR retenido antes de guardar.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Program.declaracionActual == null) return;

            var conexion = new clsConexion();
            conexion.GuardarTodosLosModulos(Program.declaracionActual);
            conexion.MarcarModuloCompletado(Program.declaracionActual.Id, "modulo_isr_salarios_completado");

            Program.declaracionActual.ModuloIsrSalariosCompletado = true;
            Program.declaracionActual.MontoIsrSalarios = Program.modeloIsrSalarios.CantidadAPagar;
            Program.formAdmin.AplicarModulosDeclaracionActual();

            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}