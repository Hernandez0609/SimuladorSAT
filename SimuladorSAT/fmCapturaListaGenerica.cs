using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturaListaGenerica : Form
    {
        public string ModoCaptura { get; set; } = "Estímulos";

        public fmCapturaListaGenerica()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            AjustarPosicionesUI(false);
            this.Owner = null;
        }

        public void ConfigurarInterfaz(string modo, string titulo, string montoLimite = "")
        {
            this.ModoCaptura = modo;
            if (this.lblTitulo != null) this.lblTitulo.Text = titulo;
            if (this.txtLimite != null) this.txtLimite.Text = string.IsNullOrEmpty(montoLimite) ? "0" : montoLimite;
        }

        /// <summary>
        /// Mueve la tabla y los letreros hacia abajo cuando el panel de captura se expande
        /// </summary>
        private void AjustarPosicionesUI(bool panelVisible)
        {
            this.SuspendLayout(); // Evita repintar mientras se reposicionan varios controles

            pnlCapturaDesplegable.Visible = panelVisible;
            btnAgregar.Visible = !panelVisible;

            if (panelVisible)
            {
                dgvRegistros.Location = new Point(25, 205);
                dgvRegistros.Size = new Size(900, 110);
            }
            else
            {
                dgvRegistros.Location = new Point(25, 95);
                dgvRegistros.Size = new Size(900, 220);
            }

            lblTotalRegistros.Location = new Point(25, 325);
            lblPagina.Location = new Point(400, 325);
            lblMensajeAlerta.Location = new Point(25, 360);
            lblIconoAlerta.Location = new Point(535, 360);

            this.ResumeLayout(true); // Repinta todo de una sola vez
        }

        // ====================================================================
        // GESTIÓN DE EVENTOS INTERACTIVOS (FIGMA)
        // ====================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AjustarPosicionesUI(true);
        }

        private void btnCancelarCaptura_Click(object sender, EventArgs e)
        {
            cmbTipoEstimulo.SelectedIndex = 0;
            txtMontoPorAplicar.Clear();
            AjustarPosicionesUI(false);
        }

        private void btnGuardarCaptura_Click(object sender, EventArgs e)
        {
            if (cmbTipoEstimulo.SelectedIndex <= 0)
            {
                MessageBox.Show("Por favor, selecciona un tipo de estímulo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AjustarPosicionesUI(false);
        }

        private void lblBotonCerrarX_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}