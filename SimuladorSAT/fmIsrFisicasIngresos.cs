using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmIsrFisicasIngresos : Form
    {
        public fmIsrFisicasIngresos()
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

        // ====================================================================
        // Carga el estado guardado en el modelo compartido (por si regresas a esta pantalla)
        // ====================================================================
        private void CargarValoresDesdeModelo()
        {
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
                        txtDescuentos.Text = dlg.MontoCapturado.ToString("N0");
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

                using (var dlg = new fmDetalleIngresosADisminuir())
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        txtIngresosDisminuirValor.Text = dlg.MontoCapturado.ToString("N0");
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
                        txtIngresosAdicionalesValor.Text = dlg.MontoCapturado.ToString("N0");
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

                using (var dlg = new fmDetalleTotalIngresosPercibidos())
                {
                    if (dlg.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        txtTotalPercibidos.Text = dlg.MontoCapturado.ToString("N0");
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
            if (Program.formIsrFisicasDeterminacion == null || Program.formIsrFisicasDeterminacion.IsDisposed)
            {
                Program.formIsrFisicasDeterminacion = new fmIsrFisicasDeterminacion();
            }
            Program.formIsrFisicasDeterminacion.ActualizarDesdeModelo(); // ← NUEVO
            Program.formIsrFisicasDeterminacion.WindowState = this.WindowState;
            Program.formIsrFisicasDeterminacion.Show();
            this.Hide();
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
            Program.formIsrFisicasPago.ActualizarDesdeModelo();
            Program.formIsrFisicasPago.WindowState = this.WindowState;
            Program.formIsrFisicasPago.Show();
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
            // Cerrar regresa un paso atrás: Admin (no Presentar)
            Program.formAdmin.WindowState = this.WindowState;
            Program.formAdmin.Show();
            this.Hide();
        }
    }
}