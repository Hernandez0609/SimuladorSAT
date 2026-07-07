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
            AjustarPosicionesUI(false); // Arranca en el estado del Mockup 1

            // Hace la ventana flotante sobre el padre
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
            pnlCapturaDesplegable.Visible = panelVisible;
            btnAgregar.Visible = !panelVisible; // Desaparece al capturar (Mockup 2)

            if (panelVisible)
            {
                // Baja la tabla para hacer espacio al panel desplegado
                dgvRegistros.Location = new Point(25, 205);
                dgvRegistros.Size = new Size(900, 110);
            }
            else
            {
                // Regresa la tabla a su posición inicial compacta
                dgvRegistros.Location = new Point(25, 95);
                dgvRegistros.Size = new Size(900, 220);
            }

            // Reposiciona los componentes inferiores de estatus de forma fija
            lblTotalRegistros.Location = new Point(25, 325);
            lblPagina.Location = new Point(400, 325);
            lblMensajeAlerta.Location = new Point(25, 360);
            lblIconoAlerta.Location = new Point(535, 360);
        }

        // ====================================================================
        // GESTIÓN DE EVENTOS INTERACTIVOS (FIGMA)
        // ====================================================================

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AjustarPosicionesUI(true); // Abre el panel desplegable
        }

        private void btnCancelarCaptura_Click(object sender, EventArgs e)
        {
            cmbTipoEstimulo.SelectedIndex = 0;
            txtMontoPorAplicar.Clear();
            AjustarPosicionesUI(false); // Cierra el panel y regresa al Mockup 1
        }

        private void btnGuardarCaptura_Click(object sender, EventArgs e)
        {
            if (cmbTipoEstimulo.SelectedIndex <= 0)
            {
                MessageBox.Show("Por favor, selecciona un tipo de estímulo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se meterá la lógica para agregar renglones al DataGridView más adelante
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