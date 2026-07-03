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

            // Vinculamos el evento de cierre nativo del Form (por si usan la "X" superior de la ventana)
            this.FormClosing += FmResico_FormClosing;
        }

        private void FmResico_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si el usuario cierra esta ventana voluntariamente y existe una anterior oculta, la encendemos de nuevo
            if (_ventanaAnterior != null && !e.Cancel)
            {
                _ventanaAnterior.Location = this.Location;
                _ventanaAnterior.WindowState = this.WindowState;
                _ventanaAnterior.Show();
            }
        }

        // --- AGREGA ESTE MÉTODO EN EL EVENTO CLICK DE TU BOTÓN DE 'INICIO' O 'REGRESAR' EN FMRESICO ---
        private void btnRegresarAdmin_Click(object sender, EventArgs e)
        {
            // Al cerrar la ventana actual, el evento FormClosing configurado arriba se encargará de mostrar la anterior
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            fmDetalle detalle = new fmDetalle("Actividades gravadas a la tasa del 16%", "Junio");
            detalle.ShowDialog();
        }

        private void pnlContenedorPrincipal_Paint(object sender, PaintEventArgs e)
        {
        }

        private void picEscudoUthh_Click(object sender, EventArgs e)
        {
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            fmDetalle detalle = new fmDetalle("Actividades exentas", "Abril");
            detalle.ShowDialog();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            fmDetalle detalle = new fmDetalle("Actividades no objeto del impuesto", "Junio");
            detalle.ShowDialog();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            fmDetalle detalle = new fmDetalle("IVA no cobrado por devoluciones, descuentos y bonificaciones de ventas", "Junio");
            detalle.ShowDialog();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            fmDetalle detalle = new fmDetalle("IVA retenido", "Junio");
            detalle.ShowDialog();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            fmDetalle detalle = new fmDetalle("IVA por devoluciones, descuentos y bonificaciones en gastos", "Junio");
            detalle.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            fmCapturar ventana = new fmCapturar("Tasa0");
            ventana.ShowDialog();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            fmCapturar ventana = new fmCapturar("IvaAcreditable");
            ventana.ShowDialog();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
