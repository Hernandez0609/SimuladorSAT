namespace SimuladorSAT
{
    partial class fmDetalleDescuentosIngresos
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblTextoTabla = new System.Windows.Forms.Label();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.colMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFacturasCanceladas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFacturasVigentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotalDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCampo1 = new System.Windows.Forms.Label();
            this.txtCampo1 = new System.Windows.Forms.TextBox();
            this.lblCampo2 = new System.Windows.Forms.Label();
            this.lblSigno2 = new System.Windows.Forms.Label();
            this.txtCampo2 = new System.Windows.Forms.TextBox();
            this.lblCampo3 = new System.Windows.Forms.Label();
            this.lblSigno3 = new System.Windows.Forms.Label();
            this.txtCampo3 = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
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
            this.lblTituloModal.Text = "Descuentos, devoluciones y bonificaciones facturadas";

            this.btnCerrarX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarX.FlatAppearance.BorderSize = 0;
            this.btnCerrarX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarX.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCerrarX.ForeColor = System.Drawing.Color.White;
            this.btnCerrarX.Location = new System.Drawing.Point(1350, 15);
            this.btnCerrarX.Name = "btnCerrarX";
            this.btnCerrarX.Size = new System.Drawing.Size(40, 40);
            this.btnCerrarX.TabIndex = 1;
            this.btnCerrarX.Text = "X";
            this.btnCerrarX.Click += new System.EventHandler(this.btnCerrarX_Click);

            // ====================================================================
            // Descripción — más espacio
            // ====================================================================
            this.lblDescripcion.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDescripcion.Location = new System.Drawing.Point(30, 100);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(1330, 55);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "A continuación se muestra el detalle de prellenado de las devoluciones, descuentos y bonificaciones del periodo, este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";

            this.lblTextoTabla.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTextoTabla.Location = new System.Drawing.Point(30, 175);
            this.lblTextoTabla.Name = "lblTextoTabla";
            this.lblTextoTabla.Size = new System.Drawing.Size(1000, 20);
            this.lblTextoTabla.TabIndex = 2;
            this.lblTextoTabla.Text = "Suma de facturas emitidas de tipo ingreso del mes con método de pago \"Pago en una sola exhibición\" (PUE).";

            // ====================================================================
            // dgvTabla — mucho más grande y con columnas anchas
            // ====================================================================
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.RowHeadersVisible = false;
            this.dgvTabla.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTabla.Font = new System.Drawing.Font("Arial", 9F);
            this.dgvTabla.Location = new System.Drawing.Point(30, 220);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.Size = new System.Drawing.Size(1340, 75);
            this.dgvTabla.TabIndex = 3;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla.ColumnHeadersHeight = 30;
            this.dgvTabla.RowTemplate.Height = 37;
            this.dgvTabla.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvTabla.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvTabla.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.colMes.HeaderText = "Mes";
            this.colMes.Name = "colMes";
            this.colMes.FillWeight = 60;
            this.colFacturasCanceladas.HeaderText = "Número de facturas Canceladas";
            this.colFacturasCanceladas.Name = "colFacturasCanceladas";
            this.colFacturasCanceladas.FillWeight = 140;
            this.colFacturasVigentes.HeaderText = "Número de facturas vigentes";
            this.colFacturasVigentes.Name = "colFacturasVigentes";
            this.colFacturasVigentes.FillWeight = 140;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.FillWeight = 100;
            this.colDescuento.HeaderText = "Descuento";
            this.colDescuento.Name = "colDescuento";
            this.colDescuento.FillWeight = 100;
            this.colSubtotalDescuento.HeaderText = "Subtotal- Descuento";
            this.colSubtotalDescuento.Name = "colSubtotalDescuento";
            this.colSubtotalDescuento.FillWeight = 120;

            this.dgvTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        this.colMes, this.colFacturasCanceladas, this.colFacturasVigentes,
        this.colSubtotal, this.colDescuento, this.colSubtotalDescuento });
            this.dgvTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ====================================================================
            // Campo 1 — más separación entre secciones
            // ====================================================================
            this.lblCampo1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCampo1.Location = new System.Drawing.Point(30, 360);
            this.lblCampo1.Name = "lblCampo1";
            this.lblCampo1.Size = new System.Drawing.Size(700, 40);
            this.lblCampo1.TabIndex = 4;
            this.lblCampo1.Text = "Descuentos, devoluciones y bonificaciones amparadas por comprobantes fiscales de egresos";

            this.txtCampo1.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtCampo1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo1.Location = new System.Drawing.Point(800, 368);
            this.txtCampo1.Name = "txtCampo1";
            this.txtCampo1.ReadOnly = true;
            this.txtCampo1.Size = new System.Drawing.Size(195, 25);
            this.txtCampo1.TabIndex = 5;
            this.txtCampo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // Campo 2
            // ====================================================================
            this.lblCampo2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCampo2.Location = new System.Drawing.Point(30, 450);
            this.lblCampo2.Name = "lblCampo2";
            this.lblCampo2.Size = new System.Drawing.Size(700, 40);
            this.lblCampo2.TabIndex = 6;
            this.lblCampo2.Text = "*Descuentos, devoluciones y bonificaciones de integrantes por copropiedad";

            this.lblSigno2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno2.Location = new System.Drawing.Point(755, 460);
            this.lblSigno2.Name = "lblSigno2";
            this.lblSigno2.Size = new System.Drawing.Size(35, 20);
            this.lblSigno2.TabIndex = 7;
            this.lblSigno2.Text = "(-)";

            this.txtCampo2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo2.Location = new System.Drawing.Point(800, 458);
            this.txtCampo2.Name = "txtCampo2";
            this.txtCampo2.Size = new System.Drawing.Size(195, 25);
            this.txtCampo2.TabIndex = 8;
            this.txtCampo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCampo2.TextChanged += new System.EventHandler(this.txtCampo2_TextChanged);

            // ====================================================================
            // Campo 3
            // ====================================================================
            this.lblCampo3.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCampo3.Location = new System.Drawing.Point(30, 540);
            this.lblCampo3.Name = "lblCampo3";
            this.lblCampo3.Size = new System.Drawing.Size(700, 40);
            this.lblCampo3.TabIndex = 9;
            this.lblCampo3.Text = "Total de descuentos, devoluciones y bonificaciones amparadas por comprobantes fiscales de egresos";

            this.lblSigno3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno3.Location = new System.Drawing.Point(755, 550);
            this.lblSigno3.Name = "lblSigno3";
            this.lblSigno3.Size = new System.Drawing.Size(35, 20);
            this.lblSigno3.TabIndex = 10;
            this.lblSigno3.Text = "(=)";

            this.txtCampo3.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtCampo3.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo3.Location = new System.Drawing.Point(800, 548);
            this.txtCampo3.Name = "txtCampo3";
            this.txtCampo3.ReadOnly = true;
            this.txtCampo3.Size = new System.Drawing.Size(195, 25);
            this.txtCampo3.TabIndex = 11;
            this.txtCampo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // btnCerrar
            // ====================================================================
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCerrar.Location = new System.Drawing.Point(1260, 630);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ====================================================================
            // Form — SIN borde nativo, tamaño grande (~70% de pantalla en 1920x1080)
            // ====================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtCampo3);
            this.Controls.Add(this.lblSigno3);
            this.Controls.Add(this.lblCampo3);
            this.Controls.Add(this.txtCampo2);
            this.Controls.Add(this.lblSigno2);
            this.Controls.Add(this.lblCampo2);
            this.Controls.Add(this.txtCampo1);
            this.Controls.Add(this.lblCampo1);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.lblTextoTabla);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // ← quita el borde nativo duplicado
            this.Name = "fmDetalleDescuentosIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Descuentos, devoluciones y bonificaciones facturadas";

            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Button btnCerrarX;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblTextoTabla;
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacturasCanceladas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacturasVigentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotalDescuento;
        private System.Windows.Forms.Label lblCampo1;
        private System.Windows.Forms.TextBox txtCampo1;
        private System.Windows.Forms.Label lblCampo2;
        private System.Windows.Forms.Label lblSigno2;
        private System.Windows.Forms.TextBox txtCampo2;
        private System.Windows.Forms.Label lblCampo3;
        private System.Windows.Forms.Label lblSigno3;
        private System.Windows.Forms.TextBox txtCampo3;
        private System.Windows.Forms.Button btnCerrar;
    }
}