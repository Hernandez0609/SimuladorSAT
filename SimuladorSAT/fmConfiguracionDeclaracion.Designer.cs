namespace SimuladorSAT
{
    partial class fmConfiguracionDeclaracion
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
            this.pnlNavbarAzul = new System.Windows.Forms.Panel();
            this.btnPresentarDeclaracion = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();

            this.lblEjercicio = new System.Windows.Forms.Label();
            this.cmbEjercicio = new System.Windows.Forms.ComboBox();
            this.lblPeriocidad = new System.Windows.Forms.Label();
            this.cmbPeriocidad = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblTipoDeclaracion = new System.Windows.Forms.Label();
            this.cmbTipoDeclaracion = new System.Windows.Forms.ComboBox();
            this.lblTipoComplementaria = new System.Windows.Forms.Label();
            this.cmbTipoComplementaria = new System.Windows.Forms.ComboBox();

            this.btnCircIsrFisicas = new System.Windows.Forms.Button();
            this.lblCircIsrFisicas = new System.Windows.Forms.Label();
            this.btnCircIsrSalarios = new System.Windows.Forms.Button();
            this.lblCircIsrSalarios = new System.Windows.Forms.Label();
            this.btnCircIva = new System.Windows.Forms.Button();
            this.lblCircIva = new System.Windows.Forms.Label();

            this.btnSiguiente = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogoUthh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEscudoUthh)).BeginInit();
            this.SuspendLayout();

            // pnlLogosBlancos
            this.pnlLogosBlancos.BackColor = System.Drawing.Color.White;
            this.pnlLogosBlancos.Controls.Add(this.picLogoUthh);
            this.pnlLogosBlancos.Controls.Add(this.picEscudoUthh);
            this.pnlLogosBlancos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogosBlancos.Location = new System.Drawing.Point(0, 0);
            this.pnlLogosBlancos.Size = new System.Drawing.Size(1445, 85);
            this.pnlLogosBlancos.TabIndex = 0;

            this.picLogoUthh.Image = global::SimuladorSAT.Properties.Resources.logouthh;
            this.picLogoUthh.Location = new System.Drawing.Point(20, 8);
            this.picLogoUthh.Size = new System.Drawing.Size(340, 76);
            this.picLogoUthh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoUthh.TabStop = false;

            this.picEscudoUthh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picEscudoUthh.Image = global::SimuladorSAT.Properties.Resources.escudo;
            this.picEscudoUthh.Location = new System.Drawing.Point(1335, 5);
            this.picEscudoUthh.Size = new System.Drawing.Size(82, 76);
            this.picEscudoUthh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscudoUthh.TabStop = false;

            // pnlFranjaGrisDatos — SIN datos de la derecha (aún no se elige nada)
            this.pnlFranjaGrisDatos.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosIzquierda);
            this.pnlFranjaGrisDatos.Controls.Add(this.lblDatosCentro);
            this.pnlFranjaGrisDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFranjaGrisDatos.Location = new System.Drawing.Point(0, 85);
            this.pnlFranjaGrisDatos.Size = new System.Drawing.Size(1445, 80);
            this.pnlFranjaGrisDatos.TabIndex = 1;

            this.lblDatosIzquierda.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDatosIzquierda.Location = new System.Drawing.Point(23, 11);
            this.lblDatosIzquierda.Size = new System.Drawing.Size(343, 59);
            this.lblDatosIzquierda.Text = "RFC: xxxxxxxxx | FULANO PEREZ\r\nPEREZ";

            this.lblDatosCentro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDatosCentro.Font = new System.Drawing.Font("Arial", 13F);
            this.lblDatosCentro.Location = new System.Drawing.Point(437, 11);
            this.lblDatosCentro.Size = new System.Drawing.Size(571, 59);
            this.lblDatosCentro.Text = "Declaración Provisional o Definitiva de Impuestos\r\nFederales";
            this.lblDatosCentro.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // pnlNavbarAzul
            this.pnlNavbarAzul.BackColor = System.Drawing.Color.FromArgb(13, 78, 92);
            this.pnlNavbarAzul.Controls.Add(this.btnPresentarDeclaracion);
            this.pnlNavbarAzul.Controls.Add(this.btnInicio);
            this.pnlNavbarAzul.Controls.Add(this.btnCerrar);
            this.pnlNavbarAzul.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbarAzul.Location = new System.Drawing.Point(0, 165);
            this.pnlNavbarAzul.Size = new System.Drawing.Size(1445, 48);
            this.pnlNavbarAzul.TabIndex = 2;

            this.btnPresentarDeclaracion.FlatAppearance.BorderSize = 0;
            this.btnPresentarDeclaracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentarDeclaracion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnPresentarDeclaracion.ForeColor = System.Drawing.Color.White;
            this.btnPresentarDeclaracion.Location = new System.Drawing.Point(35, 0);
            this.btnPresentarDeclaracion.Size = new System.Drawing.Size(229, 48);
            this.btnPresentarDeclaracion.Text = "Presentar declaración";
            this.btnPresentarDeclaracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(1200, 0);
            this.btnInicio.Size = new System.Drawing.Size(95, 48);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1300, 0);
            this.btnCerrar.Size = new System.Drawing.Size(95, 48);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // pnlContenedorPrincipal
            this.Load += new System.EventHandler(this.fmConfiguracionDeclaracion_Load);
            this.pnlContenedorPrincipal.Resize += new System.EventHandler(this.pnlContenedorPrincipal_Resize);
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(0, 213);
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1445, 565);
            this.pnlContenedorPrincipal.TabIndex = 3;
            this.pnlContenedorPrincipal.Controls.Add(this.lblTituloModulo);
            this.pnlContenedorPrincipal.Controls.Add(this.lblEjercicio);
            this.pnlContenedorPrincipal.Controls.Add(this.cmbEjercicio);
            this.pnlContenedorPrincipal.Controls.Add(this.lblPeriocidad);
            this.pnlContenedorPrincipal.Controls.Add(this.cmbPeriocidad);
            this.pnlContenedorPrincipal.Controls.Add(this.lblPeriodo);
            this.pnlContenedorPrincipal.Controls.Add(this.cmbPeriodo);
            this.pnlContenedorPrincipal.Controls.Add(this.lblTipoDeclaracion);
            this.pnlContenedorPrincipal.Controls.Add(this.cmbTipoDeclaracion);
            this.pnlContenedorPrincipal.Controls.Add(this.lblTipoComplementaria);
            this.pnlContenedorPrincipal.Controls.Add(this.cmbTipoComplementaria);
            this.pnlContenedorPrincipal.Controls.Add(this.btnCircIsrFisicas);
            this.pnlContenedorPrincipal.Controls.Add(this.lblCircIsrFisicas);
            this.pnlContenedorPrincipal.Controls.Add(this.btnCircIsrSalarios);
            this.pnlContenedorPrincipal.Controls.Add(this.lblCircIsrSalarios);
            this.pnlContenedorPrincipal.Controls.Add(this.btnCircIva);
            this.pnlContenedorPrincipal.Controls.Add(this.lblCircIva);
            this.pnlContenedorPrincipal.Controls.Add(this.btnSiguiente);

            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Arial", 16F);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTituloModulo.Location = new System.Drawing.Point(46, 27);
            this.lblTituloModulo.Text = "Configuración de la declaración";

            // Ejercicio
            this.lblEjercicio.AutoSize = true;
            this.lblEjercicio.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEjercicio.Location = new System.Drawing.Point(46, 100);
            this.lblEjercicio.Text = "Ejercicio";

            this.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEjercicio.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbEjercicio.Location = new System.Drawing.Point(46, 125);
            this.cmbEjercicio.Size = new System.Drawing.Size(300, 28);
            this.cmbEjercicio.SelectedIndexChanged += new System.EventHandler(this.cmbEjercicio_SelectedIndexChanged);

            // Periocidad
            this.lblPeriocidad.AutoSize = true;
            this.lblPeriocidad.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriocidad.Location = new System.Drawing.Point(46, 170);
            this.lblPeriocidad.Text = "Periodicidad";

            this.cmbPeriocidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriocidad.Enabled = false;
            this.cmbPeriocidad.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbPeriocidad.Location = new System.Drawing.Point(46, 195);
            this.cmbPeriocidad.Size = new System.Drawing.Size(300, 28);
            this.cmbPeriocidad.Items.AddRange(new object[] { "-Seleccione-", "Mensual" });
            this.cmbPeriocidad.SelectedIndex = 0;
            this.cmbPeriocidad.SelectedIndexChanged += new System.EventHandler(this.cmbPeriocidad_SelectedIndexChanged);

            // Periodo (a la derecha de Periocidad, misma fila de labels)
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriodo.Location = new System.Drawing.Point(400, 170);
            this.lblPeriodo.Text = "Periodo";
            this.lblPeriodo.Visible = false;

            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbPeriodo.Location = new System.Drawing.Point(400, 195);
            this.cmbPeriodo.Size = new System.Drawing.Size(300, 28);
            this.cmbPeriodo.Visible = false;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);

            // Tipo de declaración
            this.lblTipoDeclaracion.AutoSize = true;
            this.lblTipoDeclaracion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTipoDeclaracion.Location = new System.Drawing.Point(46, 240);
            this.lblTipoDeclaracion.Text = "Tipo de declaración";
            this.lblTipoDeclaracion.Visible = false;

            this.cmbTipoDeclaracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeclaracion.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTipoDeclaracion.Location = new System.Drawing.Point(46, 265);
            this.cmbTipoDeclaracion.Size = new System.Drawing.Size(300, 28);
            this.cmbTipoDeclaracion.Items.AddRange(new object[] { "-Seleccione-", "Normal", "Complementaria" });
            this.cmbTipoDeclaracion.SelectedIndex = 0;
            this.cmbTipoDeclaracion.Visible = false;
            this.cmbTipoDeclaracion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDeclaracion_SelectedIndexChanged);

            // Tipo de complementaria (a la derecha, solo si Complementaria)
            this.lblTipoComplementaria.AutoSize = true;
            this.lblTipoComplementaria.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTipoComplementaria.Location = new System.Drawing.Point(400, 240);
            this.lblTipoComplementaria.Text = "Tipo de complementaria";
            this.lblTipoComplementaria.Visible = false;

            this.cmbTipoComplementaria.SelectedIndexChanged += new System.EventHandler(this.cmbTipoComplementaria_SelectedIndexChanged);
            this.cmbTipoComplementaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComplementaria.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTipoComplementaria.Location = new System.Drawing.Point(400, 265);
            this.cmbTipoComplementaria.Size = new System.Drawing.Size(300, 28);
            this.cmbTipoComplementaria.Items.AddRange(new object[] { "-Seleccione-", "Dejar sin efecto la obligación", "Modificación de obligaciones" });
            this.cmbTipoComplementaria.SelectedIndex = 0;
            this.cmbTipoComplementaria.Visible = false;

            // Círculos de módulos
            this.btnCircIsrFisicas.Size = new System.Drawing.Size(80, 80);
            this.btnCircIsrFisicas.Location = new System.Drawing.Point(46, 330);
            this.btnCircIsrFisicas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCircIsrFisicas.FlatAppearance.BorderSize = 0;
            this.btnCircIsrFisicas.Visible = false;
            this.btnCircIsrFisicas.Click += new System.EventHandler(this.btnCircIsrFisicas_Click);

            this.lblCircIsrFisicas.AutoSize = true;
            this.lblCircIsrFisicas.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCircIsrFisicas.Location = new System.Drawing.Point(31, 415);
            this.lblCircIsrFisicas.Size = new System.Drawing.Size(110, 40);
            this.lblCircIsrFisicas.Text = "ISR simplificado de confianza.\r\n Personas físicas";
            this.lblCircIsrFisicas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCircIsrFisicas.Visible = false;

            this.btnCircIsrSalarios.Size = new System.Drawing.Size(80, 80);
            this.btnCircIsrSalarios.Location = new System.Drawing.Point(220, 330);
            this.btnCircIsrSalarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCircIsrSalarios.FlatAppearance.BorderSize = 0;
            this.btnCircIsrSalarios.Visible = false;
            this.btnCircIsrSalarios.Click += new System.EventHandler(this.btnCircIsrSalarios_Click);

            this.lblCircIsrSalarios.AutoSize = true;
            this.lblCircIsrSalarios.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCircIsrSalarios.Location = new System.Drawing.Point(200, 415);
            this.lblCircIsrSalarios.Size = new System.Drawing.Size(120, 40);
            this.lblCircIsrSalarios.Text = "ISR Retenciones por Salarios";
            this.lblCircIsrSalarios.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCircIsrSalarios.Visible = false;

            this.btnCircIva.Size = new System.Drawing.Size(80, 80);
            this.btnCircIva.Location = new System.Drawing.Point(394, 330);
            this.btnCircIva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCircIva.FlatAppearance.BorderSize = 0;
            this.btnCircIva.Visible = false;
            this.btnCircIva.Click += new System.EventHandler(this.btnCircIva_Click);

            this.lblCircIva.AutoSize = true;
            this.lblCircIva.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCircIva.Location = new System.Drawing.Point(379, 415);
            this.lblCircIva.Size = new System.Drawing.Size(110, 40);
            this.lblCircIva.Text = "IVA simplificado de confianza";
            this.lblCircIva.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCircIva.Visible = false;

            // Siguiente
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(13, 78, 92); // antes (41, 128, 185)
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(632, 490);
            this.btnSiguiente.Size = new System.Drawing.Size(160, 42);
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.Visible = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 778);
            this.Controls.Add(this.pnlContenedorPrincipal);
            this.Controls.Add(this.pnlNavbarAzul);
            this.Controls.Add(this.pnlFranjaGrisDatos);
            this.Controls.Add(this.pnlLogosBlancos);
            this.Name = "fmConfiguracionDeclaracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador SAT - Configuración de la declaración";
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
        private System.Windows.Forms.Panel pnlNavbarAzul;
        private System.Windows.Forms.Button btnPresentarDeclaracion;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.Label lblTituloModulo;
        private System.Windows.Forms.Label lblEjercicio;
        private System.Windows.Forms.ComboBox cmbEjercicio;
        private System.Windows.Forms.Label lblPeriocidad;
        private System.Windows.Forms.ComboBox cmbPeriocidad;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblTipoDeclaracion;
        private System.Windows.Forms.ComboBox cmbTipoDeclaracion;
        private System.Windows.Forms.Label lblTipoComplementaria;
        private System.Windows.Forms.ComboBox cmbTipoComplementaria;
        private System.Windows.Forms.Button btnCircIsrFisicas;
        private System.Windows.Forms.Label lblCircIsrFisicas;
        private System.Windows.Forms.Button btnCircIsrSalarios;
        private System.Windows.Forms.Label lblCircIsrSalarios;
        private System.Windows.Forms.Button btnCircIva;
        private System.Windows.Forms.Label lblCircIva;
        private System.Windows.Forms.Button btnSiguiente;
    }
}