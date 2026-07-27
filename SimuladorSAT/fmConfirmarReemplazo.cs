using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmConfirmarReemplazo : Form
    {
        public bool SeEligioReemplazar { get; private set; } = false;

        public fmConfirmarReemplazo()
        {
            InitializeComponent();
        }

        private void btnReemplazar_Click(object sender, EventArgs e)
        {
            SeEligioReemplazar = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            SeEligioReemplazar = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}