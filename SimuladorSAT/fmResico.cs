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
        public fmResico()
        {
            InitializeComponent();
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
            // Llamamos exactamente al mismo formulario, pero con parámetros diferentes
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
    }
}
