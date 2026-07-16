namespace SimuladorSAT
{
    partial class fmCapturaEstimulos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTituloModal = new System.Windows.Forms.Label();
            this.btnCerrarX = new System.Windows.Forms.Button();

            this.lblLimiteAplicar = new System.Windows.Forms.Label();
            this.txtLimiteAplicar = new System.Windows.Forms.TextBox();

            this.btnAgregar = new System.Windows.Forms.Button();

            this.pnlFormularioCaptura = new System.Windows.Forms.Panel();
            this.lblTipoEstimulo = new System.Windows.Forms.Label();
            this.cmbTipoEstimulo = new System.Windows.Forms.ComboBox();
            this.lblPorAplicar = new System.Windows.Forms.Label();
            this.txtPorAplicar = new System.Windows.Forms.TextBox();
            this.btnGuardarCaptura = new System.Windows.Forms.Button();
            this.btnCancelarCaptura = new System.Windows.Forms.Button();

            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.colTipoEstimulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorAplicar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();

            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblMensajeAlerta = new System.Windows.Forms.Label();

            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.SuspendLayout();

            // ====================================================================
            // pnlTitulo
            // ====================================================================
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlTitulo.Controls.Add(this.lblTituloModal);
            this.pnlTitulo.Controls.Add(this.btnCerrarX);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1400, 70);
            this.pnlTitulo.TabIndex = 0;

            this.lblTituloModal.AutoSize = true;
            this.lblTituloModal.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTituloModal.ForeColor = System.Drawing.Color.White;
            this.lblTituloModal.Location = new System.Drawing.Point(30, 22);
            this.lblTituloModal.Name = "lblTituloModal";
            this.lblTituloModal.TabIndex = 0;
            this.lblTituloModal.Text = "Estímulos al impuesto a cargo";

            this.btnCerrarX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarX.FlatAppearance.BorderSize = 0;
            this.btnCerrarX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarX.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCerrarX.ForeColor = System.Drawing.Color.White;
            this.btnCerrarX.Location = new System.Drawing.Point(1330, 15);
            this.btnCerrarX.Name = "btnCerrarX";
            this.btnCerrarX.Size = new System.Drawing.Size(40, 40);
            this.btnCerrarX.TabIndex = 1;
            this.btnCerrarX.Text = "X";
            this.btnCerrarX.Click += new System.EventHandler(this.btnCerrarX_Click);

            // ====================================================================
            // Límite a aplicar (siempre visible, solo lectura)
            // ====================================================================
            this.lblLimiteAplicar.AutoSize = true;
            this.lblLimiteAplicar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblLimiteAplicar.Location = new System.Drawing.Point(50, 90);
            this.lblLimiteAplicar.Name = "lblLimiteAplicar";
            this.lblLimiteAplicar.TabIndex = 1;
            this.lblLimiteAplicar.Text = "Límite a aplicar";

            this.txtLimiteAplicar.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtLimiteAplicar.Font = new System.Drawing.Font("Arial", 10F);
            this.txtLimiteAplicar.Location = new System.Drawing.Point(660, 87);
            this.txtLimiteAplicar.Name = "txtLimiteAplicar";
            this.txtLimiteAplicar.ReadOnly = true;
            this.txtLimiteAplicar.Size = new System.Drawing.Size(195, 25);
            this.txtLimiteAplicar.TabIndex = 2;
            this.txtLimiteAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // btnAgregar
            // ====================================================================
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAgregar.Location = new System.Drawing.Point(50, 135);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 32);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // ====================================================================
            // pnlFormularioCaptura
            // ====================================================================
            this.pnlFormularioCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormularioCaptura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormularioCaptura.Controls.Add(this.lblTipoEstimulo);
            this.pnlFormularioCaptura.Controls.Add(this.cmbTipoEstimulo);
            this.pnlFormularioCaptura.Controls.Add(this.lblPorAplicar);
            this.pnlFormularioCaptura.Controls.Add(this.txtPorAplicar);
            this.pnlFormularioCaptura.Controls.Add(this.btnGuardarCaptura);
            this.pnlFormularioCaptura.Controls.Add(this.btnCancelarCaptura);
            this.pnlFormularioCaptura.Location = new System.Drawing.Point(50, 135);
            this.pnlFormularioCaptura.Name = "pnlFormularioCaptura";
            this.pnlFormularioCaptura.Size = new System.Drawing.Size(1300, 150);
            this.pnlFormularioCaptura.TabIndex = 4;
            this.pnlFormularioCaptura.Visible = false;

            this.lblTipoEstimulo.AutoSize = true;
            this.lblTipoEstimulo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTipoEstimulo.Location = new System.Drawing.Point(25, 25);
            this.lblTipoEstimulo.Name = "lblTipoEstimulo";
            this.lblTipoEstimulo.TabIndex = 0;
            this.lblTipoEstimulo.Text = "*Tipo de estímulo";

            this.cmbTipoEstimulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEstimulo.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTipoEstimulo.Location = new System.Drawing.Point(200, 22);
            this.cmbTipoEstimulo.Name = "cmbTipoEstimulo";
            this.cmbTipoEstimulo.Size = new System.Drawing.Size(320, 28);
            this.cmbTipoEstimulo.TabIndex = 1;
            this.cmbTipoEstimulo.Items.AddRange(new object[] {
                "Selecciona",
                "Estímulo fiscal por proyectos de investigación y desarrollo tecnológico",
                "Estímulo fiscal por deducción inmediata de inversiones",
                "Estímulo fiscal a la producción cinematográfica nacional",
                "Estímulo fiscal al deporte de alto rendimiento"
            });
            this.cmbTipoEstimulo.SelectedIndex = 0;
            this.cmbTipoEstimulo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoEstimulo_SelectedIndexChanged);

            this.lblPorAplicar.AutoSize = true;
            this.lblPorAplicar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPorAplicar.Location = new System.Drawing.Point(580, 25);
            this.lblPorAplicar.Name = "lblPorAplicar";
            this.lblPorAplicar.TabIndex = 2;
            this.lblPorAplicar.Text = "Por aplicar en el periodo";

            this.txtPorAplicar.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtPorAplicar.Enabled = false;
            this.txtPorAplicar.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPorAplicar.Location = new System.Drawing.Point(820, 22);
            this.txtPorAplicar.Name = "txtPorAplicar";
            this.txtPorAplicar.Size = new System.Drawing.Size(300, 28);
            this.txtPorAplicar.TabIndex = 3;
            this.txtPorAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.btnGuardarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCaptura.Font = new System.Drawing.Font("Arial", 10F);
            this.btnGuardarCaptura.Location = new System.Drawing.Point(500, 90);
            this.btnGuardarCaptura.Name = "btnGuardarCaptura";
            this.btnGuardarCaptura.Size = new System.Drawing.Size(110, 32);
            this.btnGuardarCaptura.TabIndex = 4;
            this.btnGuardarCaptura.Text = "Guardar";
            this.btnGuardarCaptura.Click += new System.EventHandler(this.btnGuardarCaptura_Click);

            this.btnCancelarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCaptura.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCancelarCaptura.Location = new System.Drawing.Point(630, 90);
            this.btnCancelarCaptura.Name = "btnCancelarCaptura";
            this.btnCancelarCaptura.Size = new System.Drawing.Size(110, 32);
            this.btnCancelarCaptura.TabIndex = 5;
            this.btnCancelarCaptura.Text = "Cancelar";
            this.btnCancelarCaptura.Click += new System.EventHandler(this.btnCancelarCaptura_Click);

            // ====================================================================
            // dgvRegistros
            // ====================================================================
            this.dgvRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistros.ReadOnly = false;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRegistros.Font = new System.Drawing.Font("Arial", 10F);
            this.dgvRegistros.Location = new System.Drawing.Point(50, 300);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.Size = new System.Drawing.Size(1300, 170);
            this.dgvRegistros.TabIndex = 5;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegistros.ColumnHeadersHeight = 40;
            this.dgvRegistros.RowTemplate.Height = 40;
            this.dgvRegistros.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegistros.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvRegistros.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvRegistros.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colTipoEstimulo.HeaderText = "Tipo de estímulo";
            this.colTipoEstimulo.Name = "colTipoEstimulo";
            this.colTipoEstimulo.ReadOnly = true;
            this.colTipoEstimulo.FillWeight = 150;

            this.colPorAplicar.HeaderText = "Por aplicar en el periodo";
            this.colPorAplicar.Name = "colPorAplicar";
            this.colPorAplicar.ReadOnly = true;
            this.colPorAplicar.FillWeight = 150;

            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "🗑";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.MinimumWidth = 90;
            this.colEliminar.FillWeight = 150;

            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTipoEstimulo, this.colPorAplicar, this.colEliminar });
            this.dgvRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistros_CellClick);

            // ====================================================================
            // Total de registros / Paginación
            // ====================================================================
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalRegistros.Location = new System.Drawing.Point(50, 490);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.TabIndex = 6;
            this.lblTotalRegistros.Text = "Total de registros            0";

            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPagina.Location = new System.Drawing.Point(50, 490); // se recalcula en runtime
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.TabIndex = 7;
            this.lblPagina.Text = "< Página 1 de 0 >";

            // ====================================================================
            // Mensaje de alerta
            // ====================================================================
            this.lblMensajeAlerta.AutoSize = true;
            this.lblMensajeAlerta.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMensajeAlerta.ForeColor = System.Drawing.Color.Red;
            this.lblMensajeAlerta.Location = new System.Drawing.Point(50, 540);
            this.lblMensajeAlerta.Name = "lblMensajeAlerta";
            this.lblMensajeAlerta.TabIndex = 8;
            this.lblMensajeAlerta.Text = "Debes capturar al menos un registro dando clic en el botón \"Agregar\".";

            // ====================================================================
            // btnCerrar — mismo diseño y ubicación que todos los demás
            // ====================================================================
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1265, 575); // se recalcula en runtime
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(105, 36);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ====================================================================
            // Form
            // ====================================================================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 650);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblMensajeAlerta);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.pnlFormularioCaptura);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtLimiteAplicar);
            this.Controls.Add(this.lblLimiteAplicar);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmCapturaEstimulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estímulos al impuesto a cargo";

            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Button btnCerrarX;
        private System.Windows.Forms.Label lblLimiteAplicar;
        private System.Windows.Forms.TextBox txtLimiteAplicar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel pnlFormularioCaptura;
        private System.Windows.Forms.Label lblTipoEstimulo;
        private System.Windows.Forms.ComboBox cmbTipoEstimulo;
        private System.Windows.Forms.Label lblPorAplicar;
        private System.Windows.Forms.TextBox txtPorAplicar;
        private System.Windows.Forms.Button btnGuardarCaptura;
        private System.Windows.Forms.Button btnCancelarCaptura;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoEstimulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorAplicar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblMensajeAlerta;
        private System.Windows.Forms.Button btnCerrar;
    }
}