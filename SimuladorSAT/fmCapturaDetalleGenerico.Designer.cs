namespace SimuladorSAT
{
    partial class fmCapturaDetalleGenerico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotalMonto = new System.Windows.Forms.Label();

            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();

            this.pnlFormularioCaptura = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblPeriodicidad = new System.Windows.Forms.Label();
            this.cmbPeriodicidad = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblEjercicio = new System.Windows.Forms.Label();
            this.cmbEjercicio = new System.Windows.Forms.ComboBox();

            this.lblFechaCausacion = new System.Windows.Forms.Label();
            this.txtFechaCausacion = new System.Windows.Forms.TextBox();
            this.lblNumOp1 = new System.Windows.Forms.Label();
            this.txtNumOp1 = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblSaldoAplicar = new System.Windows.Forms.Label();
            this.txtSaldoAplicar = new System.Windows.Forms.TextBox();

            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.pnlDivisor = new System.Windows.Forms.Panel();

            this.lblTipoDecl = new System.Windows.Forms.Label();
            this.cmbTipoDecl = new System.Windows.Forms.ComboBox();
            this.lblNumOp2 = new System.Windows.Forms.Label();
            this.txtNumOp2 = new System.Windows.Forms.TextBox();
            this.lblMontoSaldo = new System.Windows.Forms.Label();
            this.txtMontoSaldo = new System.Windows.Forms.TextBox();
            this.lblRemanHist = new System.Windows.Forms.Label();
            this.txtRemanHist = new System.Windows.Forms.TextBox();
            this.lblFechaDecl = new System.Windows.Forms.Label();
            this.txtFechaDecl = new System.Windows.Forms.TextBox();
            this.lblRemanAct = new System.Windows.Forms.Label();
            this.txtRemanAct = new System.Windows.Forms.TextBox();

            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();

            this.pnlHeader.SuspendLayout();
            this.pnlFormularioCaptura.SuspendLayout();
            this.SuspendLayout();

            // ====================================================================
            // pnlHeader
            // ====================================================================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblTotalMonto);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1400, 70);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Compensaciones";

            this.lblTotalMonto.AutoSize = true;
            this.lblTotalMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMonto.Font = new System.Drawing.Font("Arial", 13F);
            this.lblTotalMonto.ForeColor = System.Drawing.Color.White;
            this.lblTotalMonto.Location = new System.Drawing.Point(1230, 25);
            this.lblTotalMonto.Name = "lblTotalMonto";
            this.lblTotalMonto.Text = "Total: $0";

            // ====================================================================
            // btnAgregar / btnCancelar / btnTerminar — DIRECTO en el Form,
            // Anchor Bottom|Right, en fila: Cancelar - Agregar - Terminar
            // ====================================================================
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(970, 590);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.Text = "Cancelar";

            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(1110, 590);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 36);
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;

            this.btnTerminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTerminar.Location = new System.Drawing.Point(1250, 590);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(120, 36);
            this.btnTerminar.Text = "Terminar";

            // ====================================================================
            // pnlFormularioCaptura — nace oculto
            // ====================================================================
            this.pnlFormularioCaptura.Location = new System.Drawing.Point(50, 20);
            this.pnlFormularioCaptura.Name = "pnlFormularioCaptura";
            this.pnlFormularioCaptura.Size = new System.Drawing.Size(1300, 460);
            this.pnlFormularioCaptura.TabIndex = 2;
            this.pnlFormularioCaptura.Visible = false;
            this.pnlFormularioCaptura.Controls.Add(this.lblTipo);
            this.pnlFormularioCaptura.Controls.Add(this.cmbTipo);
            this.pnlFormularioCaptura.Controls.Add(this.lblPeriodicidad);
            this.pnlFormularioCaptura.Controls.Add(this.cmbPeriodicidad);
            this.pnlFormularioCaptura.Controls.Add(this.lblPeriodo);
            this.pnlFormularioCaptura.Controls.Add(this.cmbPeriodo);
            this.pnlFormularioCaptura.Controls.Add(this.lblEjercicio);
            this.pnlFormularioCaptura.Controls.Add(this.cmbEjercicio);
            this.pnlFormularioCaptura.Controls.Add(this.lblFechaCausacion);
            this.pnlFormularioCaptura.Controls.Add(this.txtFechaCausacion);
            this.pnlFormularioCaptura.Controls.Add(this.lblNumOp1);
            this.pnlFormularioCaptura.Controls.Add(this.txtNumOp1);
            this.pnlFormularioCaptura.Controls.Add(this.lblConcepto);
            this.pnlFormularioCaptura.Controls.Add(this.cmbConcepto);
            this.pnlFormularioCaptura.Controls.Add(this.lblSaldoAplicar);
            this.pnlFormularioCaptura.Controls.Add(this.txtSaldoAplicar);
            this.pnlFormularioCaptura.Controls.Add(this.btnContinuar);
            this.pnlFormularioCaptura.Controls.Add(this.btnEliminar);
            this.pnlFormularioCaptura.Controls.Add(this.pnlDivisor);
            this.pnlFormularioCaptura.Controls.Add(this.lblTipoDecl);
            this.pnlFormularioCaptura.Controls.Add(this.cmbTipoDecl);
            this.pnlFormularioCaptura.Controls.Add(this.lblNumOp2);
            this.pnlFormularioCaptura.Controls.Add(this.txtNumOp2);
            this.pnlFormularioCaptura.Controls.Add(this.lblMontoSaldo);
            this.pnlFormularioCaptura.Controls.Add(this.txtMontoSaldo);
            this.pnlFormularioCaptura.Controls.Add(this.lblRemanHist);
            this.pnlFormularioCaptura.Controls.Add(this.txtRemanHist);
            this.pnlFormularioCaptura.Controls.Add(this.lblFechaDecl);
            this.pnlFormularioCaptura.Controls.Add(this.txtFechaDecl);
            this.pnlFormularioCaptura.Controls.Add(this.lblRemanAct);
            this.pnlFormularioCaptura.Controls.Add(this.txtRemanAct);

            // ---- FILA 1: Tipo | Periodicidad | Período | Ejercicio ----
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTipo.Location = new System.Drawing.Point(0, 0);
            this.lblTipo.Text = "Tipo";

            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTipo.Location = new System.Drawing.Point(0, 25);
            this.cmbTipo.Size = new System.Drawing.Size(290, 28);
            this.cmbTipo.Items.AddRange(new object[] { "-Seleccione-", "Pago de lo indebido", "Saldo a favor" });
            this.cmbTipo.SelectedIndex = 0;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);

            this.lblPeriodicidad.AutoSize = true;
            this.lblPeriodicidad.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriodicidad.Location = new System.Drawing.Point(330, 0);
            this.lblPeriodicidad.Text = "Periodicidad";

            this.cmbPeriodicidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodicidad.Enabled = false;
            this.cmbPeriodicidad.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbPeriodicidad.Location = new System.Drawing.Point(330, 25);
            this.cmbPeriodicidad.Size = new System.Drawing.Size(290, 28);
            this.cmbPeriodicidad.Items.AddRange(new object[] { "-Seleccione-", "Mensual" });
            this.cmbPeriodicidad.SelectedIndex = 0;
            this.cmbPeriodicidad.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodicidad_SelectedIndexChanged);

            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriodo.Location = new System.Drawing.Point(660, 0);
            this.lblPeriodo.Text = "Período";

            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.Enabled = false;
            this.cmbPeriodo.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbPeriodo.Location = new System.Drawing.Point(660, 25);
            this.cmbPeriodo.Size = new System.Drawing.Size(290, 28);
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);

            this.lblEjercicio.AutoSize = true;
            this.lblEjercicio.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEjercicio.Location = new System.Drawing.Point(990, 0);
            this.lblEjercicio.Text = "Ejercicio";

            this.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEjercicio.Enabled = false;
            this.cmbEjercicio.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbEjercicio.Location = new System.Drawing.Point(990, 25);
            this.cmbEjercicio.Size = new System.Drawing.Size(290, 28);
            this.cmbEjercicio.IntegralHeight = false; 
            this.cmbEjercicio.DropDownHeight = 180;
            this.cmbEjercicio.SelectedIndexChanged += new System.EventHandler(this.cmbEjercicio_SelectedIndexChanged);

            // ---- FILA 2: Fecha causación | Núm. operación | Concepto | Saldo a aplicar ----
            this.lblFechaCausacion.AutoSize = true;
            this.lblFechaCausacion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFechaCausacion.Location = new System.Drawing.Point(0, 70);
            this.lblFechaCausacion.Text = "Fecha de causación (dd-mm-aaaa)";

            this.txtFechaCausacion.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtFechaCausacion.Enabled = false;
            this.txtFechaCausacion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtFechaCausacion.Location = new System.Drawing.Point(0, 95);
            this.txtFechaCausacion.Size = new System.Drawing.Size(290, 28);

            this.lblNumOp1.AutoSize = true;
            this.lblNumOp1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNumOp1.Location = new System.Drawing.Point(330, 70);
            this.lblNumOp1.Text = "Número de operación";

            this.txtNumOp1.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtNumOp1.Enabled = false;
            this.txtNumOp1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNumOp1.Location = new System.Drawing.Point(330, 95);
            this.txtNumOp1.Size = new System.Drawing.Size(290, 28);

            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConcepto.Location = new System.Drawing.Point(660, 70);
            this.lblConcepto.Text = "Concepto";

            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.Enabled = false;
            this.cmbConcepto.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbConcepto.Location = new System.Drawing.Point(660, 95);
            this.cmbConcepto.Size = new System.Drawing.Size(290, 28);
            this.cmbConcepto.Items.AddRange(new object[] { "-Seleccione-", "IVA simplificado de confianza" });
            this.cmbConcepto.SelectedIndex = 0;
            this.cmbConcepto.SelectedIndexChanged += new System.EventHandler(this.cmbConcepto_SelectedIndexChanged);

            this.lblSaldoAplicar.AutoSize = true;
            this.lblSaldoAplicar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSaldoAplicar.Location = new System.Drawing.Point(990, 70);
            this.lblSaldoAplicar.Text = "Saldo a aplicar";

            this.txtSaldoAplicar.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtSaldoAplicar.Enabled = false;
            this.txtSaldoAplicar.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSaldoAplicar.Location = new System.Drawing.Point(990, 95);
            this.txtSaldoAplicar.Size = new System.Drawing.Size(290, 28);
            this.txtSaldoAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ---- Continuar / Eliminar ----
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.Location = new System.Drawing.Point(0, 150);
            this.btnContinuar.Size = new System.Drawing.Size(160, 38);
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            //this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);

            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnEliminar.Location = new System.Drawing.Point(180, 150);
            this.btnEliminar.Size = new System.Drawing.Size(160, 38);
            this.btnEliminar.Text = "Eliminar";
            //this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ---- Divisor ----
            this.pnlDivisor.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.pnlDivisor.Location = new System.Drawing.Point(0, 215);
            this.pnlDivisor.Size = new System.Drawing.Size(1300, 1);

            // ---- Sección gris (siempre visible, inicia deshabilitada) ----
            this.lblTipoDecl.AutoSize = true;
            this.lblTipoDecl.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTipoDecl.Location = new System.Drawing.Point(0, 250);
            this.lblTipoDecl.Text = "Tipo de declaración";

            this.cmbTipoDecl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDecl.Enabled = false;
            this.cmbTipoDecl.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTipoDecl.Location = new System.Drawing.Point(280, 247);
            this.cmbTipoDecl.Size = new System.Drawing.Size(370, 28);
            this.cmbTipoDecl.Items.AddRange(new object[] { "-Seleccione-", "Normal", "Complementaria" });
            this.cmbTipoDecl.SelectedIndex = 0;

            this.lblNumOp2.AutoSize = true;
            this.lblNumOp2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNumOp2.Location = new System.Drawing.Point(720, 250);
            this.lblNumOp2.Text = "Número de operación";

            this.txtNumOp2.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtNumOp2.Enabled = false;
            this.txtNumOp2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNumOp2.Location = new System.Drawing.Point(980, 247);
            this.txtNumOp2.Size = new System.Drawing.Size(320, 28);

            this.lblMontoSaldo.AutoSize = true;
            this.lblMontoSaldo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMontoSaldo.Location = new System.Drawing.Point(0, 305);
            this.lblMontoSaldo.Text = "Monto del saldo a favor original";

            this.txtMontoSaldo.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtMontoSaldo.Enabled = false;
            this.txtMontoSaldo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtMontoSaldo.Location = new System.Drawing.Point(280, 302);
            this.txtMontoSaldo.Size = new System.Drawing.Size(370, 28);
            this.txtMontoSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblRemanHist.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemanHist.Location = new System.Drawing.Point(720, 305);
            this.lblRemanHist.Size = new System.Drawing.Size(255, 40);
            this.lblRemanHist.Text = "Remanente histórico antes de la aplicación";

            this.txtRemanHist.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtRemanHist.Enabled = false;
            this.txtRemanHist.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRemanHist.Location = new System.Drawing.Point(980, 315);
            this.txtRemanHist.Size = new System.Drawing.Size(320, 28);
            this.txtRemanHist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblFechaDecl.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFechaDecl.Location = new System.Drawing.Point(0, 375);
            this.lblFechaDecl.Size = new System.Drawing.Size(260, 60);
            this.lblFechaDecl.Text = "Fecha en que se presentó la declaración del saldo a favor (dd-mm-aaaa)";

            this.txtFechaDecl.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtFechaDecl.Enabled = false;
            this.txtFechaDecl.Font = new System.Drawing.Font("Arial", 9F);
            this.txtFechaDecl.Location = new System.Drawing.Point(280, 385);
            this.txtFechaDecl.Size = new System.Drawing.Size(370, 28);

            this.lblRemanAct.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemanAct.Location = new System.Drawing.Point(720, 375);
            this.lblRemanAct.Size = new System.Drawing.Size(255, 40);
            this.lblRemanAct.Text = "Remanente actualizado antes de la aplicación";

            this.txtRemanAct.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtRemanAct.Enabled = false;
            this.txtRemanAct.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRemanAct.Location = new System.Drawing.Point(980, 385);
            this.txtRemanAct.Size = new System.Drawing.Size(320, 28);
            this.txtRemanAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.AutoScroll = true;
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlFormularioCaptura);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 70);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnAgregar);
            this.pnlFooter.Controls.Add(this.btnTerminar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 570);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1400, 80);
            this.pnlFooter.TabIndex = 3;

            this.btnCancelar.Location = new System.Drawing.Point(970, 22);
            this.btnAgregar.Location = new System.Drawing.Point(1110, 22);
            this.btnTerminar.Location = new System.Drawing.Point(1250, 22);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 650);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmCapturaDetalleGenerico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compensaciones";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormularioCaptura.ResumeLayout(false);
            this.pnlFormularioCaptura.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalMonto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Panel pnlFormularioCaptura;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblPeriodicidad;
        private System.Windows.Forms.ComboBox cmbPeriodicidad;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblEjercicio;
        private System.Windows.Forms.ComboBox cmbEjercicio;
        private System.Windows.Forms.Label lblFechaCausacion;
        private System.Windows.Forms.TextBox txtFechaCausacion;
        private System.Windows.Forms.Label lblNumOp1;
        private System.Windows.Forms.TextBox txtNumOp1;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblSaldoAplicar;
        private System.Windows.Forms.TextBox txtSaldoAplicar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlDivisor;
        private System.Windows.Forms.Label lblTipoDecl;
        private System.Windows.Forms.ComboBox cmbTipoDecl;
        private System.Windows.Forms.Label lblNumOp2;
        private System.Windows.Forms.TextBox txtNumOp2;
        private System.Windows.Forms.Label lblMontoSaldo;
        private System.Windows.Forms.TextBox txtMontoSaldo;
        private System.Windows.Forms.Label lblRemanHist;
        private System.Windows.Forms.TextBox txtRemanHist;
        private System.Windows.Forms.Label lblFechaDecl;
        private System.Windows.Forms.TextBox txtFechaDecl;
        private System.Windows.Forms.Label lblRemanAct;
        private System.Windows.Forms.TextBox txtRemanAct;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlFooter;
    }
}