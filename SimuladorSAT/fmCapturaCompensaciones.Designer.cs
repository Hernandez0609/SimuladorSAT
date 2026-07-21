namespace SimuladorSAT
{
    partial class fmCapturaCompensaciones
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
            this.lblTotalHeader = new System.Windows.Forms.Label();

            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlFormularioCaptura = new System.Windows.Forms.Panel();

            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblPeriocidad = new System.Windows.Forms.Label();
            this.cmbPeriocidad = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblEjercicio = new System.Windows.Forms.Label();
            this.cmbEjercicio = new System.Windows.Forms.ComboBox();

            this.lblFechaCausacion = new System.Windows.Forms.Label();
            this.txtFechaCausacion = new System.Windows.Forms.TextBox();
            this.lblNumOperacion1 = new System.Windows.Forms.Label();
            this.txtNumOperacion1 = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblSaldoAplicar = new System.Windows.Forms.Label();
            this.txtSaldoAplicar = new System.Windows.Forms.TextBox();

            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.pnlDivisor = new System.Windows.Forms.Panel();

            this.lblTipoDeclaracion = new System.Windows.Forms.Label();
            this.cmbTipoDeclaracion = new System.Windows.Forms.ComboBox();
            this.lblNumOperacion2 = new System.Windows.Forms.Label();
            this.txtNumOperacion2 = new System.Windows.Forms.TextBox();
            this.lblMontoSaldoOriginal = new System.Windows.Forms.Label();
            this.txtMontoSaldoOriginal = new System.Windows.Forms.TextBox();
            this.lblRemanenteHistorico = new System.Windows.Forms.Label();
            this.txtRemanenteHistorico = new System.Windows.Forms.TextBox();
            this.lblFechaPresentoDeclaracion = new System.Windows.Forms.Label();
            this.txtFechaPresentoDeclaracion = new System.Windows.Forms.TextBox();
            this.lblRemanenteActualizado = new System.Windows.Forms.Label();
            this.txtRemanenteActualizado = new System.Windows.Forms.TextBox();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ====================================================================
            // pnlTitulo
            // ====================================================================
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlTitulo.Controls.Add(this.lblTituloModal);
            this.pnlTitulo.Controls.Add(this.lblTotalHeader);
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
            this.lblTituloModal.Text = "Compensaciones";

            this.lblTotalHeader.AutoSize = true;
            this.lblTotalHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalHeader.Font = new System.Drawing.Font("Arial", 13F);
            this.lblTotalHeader.ForeColor = System.Drawing.Color.White;
            this.lblTotalHeader.Location = new System.Drawing.Point(1230, 25);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.TabIndex = 1;
            this.lblTotalHeader.Text = "Total: $0";

            // ====================================================================
            // pnlCuerpo
            // ====================================================================
            this.pnlCuerpo.AutoScroll = true;
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlFormularioCaptura);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 70);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1400, 0);
            this.pnlCuerpo.TabIndex = 1;

            // ====================================================================
            // pnlFormularioCaptura — margen 50px izq/der, 70px arriba/abajo (simétrico)
            // ====================================================================
            this.pnlFormularioCaptura.Location = new System.Drawing.Point(50, 70);
            this.pnlFormularioCaptura.Name = "pnlFormularioCaptura";
            this.pnlFormularioCaptura.Size = new System.Drawing.Size(1300, 460);
            this.pnlFormularioCaptura.TabIndex = 0;
            this.pnlFormularioCaptura.Visible = false;
            this.pnlFormularioCaptura.Controls.Add(this.lblTipo);
            this.pnlFormularioCaptura.Controls.Add(this.cmbTipo);
            this.pnlFormularioCaptura.Controls.Add(this.lblPeriocidad);
            this.pnlFormularioCaptura.Controls.Add(this.cmbPeriocidad);
            this.pnlFormularioCaptura.Controls.Add(this.lblPeriodo);
            this.pnlFormularioCaptura.Controls.Add(this.cmbPeriodo);
            this.pnlFormularioCaptura.Controls.Add(this.lblEjercicio);
            this.pnlFormularioCaptura.Controls.Add(this.cmbEjercicio);
            this.pnlFormularioCaptura.Controls.Add(this.lblFechaCausacion);
            this.pnlFormularioCaptura.Controls.Add(this.txtFechaCausacion);
            this.pnlFormularioCaptura.Controls.Add(this.lblNumOperacion1);
            this.pnlFormularioCaptura.Controls.Add(this.txtNumOperacion1);
            this.pnlFormularioCaptura.Controls.Add(this.lblConcepto);
            this.pnlFormularioCaptura.Controls.Add(this.cmbConcepto);
            this.pnlFormularioCaptura.Controls.Add(this.lblSaldoAplicar);
            this.pnlFormularioCaptura.Controls.Add(this.txtSaldoAplicar);
            this.pnlFormularioCaptura.Controls.Add(this.btnContinuar);
            this.pnlFormularioCaptura.Controls.Add(this.btnEliminar);
            this.pnlFormularioCaptura.Controls.Add(this.pnlDivisor);
            this.pnlFormularioCaptura.Controls.Add(this.lblTipoDeclaracion);
            this.pnlFormularioCaptura.Controls.Add(this.cmbTipoDeclaracion);
            this.pnlFormularioCaptura.Controls.Add(this.lblNumOperacion2);
            this.pnlFormularioCaptura.Controls.Add(this.txtNumOperacion2);
            this.pnlFormularioCaptura.Controls.Add(this.lblMontoSaldoOriginal);
            this.pnlFormularioCaptura.Controls.Add(this.txtMontoSaldoOriginal);
            this.pnlFormularioCaptura.Controls.Add(this.lblRemanenteHistorico);
            this.pnlFormularioCaptura.Controls.Add(this.txtRemanenteHistorico);
            this.pnlFormularioCaptura.Controls.Add(this.lblFechaPresentoDeclaracion);
            this.pnlFormularioCaptura.Controls.Add(this.txtFechaPresentoDeclaracion);
            this.pnlFormularioCaptura.Controls.Add(this.lblRemanenteActualizado);
            this.pnlFormularioCaptura.Controls.Add(this.txtRemanenteActualizado);

            // ---- FILA 1: 4 columnas, X = 0, 330, 660, 990, ancho 290 c/u ----
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

            this.lblPeriocidad.AutoSize = true;
            this.lblPeriocidad.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriocidad.Location = new System.Drawing.Point(330, 0);
            this.lblPeriocidad.Text = "Periocidad";

            this.cmbPeriocidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriocidad.Enabled = false;
            this.cmbPeriocidad.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbPeriocidad.Location = new System.Drawing.Point(330, 25);
            this.cmbPeriocidad.Size = new System.Drawing.Size(290, 28);
            this.cmbPeriocidad.Items.AddRange(new object[] { "-Seleccione-", "1-Mensual", "Del ejercicio" });
            this.cmbPeriocidad.SelectedIndex = 0;
            this.cmbPeriocidad.SelectedIndexChanged += new System.EventHandler(this.cmbPeriocidad_SelectedIndexChanged);

            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriodo.Location = new System.Drawing.Point(660, 0);
            this.lblPeriodo.Text = "Período";

            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.Enabled = false;
            this.cmbPeriodo.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbPeriodo.Location = new System.Drawing.Point(660, 25);
            this.cmbPeriodo.Size = new System.Drawing.Size(290, 28);
            this.cmbPeriodo.Items.AddRange(new object[] {
                "-Seleccione-", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });
            this.cmbPeriodo.SelectedIndex = 0;
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
            this.cmbEjercicio.IntegralHeight = false; // Desactiva el cálculo automático de Windows
            this.cmbEjercicio.DropDownHeight = 180;
            this.cmbEjercicio.SelectedIndexChanged += new System.EventHandler(this.cmbEjercicio_SelectedIndexChanged);

            // ---- FILA 2: mismas 4 columnas ----
            this.lblFechaCausacion.AutoSize = true;
            this.lblFechaCausacion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFechaCausacion.Location = new System.Drawing.Point(0, 70);
            this.lblFechaCausacion.Text = "Fecha de causación (dd-mm-aaaa)";

            this.txtFechaCausacion.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtFechaCausacion.Enabled = false;
            this.txtFechaCausacion.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFechaCausacion.Location = new System.Drawing.Point(0, 95);
            this.txtFechaCausacion.Size = new System.Drawing.Size(290, 28);

            this.lblNumOperacion1.AutoSize = true;
            this.lblNumOperacion1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNumOperacion1.Location = new System.Drawing.Point(330, 70);
            this.lblNumOperacion1.Text = "Número de operación";

            this.txtNumOperacion1.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtNumOperacion1.Enabled = false;
            this.txtNumOperacion1.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNumOperacion1.Location = new System.Drawing.Point(330, 95);
            this.txtNumOperacion1.Size = new System.Drawing.Size(290, 28);

            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConcepto.Location = new System.Drawing.Point(660, 70);
            this.lblConcepto.Text = "Concepto";

            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.Enabled = false;
            this.cmbConcepto.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbConcepto.Location = new System.Drawing.Point(660, 95);
            this.cmbConcepto.Size = new System.Drawing.Size(290, 28);
            this.cmbConcepto.Items.AddRange(new object[] { "-Seleccione-", "ISR simplificado de confianza. Personas físicas" });
            this.cmbConcepto.SelectedIndex = 0;
            this.cmbConcepto.SelectedIndexChanged += new System.EventHandler(this.cmbConcepto_SelectedIndexChanged);

            this.lblSaldoAplicar.AutoSize = true;
            this.lblSaldoAplicar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSaldoAplicar.Location = new System.Drawing.Point(990, 70);
            this.lblSaldoAplicar.Text = "Saldo a aplicar";

            this.txtSaldoAplicar.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtSaldoAplicar.Enabled = false;
            this.txtSaldoAplicar.Font = new System.Drawing.Font("Arial", 10F);
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
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);

            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnEliminar.Location = new System.Drawing.Point(180, 150);
            this.btnEliminar.Size = new System.Drawing.Size(160, 38);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ---- Divisor ----
            this.pnlDivisor.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.pnlDivisor.Location = new System.Drawing.Point(0, 215);
            this.pnlDivisor.Size = new System.Drawing.Size(1300, 1);

            // ---- Sección gris — Columna A: X=0/280, Columna B: X=720/980 ----
            this.lblTipoDeclaracion.AutoSize = true;
            this.lblTipoDeclaracion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTipoDeclaracion.Location = new System.Drawing.Point(0, 250);
            this.lblTipoDeclaracion.Text = "Tipo de declaración";

            this.cmbTipoDeclaracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeclaracion.Enabled = false;
            this.cmbTipoDeclaracion.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTipoDeclaracion.Location = new System.Drawing.Point(280, 247);
            this.cmbTipoDeclaracion.Size = new System.Drawing.Size(370, 28);
            this.cmbTipoDeclaracion.Items.AddRange(new object[] {
                "-Seleccione-", "Normal", "Complementaria", "Normal por Corrección Fiscal",
                "Complementaria por Corrección Fiscal", "Complementaria por Dictamen", "Complementaria Esquema Anterior" });
            this.cmbTipoDeclaracion.SelectedIndex = 0;

            this.lblNumOperacion2.AutoSize = true;
            this.lblNumOperacion2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNumOperacion2.Location = new System.Drawing.Point(720, 250);
            this.lblNumOperacion2.Text = "Número de operación";

            this.txtNumOperacion2.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtNumOperacion2.Enabled = false;
            this.txtNumOperacion2.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNumOperacion2.Location = new System.Drawing.Point(980, 247);
            this.txtNumOperacion2.Size = new System.Drawing.Size(320, 28);

            this.lblMontoSaldoOriginal.AutoSize = true;
            this.lblMontoSaldoOriginal.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMontoSaldoOriginal.Location = new System.Drawing.Point(0, 305);
            this.lblMontoSaldoOriginal.Text = "Monto del saldo a favor original";

            this.txtMontoSaldoOriginal.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtMontoSaldoOriginal.Enabled = false;
            this.txtMontoSaldoOriginal.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMontoSaldoOriginal.Location = new System.Drawing.Point(280, 302);
            this.txtMontoSaldoOriginal.Size = new System.Drawing.Size(370, 28);
            this.txtMontoSaldoOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblRemanenteHistorico.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemanenteHistorico.Location = new System.Drawing.Point(720, 305);
            this.lblRemanenteHistorico.Size = new System.Drawing.Size(255, 40);
            this.lblRemanenteHistorico.Text = "Remanente histórico antes de la aplicación";

            this.txtRemanenteHistorico.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtRemanenteHistorico.Enabled = false;
            this.txtRemanenteHistorico.Font = new System.Drawing.Font("Arial", 10F);
            this.txtRemanenteHistorico.Location = new System.Drawing.Point(980, 315);
            this.txtRemanenteHistorico.Size = new System.Drawing.Size(320, 28);
            this.txtRemanenteHistorico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblFechaPresentoDeclaracion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFechaPresentoDeclaracion.Location = new System.Drawing.Point(0, 375);
            this.lblFechaPresentoDeclaracion.Size = new System.Drawing.Size(260, 60);
            this.lblFechaPresentoDeclaracion.Text = "Fecha en que se presentó la declaración del saldo a favor (dd-mm-aaaa)";

            this.txtFechaPresentoDeclaracion.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtFechaPresentoDeclaracion.Enabled = false;
            this.txtFechaPresentoDeclaracion.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFechaPresentoDeclaracion.Location = new System.Drawing.Point(280, 385);
            this.txtFechaPresentoDeclaracion.Size = new System.Drawing.Size(370, 28);

            this.lblRemanenteActualizado.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemanenteActualizado.Location = new System.Drawing.Point(720, 375);
            this.lblRemanenteActualizado.Size = new System.Drawing.Size(255, 40);
            this.lblRemanenteActualizado.Text = "Remanente actualizado antes de la aplicación";

            this.txtRemanenteActualizado.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.txtRemanenteActualizado.Enabled = false;
            this.txtRemanenteActualizado.Font = new System.Drawing.Font("Arial", 10F);
            this.txtRemanenteActualizado.Location = new System.Drawing.Point(980, 385);
            this.txtRemanenteActualizado.Size = new System.Drawing.Size(320, 28);
            this.txtRemanenteActualizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ====================================================================
            // pnlFooter
            // ====================================================================
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnAgregar);
            this.pnlFooter.Controls.Add(this.btnTerminar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1400, 80);
            this.pnlFooter.TabIndex = 2;

            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTerminar.Location = new System.Drawing.Point(1250, 22);
            this.btnTerminar.Size = new System.Drawing.Size(120, 36);
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);

            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(1110, 22);
            this.btnAgregar.Size = new System.Drawing.Size(120, 36);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(970, 22);
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ====================================================================
            // Form — AutoScaleMode.None ELIMINA el descuadre por escalado de fuente
            // ====================================================================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 150);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmCapturaCompensaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compensaciones";

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Label lblTotalHeader;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlFormularioCaptura;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblPeriocidad;
        private System.Windows.Forms.ComboBox cmbPeriocidad;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblEjercicio;
        private System.Windows.Forms.ComboBox cmbEjercicio;
        private System.Windows.Forms.Label lblFechaCausacion;
        private System.Windows.Forms.TextBox txtFechaCausacion;
        private System.Windows.Forms.Label lblNumOperacion1;
        private System.Windows.Forms.TextBox txtNumOperacion1;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblSaldoAplicar;
        private System.Windows.Forms.TextBox txtSaldoAplicar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlDivisor;
        private System.Windows.Forms.Label lblTipoDeclaracion;
        private System.Windows.Forms.ComboBox cmbTipoDeclaracion;
        private System.Windows.Forms.Label lblNumOperacion2;
        private System.Windows.Forms.TextBox txtNumOperacion2;
        private System.Windows.Forms.Label lblMontoSaldoOriginal;
        private System.Windows.Forms.TextBox txtMontoSaldoOriginal;
        private System.Windows.Forms.Label lblRemanenteHistorico;
        private System.Windows.Forms.TextBox txtRemanenteHistorico;
        private System.Windows.Forms.Label lblFechaPresentoDeclaracion;
        private System.Windows.Forms.TextBox txtFechaPresentoDeclaracion;
        private System.Windows.Forms.Label lblRemanenteActualizado;
        private System.Windows.Forms.TextBox txtRemanenteActualizado;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnTerminar;
    }
}