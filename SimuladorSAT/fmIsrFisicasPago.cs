using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrFisicasPago : Form
    {
        public fmIsrFisicasPago()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarValoresDesdeModelo();
        }
        private Form _overlayForm;

        public void ActualizarDesdeModelo()
        {
            CargarValoresDesdeModelo();
        }

        private void CargarValoresDesdeModelo()
        {
            var modelo = Program.modeloIsrFisicas;

            txtACargo.Text = modelo.ImpuestoACargo.ToString("N0");
            txtTotalContribuciones1.Text = modelo.ImpuestoACargo.ToString("N0");
            txtSubsidio.Text = modelo.SubsidioParaElEmpleo.ToString("N0");

            cmbCompensaciones.SelectedIndex = modelo.TieneCompensaciones ? 1 : 0;
            cmbEstimulos.SelectedIndex = modelo.TieneEstimulos ? 1 : 0;

            txtCompensacionesValor.Text = modelo.Compensaciones.ToString("N0");
            txtEstimulosValor.Text = modelo.Estimulos.ToString("N0");

            txtTotalAplicaciones1.Text = modelo.TotalAplicaciones.ToString("N0");
            txtTotalContribuciones2.Text = modelo.ImpuestoACargo.ToString("N0");
            txtTotalAplicaciones2.Text = modelo.TotalAplicaciones.ToString("N0");
            txtCantidadACargo.Text = modelo.CantidadACargo.ToString("N0");
            txtCantidadAPagar.Text = modelo.CantidadAPagar.ToString("N0");

            AplicarEstadoFila(4, modelo.TieneCompensaciones,
                lblCompensacionesValor, lblSignoCompensaciones, txtCompensacionesValor, btnCapturarCompensaciones);
            AplicarEstadoFila(6, modelo.TieneEstimulos,
                lblEstimulosValor, lblSignoEstimulos, txtEstimulosValor, btnCapturarEstimulos);

            btnTabDatosAdicionales.Visible = modelo.EsCopropiedad;
        }

        // ====================================================================
        // Combo Compensaciones → expande/colapsa fila 4
        // ====================================================================
        private void cmbCompensaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbCompensaciones.SelectedIndex == 1;
            Program.modeloIsrFisicas.TieneCompensaciones = esSi;
            AplicarEstadoFila(4, esSi,
                lblCompensacionesValor, lblSignoCompensaciones, txtCompensacionesValor, btnCapturarCompensaciones);
        }

        // ====================================================================
        // Combo Estímulos → expande/colapsa fila 6
        // ====================================================================
        private void cmbEstimulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esSi = cmbEstimulos.SelectedIndex == 1;
            Program.modeloIsrFisicas.TieneEstimulos = esSi;
            AplicarEstadoFila(6, esSi,
                lblEstimulosValor, lblSignoEstimulos, txtEstimulosValor, btnCapturarEstimulos);
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

        // ====================================================================
        // Botones de Capturar (pendientes de conectar a un diálogo real)
        // ====================================================================
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
                        txtCompensacionesValor.Text = dlg.MontoCapturado.ToString("N0");
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

                decimal limite = Program.modeloIsrFisicas.ImpuestoACargo; // ajustar según lo que aplique como límite real
                using (var dlg = new fmCapturaEstimulos(limite))
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        txtEstimulosValor.Text = dlg.MontoCapturado.ToString("N0");
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
        private void btnTabIngresos_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasIngresos.ActualizarDesdeModelo();
            Program.formIsrFisicasIngresos.WindowState = this.WindowState;
            Program.formIsrFisicasIngresos.Show();
            this.Hide();
        }

        private void btnTabDeterminacion_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasDeterminacion.ActualizarDesdeModelo();
            Program.formIsrFisicasDeterminacion.WindowState = this.WindowState;
            Program.formIsrFisicasDeterminacion.Show();
            this.Hide();
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
            Program.formAdmin.WindowState = this.WindowState;
            Program.formAdmin.Show();
            this.Hide();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.formAdmin.WindowState = this.WindowState;
            Program.formAdmin.Show();
            this.Hide();
        }
    }
}
