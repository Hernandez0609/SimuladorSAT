namespace SimuladorSAT
{
    partial class fmConfirmarReemplazo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnReemplazar;
        private System.Windows.Forms.Button btnContinuar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnReemplazar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 90);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(520, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Existe sin enviar una declaración del mismo tipo y periodo que intentas presentar";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            //
            // lblMensaje
            //
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMensaje.Location = new System.Drawing.Point(20, 105);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(520, 40);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "¿Deseas reemplazarla o continuar con su llenado?";
            //
            // btnReemplazar
            //
            this.btnReemplazar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnReemplazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReemplazar.FlatAppearance.BorderSize = 0;
            this.btnReemplazar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnReemplazar.ForeColor = System.Drawing.Color.White;
            this.btnReemplazar.Location = new System.Drawing.Point(280, 170);
            this.btnReemplazar.Name = "btnReemplazar";
            this.btnReemplazar.Size = new System.Drawing.Size(120, 40);
            this.btnReemplazar.TabIndex = 2;
            this.btnReemplazar.Text = "Reemplazar";
            this.btnReemplazar.UseVisualStyleBackColor = false;
            this.btnReemplazar.Click += new System.EventHandler(this.btnReemplazar_Click);
            //
            // btnContinuar
            //
            this.btnContinuar.BackColor = System.Drawing.Color.White;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnContinuar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnContinuar.ForeColor = System.Drawing.Color.Black;
            this.btnContinuar.Location = new System.Drawing.Point(410, 170);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(120, 40);
            this.btnContinuar.TabIndex = 3;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            //
            // fmConfirmarReemplazo
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(560, 230);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnReemplazar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmConfirmarReemplazo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmConfirmarReemplazo";
            this.ResumeLayout(false);
        }
    }
}