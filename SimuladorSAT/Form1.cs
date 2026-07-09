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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblIconoArrendamiento_Click(object sender, EventArgs e)
        {
        }

        private void lblIconoConfianza_Click(object sender, EventArgs e)
        {
            IrAPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
        }

        private void lblTextoConfianza_Click(object sender, EventArgs e)
        {
            IrAPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
        }

        private void IrAPresentarDeclaracion(TipoRegimen regimen)
        {
            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(regimen);
            }
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }
    }
}
