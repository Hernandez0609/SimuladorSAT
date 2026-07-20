namespace SimuladorSAT
{
    partial class fmCapturaListaGenerica
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBotonCerrarX = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblLimite = new System.Windows.Forms.Label();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();

            // Panel Desplegable de Captura (Figma Mockup 2)
            this.pnlCapturaDesplegable = new System.Windows.Forms.Panel();
            this.lblAsteriscoTipo = new System.Windows.Forms.Label();
            this.lblPorAplicarPeriodo = new System.Windows.Forms.Label();
            this.cmbTipoEstimulo = new System.Windows.Forms.ComboBox();
            this.txtMontoPorAplicar = new System.Windows.Forms.TextBox();
            this.btnGuardarCaptura = new System.Windows.Forms.Button();
            this.btnCancelarCaptura = new System.Windows.Forms.Button();

            // Grid y Sección Inferior
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorAplicar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblMensajeAlerta = new System.Windows.Forms.Label();
            this.lblIconoAlerta = new System.Windows.Forms.Label();

            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCerrarForm = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlCapturaDesplegable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            // =============================================
            // FORM (Estilo Flotante Limpio sin Bordes de Windows)
            // =============================================
            this.ClientSize = new System.Drawing.Size(950, 500);
            this.Text = "";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Arial", 10F); 

            // =============================================
            // HEADER (Teal Oscuro Figma)
            // =============================================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 55;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblBotonCerrarX);

            this.lblTitulo.Text = "Estímulos al impuesto a cargo";
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Georgia", 13F);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(25, 16);

            // Botón X blanco de la esquina superior derecha
            this.lblBotonCerrarX.Text = "X";
            this.lblBotonCerrarX.ForeColor = System.Drawing.Color.White;
            this.lblBotonCerrarX.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblBotonCerrarX.AutoSize = true;
            this.lblBotonCerrarX.Location = new System.Drawing.Point(905, 16);
            this.lblBotonCerrarX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBotonCerrarX.Click += new System.EventHandler(this.lblBotonCerrarX_Click);

            // =============================================
            // PANEL DE ACCIÓN INFERIOR
            // =============================================
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Height = 50;
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.btnCerrarForm);

            // Botón Cerrar Único (Abajo a la derecha)
            this.btnCerrarForm.Text = "Cerrar";
            this.btnCerrarForm.Size = new System.Drawing.Size(90, 28);
            this.btnCerrarForm.Location = new System.Drawing.Point(835, 10);
            this.btnCerrarForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarForm.BackColor = System.Drawing.Color.White;
            this.btnCerrarForm.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarForm.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCerrarForm.Font = new System.Drawing.Font("Georgia", 9.5F);
            this.btnCerrarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarForm.Click += new System.EventHandler(this.btnCerrarForm_Click);

            // =============================================
            // PANEL CONTENIDO PRINCIPAL
            // =============================================
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.lblLimite);
            this.pnlContenido.Controls.Add(this.txtLimite);
            this.pnlContenido.Controls.Add(this.btnAgregar);
            this.pnlContenido.Controls.Add(this.pnlCapturaDesplegable);
            this.pnlContenido.Controls.Add(this.dgvRegistros);
            this.pnlContenido.Controls.Add(this.lblTotalRegistros);
            this.pnlContenido.Controls.Add(this.lblPagina);
            this.pnlContenido.Controls.Add(this.lblMensajeAlerta);
            this.pnlContenido.Controls.Add(this.lblIconoAlerta);

            // Límite a aplicar central
            this.lblLimite.Text = "Limite a aplicar";
            this.lblLimite.Font = new System.Drawing.Font("Georgia", 12F);
            this.lblLimite.AutoSize = true;
            this.lblLimite.Location = new System.Drawing.Point(25, 15);

            this.txtLimite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLimite.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLimite.Location = new System.Drawing.Point(424, 25);
            this.txtLimite.Size = new System.Drawing.Size(120, 23);
            this.txtLimite.ReadOnly = true;
            this.txtLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimite.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtLimite.Text = "0";

            // Botón Agregar de Figma (Bordes redondeados, fondo blanco)
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 28);
            this.btnAgregar.Location = new System.Drawing.Point(25, 55);
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // =============================================
            // PANEL DESPLEGABLE DE CAPTURA (Figma Mockup 2)
            // =============================================
            this.pnlCapturaDesplegable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCapturaDesplegable.Location = new System.Drawing.Point(25, 55);
            this.pnlCapturaDesplegable.Size = new System.Drawing.Size(900, 135);
            this.pnlCapturaDesplegable.BackColor = System.Drawing.Color.White;
            this.pnlCapturaDesplegable.Visible = false; // Oculto inicialmente como pide Figma 1
            this.pnlCapturaDesplegable.Controls.Add(this.lblAsteriscoTipo);
            this.pnlCapturaDesplegable.Controls.Add(this.lblPorAplicarPeriodo);
            this.pnlCapturaDesplegable.Controls.Add(this.cmbTipoEstimulo);
            this.pnlCapturaDesplegable.Controls.Add(this.txtMontoPorAplicar);
            this.pnlCapturaDesplegable.Controls.Add(this.btnGuardarCaptura);
            this.pnlCapturaDesplegable.Controls.Add(this.btnCancelarCaptura);

            this.lblAsteriscoTipo.Text = "*Tipo de estimulo";
            this.lblAsteriscoTipo.Location = new System.Drawing.Point(15, 18);
            this.lblAsteriscoTipo.AutoSize = true;

            this.cmbTipoEstimulo.Location = new System.Drawing.Point(400, 15);
            this.cmbTipoEstimulo.Size = new System.Drawing.Size(120, 23);
            this.cmbTipoEstimulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEstimulo.Items.AddRange(new object[] { "Selecciona", "Estímulo Fronterizo", "Estímulo Diésel" });
            this.cmbTipoEstimulo.SelectedIndex = 0;
            this.cmbTipoEstimulo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoEstimulo_SelectedIndexChanged);

            this.lblPorAplicarPeriodo.Text = "Por aplicar en el periodo";
            this.lblPorAplicarPeriodo.Location = new System.Drawing.Point(15, 53);
            this.lblPorAplicarPeriodo.AutoSize = true;

            this.txtMontoPorAplicar.Anchor = System.Windows.Forms.AnchorStyles.None; 
            this.txtMontoPorAplicar.Font = new System.Drawing.Font("Arial", 9F); 
            this.txtMontoPorAplicar.Location = new System.Drawing.Point(400, 50);
            this.txtMontoPorAplicar.Size = new System.Drawing.Size(120, 23);
            this.txtMontoPorAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoPorAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));

            // Botones del panel interno
            this.btnGuardarCaptura.Text = "Guardar";
            this.btnGuardarCaptura.Size = new System.Drawing.Size(90, 28);
            this.btnGuardarCaptura.Location = new System.Drawing.Point(340, 95);
            this.btnGuardarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCaptura.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnGuardarCaptura.BackColor = System.Drawing.Color.White;
            this.btnGuardarCaptura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCaptura.Click += new System.EventHandler(this.btnGuardarCaptura_Click);

            this.btnCancelarCaptura.Text = "Cancelar";
            this.btnCancelarCaptura.Size = new System.Drawing.Size(90, 28);
            this.btnCancelarCaptura.Location = new System.Drawing.Point(450, 95);
            this.btnCancelarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCaptura.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancelarCaptura.BackColor = System.Drawing.Color.White;
            this.btnCancelarCaptura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCaptura.Click += new System.EventHandler(this.btnCancelarCaptura_Click);

            // =============================================
            // DATAGRIDVIEW (Alineado dinámicamente)
            // =============================================
            this.dgvRegistros.Location = new System.Drawing.Point(25, 100); // Cambia dinámicamente en el código
            this.dgvRegistros.Size = new System.Drawing.Size(900, 160);
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single; 
            this.dgvRegistros.GridColor = System.Drawing.Color.FromArgb(220, 220, 220); 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; 
            this.dgvRegistros.Font = new System.Drawing.Font("Arial", 10F); 
            this.dgvRegistros.ColumnHeadersHeight = 32;
            this.dgvRegistros.RowTemplate.Height = 32;
            // Estilo de celdas normales — BLANCO, no gris
            this.dgvRegistros.DefaultCellStyle.BackColor = System.Drawing.Color.White; 
            this.dgvRegistros.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White; 
            this.dgvRegistros.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRegistros.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Estilos de los encabezados
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold); 
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White; 
            this.dgvRegistros.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black; 
            this.dgvRegistros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRegistros.EnableHeadersVisualStyles = false;
            this.dgvRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistros_CellClick);

            this.colTipo.HeaderText = "Tipo de estimulo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTipo.FillWeight = 150;

            this.colPorAplicar.HeaderText = "Por aplicar en el periodo";
            this.colPorAplicar.Name = "colPorAplicar";
            this.colPorAplicar.ReadOnly = true;
            this.colPorAplicar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPorAplicar.FillWeight = 150;

            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "🗑"; // AGREGAR — el ícono que faltaba
            this.colEliminar.UseColumnTextForButtonValue = true; // AGREGAR — obligatorio para que se vea el texto/ícono
            this.colEliminar.ReadOnly = false; // antes true — debe ser false para que se pueda hacer clic
            this.colEliminar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEliminar.FillWeight = 150;

            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colTipo, this.colPorAplicar, this.colEliminar });

            // =============================================
            // CONTADORES Y ADVERTENCIA DE FIGMA
            // =============================================
            this.lblTotalRegistros.Text = "Total de registros            0";
            this.lblTotalRegistros.Location = new System.Drawing.Point(25, 275);
            this.lblTotalRegistros.AutoSize = true;

            this.lblPagina.Text = "< Pagina 1 de 0 >";
            this.lblPagina.Location = new System.Drawing.Point(400, 275);
            this.lblPagina.AutoSize = true;

            // Letrero Rojo Obligatorio de Figma
            this.lblMensajeAlerta.Text = "Debes capturar al menos un registro dando clic en el boton \"Agregar\".";
            this.lblMensajeAlerta.ForeColor = System.Drawing.Color.Red;
            this.lblMensajeAlerta.Location = new System.Drawing.Point(25, 330);
            this.lblMensajeAlerta.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.lblMensajeAlerta.AutoSize = true;

            // Icono Exclamación (!) Rojo con fondo Negro
            this.lblIconoAlerta.Text = " ! ";
            this.lblIconoAlerta.ForeColor = System.Drawing.Color.White;
            this.lblIconoAlerta.BackColor = System.Drawing.Color.Red;
            this.lblIconoAlerta.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblIconoAlerta.Location = new System.Drawing.Point(50, 330);
            this.lblIconoAlerta.AutoSize = true;

            // =============================================
            // COMPOSICIÓN FINAL DEL FORMULARIO
            // =============================================
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlCapturaDesplegable.ResumeLayout(false);
            this.pnlCapturaDesplegable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBotonCerrarX;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblLimite;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.Button btnAgregar;

        // Controles agregados para el comportamiento dinámico de Figma
        private System.Windows.Forms.Panel pnlCapturaDesplegable;
        private System.Windows.Forms.Label lblAsteriscoTipo;
        private System.Windows.Forms.Label lblPorAplicarPeriodo;
        private System.Windows.Forms.ComboBox cmbTipoEstimulo;
        private System.Windows.Forms.TextBox txtMontoPorAplicar;
        private System.Windows.Forms.Button btnGuardarCaptura;
        private System.Windows.Forms.Button btnCancelarCaptura;

        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorAplicar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblMensajeAlerta;
        private System.Windows.Forms.Label lblIconoAlerta;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCerrarForm;
    }
}