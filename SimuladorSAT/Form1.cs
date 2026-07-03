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
            var form = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
        }

        private void lblTextoConfianza_Click(object sender, EventArgs e)
        {
            var form = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
        }
    }
}
