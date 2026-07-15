namespace SimuladorSAT
{
    partial class fmDetalleIngresosADisminuir
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
            this.btnAgregar = new System.Windows.Forms.Button();

            this.pnlFormularioCaptura = new System.Windows.Forms.Panel();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnGuardarCaptura = new System.Windows.Forms.Button();
            this.btnCancelarCaptura = new System.Windows.Forms.Button();

            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();

            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblMensajeAlerta = new System.Windows.Forms.Label();

            this.lblTotalIngresosADisminuir = new System.Windows.Forms.Label();
            this.txtTotalIngresosADisminuir = new System.Windows.Forms.TextBox();

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
            this.pnlTitulo.Size = new System.Drawing.Size(1536, 70);
            this.pnlTitulo.TabIndex = 0;

            this.lblTituloModal.AutoSize = true;
            this.lblTituloModal.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTituloModal.ForeColor = System.Drawing.Color.White;
            this.lblTituloModal.Location = new System.Drawing.Point(30, 22);
            this.lblTituloModal.Name = "lblTituloModal";
            this.lblTituloModal.TabIndex = 0;
            this.lblTituloModal.Text = "Ingresos a disminuir";

            this.btnCerrarX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarX.FlatAppearance.BorderSize = 0;
            this.btnCerrarX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarX.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCerrarX.ForeColor = System.Drawing.Color.White;
            this.btnCerrarX.Location = new System.Drawing.Point(1486, 15);
            this.btnCerrarX.Name = "btnCerrarX";
            this.btnCerrarX.Size = new System.Drawing.Size(40, 40);
            this.btnCerrarX.TabIndex = 1;
            this.btnCerrarX.Text = "X";
            this.btnCerrarX.Click += new System.EventHandler(this.btnCerrarX_Click);

            // ====================================================================
            // btnAgregar
            // ====================================================================
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAgregar.Location = new System.Drawing.Point(30, 90);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 32);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // ====================================================================
            // pnlFormularioCaptura — panel desplegable, anclado para estirarse
            // ====================================================================
            this.pnlFormularioCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormularioCaptura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormularioCaptura.Controls.Add(this.lblConcepto);
            this.pnlFormularioCaptura.Controls.Add(this.cmbConcepto);
            this.pnlFormularioCaptura.Controls.Add(this.lblImporte);
            this.pnlFormularioCaptura.Controls.Add(this.txtImporte);
            this.pnlFormularioCaptura.Controls.Add(this.btnGuardarCaptura);
            this.pnlFormularioCaptura.Controls.Add(this.btnCancelarCaptura);
            this.pnlFormularioCaptura.Location = new System.Drawing.Point(30, 90);
            this.pnlFormularioCaptura.Name = "pnlFormularioCaptura";
            this.pnlFormularioCaptura.Size = new System.Drawing.Size(1476, 150);
            this.pnlFormularioCaptura.TabIndex = 2;
            this.pnlFormularioCaptura.Visible = false;

            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConcepto.Location = new System.Drawing.Point(25, 28);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.TabIndex = 0;
            this.lblConcepto.Text = "*Concepto";

            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbConcepto.Location = new System.Drawing.Point(140, 25);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(300, 28);
            this.cmbConcepto.TabIndex = 1;
            this.cmbConcepto.Items.AddRange(new object[] {
                "Selecciona",
                "IEPS cobrado no trasladado de manera expresa y por separado",
                "Ingresos facturados pendientes de cancelación con aceptación del receptor",
                "Ingresos facturados acumulados en periodos anteriores",
                "Apoyos gubernamentales",
                "Ingresos facturados a cuenta de terceros"
            });
            this.cmbConcepto.SelectedIndex = 0;
            this.cmbConcepto.SelectedIndexChanged += new System.EventHandler(this.cmbConcepto_SelectedIndexChanged);

            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Arial", 10F);
            this.lblImporte.Location = new System.Drawing.Point(560, 28);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.TabIndex = 2;
            this.lblImporte.Text = "Importe";

            this.txtImporte.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtImporte.Enabled = false;
            this.txtImporte.Font = new System.Drawing.Font("Arial", 10F);
            this.txtImporte.Location = new System.Drawing.Point(650, 25);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(300, 28);
            this.txtImporte.TabIndex = 3;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.btnGuardarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCaptura.Font = new System.Drawing.Font("Arial", 10F);
            this.btnGuardarCaptura.Location = new System.Drawing.Point(600, 90);
            this.btnGuardarCaptura.Name = "btnGuardarCaptura";
            this.btnGuardarCaptura.Size = new System.Drawing.Size(110, 32);
            this.btnGuardarCaptura.TabIndex = 4;
            this.btnGuardarCaptura.Text = "Guardar";
            this.btnGuardarCaptura.Click += new System.EventHandler(this.btnGuardarCaptura_Click);

            this.btnCancelarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCaptura.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCancelarCaptura.Location = new System.Drawing.Point(730, 90);
            this.btnCancelarCaptura.Name = "btnCancelarCaptura";
            this.btnCancelarCaptura.Size = new System.Drawing.Size(110, 32);
            this.btnCancelarCaptura.TabIndex = 5;
            this.btnCancelarCaptura.Text = "Cancelar";
            this.btnCancelarCaptura.Click += new System.EventHandler(this.btnCancelarCaptura_Click);

            // ====================================================================
            // dgvRegistros — anclado, fondo blanco (sin franja gris cuando está vacío)
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
            this.dgvRegistros.Location = new System.Drawing.Point(30, 260);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.Size = new System.Drawing.Size(1476, 170);
            this.dgvRegistros.TabIndex = 3;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegistros.ColumnHeadersHeight = 40;
            this.dgvRegistros.RowTemplate.Height = 40;
            this.dgvRegistros.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colConcepto.HeaderText = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.ReadOnly = true;
            this.colConcepto.FillWeight = 150;

            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.FillWeight = 150;

            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "🗑";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.MinimumWidth = 90;
            this.colEliminar.FillWeight = 150;

            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colConcepto, this.colImporte, this.colEliminar });
            this.dgvRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistros_CellClick);

            // ====================================================================
            // Total de registros / Paginación
            // ====================================================================
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalRegistros.Location = new System.Drawing.Point(30, 460);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.TabIndex = 4;
            this.lblTotalRegistros.Text = "Total de registros            0";

            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPagina.Location = new System.Drawing.Point(30, 460);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.TabIndex = 5;
            this.lblPagina.Text = "< Página 1 de 0 >";

            // ====================================================================
            // Mensaje de alerta
            // ====================================================================
            this.lblMensajeAlerta.AutoSize = true;
            this.lblMensajeAlerta.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMensajeAlerta.ForeColor = System.Drawing.Color.Red;
            this.lblMensajeAlerta.Location = new System.Drawing.Point(30, 510);
            this.lblMensajeAlerta.Name = "lblMensajeAlerta";
            this.lblMensajeAlerta.TabIndex = 6;
            this.lblMensajeAlerta.Text = "Debes capturar al menos un registro dando clic en el botón \"Agregar\".";

            // ====================================================================
            // Total de ingresos a disminuir
            // ====================================================================
            this.lblTotalIngresosADisminuir.AutoSize = true;
            this.lblTotalIngresosADisminuir.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalIngresosADisminuir.Location = new System.Drawing.Point(30, 555);
            this.lblTotalIngresosADisminuir.Name = "lblTotalIngresosADisminuir";
            this.lblTotalIngresosADisminuir.TabIndex = 7;
            this.lblTotalIngresosADisminuir.Text = "Ingresos a disminuir";

            this.txtTotalIngresosADisminuir.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtTotalIngresosADisminuir.Font = new System.Drawing.Font("Arial", 10F);
            this.txtTotalIngresosADisminuir.Location = new System.Drawing.Point(280, 552);
            this.txtTotalIngresosADisminuir.Name = "txtTotalIngresosADisminuir";
            this.txtTotalIngresosADisminuir.ReadOnly = true;
            this.txtTotalIngresosADisminuir.Size = new System.Drawing.Size(195, 25);
            this.txtTotalIngresosADisminuir.TabIndex = 8;
            this.txtTotalIngresosADisminuir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // btnCerrar — anclado abajo a la derecha
            // ====================================================================
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCerrar.Location = new System.Drawing.Point(1396, 570);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 35);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ====================================================================
            // Form
            // ====================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1536, 640); // valor inicial de diseño; se recalcula en el constructor
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtTotalIngresosADisminuir);
            this.Controls.Add(this.lblTotalIngresosADisminuir);
            this.Controls.Add(this.lblMensajeAlerta);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.pnlFormularioCaptura);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmDetalleIngresosADisminuir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingresos a disminuir";

            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Button btnCerrarX;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel pnlFormularioCaptura;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnGuardarCaptura;
        private System.Windows.Forms.Button btnCancelarCaptura;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblMensajeAlerta;
        private System.Windows.Forms.Label lblTotalIngresosADisminuir;
        private System.Windows.Forms.TextBox txtTotalIngresosADisminuir;
        private System.Windows.Forms.Button btnCerrar;
    }
}