using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmResico : Form
    {
        // Almacena la ventana padre que se ocultó
        private Form _ventanaAnterior;
        private Form _overlayForm;

        // Constructor base por si el Designer lo requiere de respaldo
        public fmResico()
        {
            InitializeComponent();
        }

        // Constructor principal que recibe la interfaz de Administración de Declaración
        public fmResico(Form ventanaAnterior)
        {
            InitializeComponent();
            _ventanaAnterior = ventanaAnterior;

            // Vinculamos el evento de cierre nativo del Form
            this.FormClosing += FmResico_FormClosing;
        }

        // ====================================================================
        // GESTIÓN ELÁSTICA DEL OVERLAY OSCURO (Efecto Figma Lightbox)
        // ====================================================================
        private void ActivarCortinaOscura()
        {
            _overlayForm = new Form();
            _overlayForm.FormBorderStyle = FormBorderStyle.None;
            _overlayForm.BackColor = Color.Black;
            _overlayForm.Opacity = 0.50; // 50% de oscuridad
            _overlayForm.ShowInTaskbar = false;
            _overlayForm.StartPosition = FormStartPosition.Manual;
            _overlayForm.Bounds = this.Bounds; // Cubre RESICO por completo
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

        private void FmResico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ventanaAnterior != null && !e.Cancel)
            {
                _ventanaAnterior.Location = this.Location;
                _ventanaAnterior.WindowState = this.WindowState;
                _ventanaAnterior.Show();
            }
        }

        private void btnRegresarAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ====================================================================
        // BOTONES DE DETALLE (USANDO EL OVERLAY OSCURO)
        // ====================================================================
        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmDetalle detalle = new fmDetalle("Actividades gravadas a la tasa del 16%", "Junio");
                detalle.ShowDialog(_overlayForm); // Flota sobre el overlay sin ruidos
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmDetalle detalle = new fmDetalle("Actividades exentas", "Abril");
                detalle.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmDetalle detalle = new fmDetalle("Actividades no objeto del impuesto", "Junio");
                detalle.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmDetalle detalle = new fmDetalle("IVA no cobrado por devoluciones, descuentos y bonificaciones de ventas", "Junio");
                detalle.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmDetalle detalle = new fmDetalle("IVA retenido", "Junio");
                detalle.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmDetalle detalle = new fmDetalle("IVA por devoluciones, descuentos y bonificaciones en gastos", "Junio");
                detalle.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        // ====================================================================
        // BOTONES DE CAPTURA (USANDO EL OVERLAY OSCURO)
        // ====================================================================
        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmCapturar ventana = new fmCapturar("Tasa0");
                ventana.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarCortinaOscura();
                fmCapturar ventana = new fmCapturar("IvaAcreditable");
                ventana.ShowDialog(_overlayForm);
            }
            finally
            {
                DesactivarCortinaOscura();
            }
        }

        // ====================================================================
        // FLUJOS GENERALES DE NAVEGACIÓN
        // ====================================================================
        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
            fmPagoIVA ventanaPago = new fmPagoIVA();
            ventanaPago.FormClosed += (s, args) => this.Close();
            ventanaPago.WindowState = FormWindowState.Maximized;
            ventanaPago.Show();
            this.Hide();
        }

        private void pnlContenedorPrincipal_Paint(object sender, PaintEventArgs e) { }
        private void picEscudoUthh_Click(object sender, EventArgs e) { }
    }
}
