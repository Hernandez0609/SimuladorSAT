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
    }
}
