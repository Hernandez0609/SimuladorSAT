namespace SimuladorSAT
{
    partial class fmIsrFisicasPago
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLogosBlancos = new System.Windows.Forms.Panel();
            this.picLogoUthh = new System.Windows.Forms.PictureBox();
            this.picEscudoUthh = new System.Windows.Forms.PictureBox();
            this.pnlFranjaGrisDatos = new System.Windows.Forms.Panel();
            this.lblDatosIzquierda = new System.Windows.Forms.Label();
            this.lblDatosCentro = new System.Windows.Forms.Label();
            this.lblDatosDerecha = new System.Windows.Forms.Label();
            this.pnlNavbarAzul = new System.Windows.Forms.Panel();
            this.btnPresentarDeclaracion = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnTabIngresos = new System.Windows.Forms.Button();
            this.btnTabDeterminacion = new System.Windows.Forms.Button();
            this.btnTabPago = new System.Windows.Forms.Button();
            this.btnTabDatosAdicionales = new System.Windows.Forms.Button();
            this.pnlContenedorTabla = new System.Windows.Forms.Panel();
            this.lblAsteriscos = new System.Windows.Forms.Label();
            this.tlpCamposSat = new System.Windows.Forms.TableLayoutPanel();

            this.lblACargo = new System.Windows.Forms.Label();
            this.txtACargo = new System.Windows.Forms.TextBox();
            this.lblTotalContribuciones1 = new System.Windows.Forms.Label();
            this.lblSigno1 = new System.Windows.Forms.Label();
            this.txtTotalContribuciones1 = new System.Windows.Forms.TextBox();
            this.lblSubsidio = new System.Windows.Forms.Label();
            this.txtSubsidio = new System.Windows.Forms.TextBox();
            this.lblCompensaciones = new System.Windows.Forms.Label();
            this.cmbCompensaciones = new System.Windows.Forms.ComboBox();
            this.lblCompensacionesValor = new System.Windows.Forms.Label();
            this.lblSignoCompensaciones = new System.Windows.Forms.Label();
            this.txtCompensacionesValor = new System.Windows.Forms.TextBox();
            this.btnCapturarCompensaciones = new System.Windows.Forms.Button();
            this.lblEstimulos = new System.Windows.Forms.Label();
            this.cmbEstimulos = new System.Windows.Forms.ComboBox();
            this.lblEstimulosValor = new System.Windows.Forms.Label();
            this.lblSignoEstimulos = new System.Windows.Forms.Label();
            this.txtEstimulosValor = new System.Windows.Forms.TextBox();
            this.btnCapturarEstimulos = new System.Windows.Forms.Button();
            this.lblTotalAplicaciones1 = new System.Windows.Forms.Label();
            this.lblSigno2 = new System.Windows.Forms.Label();
            this.txtTotalAplicaciones1 = new System.Windows.Forms.TextBox();
            this.lblTotalContribuciones2 = new System.Windows.Forms.Label();
            this.txtTotalContribuciones2 = new System.Windows.Forms.TextBox();
            this.lblTotalAplicaciones2 = new System.Windows.Forms.Label();
            this.lblSigno3 = new System.Windows.Forms.Label();
            this.txtTotalAplicaciones2 = new System.Windows.Forms.TextBox();
            this.lblCantidadACargo = new System.Windows.Forms.Label();
            this.lblSigno4 = new System.Windows.Forms.Label();
            this.txtCantidadACargo = new System.Windows.Forms.TextBox();
            this.lblCantidadAPagar = new System.Windows.Forms.Label();
            this.txtCantidadAPagar = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.picLogoUthh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEscudoUthh)).BeginInit();
            this.SuspendLayout();

            // ====================================================================
            // pnlLogosBlancos
            // ====================================================================
            this.pnlLogosBlancos.BackColor = System.Drawing.Color.White;
            this.pnlLogosBlancos.Controls.Add(this.picLogoUthh);
            this.pnlLogosBlancos.Controls.Add(this.picEscudoUthh);
            this.pnlLogosBlancos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogosBlancos.Location = new System.Drawing.Point(0, 0);
            this.pnlLogosBlancos.Name = "pnlLogosBlancos";
            this.pnlLogosBlancos.Size = new System.Drawing.Size(1445, 85);
            this.pnlLogosBlancos.TabIndex = 0;

            this.picLogoUthh.Image = global::SimuladorSAT.Properties.Resources.logouthh;
            this.picLogoUthh.Location = new System.Drawing.Point(20, 8);
            this.picLogoUthh.Name = "picLogoUthh";
            this.picLogoUthh.Size = new System.Drawing.Size(340, 76);
            this.picLogoUthh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoUthh.TabIndex = 0;
            this.picLogoUthh.TabStop = false;

            this.picEscudoUthh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picEscudoUthh.Image = global::SimuladorSAT.Properties.Resources.escudo;
            this.picEscudoUthh.Location = new System.Drawing.Point(1335, 5);
            this.picEscudoUthh.Name = "picEscudoUthh";
            this.picEscudoUthh.Size = new System.Drawing.Size(82, 76);
            this.picEscudoUthh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscudoUthh.TabIndex = 1;
            this.picEscudoUthh.TabStop = false;

            // ====================================================================
            // pnlFranjaGrisDatos
            // ====================================================================
            this.pnlFranjaGrisDatos.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosIzquierda);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosCentro);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosDerecha);
            this.pnlFranjaGrisDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFranjaGrisDatos.Location = new System.Drawing.Point(0, 85);
            this.pnlFranjaGrisDatos.Name = "pnlFranjaGrisDatos";
            this.pnlFranjaGrisDatos.Size = new System.Drawing.Size(1445, 80);
            this.pnlFranjaGrisDatos.TabIndex = 1;

            this.lblDatosIzquierda.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDatosIzquierda.Location = new System.Drawing.Point(23, 11);
            this.lblDatosIzquierda.Name = "lblDatosIzquierda";
            this.lblDatosIzquierda.Size = new System.Drawing.Size(343, 59);
            this.lblDatosIzquierda.TabIndex = 0;
            this.lblDatosIzquierda.Text = "RFC: xxxxxxxxx | FULANO PEREZ\r\nPEREZ";

            this.lblDatosCentro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDatosCentro.Font = new System.Drawing.Font("Arial", 13F);
            this.lblDatosCentro.Location = new System.Drawing.Point(437, 11);
            this.lblDatosCentro.Name = "lblDatosCentro";
            this.lblDatosCentro.Size = new System.Drawing.Size(571, 59);
            this.lblDatosCentro.TabIndex = 1;
            this.lblDatosCentro.Text = "Declaración Provisional o Definitiva de Impuestos\r\nFederales";
            this.lblDatosCentro.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.lblDatosDerecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatosDerecha.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDatosDerecha.Location = new System.Drawing.Point(1079, 11);
            this.lblDatosDerecha.Name = "lblDatosDerecha";
            this.lblDatosDerecha.Size = new System.Drawing.Size(343, 59);
            this.lblDatosDerecha.TabIndex = 2;
            this.lblDatosDerecha.Text = "Ejercicio: 2026 / periodo: xxxx\r\nDeclaración: Normal\r\nVencimiento: xx/xx/xx";
            this.lblDatosDerecha.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // ====================================================================
            // pnlNavbarAzul
            // ====================================================================
            this.pnlNavbarAzul.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlNavbarAzul.Controls.Add(this.btnPresentarDeclaracion);
            this.pnlNavbarAzul.Controls.Add(this.btnInicio);
            this.pnlNavbarAzul.Controls.Add(this.btnCerrar);
            this.pnlNavbarAzul.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbarAzul.Location = new System.Drawing.Point(0, 165);
            this.pnlNavbarAzul.Name = "pnlNavbarAzul";
            this.pnlNavbarAzul.Size = new System.Drawing.Size(1445, 48);
            this.pnlNavbarAzul.TabIndex = 2;

            this.btnPresentarDeclaracion.FlatAppearance.BorderSize = 0;
            this.btnPresentarDeclaracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentarDeclaracion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnPresentarDeclaracion.ForeColor = System.Drawing.Color.White;
            this.btnPresentarDeclaracion.Location = new System.Drawing.Point(35, 0);
            this.btnPresentarDeclaracion.Name = "btnPresentarDeclaracion";
            this.btnPresentarDeclaracion.Size = new System.Drawing.Size(229, 48);
            this.btnPresentarDeclaracion.TabIndex = 0;
            this.btnPresentarDeclaracion.Text = "Presentar declaración";
            this.btnPresentarDeclaracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(1200, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(95, 48);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1300, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(95, 48);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ====================================================================
            // pnlContenedorPrincipal
            // ====================================================================
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(0, 213);
            this.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1445, 565);
            this.pnlContenedorPrincipal.TabIndex = 3;
            this.pnlContenedorPrincipal.Controls.Add(this.lblTituloModulo);
            this.pnlContenedorPrincipal.Controls.Add(this.btnAdministracion);
            this.pnlContenedorPrincipal.Controls.Add(this.btnGuardar);
            this.pnlContenedorPrincipal.Controls.Add(this.btnTabIngresos);
            this.pnlContenedorPrincipal.Controls.Add(this.btnTabDeterminacion);
            this.pnlContenedorPrincipal.Controls.Add(this.btnTabPago);
            this.pnlContenedorPrincipal.Controls.Add(this.btnTabDatosAdicionales);
            this.pnlContenedorPrincipal.Controls.Add(this.pnlContenedorTabla);

            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Arial", 16F);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTituloModulo.Location = new System.Drawing.Point(46, 27);
            this.lblTituloModulo.Name = "lblTituloModulo";
            this.lblTituloModulo.TabIndex = 0;
            this.lblTituloModulo.Text = "ISR simplificado de confianza. Personas físicas";

            this.btnAdministracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdministracion.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministracion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdministracion.ForeColor = System.Drawing.Color.White;
            this.btnAdministracion.Location = new System.Drawing.Point(940, 21);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(360, 37);
            this.btnAdministracion.TabIndex = 1;
            this.btnAdministracion.Text = "Administración de la declaración";
            this.btnAdministracion.UseVisualStyleBackColor = false;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(1310, 21);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 37);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            // ---- Pestañas: aquí "PAGO" va en azul (activa) ----
            this.btnTabIngresos.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnTabIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabIngresos.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTabIngresos.ForeColor = System.Drawing.Color.Silver;
            this.btnTabIngresos.Location = new System.Drawing.Point(46, 80);
            this.btnTabIngresos.Name = "btnTabIngresos";
            this.btnTabIngresos.Size = new System.Drawing.Size(140, 34);
            this.btnTabIngresos.TabIndex = 3;
            this.btnTabIngresos.Text = "Ingresos";
            this.btnTabIngresos.UseVisualStyleBackColor = false;
            this.btnTabIngresos.Click += new System.EventHandler(this.btnTabIngresos_Click);

            this.btnTabDeterminacion.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnTabDeterminacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDeterminacion.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTabDeterminacion.ForeColor = System.Drawing.Color.Silver;
            this.btnTabDeterminacion.Location = new System.Drawing.Point(186, 80);
            this.btnTabDeterminacion.Name = "btnTabDeterminacion";
            this.btnTabDeterminacion.Size = new System.Drawing.Size(170, 34);
            this.btnTabDeterminacion.TabIndex = 4;
            this.btnTabDeterminacion.Text = "Determinación";
            this.btnTabDeterminacion.UseVisualStyleBackColor = false;
            this.btnTabDeterminacion.Click += new System.EventHandler(this.btnTabDeterminacion_Click);

            this.btnTabPago.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnTabPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabPago.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabPago.ForeColor = System.Drawing.Color.White;
            this.btnTabPago.Location = new System.Drawing.Point(356, 80);
            this.btnTabPago.Name = "btnTabPago";
            this.btnTabPago.Size = new System.Drawing.Size(110, 34);
            this.btnTabPago.TabIndex = 5;
            this.btnTabPago.Text = "Pago";
            this.btnTabPago.UseVisualStyleBackColor = false;

            this.btnTabDatosAdicionales.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnTabDatosAdicionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDatosAdicionales.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTabDatosAdicionales.ForeColor = System.Drawing.Color.Silver;
            this.btnTabDatosAdicionales.Location = new System.Drawing.Point(464, 80);
            this.btnTabDatosAdicionales.Name = "btnTabDatosAdicionales";
            this.btnTabDatosAdicionales.Size = new System.Drawing.Size(190, 34);
            this.btnTabDatosAdicionales.TabIndex = 6;
            this.btnTabDatosAdicionales.Text = "Datos adicionales";
            this.btnTabDatosAdicionales.UseVisualStyleBackColor = false;
            this.btnTabDatosAdicionales.Visible = false;
            this.btnTabDatosAdicionales.Click += new System.EventHandler(this.btnTabDatosAdicionales_Click);

            // ====================================================================
            // pnlContenedorTabla
            // ====================================================================
            this.pnlContenedorTabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedorTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedorTabla.Controls.Add(this.lblAsteriscos);
            this.pnlContenedorTabla.Controls.Add(this.tlpCamposSat);
            this.pnlContenedorTabla.Location = new System.Drawing.Point(30, 114);
            this.pnlContenedorTabla.Name = "pnlContenedorTabla";
            this.pnlContenedorTabla.Size = new System.Drawing.Size(1385, 620);
            this.pnlContenedorTabla.TabIndex = 7;

            this.lblAsteriscos.AutoSize = true;
            this.lblAsteriscos.Font = new System.Drawing.Font("Arial", 8F);
            this.lblAsteriscos.ForeColor = System.Drawing.Color.Gray;
            this.lblAsteriscos.Location = new System.Drawing.Point(10, 8);
            this.lblAsteriscos.Name = "lblAsteriscos";
            this.lblAsteriscos.TabIndex = 0;
            this.lblAsteriscos.Text = "Los campos marcados con asterisco (*) son obligatorios";

            // ====================================================================
            // tlpCamposSat — 12 filas (10 fijas + 2 condicionales)
            // ====================================================================
            this.tlpCamposSat.ColumnCount = 5;
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));

            this.tlpCamposSat.RowCount = 12;
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 0 A cargo
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 1 Total contribuciones (=)
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 2 Subsidio
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 3 ¿Compensaciones?
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));  // 4 Compensaciones (condicional)
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 5 ¿Estímulos?
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));  // 6 Estímulos (condicional)
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 7 Total aplicaciones (=)
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 8 Total contribuciones
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 9 Total aplicaciones (-)
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 10 Cantidad a cargo (=)
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F)); // 11 Cantidad a pagar

            this.tlpCamposSat.Location = new System.Drawing.Point(18, 40);
            this.tlpCamposSat.Name = "tlpCamposSat";
            this.tlpCamposSat.AutoSize = true;
            this.tlpCamposSat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpCamposSat.Size = new System.Drawing.Size(1340, 570);
            this.tlpCamposSat.TabIndex = 1;

            // Fila 0: A cargo
            this.lblACargo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblACargo.AutoSize = true;
            this.lblACargo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblACargo.Text = "A cargo";
            this.tlpCamposSat.Controls.Add(this.lblACargo, 0, 0);

            this.txtACargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtACargo.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtACargo.ReadOnly = true;
            this.txtACargo.Size = new System.Drawing.Size(195, 25);
            this.txtACargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtACargo, 2, 0);

            // Fila 1: Total de contribuciones (=)
            this.lblTotalContribuciones1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalContribuciones1.AutoSize = true;
            this.lblTotalContribuciones1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalContribuciones1.Text = "Total de contribuciones";
            this.tlpCamposSat.Controls.Add(this.lblTotalContribuciones1, 0, 1);

            this.lblSigno1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSigno1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno1.Text = "(=)";
            this.lblSigno1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSigno1, 1, 1);

            this.txtTotalContribuciones1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalContribuciones1.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtTotalContribuciones1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalContribuciones1.ReadOnly = true;
            this.txtTotalContribuciones1.Size = new System.Drawing.Size(195, 25);
            this.txtTotalContribuciones1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtTotalContribuciones1, 2, 1);

            // Fila 2: Subsidio para el empleo
            this.lblSubsidio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubsidio.AutoSize = true;
            this.lblSubsidio.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSubsidio.Text = "Subsidio para el empleo";
            this.tlpCamposSat.Controls.Add(this.lblSubsidio, 0, 2);

            this.txtSubsidio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSubsidio.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSubsidio.Size = new System.Drawing.Size(195, 25);
            this.txtSubsidio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtSubsidio, 2, 2);

            // Fila 3: ¿Tienes compensaciones por aplicar?
            this.lblCompensaciones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCompensaciones.AutoSize = true;
            this.lblCompensaciones.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCompensaciones.Text = "*¿Tienes compensaciones por aplicar?";
            this.tlpCamposSat.Controls.Add(this.lblCompensaciones, 0, 3);

            this.cmbCompensaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCompensaciones.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbCompensaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompensaciones.Size = new System.Drawing.Size(195, 25);
            this.cmbCompensaciones.Items.AddRange(new object[] { "No", "Sí" });
            this.cmbCompensaciones.SelectedIndex = 0;
            this.cmbCompensaciones.SelectedIndexChanged += new System.EventHandler(this.cmbCompensaciones_SelectedIndexChanged);
            this.tlpCamposSat.Controls.Add(this.cmbCompensaciones, 2, 3);

            // Fila 4: Compensaciones (condicional)
            this.lblCompensacionesValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCompensacionesValor.AutoSize = true;
            this.lblCompensacionesValor.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCompensacionesValor.Text = "*Compensaciones";
            this.lblCompensacionesValor.Visible = false;
            this.tlpCamposSat.Controls.Add(this.lblCompensacionesValor, 0, 4);

            this.lblSignoCompensaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignoCompensaciones.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSignoCompensaciones.Text = "(+)";
            this.lblSignoCompensaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignoCompensaciones.Visible = false;
            this.tlpCamposSat.Controls.Add(this.lblSignoCompensaciones, 1, 4);

            this.txtCompensacionesValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCompensacionesValor.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtCompensacionesValor.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCompensacionesValor.ReadOnly = true;
            this.txtCompensacionesValor.Size = new System.Drawing.Size(195, 25);
            this.txtCompensacionesValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCompensacionesValor.Visible = false;
            this.tlpCamposSat.Controls.Add(this.txtCompensacionesValor, 2, 4);

            this.btnCapturarCompensaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCapturarCompensaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturarCompensaciones.Size = new System.Drawing.Size(137, 28);
            this.btnCapturarCompensaciones.Text = "Capturar";
            this.btnCapturarCompensaciones.Visible = false;
            this.btnCapturarCompensaciones.Click += new System.EventHandler(this.btnCapturarCompensaciones_Click);
            this.tlpCamposSat.Controls.Add(this.btnCapturarCompensaciones, 3, 4);

            // Fila 5: ¿Tienes estímulos por aplicar?
            this.lblEstimulos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEstimulos.AutoSize = true;
            this.lblEstimulos.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEstimulos.Text = "*¿Tienes estímulos por aplicar?";
            this.tlpCamposSat.Controls.Add(this.lblEstimulos, 0, 5);

            this.cmbEstimulos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbEstimulos.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbEstimulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstimulos.Size = new System.Drawing.Size(195, 25);
            this.cmbEstimulos.Items.AddRange(new object[] { "No", "Sí" });
            this.cmbEstimulos.SelectedIndex = 0;
            this.cmbEstimulos.SelectedIndexChanged += new System.EventHandler(this.cmbEstimulos_SelectedIndexChanged);
            this.tlpCamposSat.Controls.Add(this.cmbEstimulos, 2, 5);

            // Fila 6: Estímulos al impuesto a cargo (condicional)
            this.lblEstimulosValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEstimulosValor.AutoSize = true;
            this.lblEstimulosValor.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEstimulosValor.Text = "*Estímulos al impuesto a cargo";
            this.lblEstimulosValor.Visible = false;
            this.tlpCamposSat.Controls.Add(this.lblEstimulosValor, 0, 6);

            this.lblSignoEstimulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignoEstimulos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSignoEstimulos.Text = "(+)";
            this.lblSignoEstimulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignoEstimulos.Visible = false;
            this.tlpCamposSat.Controls.Add(this.lblSignoEstimulos, 1, 6);

            this.txtEstimulosValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEstimulosValor.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtEstimulosValor.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEstimulosValor.ReadOnly = true;
            this.txtEstimulosValor.Size = new System.Drawing.Size(195, 25);
            this.txtEstimulosValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstimulosValor.Visible = false;
            this.tlpCamposSat.Controls.Add(this.txtEstimulosValor, 2, 6);

            this.btnCapturarEstimulos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCapturarEstimulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturarEstimulos.Size = new System.Drawing.Size(137, 28);
            this.btnCapturarEstimulos.Text = "Capturar";
            this.btnCapturarEstimulos.Visible = false;
            this.btnCapturarEstimulos.Click += new System.EventHandler(this.btnCapturarEstimulos_Click);
            this.tlpCamposSat.Controls.Add(this.btnCapturarEstimulos, 3, 6);

            // Fila 7: Total de aplicaciones (=)
            this.lblTotalAplicaciones1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalAplicaciones1.AutoSize = true;
            this.lblTotalAplicaciones1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalAplicaciones1.Text = "Total de aplicaciones";
            this.tlpCamposSat.Controls.Add(this.lblTotalAplicaciones1, 0, 7);

            this.lblSigno2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSigno2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno2.Text = "(=)";
            this.lblSigno2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSigno2, 1, 7);

            this.txtTotalAplicaciones1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalAplicaciones1.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtTotalAplicaciones1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalAplicaciones1.ReadOnly = true;
            this.txtTotalAplicaciones1.Size = new System.Drawing.Size(195, 25);
            this.txtTotalAplicaciones1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtTotalAplicaciones1, 2, 7);

            // Fila 8: Total de contribuciones (sin signo)
            this.lblTotalContribuciones2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalContribuciones2.AutoSize = true;
            this.lblTotalContribuciones2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalContribuciones2.Text = "Total de contribuciones";
            this.tlpCamposSat.Controls.Add(this.lblTotalContribuciones2, 0, 8);

            this.txtTotalContribuciones2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalContribuciones2.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtTotalContribuciones2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalContribuciones2.ReadOnly = true;
            this.txtTotalContribuciones2.Size = new System.Drawing.Size(195, 25);
            this.txtTotalContribuciones2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtTotalContribuciones2, 2, 8);

            // Fila 9: Total de aplicaciones (-)
            this.lblTotalAplicaciones2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalAplicaciones2.AutoSize = true;
            this.lblTotalAplicaciones2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalAplicaciones2.Text = "Total de aplicaciones";
            this.tlpCamposSat.Controls.Add(this.lblTotalAplicaciones2, 0, 9);

            this.lblSigno3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSigno3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno3.Text = "(-)";
            this.lblSigno3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSigno3, 1, 9);

            this.txtTotalAplicaciones2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalAplicaciones2.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtTotalAplicaciones2.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalAplicaciones2.ReadOnly = true;
            this.txtTotalAplicaciones2.Size = new System.Drawing.Size(195, 25);
            this.txtTotalAplicaciones2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtTotalAplicaciones2, 2, 9);

            // Fila 10: Cantidad a cargo (=)
            this.lblCantidadACargo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCantidadACargo.AutoSize = true;
            this.lblCantidadACargo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCantidadACargo.Text = "Cantidad a cargo";
            this.tlpCamposSat.Controls.Add(this.lblCantidadACargo, 0, 10);

            this.lblSigno4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSigno4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSigno4.Text = "(=)";
            this.lblSigno4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSigno4, 1, 10);

            this.txtCantidadACargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCantidadACargo.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtCantidadACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCantidadACargo.ReadOnly = true;
            this.txtCantidadACargo.Size = new System.Drawing.Size(195, 25);
            this.txtCantidadACargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtCantidadACargo, 2, 10);

            // Fila 11: Cantidad a pagar (sin signo)
            this.lblCantidadAPagar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCantidadAPagar.AutoSize = true;
            this.lblCantidadAPagar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCantidadAPagar.Text = "Cantidad a pagar";
            this.tlpCamposSat.Controls.Add(this.lblCantidadAPagar, 0, 11);

            this.txtCantidadAPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCantidadAPagar.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtCantidadAPagar.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCantidadAPagar.ReadOnly = true;
            this.txtCantidadAPagar.Size = new System.Drawing.Size(195, 25);
            this.txtCantidadAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtCantidadAPagar, 2, 11);

            // ====================================================================
            // Form
            // ====================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 778);
            this.Controls.Add(this.pnlContenedorPrincipal);
            this.Controls.Add(this.pnlNavbarAzul);
            this.Controls.Add(this.pnlFranjaGrisDatos);
            this.Controls.Add(this.pnlLogosBlancos);
            this.MinimumSize = new System.Drawing.Size(1168, 637);
            this.Name = "fmIsrFisicasPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador SAT - ISR Personas Físicas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.picLogoUthh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEscudoUthh)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlLogosBlancos;
        private System.Windows.Forms.PictureBox picLogoUthh;
        private System.Windows.Forms.PictureBox picEscudoUthh;
        private System.Windows.Forms.Panel pnlFranjaGrisDatos;
        private System.Windows.Forms.Label lblDatosIzquierda;
        private System.Windows.Forms.Label lblDatosCentro;
        private System.Windows.Forms.Label lblDatosDerecha;
        private System.Windows.Forms.Panel pnlNavbarAzul;
        private System.Windows.Forms.Button btnPresentarDeclaracion;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.Label lblTituloModulo;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnTabIngresos;
        private System.Windows.Forms.Button btnTabDeterminacion;
        private System.Windows.Forms.Button btnTabPago;
        private System.Windows.Forms.Button btnTabDatosAdicionales;
        private System.Windows.Forms.Panel pnlContenedorTabla;
        private System.Windows.Forms.Label lblAsteriscos;
        private System.Windows.Forms.TableLayoutPanel tlpCamposSat;

        private System.Windows.Forms.Label lblACargo;
        private System.Windows.Forms.TextBox txtACargo;
        private System.Windows.Forms.Label lblTotalContribuciones1;
        private System.Windows.Forms.Label lblSigno1;
        private System.Windows.Forms.TextBox txtTotalContribuciones1;
        private System.Windows.Forms.Label lblSubsidio;
        private System.Windows.Forms.TextBox txtSubsidio;
        private System.Windows.Forms.Label lblCompensaciones;
        private System.Windows.Forms.ComboBox cmbCompensaciones;
        private System.Windows.Forms.Label lblCompensacionesValor;
        private System.Windows.Forms.Label lblSignoCompensaciones;
        private System.Windows.Forms.TextBox txtCompensacionesValor;
        private System.Windows.Forms.Button btnCapturarCompensaciones;
        private System.Windows.Forms.Label lblEstimulos;
        private System.Windows.Forms.ComboBox cmbEstimulos;
        private System.Windows.Forms.Label lblEstimulosValor;
        private System.Windows.Forms.Label lblSignoEstimulos;
        private System.Windows.Forms.TextBox txtEstimulosValor;
        private System.Windows.Forms.Button btnCapturarEstimulos;
        private System.Windows.Forms.Label lblTotalAplicaciones1;
        private System.Windows.Forms.Label lblSigno2;
        private System.Windows.Forms.TextBox txtTotalAplicaciones1;
        private System.Windows.Forms.Label lblTotalContribuciones2;
        private System.Windows.Forms.TextBox txtTotalContribuciones2;
        private System.Windows.Forms.Label lblTotalAplicaciones2;
        private System.Windows.Forms.Label lblSigno3;
        private System.Windows.Forms.TextBox txtTotalAplicaciones2;
        private System.Windows.Forms.Label lblCantidadACargo;
        private System.Windows.Forms.Label lblSigno4;
        private System.Windows.Forms.TextBox txtCantidadACargo;
        private System.Windows.Forms.Label lblCantidadAPagar;
        private System.Windows.Forms.TextBox txtCantidadAPagar;
    }
}