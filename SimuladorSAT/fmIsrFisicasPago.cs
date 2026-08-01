using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrFisicasPago : Form, IInfoDeclaracion
    {
        public fmIsrFisicasPago()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarValoresDesdeModelo();
            txtSubsidio.TextChanged += (s, e) => { GuardarSubsidioDesdeTexto(); RecalcularPago(); };
            txtSubsidio.Enter += SeleccionarTextoAlEntrar;
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
        private void SeleccionarTextoAlEntrar(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BeginInvoke((MethodInvoker)delegate { txt.SelectAll(); });
            }
        }
        private void CargarValoresDesdeModelo()
        {
            var modelo = Program.modeloIsrFisicas;

            txtACargo.Text = modelo.ImpuestoACargo.ToString("N0");
            txtSubsidio.Text = modelo.SubsidioParaElEmpleo.ToString("N0");
            cmbCompensaciones.SelectedIndex = modelo.TieneCompensaciones ? 1 : 0;
            cmbEstimulos.SelectedIndex = modelo.TieneEstimulos ? 1 : 0;
            txtCompensacionesValor.Text = modelo.Compensaciones.ToString("N0");
            txtEstimulosValor.Text = modelo.Estimulos.ToString("N0");

            AplicarEstadoFila(4, modelo.TieneCompensaciones,
                lblCompensacionesValor, lblSignoCompensaciones, txtCompensacionesValor, btnCapturarCompensaciones);
            AplicarEstadoFila(6, modelo.TieneEstimulos,
                lblEstimulosValor, lblSignoEstimulos, txtEstimulosValor, btnCapturarEstimulos);

            btnTabDatosAdicionales.Visible = modelo.EsCopropiedad;

            RecalcularPago();
            ActualizarEstadoPestañas();
        }

        private void GuardarSubsidioDesdeTexto()
        {
            string limpio = txtSubsidio.Text.Replace("$", "").Replace(",", "").Trim();
            Program.modeloIsrFisicas.SubsidioParaElEmpleo = decimal.TryParse(limpio, out decimal v) ? v : 0;
        }

        private void RecalcularPago()
        {
            var m = Program.modeloIsrFisicas;

            decimal compensaciones = m.TieneCompensaciones ? m.Compensaciones : 0;
            decimal estimulos = m.TieneEstimulos ? m.Estimulos : 0;

            m.TotalAplicaciones = m.SubsidioParaElEmpleo + compensaciones + estimulos;

            decimal cantidad = m.ImpuestoACargo - m.TotalAplicaciones;
            if (cantidad < 0) cantidad = 0;

            m.CantidadACargo = cantidad;
            m.CantidadAPagar = cantidad;

            txtTotalContribuciones1.Text = m.ImpuestoACargo.ToString("N0");
            txtTotalAplicaciones1.Text = m.TotalAplicaciones.ToString("N0");
            txtTotalContribuciones2.Text = m.ImpuestoACargo.ToString("N0");
            txtTotalAplicaciones2.Text = m.TotalAplicaciones.ToString("N0");
            txtCantidadACargo.Text = m.CantidadACargo.ToString("N0");
            txtCantidadAPagar.Text = m.CantidadAPagar.ToString("N0");
        }
        public void ActualizarEstadoPestañas()
        {
            var m = Program.modeloIsrFisicas;
            EstadoPestanasHelper.Aplicar(btnTabIngresos, "Ingresos", true, true, esPaginaActual: false);
            EstadoPestanasHelper.Aplicar(btnTabDeterminacion, "Determinación", true, true, esPaginaActual: false);
            // Pago es la página actual — se deja el color/teal del Designer, solo se actualiza si acaso
        }
        private void cmbCompensaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbCompensaciones.SelectedIndex == 1;
            Program.modeloIsrFisicas.TieneCompensaciones = esSi;
            if (!esSi) Program.modeloIsrFisicas.CompensacionesCapturado = false;
            AplicarEstadoFila(4, esSi,
                lblCompensacionesValor, lblSignoCompensaciones, txtCompensacionesValor, btnCapturarCompensaciones);
            RecalcularPago();
        }

        private void cmbEstimulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbEstimulos.SelectedIndex == 1;
            Program.modeloIsrFisicas.TieneEstimulos = esSi;
            if (!esSi) Program.modeloIsrFisicas.EstimulosCapturado = false;
            AplicarEstadoFila(6, esSi,
                lblEstimulosValor, lblSignoEstimulos, txtEstimulosValor, btnCapturarEstimulos);
            RecalcularPago();
        }

        private void AplicarEstadoFila(int indiceFila, bool mostrar,
            Label lbl, Label lblSigno, TextBox txt, Button btnCapturar)
        {
            this.SuspendLayout();
            tlpCamposSat.RowStyles[indiceFila] = mostrar
                ? new RowStyle(SizeType.Absolute, 46F)
                : new RowStyle(SizeType.Absolute, 0F);
            lbl.Visible = mostrar;
            lblSigno.Visible = mostrar;
            txt.Visible = mostrar;
            btnCapturar.Visible = mostrar;
            this.ResumeLayout(true);
        }

        private void btnCapturarCompensaciones_Click(object sender, EventArgs e)
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
                using (var dlg = new fmCapturaCompensaciones())
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIsrFisicas.Compensaciones = dlg.MontoCapturado;
                        Program.modeloIsrFisicas.CompensacionesCapturado = true;
                        txtCompensacionesValor.Text = dlg.MontoCapturado.ToString("N0");
                        RecalcularPago();
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

        private void btnCapturarEstimulos_Click(object sender, EventArgs e)
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
                decimal limite = Program.modeloIsrFisicas.ImpuestoACargo;
                using (var dlg = new fmCapturaEstimulos(limite))
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIsrFisicas.Estimulos = dlg.MontoCapturado;
                        Program.modeloIsrFisicas.EstimulosCapturado = true;
                        txtEstimulosValor.Text = dlg.MontoCapturado.ToString("N0");
                        RecalcularPago();
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

        private void btnTabIngresos_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasIngresos.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasIngresos, this);
        }
        private void btnTabDeterminacion_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasDeterminacion.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasDeterminacion, this);
        }
        private void btnTabDatosAdicionales_Click(object sender, EventArgs e)
        {
            // Se conectará cuando exista fmIsrFisicasDatosAdicionales
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
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
            if (Program.declaracionActual == null) return;

            var m = Program.modeloIsrFisicas;
            if (m.TieneCompensaciones && !m.CompensacionesCapturado)
            {
                MessageBox.Show("Captura el monto de compensaciones antes de guardar.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (m.TieneEstimulos && !m.EstimulosCapturado)
            {
                MessageBox.Show("Captura el monto de estímulos antes de guardar.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conexion = new clsConexion();
            conexion.MarcarModuloCompletado(Program.declaracionActual.Id, "modulo_isr_fisicas_completado");
            Program.declaracionActual.ModuloIsrFisicasCompletado = true;
            Program.declaracionActual.MontoIsrFisicas = m.CantidadAPagar;

            Program.formAdmin.AplicarModulosDeclaracionActual();
            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}