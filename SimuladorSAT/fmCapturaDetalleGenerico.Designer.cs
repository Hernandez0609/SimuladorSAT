namespace SimuladorSAT
{
    partial class fmCapturaDetalleGenerico
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
            this.lblTotalMonto = new System.Windows.Forms.Label();
            this.pnlFormularioCaptura = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblPeriodicidad = new System.Windows.Forms.Label();
            this.txtPeriodicidad = new System.Windows.Forms.TextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.lblEjercicio = new System.Windows.Forms.Label();
            this.txtEjercicio = new System.Windows.Forms.TextBox();
            this.lblFechaCausacion = new System.Windows.Forms.Label();
            this.txtFechaCausacion = new System.Windows.Forms.TextBox();
            this.lblNumOp1 = new System.Windows.Forms.Label();
            this.txtNumOp1 = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblSaldoAplicar = new System.Windows.Forms.Label();
            this.txtSaldoAplicar = new System.Windows.Forms.TextBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTipoDecl = new System.Windows.Forms.Label();
            this.txtTipoDecl = new System.Windows.Forms.TextBox();
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.lblTipoEstimulo = new System.Windows.Forms.Label();
            this.cmbTipoEstimulo = new System.Windows.Forms.ComboBox();
            this.lblPorAplicar = new System.Windows.Forms.Label();
            this.txtPorAplicar = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFormularioCaptura.SuspendLayout();
            this.SuspendLayout();

            // ==========================================
            // PANEL CABECERA (ESTILO FIGMA AZUL OSCURO)
            // ==========================================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblTotalMonto);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(950, 75);

            // Título Principal
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Georgia", 14F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);
            this.lblTitulo.Size = new System.Drawing.Size(150, 25);
            this.lblTitulo.Text = "Compensaciones";

            // Total Acumulado Derecho
            this.lblTotalMonto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalMonto.Font = new System.Drawing.Font("Georgia", 14F);
            this.lblTotalMonto.ForeColor = System.Drawing.Color.White;
            this.lblTotalMonto.Location = new System.Drawing.Point(750, 25);
            this.lblTotalMonto.Size = new System.Drawing.Size(160, 25);
            this.lblTotalMonto.Text = "Total: $0";
            this.lblTotalMonto.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // ====================================================================
            // PANEL CONTENEDOR DESPLEGABLE (Escondido al abrir por primera vez)
            // ====================================================================
            this.pnlFormularioCaptura.BackColor = System.Drawing.Color.White;
            this.pnlFormularioCaptura.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTipo, this.cmbTipo, this.lblPeriodicidad, this.txtPeriodicidad, this.lblPeriodo, this.txtPeriodo, this.lblEjercicio, this.txtEjercicio,
                this.lblFechaCausacion, this.txtFechaCausacion, this.lblNumOp1, this.txtNumOp1, this.lblConcepto, this.txtConcepto, this.lblSaldoAplicar, this.txtSaldoAplicar,
                this.btnContinuar, this.btnEliminar,
                this.lblTipoDecl, this.txtTipoDecl, this.lblNumOp2, this.txtNumOp2, this.lblMontoSaldo, this.txtMontoSaldo,
                this.lblRemanHist, this.txtRemanHist, this.lblFechaDecl, this.txtFechaDecl, this.lblRemanAct, this.txtRemanAct
            });
            this.pnlFormularioCaptura.Location = new System.Drawing.Point(20, 90);
            this.pnlFormularioCaptura.Size = new System.Drawing.Size(910, 340);
            this.pnlFormularioCaptura.Visible = false; // CRÍTICO: Inicia limpio estilo Figma

            // --- FILA 1 DE CAPTURA (4 Columnas) ---
            // Columna 1: Tipo
            this.lblTipo.Text = "Tipo";
            this.lblTipo.Location = new System.Drawing.Point(20, 10);
            this.lblTipo.Size = new System.Drawing.Size(180, 20);
            this.cmbTipo.Location = new System.Drawing.Point(20, 35);
            this.cmbTipo.Size = new System.Drawing.Size(200, 25);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Columna 2: Periodicidad
            this.lblPeriodicidad.Text = "Periodicidad";
            this.lblPeriodicidad.Location = new System.Drawing.Point(240, 10);
            this.lblPeriodicidad.Size = new System.Drawing.Size(180, 20);
            this.txtPeriodicidad.Location = new System.Drawing.Point(240, 35);
            this.txtPeriodicidad.Size = new System.Drawing.Size(200, 25);

            // Columna 3: Periodo
            this.lblPeriodo.Text = "Periodo";
            this.lblPeriodo.Location = new System.Drawing.Point(460, 10);
            this.lblPeriodo.Size = new System.Drawing.Size(180, 20);
            this.txtPeriodo.Location = new System.Drawing.Point(460, 35);
            this.txtPeriodo.Size = new System.Drawing.Size(200, 25);

            // Columna 4: Ejercicio
            this.lblEjercicio.Text = "Ejercicio";
            this.lblEjercicio.Location = new System.Drawing.Point(680, 10);
            this.lblEjercicio.Size = new System.Drawing.Size(180, 20);
            this.txtEjercicio.Location = new System.Drawing.Point(680, 35);
            this.txtEjercicio.Size = new System.Drawing.Size(200, 25);

            // --- FILA 2 DE CAPTURA (4 Columnas) ---
            // Columna 1: Fecha de causación
            this.lblFechaCausacion.Text = "Fecha de causación (dd-mm-aaaa)";
            this.lblFechaCausacion.Location = new System.Drawing.Point(20, 75);
            this.lblFechaCausacion.Size = new System.Drawing.Size(210, 20);
            this.txtFechaCausacion.Location = new System.Drawing.Point(20, 100);
            this.txtFechaCausacion.Size = new System.Drawing.Size(200, 25);

            // Columna 2: Número de operación
            this.lblNumOp1.Text = "Numero de operación";
            this.lblNumOp1.Location = new System.Drawing.Point(240, 75);
            this.lblNumOp1.Size = new System.Drawing.Size(180, 20);
            this.txtNumOp1.Location = new System.Drawing.Point(240, 100);
            this.txtNumOp1.Size = new System.Drawing.Size(200, 25);

            // Columna 3: Concepto
            this.lblConcepto.Text = "Concepto";
            this.lblConcepto.Location = new System.Drawing.Point(460, 75);
            this.lblConcepto.Size = new System.Drawing.Size(180, 20);
            this.txtConcepto.Location = new System.Drawing.Point(460, 100);
            this.txtConcepto.Size = new System.Drawing.Size(200, 25);

            // Columna 4: Saldo a aplicar
            this.lblSaldoAplicar.Text = "Saldo a aplicar";
            this.lblSaldoAplicar.Location = new System.Drawing.Point(680, 75);
            this.lblSaldoAplicar.Size = new System.Drawing.Size(180, 20);
            this.txtSaldoAplicar.Location = new System.Drawing.Point(680, 100);
            this.txtSaldoAplicar.Size = new System.Drawing.Size(200, 25);
            this.txtSaldoAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // --- BOTONES INTERMEDIOS DE FLUJO ---
            // Continuar (Rojo sólido institucional del SAT)
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.BackColor = System.Drawing.Color.Red;
            this.btnContinuar.ForeColor = System.Drawing.Color.Black;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Location = new System.Drawing.Point(20, 140);
            this.btnContinuar.Size = new System.Drawing.Size(110, 32);

            // Eliminar (Blanco con borde gris)
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(140, 140);
            this.btnEliminar.Size = new System.Drawing.Size(110, 32);

            // --- SEGUNDO BLOQUE DE DATOS: SALDO A FAVOR (2 Columnas anchas) ---
            // Columna Izquierda
            this.lblTipoDecl.Text = "Tipo de declaración";
            this.lblTipoDecl.Location = new System.Drawing.Point(20, 195);
            this.lblTipoDecl.Size = new System.Drawing.Size(260, 20);
            this.txtTipoDecl.Location = new System.Drawing.Point(290, 192);
            this.txtTipoDecl.Size = new System.Drawing.Size(200, 25);

            this.lblMontoSaldo.Text = "Monto del saldo a favor original";
            this.lblMontoSaldo.Location = new System.Drawing.Point(20, 230);
            this.lblMontoSaldo.Size = new System.Drawing.Size(260, 20);
            this.txtMontoSaldo.Location = new System.Drawing.Point(290, 227);
            this.txtMontoSaldo.Size = new System.Drawing.Size(200, 25);

            this.lblFechaDecl.Text = "Fecha en que se presentó la declaración del saldo a favor (dd-mm-aaaa)";
            this.lblFechaDecl.Location = new System.Drawing.Point(20, 265);
            this.lblFechaDecl.Size = new System.Drawing.Size(260, 40); // Doble renglón por texto largo
            this.txtFechaDecl.Location = new System.Drawing.Point(290, 262);
            this.txtFechaDecl.Size = new System.Drawing.Size(200, 25);

            // Columna Derecha
            this.lblNumOp2.Text = "Número de operación";
            this.lblNumOp2.Location = new System.Drawing.Point(520, 195);
            this.lblNumOp2.Size = new System.Drawing.Size(180, 20);
            this.txtNumOp2.Location = new System.Drawing.Point(710, 192);
            this.txtNumOp2.Size = new System.Drawing.Size(180, 25);

            this.lblRemanHist.Text = "Remanente histórico antes de la aplicación";
            this.lblRemanHist.Location = new System.Drawing.Point(520, 230);
            this.lblRemanHist.Size = new System.Drawing.Size(180, 20);
            this.txtRemanHist.Location = new System.Drawing.Point(710, 227);
            this.txtRemanHist.Size = new System.Drawing.Size(180, 25);

            this.lblRemanAct.Text = "Remanente actualizado antes de la aplicación";
            this.lblRemanAct.Location = new System.Drawing.Point(520, 265);
            this.lblRemanAct.Size = new System.Drawing.Size(180, 20);
            this.txtRemanAct.Location = new System.Drawing.Point(710, 262);
            this.txtRemanAct.Size = new System.Drawing.Size(180, 25);

            // ====================================================================
            // PANEL INFERIOR FIJO: BOTONES DE ACCIÓN DE LA VENTANA
            // ====================================================================
            // Cancelar (Izquierda del grupo)
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(620, 445);
            this.btnCancelar.Size = new System.Drawing.Size(95, 32);

            // Agregar (Fondo azul oscuro oficial del simulador)
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(725, 445);
            this.btnAgregar.Size = new System.Drawing.Size(95, 32);

            // Terminar (Borde gris, fondo blanco)
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.BackColor = System.Drawing.Color.White;
            this.btnTerminar.Location = new System.Drawing.Point(830, 445);
            this.btnTerminar.Size = new System.Drawing.Size(95, 32);

            // ==========================================
            // CONFIGURACIÓN PROPIEDADES DE VENTANA DIÁLOGO MODAL FLOATING
            // ==========================================
            this.ClientSize = new System.Drawing.Size(950, 500);
            this.Text = "";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Activa la sombra nativa
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Georgia", 10F); // Tipografía Georgia corporativa del SAT

            // Registro general de las capas en el Formulario
            this.Controls.Add(this.pnlFormularioCaptura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.pnlHeader);

            // Controles fantasmas no utilizados pero declarados
            this.Controls.Add(this.lblTipoEstimulo);
            this.Controls.Add(this.cmbTipoEstimulo);
            this.Controls.Add(this.lblPorAplicar);
            this.Controls.Add(this.txtPorAplicar);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormularioCaptura.ResumeLayout(false);
            this.pnlFormularioCaptura.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Componentes nativos reestructurados
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTotalMonto;
        private System.Windows.Forms.Panel pnlFormularioCaptura;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnTerminar;

        // Variables de control originales mapeadas perfectamente
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblPeriodicidad;
        private System.Windows.Forms.TextBox txtPeriodicidad;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label lblEjercicio;
        private System.Windows.Forms.TextBox txtEjercicio;
        private System.Windows.Forms.Label lblFechaCausacion;
        private System.Windows.Forms.TextBox txtFechaCausacion;
        private System.Windows.Forms.Label lblNumOp1;
        private System.Windows.Forms.TextBox txtNumOp1;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblSaldoAplicar;
        private System.Windows.Forms.TextBox txtSaldoAplicar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTipoDecl;
        private System.Windows.Forms.TextBox txtTipoDecl;
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
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTipoEstimulo;
        private System.Windows.Forms.ComboBox cmbTipoEstimulo;
        private System.Windows.Forms.Label lblPorAplicar;
        private System.Windows.Forms.TextBox txtPorAplicar;
    }
}