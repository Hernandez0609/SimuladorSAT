namespace SimuladorDidactitoSAT
{
    partial class fmPago
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.lblUserIcon = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(75)))), ((int)(((byte)(91)))));
            this.panelHeader.Controls.Add(this.lblInicio);
            this.panelHeader.Controls.Add(this.lblPersonas);
            this.panelHeader.Controls.Add(this.lblEmpresa);
            this.panelHeader.Controls.Add(this.panelSearch);
            this.panelHeader.Controls.Add(this.lblUserIcon);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 85);
            this.panelHeader.TabIndex = 0;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInicio.Font = new System.Drawing.Font("Georgia", 13.52F);
            this.lblInicio.ForeColor = System.Drawing.Color.White;
            this.lblInicio.Location = new System.Drawing.Point(120, 32);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(56, 21);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Inicio";
            // 
            // lblPersonas
            // 
            this.lblPersonas.AutoSize = true;
            this.lblPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPersonas.Font = new System.Drawing.Font("Georgia", 13.52F);
            this.lblPersonas.ForeColor = System.Drawing.Color.White;
            this.lblPersonas.Location = new System.Drawing.Point(230, 32);
            this.lblPersonas.Name = "lblPersonas";
            this.lblPersonas.Size = new System.Drawing.Size(83, 21);
            this.lblPersonas.TabIndex = 1;
            this.lblPersonas.Text = "Personas";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEmpresa.Font = new System.Drawing.Font("Georgia", 13.52F);
            this.lblEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEmpresa.Location = new System.Drawing.Point(360, 32);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(81, 21);
            this.lblEmpresa.TabIndex = 2;
            this.lblEmpresa.Text = "Empresa";
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelSearch.Controls.Add(this.txtBuscar);
            this.panelSearch.Controls.Add(this.lblSearchIcon);
            this.panelSearch.Location = new System.Drawing.Point(580, 24);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(250, 36);
            this.panelSearch.TabIndex = 3;
            this.panelSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSearch_Paint);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Georgia", 11.252F);
            this.txtBuscar.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscar.Location = new System.Drawing.Point(15, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(195, 18);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "Buscar";
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSearchIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblSearchIcon.Location = new System.Drawing.Point(218, 7);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(23, 20);
            this.lblSearchIcon.TabIndex = 1;
            this.lblSearchIcon.Text = "🔍";
            // 
            // lblUserIcon
            // 
            this.lblUserIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserIcon.AutoSize = true;
            this.lblUserIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserIcon.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIcon.ForeColor = System.Drawing.Color.White;
            this.lblUserIcon.Location = new System.Drawing.Point(890, 15);
            this.lblUserIcon.Name = "lblUserIcon";
            this.lblUserIcon.Size = new System.Drawing.Size(51, 45);
            this.lblUserIcon.TabIndex = 4;
            this.lblUserIcon.Text = "👤";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(75)))), ((int)(((byte)(91)))));
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 611);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(984, 50);
            this.panelFooter.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(50, 150);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(884, 236);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Bienvienid@s al simulador\r\nde declaracion de\r\nimpuestos del SAT";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(417, 410);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // fmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "fmPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador Didáctico SAT";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblPersonas;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.Label lblUserIcon;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogo;
    }
}