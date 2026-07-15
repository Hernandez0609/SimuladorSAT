namespace SimuladorSAT
{
    partial class fmIsrFisicasDeterminacion
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

            this.lblTotalPercibidos = new System.Windows.Forms.Label();
            this.txtTotalPercibidos = new System.Windows.Forms.TextBox();
            this.lblTasaAplicable = new System.Windows.Forms.Label();
            this.lblSignoTasa = new System.Windows.Forms.Label();
            this.txtTasaAplicable = new System.Windows.Forms.TextBox();
            this.lblImpuestoMensual = new System.Windows.Forms.Label();
            this.lblSignoImpuestoMensual = new System.Windows.Forms.Label();
            this.txtImpuestoMensual = new System.Windows.Forms.TextBox();
            this.lblIsrRetenido = new System.Windows.Forms.Label();
            this.lblSignoIsrRetenido = new System.Windows.Forms.Label();
            this.txtIsrRetenido = new System.Windows.Forms.TextBox();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.lblImpuestoACargo = new System.Windows.Forms.Label();
            this.lblSignoImpuestoACargo = new System.Windows.Forms.Label();
            this.txtImpuestoACargo = new System.Windows.Forms.TextBox();

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

            // ---- Pestañas: aquí "Determinación" va en azul (activa) ----
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

            this.btnTabDeterminacion.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.btnTabDeterminacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDeterminacion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabDeterminacion.ForeColor = System.Drawing.Color.White;
            this.btnTabDeterminacion.Location = new System.Drawing.Point(185, 80);
            this.btnTabDeterminacion.Name = "btnTabDeterminacion";
            this.btnTabDeterminacion.Size = new System.Drawing.Size(170, 34);
            this.btnTabDeterminacion.TabIndex = 4;
            this.btnTabDeterminacion.Text = "Determinación";
            this.btnTabDeterminacion.UseVisualStyleBackColor = false;

            this.btnTabPago.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnTabPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabPago.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTabPago.ForeColor = System.Drawing.Color.Silver;
            this.btnTabPago.Location = new System.Drawing.Point(355, 80);
            this.btnTabPago.Name = "btnTabPago";
            this.btnTabPago.Size = new System.Drawing.Size(110, 34);
            this.btnTabPago.TabIndex = 5;
            this.btnTabPago.Text = "PAGO";
            this.btnTabPago.UseVisualStyleBackColor = false;
            this.btnTabPago.Click += new System.EventHandler(this.btnTabPago_Click);

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
            this.pnlContenedorTabla.Size = new System.Drawing.Size(1385, 340);
            this.pnlContenedorTabla.TabIndex = 7;

            this.lblAsteriscos.AutoSize = true;
            this.lblAsteriscos.Font = new System.Drawing.Font("Arial", 8F);
            this.lblAsteriscos.ForeColor = System.Drawing.Color.Gray;
            this.lblAsteriscos.Location = new System.Drawing.Point(10, 8);
            this.lblAsteriscos.Name = "lblAsteriscos";
            this.lblAsteriscos.TabIndex = 0;
            this.lblAsteriscos.Text = "Los campos marcados con asterisco (*) son obligatorios";

            // ====================================================================
            // tlpCamposSat — 5 filas fijas, sin lógica elástica
            // ====================================================================
            this.tlpCamposSat.ColumnCount = 5;
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpCamposSat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));

            this.tlpCamposSat.RowCount = 5;
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpCamposSat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));

            this.tlpCamposSat.Location = new System.Drawing.Point(18, 40);
            this.tlpCamposSat.Name = "tlpCamposSat";
            this.tlpCamposSat.Size = new System.Drawing.Size(1340, 260);
            this.tlpCamposSat.TabIndex = 1;

            // Fila 0: Total de ingresos percibidos por la actividad (sin signo)
            this.lblTotalPercibidos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalPercibidos.AutoSize = true;
            this.lblTotalPercibidos.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTotalPercibidos.Text = "Total de ingresos percibidos por la actividad";
            this.tlpCamposSat.Controls.Add(this.lblTotalPercibidos, 0, 0);

            this.txtTotalPercibidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalPercibidos.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtTotalPercibidos.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTotalPercibidos.ReadOnly = true;
            this.txtTotalPercibidos.Size = new System.Drawing.Size(195, 25);
            this.txtTotalPercibidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtTotalPercibidos, 2, 0);

            // Fila 1: Tasa aplicable (x)
            this.lblTasaAplicable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTasaAplicable.AutoSize = true;
            this.lblTasaAplicable.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTasaAplicable.Text = "Tasa aplicable";
            this.tlpCamposSat.Controls.Add(this.lblTasaAplicable, 0, 1);

            this.lblSignoTasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignoTasa.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSignoTasa.Text = "(x)";
            this.lblSignoTasa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSignoTasa, 1, 1);

            this.txtTasaAplicable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTasaAplicable.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtTasaAplicable.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTasaAplicable.ReadOnly = true;
            this.txtTasaAplicable.Size = new System.Drawing.Size(195, 25);
            this.txtTasaAplicable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtTasaAplicable, 2, 1);

            // Fila 2: Impuesto mensual (=)
            this.lblImpuestoMensual.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImpuestoMensual.AutoSize = true;
            this.lblImpuestoMensual.Font = new System.Drawing.Font("Arial", 10F);
            this.lblImpuestoMensual.Text = "Impuesto mensual";
            this.tlpCamposSat.Controls.Add(this.lblImpuestoMensual, 0, 2);

            this.lblSignoImpuestoMensual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignoImpuestoMensual.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSignoImpuestoMensual.Text = "(=)";
            this.lblSignoImpuestoMensual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSignoImpuestoMensual, 1, 2);

            this.txtImpuestoMensual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtImpuestoMensual.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtImpuestoMensual.Font = new System.Drawing.Font("Arial", 9F);
            this.txtImpuestoMensual.ReadOnly = true;
            this.txtImpuestoMensual.Size = new System.Drawing.Size(195, 25);
            this.txtImpuestoMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtImpuestoMensual, 2, 2);

            // Fila 3: ISR retenido por personas morales (-) + botón Detalle
            this.lblIsrRetenido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIsrRetenido.AutoSize = true;
            this.lblIsrRetenido.Font = new System.Drawing.Font("Arial", 10F);
            this.lblIsrRetenido.Text = "ISR retenido por personas morales";
            this.tlpCamposSat.Controls.Add(this.lblIsrRetenido, 0, 3);

            this.lblSignoIsrRetenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignoIsrRetenido.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSignoIsrRetenido.Text = "(-)";
            this.lblSignoIsrRetenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSignoIsrRetenido, 1, 3);

            this.txtIsrRetenido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIsrRetenido.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtIsrRetenido.Font = new System.Drawing.Font("Arial", 9F);
            this.txtIsrRetenido.ReadOnly = true;
            this.txtIsrRetenido.Size = new System.Drawing.Size(195, 25);
            this.txtIsrRetenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtIsrRetenido, 2, 3);

            this.btnDetalle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Size = new System.Drawing.Size(137, 28);
            this.btnDetalle.TabIndex = 5;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            this.tlpCamposSat.Controls.Add(this.btnDetalle, 3, 3);

            // Fila 4: Impuesto a cargo (=)
            this.lblImpuestoACargo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImpuestoACargo.AutoSize = true;
            this.lblImpuestoACargo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblImpuestoACargo.Text = "Impuesto a cargo";
            this.tlpCamposSat.Controls.Add(this.lblImpuestoACargo, 0, 4);

            this.lblSignoImpuestoACargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignoImpuestoACargo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSignoImpuestoACargo.Text = "(=)";
            this.lblSignoImpuestoACargo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlpCamposSat.Controls.Add(this.lblSignoImpuestoACargo, 1, 4);

            this.txtImpuestoACargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtImpuestoACargo.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtImpuestoACargo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtImpuestoACargo.ReadOnly = true;
            this.txtImpuestoACargo.Size = new System.Drawing.Size(195, 25);
            this.txtImpuestoACargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpCamposSat.Controls.Add(this.txtImpuestoACargo, 2, 4);

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
            this.Name = "fmIsrFisicasDeterminacion";
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

        private System.Windows.Forms.Label lblTotalPercibidos;
        private System.Windows.Forms.TextBox txtTotalPercibidos;
        private System.Windows.Forms.Label lblTasaAplicable;
        private System.Windows.Forms.Label lblSignoTasa;
        private System.Windows.Forms.TextBox txtTasaAplicable;
        private System.Windows.Forms.Label lblImpuestoMensual;
        private System.Windows.Forms.Label lblSignoImpuestoMensual;
        private System.Windows.Forms.TextBox txtImpuestoMensual;
        private System.Windows.Forms.Label lblIsrRetenido;
        private System.Windows.Forms.Label lblSignoIsrRetenido;
        private System.Windows.Forms.TextBox txtIsrRetenido;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Label lblImpuestoACargo;
        private System.Windows.Forms.Label lblSignoImpuestoACargo;
        private System.Windows.Forms.TextBox txtImpuestoACargo;
    }
}