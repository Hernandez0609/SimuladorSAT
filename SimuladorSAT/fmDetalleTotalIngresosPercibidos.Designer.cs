namespace SimuladorSAT
{
    partial class fmDetalleTotalIngresosPercibidos
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

            this.lblMontoPorDetallar = new System.Windows.Forms.Label();
            this.txtMontoPorDetallar = new System.Windows.Forms.TextBox();
            this.lblMontoDetallado = new System.Windows.Forms.Label();
            this.txtMontoDetallado = new System.Windows.Forms.TextBox();

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

            // Fila de Total, siempre visible, blanca, sin eliminar
            this.tlpTotalRow = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalConceptoCell = new System.Windows.Forms.Label();
            this.lblTotalImporteCell = new System.Windows.Forms.Label();
            this.lblTotalEliminarCell = new System.Windows.Forms.Label();

            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();

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
            this.lblTituloModal.Text = "Total de ingresos percibidos por la actividad";

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
            // Monto por detallar / Monto detallado (informativos, solo lectura)
            // ====================================================================
            this.lblMontoPorDetallar.AutoSize = true;
            this.lblMontoPorDetallar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMontoPorDetallar.Location = new System.Drawing.Point(30, 90);
            this.lblMontoPorDetallar.Name = "lblMontoPorDetallar";
            this.lblMontoPorDetallar.TabIndex = 1;
            this.lblMontoPorDetallar.Text = "Monto por detallar";

            this.txtMontoPorDetallar.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtMontoPorDetallar.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMontoPorDetallar.Location = new System.Drawing.Point(560, 87);
            this.txtMontoPorDetallar.Name = "txtMontoPorDetallar";
            this.txtMontoPorDetallar.ReadOnly = true;
            this.txtMontoPorDetallar.Size = new System.Drawing.Size(195, 25);
            this.txtMontoPorDetallar.TabIndex = 2;
            this.txtMontoPorDetallar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblMontoDetallado.AutoSize = true;
            this.lblMontoDetallado.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMontoDetallado.Location = new System.Drawing.Point(30, 130);
            this.lblMontoDetallado.Name = "lblMontoDetallado";
            this.lblMontoDetallado.TabIndex = 3;
            this.lblMontoDetallado.Text = "Monto detallado";

            this.txtMontoDetallado.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtMontoDetallado.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMontoDetallado.Location = new System.Drawing.Point(560, 127);
            this.txtMontoDetallado.Name = "txtMontoDetallado";
            this.txtMontoDetallado.ReadOnly = true;
            this.txtMontoDetallado.Size = new System.Drawing.Size(195, 25);
            this.txtMontoDetallado.TabIndex = 4;
            this.txtMontoDetallado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // btnAgregar
            // ====================================================================
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAgregar.Location = new System.Drawing.Point(30, 175);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 32);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // ====================================================================
            // pnlFormularioCaptura
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
            this.pnlFormularioCaptura.Location = new System.Drawing.Point(30, 175);
            this.pnlFormularioCaptura.Name = "pnlFormularioCaptura";
            this.pnlFormularioCaptura.Size = new System.Drawing.Size(1476, 150);
            this.pnlFormularioCaptura.TabIndex = 6;
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
                 "Actividad empresarial",
                 "Servicios profesionales (Honorarios)",
                 "Actividades agrícolas, ganaderas, silvícolas o pesqueras",
                 "Enajenación de activos fijos y terrenos de su propiedad afectos a su actividad",
                 "Uso o goce temporal de bienes"
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
            // dgvRegistros — solo conceptos capturados (SIN fila de Total aquí dentro)
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
            this.dgvRegistros.Location = new System.Drawing.Point(30, 345);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.Size = new System.Drawing.Size(1476, 160);
            this.dgvRegistros.TabIndex = 7;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegistros.ColumnHeadersHeight = 32;
            this.dgvRegistros.RowTemplate.Height = 32;
            this.dgvRegistros.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegistros.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvRegistros.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvRegistros.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            // tlpTotalRow — fila fija de Total, blanca, sin eliminar, siempre visible
            // ====================================================================
            this.tlpTotalRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTotalRow.BackColor = System.Drawing.Color.White;
            this.tlpTotalRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpTotalRow.ColumnCount = 3;
            this.tlpTotalRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpTotalRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpTotalRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpTotalRow.RowCount = 1;
            this.tlpTotalRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTotalRow.Location = new System.Drawing.Point(30, 505);
            this.tlpTotalRow.Name = "tlpTotalRow";
            this.tlpTotalRow.Size = new System.Drawing.Size(1476, 32);
            this.tlpTotalRow.TabIndex = 8;
            this.tlpTotalRow.Controls.Add(this.lblTotalConceptoCell, 0, 0);
            this.tlpTotalRow.Controls.Add(this.lblTotalImporteCell, 1, 0);
            this.tlpTotalRow.Controls.Add(this.lblTotalEliminarCell, 2, 0);

            this.lblTotalConceptoCell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalConceptoCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalConceptoCell.Text = "Total";
            this.lblTotalConceptoCell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTotalImporteCell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalImporteCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalImporteCell.Text = "0";
            this.lblTotalImporteCell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTotalEliminarCell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalEliminarCell.Text = "";

            // ====================================================================
            // Total de registros / Paginación
            // ====================================================================
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalRegistros.Location = new System.Drawing.Point(30, 555);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.TabIndex = 9;
            this.lblTotalRegistros.Text = "Total de registros            0";

            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPagina.Location = new System.Drawing.Point(30, 555); // se recalcula en runtime
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.TabIndex = 10;
            this.lblPagina.Text = "< Página 1 de 0 >";

            // ====================================================================
            // btnCerrar — mismo diseño y ubicación que todos los demás
            // ====================================================================
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1395, 555); // se recalcula en runtime
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(105, 36);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ====================================================================
            // Form
            // ====================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1536, 640); // valor inicial; recalculado en el constructor
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.tlpTotalRow);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.pnlFormularioCaptura);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMontoDetallado);
            this.Controls.Add(this.lblMontoDetallado);
            this.Controls.Add(this.txtMontoPorDetallar);
            this.Controls.Add(this.lblMontoPorDetallar);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmDetalleTotalIngresosPercibidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Total de ingresos percibidos por la actividad";

            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Button btnCerrarX;
        private System.Windows.Forms.Label lblMontoPorDetallar;
        private System.Windows.Forms.TextBox txtMontoPorDetallar;
        private System.Windows.Forms.Label lblMontoDetallado;
        private System.Windows.Forms.TextBox txtMontoDetallado;
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
        private System.Windows.Forms.TableLayoutPanel tlpTotalRow;
        private System.Windows.Forms.Label lblTotalConceptoCell;
        private System.Windows.Forms.Label lblTotalImporteCell;
        private System.Windows.Forms.Label lblTotalEliminarCell;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnCerrar;
    }
}