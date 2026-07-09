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
        private Form _ventanaAnterior;
        private Form _overlayForm;

        public fmResico()
        {
            InitializeComponent();
        }

        public fmResico(Form ventanaAnterior)
        {
            InitializeComponent();
            _ventanaAnterior = ventanaAnterior;
        }

        // ====================================================================
        // GESTIÓN ELÁSTICA DEL OVERLAY OSCURO (Efecto Figma Lightbox)
        // ====================================================================
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

        // Regresa a Administración, marcando el módulo como completado
        private void RegresarAAdmin()
        {
            if (_ventanaAnterior is fmAdminDeclaracion admin)
            {
                admin.MarcarIvaSimplificadoCompletado(195); // Valor simulado
            }
            if (_ventanaAnterior != null)
            {
                _ventanaAnterior.WindowState = this.WindowState;
                _ventanaAnterior.Show();
            }
            this.Hide();
        }

        private void btnRegresarAdmin_Click(object sender, EventArgs e)
        {
            RegresarAAdmin();
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
                detalle.ShowDialog(_overlayForm);
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
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            RegresarAAdmin();
        }

        private void btnTabPago_Click(object sender, EventArgs e)
        {
            if (Program.formPagoIva == null || Program.formPagoIva.IsDisposed)
            {
                Program.formPagoIva = new fmPagoIVA();
            }
            Program.formPagoIva.WindowState = FormWindowState.Maximized;
            Program.formPagoIva.Show();
            this.Hide();
        }

        private void pnlContenedorPrincipal_Paint(object sender, PaintEventArgs e) { }
        private void picEscudoUthh_Click(object sender, EventArgs e) { }
    }
}