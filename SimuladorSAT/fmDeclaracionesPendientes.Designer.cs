namespace SimuladorSAT
{
    partial class fmDeclaracionesPendientes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLogosBlancos = new System.Windows.Forms.Panel();
            this.picLogoUthh = new System.Windows.Forms.PictureBox();
            this.picEscudoUthh = new System.Windows.Forms.PictureBox();
            this.pnlFranjaGrisDatos = new System.Windows.Forms.Panel();
            this.lblDatosIzquierda = new System.Windows.Forms.Label();
            this.lblDatosCentro = new System.Windows.Forms.Label();
            this.pnlNavbarAzul = new System.Windows.Forms.Panel();
            this.btnPresentarDeclaracion = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.pnlListaContenedor = new System.Windows.Forms.Panel();
            this.btnNuevaDeclaracion = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogoUthh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEscudoUthh)).BeginInit();
            this.SuspendLayout();

            this.pnlLogosBlancos.BackColor = System.Drawing.Color.White;
            this.pnlLogosBlancos.Controls.Add(this.picLogoUthh);
            this.pnlLogosBlancos.Controls.Add(this.picEscudoUthh);
            this.pnlLogosBlancos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogosBlancos.Location = new System.Drawing.Point(0, 0);
            this.pnlLogosBlancos.Size = new System.Drawing.Size(1445, 85);

            this.picLogoUthh.Image = global::SimuladorSAT.Properties.Resources.logouthh;
            this.picLogoUthh.Location = new System.Drawing.Point(20, 8);
            this.picLogoUthh.Size = new System.Drawing.Size(340, 76);
            this.picLogoUthh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoUthh.TabStop = false;

            this.picEscudoUthh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picEscudoUthh.Image = global::SimuladorSAT.Properties.Resources.escudo;
            this.picEscudoUthh.Location = new System.Drawing.Point(1335, 5);
            this.picEscudoUthh.Size = new System.Drawing.Size(82, 76);
            this.picEscudoUthh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscudoUthh.TabStop = false;

            this.pnlFranjaGrisDatos.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosIzquierda);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosCentro);
            this.pnlFranjaGrisDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFranjaGrisDatos.Location = new System.Drawing.Point(0, 85);
            this.pnlFranjaGrisDatos.Size = new System.Drawing.Size(1445, 80);

            this.lblDatosIzquierda.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDatosIzquierda.Location = new System.Drawing.Point(23, 11);
            this.lblDatosIzquierda.Size = new System.Drawing.Size(343, 59);
            this.lblDatosIzquierda.Text = "RFC: xxxxxxxxx | FULANO PEREZ\r\nPEREZ";

            this.lblDatosCentro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDatosCentro.Font = new System.Drawing.Font("Arial", 13F);
            this.lblDatosCentro.Location = new System.Drawing.Point(437, 11);
            this.lblDatosCentro.Size = new System.Drawing.Size(571, 59);
            this.lblDatosCentro.Text = "Declaración Provisional o Definitiva de Impuestos\r\nFederales";
            this.lblDatosCentro.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.pnlNavbarAzul.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlNavbarAzul.Controls.Add(this.btnPresentarDeclaracion);
            this.pnlNavbarAzul.Controls.Add(this.btnInicio);
            this.pnlNavbarAzul.Controls.Add(this.btnCerrar);
            this.pnlNavbarAzul.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbarAzul.Location = new System.Drawing.Point(0, 165);
            this.pnlNavbarAzul.Size = new System.Drawing.Size(1445, 48);

            this.btnPresentarDeclaracion.FlatAppearance.BorderSize = 0;
            this.btnPresentarDeclaracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentarDeclaracion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnPresentarDeclaracion.ForeColor = System.Drawing.Color.White;
            this.btnPresentarDeclaracion.Location = new System.Drawing.Point(35, 0);
            this.btnPresentarDeclaracion.Size = new System.Drawing.Size(229, 48);
            this.btnPresentarDeclaracion.Text = "Presentar declaración";
            this.btnPresentarDeclaracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(1200, 0);
            this.btnInicio.Size = new System.Drawing.Size(95, 48);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1300, 0);
            this.btnCerrar.Size = new System.Drawing.Size(95, 48);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.Load += new System.EventHandler(this.fmDeclaracionesPendientes_Load);
            this.pnlContenedorPrincipal.Resize += new System.EventHandler(this.pnlContenedorPrincipal_Resize);
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(0, 213);
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1445, 565);
            this.pnlContenedorPrincipal.Controls.Add(this.lblTituloModulo);
            this.pnlContenedorPrincipal.Controls.Add(this.pnlListaContenedor);
            this.pnlContenedorPrincipal.Controls.Add(this.btnNuevaDeclaracion);

            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Arial", 16F);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTituloModulo.Location = new System.Drawing.Point(46, 27);
            this.lblTituloModulo.Text = "Formulario no concluido";

            this.pnlListaContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListaContenedor.Location = new System.Drawing.Point(46, 90);
            this.pnlListaContenedor.Size = new System.Drawing.Size(760, 400);
            this.pnlListaContenedor.AutoScroll = true;

            this.btnNuevaDeclaracion.BackColor = System.Drawing.Color.FromArgb(13, 78, 92); // antes (41,128,185)
            this.btnNuevaDeclaracion.FlatAppearance.BorderSize = 0;
            this.btnNuevaDeclaracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaDeclaracion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnNuevaDeclaracion.ForeColor = System.Drawing.Color.White;
            this.btnNuevaDeclaracion.Location = new System.Drawing.Point(840, 90);
            this.btnNuevaDeclaracion.Size = new System.Drawing.Size(180, 70);
            this.btnNuevaDeclaracion.Text = "Iniciar una nueva declaración";
            this.btnNuevaDeclaracion.Click += new System.EventHandler(this.btnNuevaDeclaracion_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 778);
            this.Controls.Add(this.pnlContenedorPrincipal);
            this.Controls.Add(this.pnlNavbarAzul);
            this.Controls.Add(this.pnlFranjaGrisDatos);
            this.Controls.Add(this.pnlLogosBlancos);
            this.Name = "fmDeclaracionesPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador SAT - Formulario no concluido";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.picLogoUthh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEscudoUthh)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlLogosBlancos;
        private System.Windows.Forms.PictureBox picLogoUthh;
        private System.Windows.Forms.PictureBox picEscudoUthh;
        private System.Windows.Forms.Panel pnlFranjaGrisDatos;
        private System.Windows.Forms.Label lblDatosIzquierda;
        private System.Windows.Forms.Label lblDatosCentro;
        private System.Windows.Forms.Panel pnlNavbarAzul;
        private System.Windows.Forms.Button btnPresentarDeclaracion;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.Label lblTituloModulo;
        private System.Windows.Forms.Panel pnlListaContenedor;
        private System.Windows.Forms.Button btnNuevaDeclaracion;
    }
}