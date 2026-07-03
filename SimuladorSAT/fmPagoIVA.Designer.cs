namespace SimuladorSAT
{
    partial class fmPagoIVA
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlBotonesSuperior = new System.Windows.Forms.Panel();
            this.btnAdmonDeclaracion = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabDeterminacion = new System.Windows.Forms.Button();
            this.btnTabPago = new System.Windows.Forms.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblCamposObligatorios = new System.Windows.Forms.Label();
            this.lblACargo = new System.Windows.Forms.Label();
            this.txtACargo = new System.Windows.Forms.TextBox();
            this.lblTotalContrib1 = new System.Windows.Forms.Label();
            this.lblMas1 = new System.Windows.Forms.Label();
            this.txtTotalContrib1 = new System.Windows.Forms.TextBox();
            this.lblPregCompensaciones = new System.Windows.Forms.Label();
            this.cmbCompensaciones = new System.Windows.Forms.ComboBox();
            this.lblCompensaciones = new System.Windows.Forms.Label();
            this.lblMasComp = new System.Windows.Forms.Label();
            this.txtCompensaciones = new System.Windows.Forms.TextBox();
            this.btnCapturarComp = new System.Windows.Forms.Button();
            this.lblPregEstimulos = new System.Windows.Forms.Label();
            this.cmbEstimulos = new System.Windows.Forms.ComboBox();
            this.lblEstimulos = new System.Windows.Forms.Label();
            this.lblMasEst = new System.Windows.Forms.Label();
            this.txtEstimulos = new System.Windows.Forms.TextBox();
            this.btnCapturarEst = new System.Windows.Forms.Button();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.lblTotalAplicaciones1 = new System.Windows.Forms.Label();
            this.lblMasApl1 = new System.Windows.Forms.Label();
            this.txtTotalAplicaciones1 = new System.Windows.Forms.TextBox();
            this.lblTotalContrib2 = new System.Windows.Forms.Label();
            this.txtTotalContrib2 = new System.Windows.Forms.TextBox();
            this.lblTotalAplicaciones2 = new System.Windows.Forms.Label();
            this.lblMenosApl2 = new System.Windows.Forms.Label();
            this.txtTotalAplicaciones2 = new System.Windows.Forms.TextBox();
            this.lblCantidadACargo = new System.Windows.Forms.Label();
            this.lblMasCant = new System.Windows.Forms.Label();
            this.txtCantidadACargo = new System.Windows.Forms.TextBox();
            this.lblCantidadAPagar = new System.Windows.Forms.Label();
            this.txtCantidadAPagar = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlBotonesSuperior.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(114)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(229, 21);
            this.lblTitulo.Text = "IVA simplificado de confianza";
            // 
            // pnlBotonesSuperior
            // 
            this.pnlBotonesSuperior.BackColor = System.Drawing.Color.White;
            this.pnlBotonesSuperior.Controls.Add(this.btnAdmonDeclaracion);
            this.pnlBotonesSuperior.Controls.Add(this.btnGuardar);
            this.pnlBotonesSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotonesSuperior.Location = new System.Drawing.Point(0, 50);
            this.pnlBotonesSuperior.Name = "pnlBotonesSuperior";
            this.pnlBotonesSuperior.Size = new System.Drawing.Size(1000, 50);
            this.pnlBotonesSuperior.TabIndex = 1;
            // 
            // btnAdmonDeclaracion
            // 
            this.btnAdmonDeclaracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(114)))));
            this.btnAdmonDeclaracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmonDeclaracion.FlatAppearance.BorderSize = 0;
            this.btnAdmonDeclaracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmonDeclaracion.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAdmonDeclaracion.ForeColor = System.Drawing.Color.White;
            this.btnAdmonDeclaracion.Location = new System.Drawing.Point(580, 10);
            this.btnAdmonDeclaracion.Name = "btnAdmonDeclaracion";
            this.btnAdmonDeclaracion.Size = new System.Drawing.Size(240, 30);
            this.btnAdmonDeclaracion.Text = "Administración de la declaración";
            this.btnAdmonDeclaracion.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(114)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(835, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.Controls.Add(this.btnTabDeterminacion);
            this.pnlTabs.Controls.Add(this.btnTabPago);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 100);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1000, 45);
            this.pnlTabs.TabIndex = 2;
            // 
            // btnTabDeterminacion
            // 
            this.btnTabDeterminacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnTabDeterminacion.FlatAppearance.BorderSize = 0;
            this.btnTabDeterminacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDeterminacion.Font = new System.Drawing.Font("Arial", 9F);
            this.btnTabDeterminacion.ForeColor = System.Drawing.Color.DimGray;
            this.btnTabDeterminacion.Location = new System.Drawing.Point(25, 5);
            this.btnTabDeterminacion.Name = "btnTabDeterminacion";
            this.btnTabDeterminacion.Size = new System.Drawing.Size(140, 35);
            this.btnTabDeterminacion.Text = "Determinación";
            this.btnTabDeterminacion.UseVisualStyleBackColor = false;
            // 
            // btnTabPago
            // 
            this.btnTabPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(114)))));
            this.btnTabPago.FlatAppearance.BorderSize = 0;
            this.btnTabPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabPago.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabPago.ForeColor = System.Drawing.Color.White;
            this.btnTabPago.Location = new System.Drawing.Point(165, 5);
            this.btnTabPago.Name = "btnTabPago";
            this.btnTabPago.Size = new System.Drawing.Size(100, 35);
            this.btnTabPago.Text = "PAGO";
            this.btnTabPago.UseVisualStyleBackColor = false;
            // 
            // pnlContenido
            // 
            this.pnlContenido.AutoScroll = true;
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.lblCamposObligatorios);
            this.pnlContenido.Controls.Add(this.lblACargo);
            this.pnlContenido.Controls.Add(this.txtACargo);
            this.pnlContenido.Controls.Add(this.lblTotalContrib1);
            this.pnlContenido.Controls.Add(this.lblMas1);
            this.pnlContenido.Controls.Add(this.txtTotalContrib1);
            this.pnlContenido.Controls.Add(this.lblPregCompensaciones);
            this.pnlContenido.Controls.Add(this.cmbCompensaciones);
            this.pnlContenido.Controls.Add(this.lblCompensaciones);
            this.pnlContenido.Controls.Add(this.lblMasComp);
            this.pnlContenido.Controls.Add(this.txtCompensaciones);
            this.pnlContenido.Controls.Add(this.btnCapturarComp);
            this.pnlContenido.Controls.Add(this.lblPregEstimulos);
            this.pnlContenido.Controls.Add(this.cmbEstimulos);
            this.pnlContenido.Controls.Add(this.lblEstimulos);
            this.pnlContenido.Controls.Add(this.lblMasEst);
            this.pnlContenido.Controls.Add(this.txtEstimulos);
            this.pnlContenido.Controls.Add(this.btnCapturarEst);
            this.pnlContenido.Controls.Add(this.pnlSeparador);
            this.pnlContenido.Controls.Add(this.lblTotalAplicaciones1);
            this.pnlContenido.Controls.Add(this.lblMasApl1);
            this.pnlContenido.Controls.Add(this.txtTotalAplicaciones1);
            this.pnlContenido.Controls.Add(this.lblTotalContrib2);
            this.pnlContenido.Controls.Add(this.txtTotalContrib2);
            this.pnlContenido.Controls.Add(this.lblTotalAplicaciones2);
            this.pnlContenido.Controls.Add(this.lblMenosApl2);
            this.pnlContenido.Controls.Add(this.txtTotalAplicaciones2);
            this.pnlContenido.Controls.Add(this.lblCantidadACargo);
            this.pnlContenido.Controls.Add(this.lblMasCant);
            this.pnlContenido.Controls.Add(this.txtCantidadACargo);
            this.pnlContenido.Controls.Add(this.lblCantidadAPagar);
            this.pnlContenido.Controls.Add(this.txtCantidadAPagar);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 145);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1000, 505);
            this.pnlContenido.TabIndex = 3;
            // 
            // lblCamposObligatorios
            // 
            this.lblCamposObligatorios.AutoSize = true;
            this.lblCamposObligatorios.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblCamposObligatorios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblCamposObligatorios.Location = new System.Drawing.Point(25, 15);
            this.lblCamposObligatorios.Name = "lblCamposObligatorios";
            this.lblCamposObligatorios.Size = new System.Drawing.Size(306, 15);
            this.lblCamposObligatorios.Text = "Los campos marcados con asterisco (*) son obligatorios";
            // 
            // lblACargo
            // 
            this.lblACargo.AutoSize = true;
            this.lblACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblACargo.Location = new System.Drawing.Point(25, 49);
            this.lblACargo.Name = "lblACargo";
            this.lblACargo.Size = new System.Drawing.Size(49, 15);
            this.lblACargo.Text = "A cargo";
            // 
            // txtACargo
            // 
            this.txtACargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtACargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtACargo.Location = new System.Drawing.Point(620, 45);
            this.txtACargo.Name = "txtACargo";
            this.txtACargo.ReadOnly = true;
            this.txtACargo.Size = new System.Drawing.Size(220, 21);
            this.txtACargo.TabIndex = 1;
            this.txtACargo.Text = "0";
            this.txtACargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalContrib1
            // 
            this.lblTotalContrib1.AutoSize = true;
            this.lblTotalContrib1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTotalContrib1.Location = new System.Drawing.Point(25, 87);
            this.lblTotalContrib1.Name = "lblTotalContrib1";
            this.lblTotalContrib1.Size = new System.Drawing.Size(130, 15);
            this.lblTotalContrib1.Text = "Total de contribuciones";
            // 
            // lblMas1
            // 
            this.lblMas1.AutoSize = true;
            this.lblMas1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMas1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMas1.Location = new System.Drawing.Point(590, 87);
            this.lblMas1.Name = "lblMas1";
            this.lblMas1.Size = new System.Drawing.Size(22, 15);
            this.lblMas1.Text = "(+)";
            // 
            // txtTotalContrib1
            // 
            this.txtTotalContrib1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtTotalContrib1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalContrib1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalContrib1.Location = new System.Drawing.Point(620, 83);
            this.txtTotalContrib1.Name = "txtTotalContrib1";
            this.txtTotalContrib1.ReadOnly = true;
            this.txtTotalContrib1.Size = new System.Drawing.Size(220, 21);
            this.txtTotalContrib1.TabIndex = 3;
            this.txtTotalContrib1.Text = "0";
            this.txtTotalContrib1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPregCompensaciones
            // 
            this.lblPregCompensaciones.AutoSize = true;
            this.lblPregCompensaciones.Font = new System.Drawing.Font("Arial", 9F);
            this.lblPregCompensaciones.Location = new System.Drawing.Point(25, 125);
            this.lblPregCompensaciones.Name = "lblPregCompensaciones";
            this.lblPregCompensaciones.Size = new System.Drawing.Size(215, 15);
            this.lblPregCompensaciones.Text = "*¿Tienes compensaciones por aplicar?";
            // 
            // cmbCompensaciones
            // 
            this.cmbCompensaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompensaciones.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbCompensaciones.FormattingEnabled = true;
            this.cmbCompensaciones.Items.AddRange(new object[] { "No", "Si" });
            this.cmbCompensaciones.Location = new System.Drawing.Point(620, 121);
            this.cmbCompensaciones.Name = "cmbCompensaciones";
            this.cmbCompensaciones.Size = new System.Drawing.Size(120, 23);
            this.cmbCompensaciones.TabIndex = 5;
            // 
            // lblCompensaciones
            // 
            this.lblCompensaciones.AutoSize = true;
            this.lblCompensaciones.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCompensaciones.Location = new System.Drawing.Point(40, 163);
            this.lblCompensaciones.Name = "lblCompensaciones";
            this.lblCompensaciones.Size = new System.Drawing.Size(109, 15);
            this.lblCompensaciones.Text = "*Compensaciones";
            this.lblCompensaciones.Visible = false;
            // 
            // lblMasComp
            // 
            this.lblMasComp.AutoSize = true;
            this.lblMasComp.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMasComp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMasComp.Location = new System.Drawing.Point(590, 163);
            this.lblMasComp.Name = "lblMasComp";
            this.lblMasComp.Size = new System.Drawing.Size(22, 15);
            this.lblMasComp.Text = "(+)";
            this.lblMasComp.Visible = false;
            // 
            // txtCompensaciones
            // 
            this.txtCompensaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.txtCompensaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompensaciones.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCompensaciones.Location = new System.Drawing.Point(620, 159);
            this.txtCompensaciones.Name = "txtCompensaciones";
            this.txtCompensaciones.ReadOnly = true;
            this.txtCompensaciones.Size = new System.Drawing.Size(220, 21);
            this.txtCompensaciones.TabIndex = 8;
            this.txtCompensaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCompensaciones.Visible = false;
            // 
            // btnCapturarComp
            // 
            this.btnCapturarComp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnCapturarComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapturarComp.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapturarComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturarComp.Font = new System.Drawing.Font("Arial", 8.5F);
            this.btnCapturarComp.ForeColor = System.Drawing.Color.Black;
            this.btnCapturarComp.Location = new System.Drawing.Point(855, 157);
            this.btnCapturarComp.Name = "btnCapturarComp";
            this.btnCapturarComp.Size = new System.Drawing.Size(85, 25);
            this.btnCapturarComp.Text = "Capturar";
            this.btnCapturarComp.UseVisualStyleBackColor = false;
            this.btnCapturarComp.Visible = false;
            // 
            // lblPregEstimulos
            // 
            this.lblPregEstimulos.AutoSize = true;
            this.lblPregEstimulos.Font = new System.Drawing.Font("Arial", 9F);
            this.lblPregEstimulos.Location = new System.Drawing.Point(25, 201);
            this.lblPregEstimulos.Name = "lblPregEstimulos";
            this.lblPregEstimulos.Size = new System.Drawing.Size(180, 15);
            this.lblPregEstimulos.Text = "*¿Tienes estímulos por aplicar?";
            // 
            // cmbEstimulos
            // 
            this.cmbEstimulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstimulos.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbEstimulos.FormattingEnabled = true;
            this.cmbEstimulos.Items.AddRange(new object[] { "No", "Si" });
            this.cmbEstimulos.Location = new System.Drawing.Point(620, 197);
            this.cmbEstimulos.Name = "cmbEstimulos";
            this.cmbEstimulos.Size = new System.Drawing.Size(120, 23);
            this.cmbEstimulos.TabIndex = 11;
            // 
            // lblEstimulos
            // 
            this.lblEstimulos.AutoSize = true;
            this.lblEstimulos.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEstimulos.Location = new System.Drawing.Point(40, 239);
            this.lblEstimulos.Name = "lblEstimulos";
            this.lblEstimulos.Size = new System.Drawing.Size(181, 15);
            this.lblEstimulos.Text = "*Estímulos al impuesto a cargo";
            this.lblEstimulos.Visible = false;
            // 
            // lblMasEst
            // 
            this.lblMasEst.AutoSize = true;
            this.lblMasEst.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMasEst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMasEst.Location = new System.Drawing.Point(590, 239);
            this.lblMasEst.Name = "lblMasEst";
            this.lblMasEst.Size = new System.Drawing.Size(22, 15);
            this.lblMasEst.Text = "(+)";
            this.lblMasEst.Visible = false;
            // 
            // txtEstimulos
            // 
            this.txtEstimulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.txtEstimulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstimulos.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEstimulos.Location = new System.Drawing.Point(620, 235);
            this.txtEstimulos.Name = "txtEstimulos";
            this.txtEstimulos.ReadOnly = true;
            this.txtEstimulos.Size = new System.Drawing.Size(220, 21);
            this.txtEstimulos.TabIndex = 14;
            this.txtEstimulos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstimulos.Visible = false;
            // 
            // btnCapturarEst
            // 
            this.btnCapturarEst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnCapturarEst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapturarEst.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapturarEst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturarEst.Font = new System.Drawing.Font("Arial", 8.5F);
            this.btnCapturarEst.ForeColor = System.Drawing.Color.Black;
            this.btnCapturarEst.Location = new System.Drawing.Point(855, 233);
            this.btnCapturarEst.Name = "btnCapturarEst";
            this.btnCapturarEst.Size = new System.Drawing.Size(85, 25);
            this.btnCapturarEst.Text = "Capturar";
            this.btnCapturarEst.UseVisualStyleBackColor = false;
            this.btnCapturarEst.Visible = false;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlSeparador.Location = new System.Drawing.Point(25, 275);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(915, 1);
            this.pnlSeparador.TabIndex = 16;
            // 
            // lblTotalAplicaciones1
            // 
            this.lblTotalAplicaciones1.AutoSize = true;
            this.lblTotalAplicaciones1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTotalAplicaciones1.Location = new System.Drawing.Point(25, 295);
            this.lblTotalAplicaciones1.Name = "lblTotalAplicaciones1";
            this.lblTotalAplicaciones1.Size = new System.Drawing.Size(118, 15);
            this.lblTotalAplicaciones1.Text = "Total de aplicaciones";
            // 
            // lblMasApl1
            // 
            this.lblMasApl1.AutoSize = true;
            this.lblMasApl1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMasApl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMasApl1.Location = new System.Drawing.Point(590, 295);
            this.lblMasApl1.Name = "lblMasApl1";
            this.lblMasApl1.Size = new System.Drawing.Size(22, 15);
            this.lblMasApl1.Text = "(+)";
            // 
            // txtTotalAplicaciones1
            // 
            this.txtTotalAplicaciones1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtTotalAplicaciones1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAplicaciones1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalAplicaciones1.Location = new System.Drawing.Point(620, 291);
            this.txtTotalAplicaciones1.Name = "txtTotalAplicaciones1";
            this.txtTotalAplicaciones1.ReadOnly = true;
            this.txtTotalAplicaciones1.Size = new System.Drawing.Size(220, 21);
            this.txtTotalAplicaciones1.TabIndex = 19;
            this.txtTotalAplicaciones1.Text = "0";
            this.txtTotalAplicaciones1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalContrib2
            // 
            this.lblTotalContrib2.AutoSize = true;
            this.lblTotalContrib2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTotalContrib2.Location = new System.Drawing.Point(25, 333);
            this.lblTotalContrib2.Name = "lblTotalContrib2";
            this.lblTotalContrib2.Size = new System.Drawing.Size(130, 15);
            this.lblTotalContrib2.Text = "Total de contribuciones";
            // 
            // txtTotalContrib2
            // 
            this.txtTotalContrib2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtTotalContrib2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalContrib2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalContrib2.Location = new System.Drawing.Point(620, 329);
            this.txtTotalContrib2.Name = "txtTotalContrib2";
            this.txtTotalContrib2.ReadOnly = true;
            this.txtTotalContrib2.Size = new System.Drawing.Size(220, 21);
            this.txtTotalContrib2.TabIndex = 21;
            this.txtTotalContrib2.Text = "0";
            this.txtTotalContrib2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAplicaciones2
            // 
            this.lblTotalAplicaciones2.AutoSize = true;
            this.lblTotalAplicaciones2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTotalAplicaciones2.Location = new System.Drawing.Point(25, 371);
            this.lblTotalAplicaciones2.Name = "lblTotalAplicaciones2";
            this.lblTotalAplicaciones2.Size = new System.Drawing.Size(118, 15);
            this.lblTotalAplicaciones2.Text = "Total de aplicaciones";
            // 
            // lblMenosApl2
            // 
            this.lblMenosApl2.AutoSize = true;
            this.lblMenosApl2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMenosApl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMenosApl2.Location = new System.Drawing.Point(593, 371);
            this.lblMenosApl2.Name = "lblMenosApl2";
            this.lblMenosApl2.Size = new System.Drawing.Size(19, 15);
            this.lblMenosApl2.Text = "(-)";
            // 
            // txtTotalAplicaciones2
            // 
            this.txtTotalAplicaciones2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtTotalAplicaciones2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAplicaciones2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalAplicaciones2.Location = new System.Drawing.Point(620, 367);
            this.txtTotalAplicaciones2.Name = "txtTotalAplicaciones2";
            this.txtTotalAplicaciones2.ReadOnly = true;
            this.txtTotalAplicaciones2.Size = new System.Drawing.Size(220, 21);
            this.txtTotalAplicaciones2.TabIndex = 24;
            this.txtTotalAplicaciones2.Text = "0";
            this.txtTotalAplicaciones2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCantidadACargo
            // 
            this.lblCantidadACargo.AutoSize = true;
            this.lblCantidadACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCantidadACargo.Location = new System.Drawing.Point(25, 409);
            this.lblCantidadACargo.Name = "lblCantidadACargo";
            this.lblCantidadACargo.Size = new System.Drawing.Size(102, 15);
            this.lblCantidadACargo.Text = "Cantidad a cargo";
            // 
            // lblMasCant
            // 
            this.lblMasCant.AutoSize = true;
            this.lblMasCant.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMasCant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMasCant.Location = new System.Drawing.Point(590, 409);
            this.lblMasCant.Name = "lblMasCant";
            this.lblMasCant.Size = new System.Drawing.Size(22, 15);
            this.lblMasCant.Text = "(+)";
            // 
            // txtCantidadACargo
            // 
            this.txtCantidadACargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtCantidadACargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCantidadACargo.Location = new System.Drawing.Point(620, 405);
            this.txtCantidadACargo.Name = "txtCantidadACargo";
            this.txtCantidadACargo.ReadOnly = true;
            this.txtCantidadACargo.Size = new System.Drawing.Size(220, 21);
            this.txtCantidadACargo.TabIndex = 27;
            this.txtCantidadACargo.Text = "0";
            this.txtCantidadACargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCantidadAPagar
            // 
            this.lblCantidadAPagar.AutoSize = true;
            this.lblCantidadAPagar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidadAPagar.Location = new System.Drawing.Point(25, 447);
            this.lblCantidadAPagar.Name = "lblCantidadAPagar";
            this.lblCantidadAPagar.Size = new System.Drawing.Size(104, 15);
            this.lblCantidadAPagar.Text = "Cantidad a pagar";
            // 
            // txtCantidadAPagar
            // 
            this.txtCantidadAPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtCantidadAPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadAPagar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtCantidadAPagar.Location = new System.Drawing.Point(620, 443);
            this.txtCantidadAPagar.Name = "txtCantidadAPagar";
            this.txtCantidadAPagar.ReadOnly = true;
            this.txtCantidadAPagar.Size = new System.Drawing.Size(220, 21);
            this.txtCantidadAPagar.TabIndex = 29;
            this.txtCantidadAPagar.Text = "0";
            this.txtCantidadAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fmPagoIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlBotonesSuperior);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "fmPagoIVA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago IVA Simplificado de Confianza";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBotonesSuperior.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlBotonesSuperior;
        private System.Windows.Forms.Button btnAdmonDeclaracion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabDeterminacion;
        private System.Windows.Forms.Button btnTabPago;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblCamposObligatorios;
        private System.Windows.Forms.Label lblACargo;
        private System.Windows.Forms.TextBox txtACargo;
        private System.Windows.Forms.Label lblTotalContrib1;
        private System.Windows.Forms.Label lblMas1;
        private System.Windows.Forms.TextBox txtTotalContrib1;
        private System.Windows.Forms.Label lblPregCompensaciones;
        private System.Windows.Forms.ComboBox cmbCompensaciones;
        private System.Windows.Forms.Label lblCompensaciones;
        private System.Windows.Forms.Label lblMasComp;
        private System.Windows.Forms.TextBox txtCompensaciones;
        private System.Windows.Forms.Button btnCapturarComp;
        private System.Windows.Forms.Label lblPregEstimulos;
        private System.Windows.Forms.ComboBox cmbEstimulos;
        private System.Windows.Forms.Label lblEstimulos;
        private System.Windows.Forms.Label lblMasEst;
        private System.Windows.Forms.TextBox txtEstimulos;
        private System.Windows.Forms.Button btnCapturarEst;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Label lblTotalAplicaciones1;
        private System.Windows.Forms.Label lblMasApl1;
        private System.Windows.Forms.TextBox txtTotalAplicaciones1;
        private System.Windows.Forms.Label lblTotalContrib2;
        private System.Windows.Forms.TextBox txtTotalContrib2;
        private System.Windows.Forms.Label lblTotalAplicaciones2;
        private System.Windows.Forms.Label lblMenosApl2;
        private System.Windows.Forms.TextBox txtTotalAplicaciones2;
        private System.Windows.Forms.Label lblCantidadACargo;
        private System.Windows.Forms.Label lblMasCant;
        private System.Windows.Forms.TextBox txtCantidadACargo;
        private System.Windows.Forms.Label lblCantidadAPagar;
        private System.Windows.Forms.TextBox txtCantidadAPagar;
    }
}