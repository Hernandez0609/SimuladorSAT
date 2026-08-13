namespace SimuladorSAT
{
    partial class Form1
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
            this.pnlMenuSuperior = new System.Windows.Forms.Panel();



            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.lblMenuEmpresa = new System.Windows.Forms.Label();
            this.lblMenuPersonas = new System.Windows.Forms.Label();
            this.lblMenuInicio = new System.Windows.Forms.Label();
            this.pnlFondoBlanco = new System.Windows.Forms.Panel();
            this.flpContenedorMosaicos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSueldos = new System.Windows.Forms.Panel();
            this.lblIconoSueldos = new System.Windows.Forms.Label();
            this.lblTextoSueldos = new System.Windows.Forms.Label();
            this.pnlActividades = new System.Windows.Forms.Panel();
            this.lblIconoActividades = new System.Windows.Forms.Label();
            this.lblTextoActividades = new System.Windows.Forms.Label();
            this.pnlConfianza = new System.Windows.Forms.Panel();
            this.lblIconoConfianza = new System.Windows.Forms.Label();
            this.lblTextoConfianza = new System.Windows.Forms.Label();
            this.pnlArrendamiento = new System.Windows.Forms.Panel();
            this.lblIconoArrendamiento = new System.Windows.Forms.Label();
            this.lblTextoArrendamiento = new System.Windows.Forms.Label();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.pnlMenuSuperior.SuspendLayout();
            
            this.pnlFondoBlanco.SuspendLayout();
            this.flpContenedorMosaicos.SuspendLayout();
            this.pnlSueldos.SuspendLayout();
            this.pnlActividades.SuspendLayout();
            this.pnlConfianza.SuspendLayout();
            this.pnlArrendamiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuSuperior
            // 
            this.pnlMenuSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.pnlMenuSuperior.Controls.Add(this.picUserIcon);
            this.pnlMenuSuperior.Controls.Add(this.lblMenuEmpresa);
            this.pnlMenuSuperior.Controls.Add(this.lblMenuPersonas);
            this.pnlMenuSuperior.Controls.Add(this.lblMenuInicio);
            this.pnlMenuSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuSuperior.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenuSuperior.Name = "pnlMenuSuperior";
            this.pnlMenuSuperior.Size = new System.Drawing.Size(1920, 130);
            this.pnlMenuSuperior.TabIndex = 0;
            // 
            // 
            this.picUserIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUserIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUserIcon.Location = new System.Drawing.Point(1800, 20);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(60, 60);
            this.picUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserIcon.TabIndex = 3;
            this.picUserIcon.TabStop = false;
            this.picUserIcon.Click += new System.EventHandler(this.picUserIcon_Click);
            // 
            // lblMenuEmpresa
            // 
            this.lblMenuEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuEmpresa.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblMenuEmpresa.Location = new System.Drawing.Point(560, 0);
            this.lblMenuEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuEmpresa.Name = "lblMenuEmpresa";
            this.lblMenuEmpresa.Size = new System.Drawing.Size(200, 130);
            this.lblMenuEmpresa.TabIndex = 2;
            this.lblMenuEmpresa.Text = "Empresa";
            this.lblMenuEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuPersonas
            // 
            this.lblMenuPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuPersonas.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPersonas.ForeColor = System.Drawing.Color.White;
            this.lblMenuPersonas.Location = new System.Drawing.Point(330, 0);
            this.lblMenuPersonas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuPersonas.Name = "lblMenuPersonas";
            this.lblMenuPersonas.Size = new System.Drawing.Size(200, 130);
            this.lblMenuPersonas.TabIndex = 1;
            this.lblMenuPersonas.Text = "Personas";
            this.lblMenuPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuInicio
            // 
            this.lblMenuInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuInicio.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuInicio.ForeColor = System.Drawing.Color.White;
            this.lblMenuInicio.Location = new System.Drawing.Point(100, 0);
            this.lblMenuInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuInicio.Name = "lblMenuInicio";
            this.lblMenuInicio.Size = new System.Drawing.Size(150, 130);
            this.lblMenuInicio.TabIndex = 0;
            this.lblMenuInicio.Text = "Inicio";
            this.lblMenuInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMenuInicio.Click += new System.EventHandler(this.lblMenuInicio_Click);
            // 
            // pnlFondoBlanco
            // 
            this.pnlFondoBlanco.BackColor = System.Drawing.Color.White;
            this.pnlFondoBlanco.Controls.Add(this.flpContenedorMosaicos);
            this.pnlFondoBlanco.Controls.Add(this.lblTituloPrincipal);
            this.pnlFondoBlanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFondoBlanco.Location = new System.Drawing.Point(0, 130);
            this.pnlFondoBlanco.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFondoBlanco.Name = "pnlFondoBlanco";
            this.pnlFondoBlanco.Size = new System.Drawing.Size(1920, 925);
            this.pnlFondoBlanco.TabIndex = 1;
            // 
            // flpContenedorMosaicos
            // 
            this.flpContenedorMosaicos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpContenedorMosaicos.Controls.Add(this.pnlSueldos);
            this.flpContenedorMosaicos.Controls.Add(this.pnlActividades);
            this.flpContenedorMosaicos.Controls.Add(this.pnlConfianza);
            this.flpContenedorMosaicos.Controls.Add(this.pnlArrendamiento);
            this.flpContenedorMosaicos.Location = new System.Drawing.Point(80, 230);
            this.flpContenedorMosaicos.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorMosaicos.Name = "flpContenedorMosaicos";
            this.flpContenedorMosaicos.Size = new System.Drawing.Size(1760, 420);
            this.flpContenedorMosaicos.TabIndex = 1;
            // 
            // pnlSueldos
            // 
            this.pnlSueldos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSueldos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSueldos.Controls.Add(this.lblIconoSueldos);
            this.pnlSueldos.Controls.Add(this.lblTextoSueldos);
            this.pnlSueldos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSueldos.Location = new System.Drawing.Point(30, 30);
            this.pnlSueldos.Margin = new System.Windows.Forms.Padding(30);
            this.pnlSueldos.Name = "pnlSueldos";
            this.pnlSueldos.Size = new System.Drawing.Size(380, 350);
            this.pnlSueldos.TabIndex = 0;
            // 
            // lblIconoSueldos
            // 
            this.lblIconoSueldos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoSueldos.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoSueldos.Location = new System.Drawing.Point(0, 0);
            this.lblIconoSueldos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIconoSueldos.Name = "lblIconoSueldos";
            this.lblIconoSueldos.Size = new System.Drawing.Size(378, 175);
            this.lblIconoSueldos.TabIndex = 0;
            this.lblIconoSueldos.Text = "💵";
            this.lblIconoSueldos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextoSueldos
            // 
            this.lblTextoSueldos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTextoSueldos.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoSueldos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTextoSueldos.Location = new System.Drawing.Point(0, 173);
            this.lblTextoSueldos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextoSueldos.Name = "lblTextoSueldos";
            this.lblTextoSueldos.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.lblTextoSueldos.Size = new System.Drawing.Size(378, 175);
            this.lblTextoSueldos.TabIndex = 1;
            this.lblTextoSueldos.Text = "Sueldos y salarios e Ingresos asimilados a salarios";
            this.lblTextoSueldos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlActividades
            // 
            this.pnlActividades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlActividades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActividades.Controls.Add(this.lblIconoActividades);
            this.pnlActividades.Controls.Add(this.lblTextoActividades);
            this.pnlActividades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlActividades.Location = new System.Drawing.Point(470, 30);
            this.pnlActividades.Margin = new System.Windows.Forms.Padding(30);
            this.pnlActividades.Name = "pnlActividades";
            this.pnlActividades.Size = new System.Drawing.Size(380, 350);
            this.pnlActividades.TabIndex = 1;
            // 
            // lblIconoActividades
            // 
            this.lblIconoActividades.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoActividades.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoActividades.Location = new System.Drawing.Point(0, 0);
            this.lblIconoActividades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIconoActividades.Name = "lblIconoActividades";
            this.lblIconoActividades.Size = new System.Drawing.Size(378, 175);
            this.lblIconoActividades.TabIndex = 0;
            this.lblIconoActividades.Text = "💼";
            this.lblIconoActividades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextoActividades
            // 
            this.lblTextoActividades.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTextoActividades.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoActividades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTextoActividades.Location = new System.Drawing.Point(0, 173);
            this.lblTextoActividades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextoActividades.Name = "lblTextoActividades";
            this.lblTextoActividades.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.lblTextoActividades.Size = new System.Drawing.Size(378, 175);
            this.lblTextoActividades.TabIndex = 1;
            this.lblTextoActividades.Text = "Personas fisicas con actividades empresriales y profesionales";
            this.lblTextoActividades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlConfianza
            // 
            this.pnlConfianza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlConfianza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfianza.Controls.Add(this.lblIconoConfianza);
            this.pnlConfianza.Controls.Add(this.lblTextoConfianza);
            this.pnlConfianza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlConfianza.Location = new System.Drawing.Point(910, 30);
            this.pnlConfianza.Margin = new System.Windows.Forms.Padding(30);
            this.pnlConfianza.Name = "pnlConfianza";
            this.pnlConfianza.Size = new System.Drawing.Size(380, 350);
            this.pnlConfianza.TabIndex = 2;
            // 
            // lblIconoConfianza
            // 
            this.lblIconoConfianza.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoConfianza.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoConfianza.Location = new System.Drawing.Point(0, 0);
            this.lblIconoConfianza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIconoConfianza.Name = "lblIconoConfianza";
            this.lblIconoConfianza.Size = new System.Drawing.Size(378, 175);
            this.lblIconoConfianza.TabIndex = 0;
            this.lblIconoConfianza.Text = "🛡️";
            this.lblIconoConfianza.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIconoConfianza.Click += new System.EventHandler(this.lblIconoConfianza_Click);
            // 
            // lblTextoConfianza
            // 
            this.lblTextoConfianza.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTextoConfianza.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoConfianza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTextoConfianza.Location = new System.Drawing.Point(0, 173);
            this.lblTextoConfianza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextoConfianza.Name = "lblTextoConfianza";
            this.lblTextoConfianza.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.lblTextoConfianza.Size = new System.Drawing.Size(378, 175);
            this.lblTextoConfianza.TabIndex = 1;
            this.lblTextoConfianza.Text = "Regimen simplificado de confianza para personas";
            this.lblTextoConfianza.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTextoConfianza.Click += new System.EventHandler(this.lblTextoConfianza_Click);
            // 
            // pnlArrendamiento
            // 
            this.pnlArrendamiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlArrendamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArrendamiento.Controls.Add(this.lblIconoArrendamiento);
            this.pnlArrendamiento.Controls.Add(this.lblTextoArrendamiento);
            this.pnlArrendamiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlArrendamiento.Location = new System.Drawing.Point(1350, 30);
            this.pnlArrendamiento.Margin = new System.Windows.Forms.Padding(30);
            this.pnlArrendamiento.Name = "pnlArrendamiento";
            this.pnlArrendamiento.Size = new System.Drawing.Size(380, 350);
            this.pnlArrendamiento.TabIndex = 3;
            // 
            // lblIconoArrendamiento
            // 
            this.lblIconoArrendamiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoArrendamiento.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoArrendamiento.Location = new System.Drawing.Point(0, 0);
            this.lblIconoArrendamiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIconoArrendamiento.Name = "lblIconoArrendamiento";
            this.lblIconoArrendamiento.Size = new System.Drawing.Size(378, 175);
            this.lblIconoArrendamiento.TabIndex = 0;
            this.lblIconoArrendamiento.Text = "🏠";
            this.lblIconoArrendamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIconoArrendamiento.Click += new System.EventHandler(this.lblIconoArrendamiento_Click);
            // 
            // lblTextoArrendamiento
            // 
            this.lblTextoArrendamiento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTextoArrendamiento.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoArrendamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTextoArrendamiento.Location = new System.Drawing.Point(0, 173);
            this.lblTextoArrendamiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextoArrendamiento.Name = "lblTextoArrendamiento";
            this.lblTextoArrendamiento.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.lblTextoArrendamiento.Size = new System.Drawing.Size(378, 175);
            this.lblTextoArrendamiento.TabIndex = 1;
            this.lblTextoArrendamiento.Text = "Arrendamiento";
            this.lblTextoArrendamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(80, 100);
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(602, 51);
            this.lblTituloPrincipal.TabIndex = 0;
            this.lblTituloPrincipal.Text = "Regímenes para personas___";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1055);
            this.Controls.Add(this.pnlFondoBlanco);
            this.Controls.Add(this.pnlMenuSuperior);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1300, 750);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador SAT - Regímenes";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenuSuperior.ResumeLayout(false);
            this.pnlFondoBlanco.ResumeLayout(false);
            this.pnlFondoBlanco.PerformLayout();
            this.flpContenedorMosaicos.ResumeLayout(false);
            this.pnlSueldos.ResumeLayout(false);
            this.pnlActividades.ResumeLayout(false);
            this.pnlConfianza.ResumeLayout(false);
            this.pnlArrendamiento.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuSuperior;
        private System.Windows.Forms.Label lblMenuInicio;
        private System.Windows.Forms.Label lblMenuPersonas;
        private System.Windows.Forms.Label lblMenuEmpresa;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.Panel pnlFondoBlanco;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorMosaicos;
        private System.Windows.Forms.Panel pnlSueldos;
        private System.Windows.Forms.Label lblIconoSueldos;
        private System.Windows.Forms.Label lblTextoSueldos;
        private System.Windows.Forms.Panel pnlActividades;
        private System.Windows.Forms.Label lblIconoActividades;
        private System.Windows.Forms.Label lblTextoActividades;
        private System.Windows.Forms.Panel pnlConfianza;
        private System.Windows.Forms.Label lblIconoConfianza;
        private System.Windows.Forms.Label lblTextoConfianza;
        private System.Windows.Forms.Panel pnlArrendamiento;
        private System.Windows.Forms.Label lblIconoArrendamiento;
        private System.Windows.Forms.Label lblTextoArrendamiento;
    }
}