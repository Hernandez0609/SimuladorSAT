namespace SimuladorSAT
{
    partial class fmInicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.btnNavInicio = new System.Windows.Forms.Label();
            this.btnNavPersonas = new System.Windows.Forms.Label();
            this.btnNavEmpresa = new System.Windows.Forms.Label();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.picLogoCentral = new System.Windows.Forms.PictureBox();

            this.pnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoCentral)).BeginInit();
            this.SuspendLayout();

            // ====================================================================
            // pnlNavbar
            // ====================================================================
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlNavbar.Controls.Add(this.btnNavInicio);
            this.pnlNavbar.Controls.Add(this.btnNavPersonas);
            this.pnlNavbar.Controls.Add(this.btnNavEmpresa);
            this.pnlNavbar.Controls.Add(this.picUserIcon);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1920, 130);
            this.pnlNavbar.TabIndex = 0;

            this.btnNavInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInicio.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavInicio.ForeColor = System.Drawing.Color.White;
            this.btnNavInicio.Location = new System.Drawing.Point(100, 0);
            this.btnNavInicio.Name = "btnNavInicio";
            this.btnNavInicio.Size = new System.Drawing.Size(150, 130);
            this.btnNavInicio.TabIndex = 0;
            this.btnNavInicio.Text = "Inicio";
            this.btnNavInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNavInicio.Click += new System.EventHandler(this.btnNavInicio_Click);

            this.btnNavPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavPersonas.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPersonas.ForeColor = System.Drawing.Color.White;
            this.btnNavPersonas.Location = new System.Drawing.Point(330, 0);
            this.btnNavPersonas.Name = "btnNavPersonas";
            this.btnNavPersonas.Size = new System.Drawing.Size(200, 130);
            this.btnNavPersonas.TabIndex = 1;
            this.btnNavPersonas.Text = "Personas";
            this.btnNavPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNavPersonas.Click += new System.EventHandler(this.btnNavPersonas_Click);

            this.btnNavEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEmpresa.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavEmpresa.ForeColor = System.Drawing.Color.White;
            this.btnNavEmpresa.Location = new System.Drawing.Point(560, 0);
            this.btnNavEmpresa.Name = "btnNavEmpresa";
            this.btnNavEmpresa.Size = new System.Drawing.Size(200, 130);
            this.btnNavEmpresa.TabIndex = 2;
            this.btnNavEmpresa.Text = "Empresa";
            this.btnNavEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.picUserIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUserIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUserIcon.Location = new System.Drawing.Point(1800, 20);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(60, 60);
            this.picUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserIcon.TabIndex = 3;
            this.picUserIcon.TabStop = false;
            this.picUserIcon.Click += new System.EventHandler(this.picUserIcon_Click);

            // ====================================================================
            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 1030);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1920, 50);
            this.pnlFooter.TabIndex = 1;

            // ====================================================================
            // lblBienvenida — más grande, Arial
            // ====================================================================
            this.lblBienvenida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBienvenida.Font = new System.Drawing.Font("Arial", 44F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.Black;
            this.lblBienvenida.Location = new System.Drawing.Point(260, 150);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(1400, 300);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenid@s al simulador\r\nde declaración de\r\nimpuestos del SAT";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ====================================================================
            // picLogoCentral — listo para recibir el logo real
            // ====================================================================
            this.picLogoCentral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLogoCentral.Location = new System.Drawing.Point(710, 480);
            this.picLogoCentral.Name = "picLogoCentral";
            this.picLogoCentral.Size = new System.Drawing.Size(500, 350);
            this.picLogoCentral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoCentral.TabIndex = 3;
            this.picLogoCentral.TabStop = false;

            // ====================================================================
            // fmInicio
            // ====================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.picLogoCentral);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlNavbar);
            this.Name = "fmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador SAT - Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fmInicio_Load);
            this.Resize += new System.EventHandler(this.fmInicio_Resize);

            this.pnlNavbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoCentral)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Label btnNavInicio;
        private System.Windows.Forms.Label btnNavPersonas;
        private System.Windows.Forms.Label btnNavEmpresa;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.PictureBox picLogoCentral;
    }
}