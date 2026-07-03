namespace SimuladorSAT
{
    partial class fmCapturaListaGenerica
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblLimite = new System.Windows.Forms.Label();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();

            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorAplicar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();

            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();

            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            // =============================================
            // FORM
            // =============================================
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Text = "Captura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // =============================================
            // HEADER (teal oscuro)
            // =============================================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 107, 114);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblTotal);

            this.lblTitulo.Text = "Compensaciones";
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 13);

            this.lblTotal.Text = "Total: $0";
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(750, 15);

            // =============================================
            // PANEL BOTONES ABAJO
            // =============================================
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Height = 55;
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnTerminar);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 32);
            this.btnCancelar.Location = new System.Drawing.Point(660, 11);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(27, 107, 114);
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(27, 107, 114);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.Size = new System.Drawing.Size(110, 32);
            this.btnTerminar.Location = new System.Drawing.Point(780, 11);
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(27, 107, 114);
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.FlatAppearance.BorderSize = 0;
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;

            // =============================================
            // PANEL CONTENIDO
            // =============================================
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);

            // Límite a aplicar (solo para Estímulos)
            this.lblLimite.Text = "Límite a aplicar";
            this.lblLimite.AutoSize = true;
            this.lblLimite.Location = new System.Drawing.Point(25, 20);
            this.lblLimite.Visible = false;

            this.txtLimite.Location = new System.Drawing.Point(200, 17);
            this.txtLimite.Size = new System.Drawing.Size(120, 26);
            this.txtLimite.ReadOnly = true;
            this.txtLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimite.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.txtLimite.Visible = false;

            // Botón Agregar
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.Location = new System.Drawing.Point(25, 20);
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(27, 107, 114);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;

            // DataGridView
            this.dgvRegistros.Location = new System.Drawing.Point(25, 65);
            this.dgvRegistros.Size = new System.Drawing.Size(850, 280);
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.ReadOnly = false;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(27, 107, 114);
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvRegistros.EnableHeadersVisualStyles = false;

            // Columnas del grid
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.FillWeight = 50;

            this.colPorAplicar.HeaderText = "Por aplicar en el periodo";
            this.colPorAplicar.Name = "colPorAplicar";
            this.colPorAplicar.ReadOnly = true;
            this.colPorAplicar.FillWeight = 35;

            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "Eliminar";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.FillWeight = 15;

            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colTipo,
                this.colPorAplicar,
                this.colEliminar
            });

            // Total de registros y paginación
            this.lblTotalRegistros.Text = "Total de registros     0";
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(25, 360);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.DimGray;

            this.lblPagina.Text = "< Pagina 1 de 0 >";
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(380, 360);
            this.lblPagina.ForeColor = System.Drawing.Color.DimGray;

            // Mensaje de validación (en rojo)
            this.lblMensaje.Text = "Debes capturar al menos un registro dando clic en el botón \"Agregar\".";
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(25, 390);
            this.lblMensaje.Visible = false;

            this.pnlContenido.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblLimite,
                this.txtLimite,
                this.btnAgregar,
                this.dgvRegistros,
                this.lblTotalRegistros,
                this.lblPagina,
                this.lblMensaje
            });

            // =============================================
            // AGREGAR AL FORM
            // =============================================
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblLimite;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorAplicar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnTerminar;
    }
}