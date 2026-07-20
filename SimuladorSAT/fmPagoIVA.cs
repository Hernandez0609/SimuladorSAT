using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmPagoIVA : Form
    {
        private double impuestoACargoInicial = 195.0;
        private double montoCompensaciones = 0.0;
        private double montoEstimulos = 0.0;
        private bool esCargaInicial = true;
        private Form _overlayForm;

        public fmPagoIVA()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);

            // Enlazar eventos de selección
            cmbCompensaciones.SelectedIndexChanged += (s, e) => EjecutarLogicaSATElastica();
            cmbEstimulos.SelectedIndexChanged += (s, e) => EjecutarLogicaSATElastica();

            btnTabDeterminacion.Click += btnTabDeterminacion_Click;

            btnCapturarComp.Click += InterfazCapturaCompensacion;
            btnCapturarEst.Click += InterfazCapturaEstimulo;

            // Valores por defecto en "No" como solicita la interfaz de Figma
            cmbCompensaciones.SelectedIndex = 0;
            cmbEstimulos.SelectedIndex = 0;
        }

        private void fmPagoIVA_Load(object sender, EventArgs e)
        {
            esCargaInicial = false;
            EjecutarLogicaSATElastica();
        }

        private void EjecutarLogicaSATElastica()
        {
            bool esSiCompensaciones = (cmbCompensaciones.SelectedItem?.ToString() == "Si");
            bool esSiEstimulos = (cmbEstimulos.SelectedItem?.ToString() == "Si");

            if (!esSiCompensaciones) montoCompensaciones = 0.0;
            if (!esSiEstimulos) montoEstimulos = 0.0;

            // --- Lógica de Despliegue Elástico Dinámico Sincronizado ---
            // Fila 3 (Compensaciones): Si es "Si" mide 35, si es "No" se reduce a 0
            tlpCamposPago.RowStyles[3] = esSiCompensaciones ? new RowStyle(SizeType.Absolute, 35F) : new RowStyle(SizeType.Absolute, 0F);
            lblCompensaciones.Visible = esSiCompensaciones;
            lblSignoComp.Visible = esSiCompensaciones;
            txtCompensaciones.Visible = esSiCompensaciones;
            btnCapturarComp.Visible = esSiCompensaciones;

            // SOLUCIÓN AL BUG DEL DESIGNER: Forzamos el alto real cuando es visible
            if (esSiCompensaciones)
            {
                btnCapturarComp.Height = 25;
                txtCompensaciones.Height = 25;
            }

            // Fila 5 (Estímulos): Si es "Si" mide 35, si es "No" se reduce a 0
            tlpCamposPago.RowStyles[5] = esSiEstimulos ? new RowStyle(SizeType.Absolute, 35F) : new RowStyle(SizeType.Absolute, 0F);
            lblEstimulos.Visible = esSiEstimulos;
            lblSignoEst.Visible = esSiEstimulos;
            txtEstimulos.Visible = esSiEstimulos;
            btnCapturarEst.Visible = esSiEstimulos;

            // SOLUCIÓN AL BUG DEL DESIGNER: Forzamos el alto real cuando es visible
            if (esSiEstimulos)
            {
                btnCapturarEst.Height = 25;
                txtEstimulos.Height = 25;
            }

            // Operaciones matemáticas de determinación de saldos
            double totalAplicaciones = montoCompensaciones + montoEstimulos;
            double cantidadCargo = impuestoACargoInicial - totalAplicaciones;
            if (cantidadCargo < 0) cantidadCargo = 0;

            if (esCargaInicial)
            {
                txtACargo.Text = "";
                txtTotalContrib1.Text = "";
                txtTotalContrib2.Text = "";
                txtCompensaciones.Text = "";
                txtEstimulos.Text = "";
                txtTotalApl1.Text = "";
                txtTotalApl2.Text = "";
                txtCantACargo.Text = "";
                txtCantAPagar.Text = "";
            }
            else
            {
                txtACargo.Text = impuestoACargoInicial.ToString("N0");
                txtTotalContrib1.Text = impuestoACargoInicial.ToString("N0");
                txtTotalContrib2.Text = impuestoACargoInicial.ToString("N0");
                txtCompensaciones.Text = montoCompensaciones.ToString("N0");
                txtEstimulos.Text = montoEstimulos.ToString("N0");
                txtTotalApl1.Text = totalAplicaciones.ToString("N0");
                txtTotalApl2.Text = totalAplicaciones.ToString("N0");
                txtCantACargo.Text = cantidadCargo.ToString("N0");
                txtCantAPagar.Text = cantidadCargo.ToString("N0");
            }
        }
        private void InterfazCapturaCompensacion(object sender, EventArgs e)
        {
            try
            {
                // 1. Calculamos el límite real actual disponible para compensar
                decimal limiteDisponible = (decimal)(impuestoACargoInicial - montoEstimulos);
                if (limiteDisponible < 0) limiteDisponible = 0;

                // 2. Creamos y mostramos el Overlay oscuro encima de fmPagoIVA
                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50; // 50% de opacidad oscura (efecto Figma)
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds; // Cubre exactamente toda la pantalla padre
                _overlayForm.Owner = this;
                _overlayForm.Show();

                // 3. Abrimos el detalle flotante de compensaciones usando el constructor correcto
                using (fmCapturaDetalleGenerico fDetalle = new fmCapturaDetalleGenerico(TipoCapturaEnum.Compensacion, limiteDisponible))
                {
                    // IMPORTANTE: Pasamos '_overlayForm' como dueño. Esto bloquea el fondo sin emitir sonidos ni parpadeos
                    if (fDetalle.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        // Extraemos el monto directamente de la propiedad pública que ya programaste
                        montoCompensaciones = (double)fDetalle.MontoCapturado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Compensaciones: " + ex.Message, "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 4. Pase lo que pase (incluso con errores o cancelaciones), disolvemos el overlay y recuperamos el brillo
                if (_overlayForm != null)
                {
                    _overlayForm.Close();
                    _overlayForm.Dispose();
                    _overlayForm = null;
                }
            }

            // 5. Recalcula la tabla elástica con el nuevo valor capturado
            EjecutarLogicaSATElastica();
        }

        private void InterfazCapturaEstimulo(object sender, EventArgs e)
        {
            try
            {
                // 1. Creamos y mostramos el Overlay oscuro encima de fmPagoIVA
                _overlayForm = new Form();
                _overlayForm.FormBorderStyle = FormBorderStyle.None;
                _overlayForm.BackColor = Color.Black;
                _overlayForm.Opacity = 0.50; // 50% de opacidad oscura (efecto Figma)
                _overlayForm.ShowInTaskbar = false;
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Bounds = this.Bounds; // Cubre exactamente al padre
                _overlayForm.Owner = this;
                _overlayForm.Show();

                // Usamos 'using' para asegurar que el formulario se destruya correctamente al cerrar
                using (fmCapturaListaGenerica fLista = new fmCapturaListaGenerica())
                {
                    // 2. Configura los títulos, el modo y el límite antes de mostrarlo
                    fLista.ConfigurarInterfaz("Estímulos", "Estímulos al impuesto a cargo", impuestoACargoInicial.ToString());

                    // 3. Abre la interfaz flotante usando el OVERLAY como dueño para bloquear el fondo limpiamente
                    if (fLista.ShowDialog(_overlayForm) == DialogResult.OK)
                    {
                        // 4. Al cerrar con OK, extrae el monto ya calculado por el propio formulario
                        montoEstimulos = (double)fLista.MontoCapturado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Estímulos: " + ex.Message, "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 5. Pase lo que pase al cerrar, destruimos la cortina negra y regresamos el brillo original
                if (_overlayForm != null)
                {
                    _overlayForm.Close();
                    _overlayForm.Dispose();
                    _overlayForm = null;
                }
            }

            // Recalcula la tabla elástica tras cerrar la captura
            EjecutarLogicaSATElastica();
        }

        private void btnTabDeterminacion_Click(object sender, EventArgs e)
        {
            if (Program.formResico != null && !Program.formResico.IsDisposed)
            {
                Program.formResico.WindowState = this.WindowState;
                Program.formResico.Show();
            }
            this.Hide();
        }

        private void tlpCamposPago_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNavInicio_Click(object sender, EventArgs e)
        {
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }

        private void btnNavCerrar_Click(object sender, EventArgs e)
        {
            if (Program.formResico != null && !Program.formResico.IsDisposed)
            {
                Program.formResico.WindowState = this.WindowState;
                Program.formResico.Show();
            }
            this.Hide();
        }
    }
}