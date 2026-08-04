using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmPagoIVA : Form, IInfoDeclaracion
    {
        private Form _overlayForm;

        public fmPagoIVA()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);

            cmbCompensaciones.SelectedIndexChanged += (s, e) => { Program.modeloIva.TieneCompensaciones = cmbCompensaciones.SelectedIndex == 1; RecalcularPago(); };
            cmbEstimulos.SelectedIndexChanged += (s, e) => { Program.modeloIva.TieneEstimulos = cmbEstimulos.SelectedIndex == 1; RecalcularPago(); };
            btnTabDeterminacion.Click += btnTabDeterminacion_Click;
            btnCapturarComp.Click += InterfazCapturaCompensacion;
            btnCapturarEst.Click += InterfazCapturaEstimulo;

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
            var m = Program.modeloIva;

            if (m.EsImpuestoAFavor)
            {
                MostrarModoFavor(m.ImpuestoFinal);
            }
            else
            {
                MostrarModoCargo();
                cmbCompensaciones.SelectedIndex = m.TieneCompensaciones ? 1 : 0;
                cmbEstimulos.SelectedIndex = m.TieneEstimulos ? 1 : 0;
                RecalcularPago();
            }

            ActualizarEstadoPestañas(); // ← esta línea faltaba
        }

        private void MostrarModoFavor(decimal monto)
        {
            tlpCamposPago.Visible = false;
            lblAFavor.Visible = true;
            txtAFavor.Visible = true;
            txtAFavor.Text = monto.ToString("N0");
        }

        private void MostrarModoCargo()
        {
            tlpCamposPago.Visible = true;
            lblAFavor.Visible = false;
            txtAFavor.Visible = false;
        }

        private void RecalcularPago()
        {
            var m = Program.modeloIva;
            if (m.EsImpuestoAFavor) return;

            decimal impuestoACargo = m.ImpuestoFinal;
            decimal compensaciones = m.TieneCompensaciones ? m.Compensaciones : 0;
            decimal estimulos = m.TieneEstimulos ? m.Estimulos : 0;

            m.TotalAplicaciones = compensaciones + estimulos;
            decimal cantidad = impuestoACargo - m.TotalAplicaciones;
            if (cantidad < 0) cantidad = 0;

            m.CantidadACargoPago = cantidad;
            m.CantidadAPagar = cantidad;

            txtACargo.Text = impuestoACargo.ToString("N0");
            txtTotalContrib1.Text = impuestoACargo.ToString("N0");
            txtCompensaciones.Text = compensaciones.ToString("N0");
            txtEstimulos.Text = estimulos.ToString("N0");
            txtTotalApl1.Text = m.TotalAplicaciones.ToString("N0");
            txtTotalContrib2.Text = impuestoACargo.ToString("N0");
            txtTotalApl2.Text = m.TotalAplicaciones.ToString("N0");
            txtCantACargo.Text = m.CantidadACargoPago.ToString("N0");
            txtCantAPagar.Text = m.CantidadAPagar.ToString("N0");

            AplicarVisibilidadFilas(m.TieneCompensaciones, m.TieneEstimulos);
        }

        private void AplicarVisibilidadFilas(bool comp, bool est)
        {
            tlpCamposPago.RowStyles[3] = comp ? new RowStyle(SizeType.Absolute, 35F) : new RowStyle(SizeType.Absolute, 0F);
            lblCompensaciones.Visible = comp; lblSignoComp.Visible = comp; txtCompensaciones.Visible = comp; btnCapturarComp.Visible = comp;

            tlpCamposPago.RowStyles[5] = est ? new RowStyle(SizeType.Absolute, 35F) : new RowStyle(SizeType.Absolute, 0F);
            lblEstimulos.Visible = est; lblSignoEst.Visible = est; txtEstimulos.Visible = est; btnCapturarEst.Visible = est;
        }

        public void ActualizarEstadoPestañas()
        {
            EstadoPestanasHelper.Aplicar(btnTabDeterminacion, "Determinación", true, true, esPaginaActual: false);
        }

        private void InterfazCapturaCompensacion(object sender, EventArgs e)
        {
            try
            {
                decimal limite = Program.modeloIva.ImpuestoFinal - Program.modeloIva.Estimulos;
                if (limite < 0) limite = 0;

                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50;
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds;
                _overlayForm.Owner = this;
                _overlayForm.Show();

                using (var fDetalle = new fmCapturaDetalleGenerico(TipoCapturaEnum.Compensacion, limite))
                {
                    if (fDetalle.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIva.Compensaciones = fDetalle.MontoCapturado;
                    }
                }
            }
            finally
            {
                if (_overlayForm != null) { _overlayForm.Close(); _overlayForm.Dispose(); _overlayForm = null; }
            }
            RecalcularPago();
        }

        private void InterfazCapturaEstimulo(object sender, EventArgs e)
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

                using (var fLista = new fmCapturaListaGenerica())
                {
                    fLista.ConfigurarInterfaz("Estímulos", "Estímulos al impuesto a cargo", Program.modeloIva.ImpuestoFinal.ToString());
                    if (fLista.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        Program.modeloIva.Estimulos = fLista.MontoCapturado;
                    }
                }
            }
            finally
            {
                if (_overlayForm != null) { _overlayForm.Close(); _overlayForm.Dispose(); _overlayForm = null; }
            }
            RecalcularPago();
        }

        private void btnTabDeterminacion_Click(object sender, EventArgs e)
        {
            if (Program.formResico != null && !Program.formResico.IsDisposed)
            {
                Program.formResico.ActualizarDesdeModelo();
                NavegacionHelper.MostrarSinParpadeo(Program.formResico, this);
            }
        }

        private void tlpCamposPago_Paint(object sender, PaintEventArgs e) { }
        private void btnNavInicio_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }
        private void btnNavCerrar_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }
        private void btnGuardar_Click(object sender, EventArgs e) { GuardarYMarcarCompletado(); }
        private void btnAdminDeclaracion_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void GuardarYMarcarCompletado()
        {
            if (Program.declaracionActual == null) return;
            var conexion = new clsConexion();

            Program.declaracionActual.ModuloIvaSimplificadoCompletado = true;
            decimal monto = Program.modeloIva.EsImpuestoAFavor ? 0 : Program.modeloIva.CantidadAPagar;
            Program.declaracionActual.MontoIva = monto;

            conexion.GuardarTodosLosModulos(Program.declaracionActual);
            conexion.MarcarModuloCompletado(Program.declaracionActual.Id, "modulo_iva_completado");
            conexion.GuardarMontosDeclaracion(Program.declaracionActual.Id,
                Program.declaracionActual.MontoIsrFisicas, Program.declaracionActual.MontoIsrSalarios, Program.declaracionActual.MontoIva);

            Program.formAdmin.AplicarModulosDeclaracionActual();
            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}