namespace SimuladorSAT
{
    partial class fmDetalleIsrRetenido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleGris = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTituloAzul = new System.Windows.Forms.Panel();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.btnIconoCerrar = new System.Windows.Forms.Button();
            this.pnlCuerpoBlanco = new System.Windows.Forms.Panel();
            this.lblExplicacion1 = new System.Windows.Forms.Label();
            this.lblTextoTabla1 = new System.Windows.Forms.Label();

            this.dgvTabla1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblTextoTabla2 = new System.Windows.Forms.Label();

            this.dgvTabla2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblCampo1 = new System.Windows.Forms.Label();
            this.txtCampo1 = new System.Windows.Forms.TextBox();
            this.lblCampo2 = new System.Windows.Forms.Label();
            this.lblSigno2 = new System.Windows.Forms.Label();
            this.txtCampo2 = new System.Windows.Forms.TextBox();
            this.lblCampo3 = new System.Windows.Forms.Label();
            this.lblSigno3 = new System.Windows.Forms.Label();
            this.txtCampo3 = new System.Windows.Forms.TextBox();
            this.lblCampo4 = new System.Windows.Forms.Label();
            this.lblSigno4 = new System.Windows.Forms.Label();
            this.txtCampo4 = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.pnlTituloAzul.SuspendLayout();
            this.pnlCuerpoBlanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla2)).BeginInit();
            this.SuspendLayout();

            // ====================================================================
            // Estilos base — TODO gris uniforme (238,238,238), Arial
            // ====================================================================
            dataGridViewCellStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyleHeader.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyleHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyleHeader.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            dataGridViewCellStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewCellStyleHeader.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyleHeader.SelectionForeColor = System.Drawing.Color.FromArgb(33, 33, 33);

            dataGridViewCellStyleGris.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyleGris.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            dataGridViewCellStyleGris.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyleGris.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyleGris.SelectionBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            dataGridViewCellStyleGris.SelectionForeColor = System.Drawing.Color.Black;

            // ====================================================================
            // pnlTituloAzul
            // ====================================================================
            this.pnlTituloAzul.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlTituloAzul.Controls.Add(this.lblTituloHeader);
            this.pnlTituloAzul.Controls.Add(this.btnIconoCerrar);
            this.pnlTituloAzul.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloAzul.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloAzul.Name = "pnlTituloAzul";
            this.pnlTituloAzul.Size = new System.Drawing.Size(1400, 60);
            this.pnlTituloAzul.TabIndex = 0;

            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(25, 18);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Text = "ISR retenido";

            this.btnIconoCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIconoCerrar.FlatAppearance.BorderSize = 0;
            this.btnIconoCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIconoCerrar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnIconoCerrar.ForeColor = System.Drawing.Color.White;
            this.btnIconoCerrar.Location = new System.Drawing.Point(1350, 12);
            this.btnIconoCerrar.Name = "btnIconoCerrar";
            this.btnIconoCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnIconoCerrar.Text = "X";
            this.btnIconoCerrar.UseVisualStyleBackColor = true;
            this.btnIconoCerrar.Click += new System.EventHandler(this.btnIconoCerrar_Click);

            // ====================================================================
            // pnlCuerpoBlanco
            // ====================================================================
            this.pnlCuerpoBlanco.AutoScroll = true;
            this.pnlCuerpoBlanco.BackColor = System.Drawing.Color.White;
            this.pnlCuerpoBlanco.Controls.Add(this.lblExplicacion1);
            this.pnlCuerpoBlanco.Controls.Add(this.lblTextoTabla1);
            this.pnlCuerpoBlanco.Controls.Add(this.dgvTabla1);
            this.pnlCuerpoBlanco.Controls.Add(this.lblTextoTabla2);
            this.pnlCuerpoBlanco.Controls.Add(this.dgvTabla2);
            this.pnlCuerpoBlanco.Controls.Add(this.lblCampo1);
            this.pnlCuerpoBlanco.Controls.Add(this.txtCampo1);
            this.pnlCuerpoBlanco.Controls.Add(this.lblCampo2);
            this.pnlCuerpoBlanco.Controls.Add(this.lblSigno2);
            this.pnlCuerpoBlanco.Controls.Add(this.txtCampo2);
            this.pnlCuerpoBlanco.Controls.Add(this.lblCampo3);
            this.pnlCuerpoBlanco.Controls.Add(this.lblSigno3);
            this.pnlCuerpoBlanco.Controls.Add(this.txtCampo3);
            this.pnlCuerpoBlanco.Controls.Add(this.lblCampo4);
            this.pnlCuerpoBlanco.Controls.Add(this.lblSigno4);
            this.pnlCuerpoBlanco.Controls.Add(this.txtCampo4);
            this.pnlCuerpoBlanco.Controls.Add(this.btnCerrar);
            this.pnlCuerpoBlanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpoBlanco.Location = new System.Drawing.Point(0, 60);
            this.pnlCuerpoBlanco.Name = "pnlCuerpoBlanco";
            this.pnlCuerpoBlanco.Size = new System.Drawing.Size(1400, 640);
            this.pnlCuerpoBlanco.TabIndex = 1;

            this.lblExplicacion1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblExplicacion1.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblExplicacion1.Location = new System.Drawing.Point(30, 20);
            this.lblExplicacion1.Name = "lblExplicacion1";
            this.lblExplicacion1.Size = new System.Drawing.Size(1340, 40);
            this.lblExplicacion1.Text = "A continuación se muestra el detalle de prellenado del ISR retenido del mes, este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";

            this.lblTextoTabla1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoTabla1.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTextoTabla1.Location = new System.Drawing.Point(30, 65);
            this.lblTextoTabla1.Name = "lblTextoTabla1";
            this.lblTextoTabla1.Size = new System.Drawing.Size(1340, 24);
            this.lblTextoTabla1.Text = "Suma de facturas emitidas de ingreso del mes con método de pago \"Pago en una sola exhibición\" (PUE).";

            // ====================================================================
            // dgvTabla1
            // ====================================================================
            this.dgvTabla1.AllowUserToAddRows = false;
            this.dgvTabla1.AllowUserToDeleteRows = false;
            this.dgvTabla1.AllowUserToResizeRows = false;
            this.dgvTabla1.AllowUserToResizeColumns = false;
            this.dgvTabla1.BackgroundColor = System.Drawing.Color.White;
            this.dgvTabla1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTabla1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyleHeader;
            this.dgvTabla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla1.ColumnHeadersHeight = 32;
            this.dgvTabla1.RowTemplate.Height = 32;
            this.dgvTabla1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dataGridViewTextBoxColumn7,
                this.dataGridViewTextBoxColumn8,
                this.dataGridViewTextBoxColumn9,
                this.dataGridViewTextBoxColumn10,
                this.dataGridViewTextBoxColumn11,
                this.dataGridViewTextBoxColumn12,
                this.dataGridViewTextBoxColumn13});
            this.dgvTabla1.Font = new System.Drawing.Font("Arial", 9F);
            this.dgvTabla1.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvTabla1.Location = new System.Drawing.Point(30, 100);
            this.dgvTabla1.Name = "dgvTabla1";
            this.dgvTabla1.ReadOnly = true;
            this.dgvTabla1.RowHeadersVisible = false;
            this.dgvTabla1.Size = new System.Drawing.Size(1340, 64);
            this.dgvTabla1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTabla1.Enabled = false; // o
            this.dgvTabla1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabla1.MultiSelect = false;

            this.dataGridViewTextBoxColumn7.FillWeight = 5;
            this.dataGridViewTextBoxColumn7.HeaderText = "Mes";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn8.FillWeight = 20;
            this.dataGridViewTextBoxColumn8.HeaderText = "Número de facturas Canceladas";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn9.FillWeight = 20;
            this.dataGridViewTextBoxColumn9.HeaderText = "Numero de facturas vigentes";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn10.FillWeight = 10;
            this.dataGridViewTextBoxColumn10.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn11.FillWeight = 10;
            this.dataGridViewTextBoxColumn11.HeaderText = "Descuento";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn12.FillWeight = 15;
            this.dataGridViewTextBoxColumn12.HeaderText = "Subtotal- Descuento";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn13.FillWeight = 20;
            this.dataGridViewTextBoxColumn13.HeaderText = "Impuestos retenidos";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyleGris;

            // ====================================================================
            // lblTextoTabla2
            // ====================================================================
            this.lblTextoTabla2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoTabla2.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTextoTabla2.Location = new System.Drawing.Point(30, 200);
            this.lblTextoTabla2.Name = "lblTextoTabla2";
            this.lblTextoTabla2.Size = new System.Drawing.Size(1340, 24);
            this.lblTextoTabla2.Text = "Suma de facturas emitidas de tipo pago donde la fecha de pago corresponde al mes.";

            // ====================================================================
            // dgvTabla2
            // ====================================================================
            this.dgvTabla2.AllowUserToAddRows = false;
            this.dgvTabla2.AllowUserToDeleteRows = false;
            this.dgvTabla2.AllowUserToResizeRows = false;
            this.dgvTabla2.AllowUserToResizeColumns = false;
            this.dgvTabla2.BackgroundColor = System.Drawing.Color.White;
            this.dgvTabla2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTabla2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyleHeader;
            this.dgvTabla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla2.ColumnHeadersHeight = 32;
            this.dgvTabla2.RowTemplate.Height = 32;
            this.dgvTabla2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dataGridViewTextBoxColumn1,
                this.dataGridViewTextBoxColumn2,
                this.dataGridViewTextBoxColumn3,
                this.dataGridViewTextBoxColumn4,
                this.dataGridViewTextBoxColumn5});
            this.dgvTabla2.Font = new System.Drawing.Font("Arial", 9F);
            this.dgvTabla2.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvTabla2.Location = new System.Drawing.Point(30, 245);
            this.dgvTabla2.Name = "dgvTabla2";
            this.dgvTabla2.ReadOnly = true;
            this.dgvTabla2.RowHeadersVisible = false;
            this.dgvTabla2.Size = new System.Drawing.Size(1340, 64);
            this.dgvTabla2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewTextBoxColumn1.FillWeight = 5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Mes";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn2.FillWeight = 23;
            this.dataGridViewTextBoxColumn2.HeaderText = "Número de facturas Canceladas";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn3.FillWeight = 23;
            this.dataGridViewTextBoxColumn3.HeaderText = "Numero de facturas vigentes";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn4.FillWeight = 24;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ingresos cobrados sin impuestos";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyleGris;

            this.dataGridViewTextBoxColumn5.FillWeight = 25;
            this.dataGridViewTextBoxColumn5.HeaderText = "Impuestos retenidos - ISR";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyleGris;

            // ====================================================================
            // Campo 1
            // ====================================================================
            this.lblCampo1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCampo1.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCampo1.Location = new System.Drawing.Point(30, 370);
            this.lblCampo1.Name = "lblCampo1";
            this.lblCampo1.Size = new System.Drawing.Size(600, 24);
            this.lblCampo1.Text = "ISR retenido de facturas emitidas de tipo ingreso";

            this.txtCampo1.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtCampo1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo1.Location = new System.Drawing.Point(700, 367);
            this.txtCampo1.Name = "txtCampo1";
            this.txtCampo1.ReadOnly = true;
            this.txtCampo1.Size = new System.Drawing.Size(220, 25);
            this.txtCampo1.TabIndex = 6;
            this.txtCampo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // Campo 2
            // ====================================================================
            this.lblCampo2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCampo2.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCampo2.Location = new System.Drawing.Point(30, 415);
            this.lblCampo2.Name = "lblCampo2";
            this.lblCampo2.Size = new System.Drawing.Size(600, 24);
            this.lblCampo2.Text = "ISR retenido a adicionar";

            this.lblSigno2.AutoSize = true;
            this.lblSigno2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno2.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblSigno2.Location = new System.Drawing.Point(660, 418);
            this.lblSigno2.Name = "lblSigno2";
            this.lblSigno2.Text = "(+)";

            this.txtCampo2.BackColor = System.Drawing.Color.White;
            this.txtCampo2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo2.Location = new System.Drawing.Point(700, 412);
            this.txtCampo2.Name = "txtCampo2";
            this.txtCampo2.Size = new System.Drawing.Size(220, 25);
            this.txtCampo2.TabIndex = 7;
            this.txtCampo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // Campo 3
            // ====================================================================
            this.lblCampo3.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCampo3.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCampo3.Location = new System.Drawing.Point(30, 460);
            this.lblCampo3.Name = "lblCampo3";
            this.lblCampo3.Size = new System.Drawing.Size(600, 24);
            this.lblCampo3.Text = "ISR retenido no acreditable";

            this.lblSigno3.AutoSize = true;
            this.lblSigno3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno3.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblSigno3.Location = new System.Drawing.Point(660, 463);
            this.lblSigno3.Name = "lblSigno3";
            this.lblSigno3.Text = "(-)";

            this.txtCampo3.BackColor = System.Drawing.Color.White;
            this.txtCampo3.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo3.Location = new System.Drawing.Point(700, 457);
            this.txtCampo3.Name = "txtCampo3";
            this.txtCampo3.Size = new System.Drawing.Size(220, 25);
            this.txtCampo3.TabIndex = 8;
            this.txtCampo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // Campo 4
            // ====================================================================
            this.lblCampo4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblCampo4.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCampo4.Location = new System.Drawing.Point(30, 510);
            this.lblCampo4.Name = "lblCampo4";
            this.lblCampo4.Size = new System.Drawing.Size(600, 40);
            this.lblCampo4.Text = "Total de ISR retenido considerado para efectos del acreditamiento";

            this.lblSigno4.AutoSize = true;
            this.lblSigno4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno4.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblSigno4.Location = new System.Drawing.Point(660, 513);
            this.lblSigno4.Name = "lblSigno4";
            this.lblSigno4.Text = "(=)";

            this.txtCampo4.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtCampo4.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCampo4.Location = new System.Drawing.Point(700, 507);
            this.txtCampo4.Name = "txtCampo4";
            this.txtCampo4.ReadOnly = true;
            this.txtCampo4.Size = new System.Drawing.Size(220, 25);
            this.txtCampo4.TabIndex = 9;
            this.txtCampo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // btnCerrar
            // ====================================================================
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1265, 575);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(105, 36);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ====================================================================
            // fmDetalleIsrRetenido
            // ====================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.pnlCuerpoBlanco);
            this.Controls.Add(this.pnlTituloAzul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDetalleIsrRetenido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ISR Retenido";
            this.Load += new System.EventHandler(this.fmDetalleIsrRetenido_Load); // ← ESTA LÍNEA FALTABA — causa raíz del problema

            this.pnlTituloAzul.ResumeLayout(false);
            this.pnlTituloAzul.PerformLayout();
            this.pnlCuerpoBlanco.ResumeLayout(false);
            this.pnlCuerpoBlanco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla2)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTituloAzul;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Button btnIconoCerrar;
        private System.Windows.Forms.Panel pnlCuerpoBlanco;
        private System.Windows.Forms.Label lblExplicacion1;
        private System.Windows.Forms.Label lblTextoTabla1;
        private System.Windows.Forms.DataGridView dgvTabla1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Label lblTextoTabla2;
        private System.Windows.Forms.DataGridView dgvTabla2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblCampo1;
        private System.Windows.Forms.TextBox txtCampo1;
        private System.Windows.Forms.Label lblCampo2;
        private System.Windows.Forms.Label lblSigno2;
        private System.Windows.Forms.TextBox txtCampo2;
        private System.Windows.Forms.Label lblCampo3;
        private System.Windows.Forms.Label lblSigno3;
        private System.Windows.Forms.TextBox txtCampo3;
        private System.Windows.Forms.Label lblCampo4;
        private System.Windows.Forms.Label lblSigno4;
        private System.Windows.Forms.TextBox txtCampo4;
        private System.Windows.Forms.Button btnCerrar;
    }
}