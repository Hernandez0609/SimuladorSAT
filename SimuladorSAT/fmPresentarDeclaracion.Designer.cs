namespace SimuladorSAT
{
    partial class fmPresentarDeclaracion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLogos = new System.Windows.Forms.Panel();
            this.picEscudo = new System.Windows.Forms.PictureBox();
            this.picLogoDer = new System.Windows.Forms.PictureBox();
            this.pnlDatosUsuario = new System.Windows.Forms.Panel();
            this.lblDatosIzq = new System.Windows.Forms.Label();
            this.lblTituloDecl = new System.Windows.Forms.Label();
            this.pnlNavBar = new System.Windows.Forms.Panel();
            this.btnPresentar = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.picLogoApp = new System.Windows.Forms.PictureBox();
            this.pnlLogos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEscudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoDer)).BeginInit();
            this.pnlDatosUsuario.SuspendLayout();
            this.pnlNavBar.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoApp)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogos
            // 
            this.pnlLogos.BackColor = System.Drawing.Color.White;
            this.pnlLogos.Controls.Add(this.picEscudo);
            this.pnlLogos.Controls.Add(this.picLogoDer);
            this.pnlLogos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogos.Location = new System.Drawing.Point(0, 0);
            this.pnlLogos.Name = "pnlLogos";
            this.pnlLogos.Size = new System.Drawing.Size(1445, 85);
            this.pnlLogos.TabIndex = 3;
            // 
            // picEscudo
            // 
            this.picEscudo.Image = global::SimuladorSAT.Properties.Resources.logouthh;
            this.picEscudo.Location = new System.Drawing.Point(20, 8);
            this.picEscudo.Name = "picEscudo";
            this.picEscudo.Size = new System.Drawing.Size(340, 76);
            this.picEscudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscudo.TabIndex = 0;
            this.picEscudo.TabStop = false;
            // 
            // picLogoDer
            // 
            this.picLogoDer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogoDer.Image = global::SimuladorSAT.Properties.Resources.escudo;
            this.picLogoDer.Location = new System.Drawing.Point(1335, 5);
            this.picLogoDer.Name = "picLogoDer";
            this.picLogoDer.Size = new System.Drawing.Size(82, 76);
            this.picLogoDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoDer.TabIndex = 1;
            this.picLogoDer.TabStop = false;
            // 
            // pnlDatosUsuario
            // 
            this.pnlDatosUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlDatosUsuario.Controls.Add(this.lblDatosIzq);
            this.pnlDatosUsuario.Controls.Add(this.lblTituloDecl);
            this.pnlDatosUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatosUsuario.Location = new System.Drawing.Point(0, 85);
            this.pnlDatosUsuario.Name = "pnlDatosUsuario";
            this.pnlDatosUsuario.Size = new System.Drawing.Size(1445, 80);
            this.pnlDatosUsuario.TabIndex = 2;
            // 
            // lblDatosIzq
            // 
            this.lblDatosIzq.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDatosIzq.Location = new System.Drawing.Point(23, 11);
            this.lblDatosIzq.Name = "lblDatosIzq";
            this.lblDatosIzq.Size = new System.Drawing.Size(343, 59);
            this.lblDatosIzq.TabIndex = 0;
            this.lblDatosIzq.Text = "RFC: xxxxxxxxx | FULANO PEREZ \r\nPEREZ";
            // 
            // lblTituloDecl
            // 
            this.lblTituloDecl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloDecl.Font = new System.Drawing.Font("Arial", 13F);
            this.lblTituloDecl.Location = new System.Drawing.Point(437, 11);
            this.lblTituloDecl.Name = "lblTituloDecl";
            this.lblTituloDecl.Size = new System.Drawing.Size(571, 59);
            this.lblTituloDecl.TabIndex = 1;
            this.lblTituloDecl.Text = "Declaración Provisional o Definitiva de Impuestos\r\nFederales";
            this.lblTituloDecl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlNavBar
            // 
            this.pnlNavBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(78)))), ((int)(((byte)(92)))));
            this.pnlNavBar.Controls.Add(this.btnPresentar);
            this.pnlNavBar.Controls.Add(this.btnInicio);
            this.pnlNavBar.Controls.Add(this.btnCerrar);
            this.pnlNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavBar.Location = new System.Drawing.Point(0, 165);
            this.pnlNavBar.Name = "pnlNavBar";
            this.pnlNavBar.Size = new System.Drawing.Size(1445, 48);
            this.pnlNavBar.TabIndex = 1;
            // 
            // btnPresentar
            // 
            this.btnPresentar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPresentar.FlatAppearance.BorderSize = 0;
            this.btnPresentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnPresentar.ForeColor = System.Drawing.Color.White;
            this.btnPresentar.Location = new System.Drawing.Point(35, 0);
            this.btnPresentar.Name = "btnPresentar";
            this.btnPresentar.Size = new System.Drawing.Size(229, 48);
            this.btnPresentar.TabIndex = 0;
            this.btnPresentar.Text = "Presentar declaración";
            this.btnPresentar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInicio
            // 
            this.btnInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(1200, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(95, 48);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1310, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(95, 48);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.picLogoApp);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 213);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1445, 565);
            this.pnlCuerpo.TabIndex = 0;
            // 
            // picLogoApp
            // 
            this.picLogoApp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogoApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.picLogoApp.Image = global::SimuladorSAT.Properties.Resources.logo_empresa;
            this.picLogoApp.Location = new System.Drawing.Point(568, 128);
            this.picLogoApp.Name = "picLogoApp";
            this.picLogoApp.Size = new System.Drawing.Size(310, 310);
            this.picLogoApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoApp.TabIndex = 0;
            this.picLogoApp.TabStop = false;
            // 
            // fmPresentarDeclaracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 778);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlNavBar);
            this.Controls.Add(this.pnlDatosUsuario);
            this.Controls.Add(this.pnlLogos);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.MinimumSize = new System.Drawing.Size(1168, 637);
            this.Name = "fmPresentarDeclaracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador SAT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlLogos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEscudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoDer)).EndInit();
            this.pnlDatosUsuario.ResumeLayout(false);
            this.pnlNavBar.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogos;
        private System.Windows.Forms.PictureBox picEscudo;
        private System.Windows.Forms.PictureBox picLogoDer;
        private System.Windows.Forms.Panel pnlDatosUsuario;
        private System.Windows.Forms.Label lblDatosIzq;
        private System.Windows.Forms.Label lblTituloDecl;
        private System.Windows.Forms.Panel pnlNavBar;
        private System.Windows.Forms.Button btnPresentar;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.PictureBox picLogoApp;
    }
}