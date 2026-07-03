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
            this.lblTitulo = new System.Windows.Forms.Label();
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
            this.pnlSep = new System.Windows.Forms.Panel();
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTipoEstimulo = new System.Windows.Forms.Label();
            this.cmbTipoEstimulo = new System.Windows.Forms.ComboBox();
            this.lblPorAplicar = new System.Windows.Forms.Label();
            this.txtPorAplicar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // ==========================================
            // TITULO
            // ==========================================
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(400, 25);
            this.lblTitulo.AutoSize = true;

            // ==========================================
            // MODO ESTIMULOS
            // ==========================================
            this.lblTipoEstimulo.Text = "*Tipo de estímulo";
            this.lblTipoEstimulo.Location = new System.Drawing.Point(20, 60);
            this.lblTipoEstimulo.Size = new System.Drawing.Size(150, 20);

            this.cmbTipoEstimulo.Location = new System.Drawing.Point(200, 57);
            this.cmbTipoEstimulo.Size = new System.Drawing.Size(450, 25);
            this.cmbTipoEstimulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEstimulo.Items.AddRange(new object[] { "--- Seleccione ---", "Estímulo fronterizo", "Estímulo diésel para maquinaria", "Otros estímulos autorizados" });
            this.cmbTipoEstimulo.SelectedIndex = 0;

            this.lblPorAplicar.Text = "*Por aplicar en el periodo";
            this.lblPorAplicar.Location = new System.Drawing.Point(20, 100);
            this.lblPorAplicar.Size = new System.Drawing.Size(150, 20);

            this.txtPorAplicar.Location = new System.Drawing.Point(200, 97);
            this.txtPorAplicar.Size = new System.Drawing.Size(150, 25);
            this.txtPorAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ==========================================
            // MODO COMPENSACIONES (Sección Izquierda)
            // ==========================================
            this.lblTipo.Text = "*Tipo";
            this.lblTipo.Location = new System.Drawing.Point(20, 60);
            this.lblTipo.Size = new System.Drawing.Size(150, 20);

            this.cmbTipo.Location = new System.Drawing.Point(200, 57);
            this.cmbTipo.Size = new System.Drawing.Size(250, 25);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "--- Seleccione ---", "IVA Saldo a Favor" });
            this.cmbTipo.SelectedIndex = 0;

            this.lblPeriodicidad.Text = "Periodicidad";
            this.lblPeriodicidad.Location = new System.Drawing.Point(20, 95);
            this.lblPeriodicidad.Size = new System.Drawing.Size(150, 20);
            this.txtPeriodicidad.Location = new System.Drawing.Point(200, 92);
            this.txtPeriodicidad.Size = new System.Drawing.Size(150, 25);

            this.lblPeriodo.Text = "Periodo";
            this.lblPeriodo.Location = new System.Drawing.Point(20, 130);
            this.lblPeriodo.Size = new System.Drawing.Size(150, 20);
            this.txtPeriodo.Location = new System.Drawing.Point(200, 127);
            this.txtPeriodo.Size = new System.Drawing.Size(150, 25);

            this.lblEjercicio.Text = "Ejercicio";
            this.lblEjercicio.Location = new System.Drawing.Point(20, 165);
            this.lblEjercicio.Size = new System.Drawing.Size(150, 20);
            this.txtEjercicio.Location = new System.Drawing.Point(200, 162);
            this.txtEjercicio.Size = new System.Drawing.Size(150, 25);

            this.lblFechaCausacion.Text = "Fecha de causación";
            this.lblFechaCausacion.Location = new System.Drawing.Point(20, 200);
            this.lblFechaCausacion.Size = new System.Drawing.Size(150, 20);
            this.txtFechaCausacion.Location = new System.Drawing.Point(200, 197);
            this.txtFechaCausacion.Size = new System.Drawing.Size(150, 25);

            this.lblNumOp1.Text = "Número de operación";
            this.lblNumOp1.Location = new System.Drawing.Point(20, 235);
            this.lblNumOp1.Size = new System.Drawing.Size(150, 20);
            this.txtNumOp1.Location = new System.Drawing.Point(200, 232);
            this.txtNumOp1.Size = new System.Drawing.Size(150, 25);

            this.lblConcepto.Text = "Concepto";
            this.lblConcepto.Location = new System.Drawing.Point(20, 270);
            this.lblConcepto.Size = new System.Drawing.Size(150, 20);
            this.txtConcepto.Location = new System.Drawing.Point(200, 267);
            this.txtConcepto.Size = new System.Drawing.Size(150, 25);

            this.lblSaldoAplicar.Text = "*Saldo a aplicar";
            this.lblSaldoAplicar.Location = new System.Drawing.Point(20, 305);
            this.lblSaldoAplicar.Size = new System.Drawing.Size(150, 20);
            this.txtSaldoAplicar.Location = new System.Drawing.Point(200, 302);
            this.txtSaldoAplicar.Size = new System.Drawing.Size(150, 25);
            this.txtSaldoAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.Location = new System.Drawing.Point(200, 340);
            this.btnContinuar.Size = new System.Drawing.Size(90, 30);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(300, 340);
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);

            // ==========================================
            // SEPARADOR VISUAL
            // ==========================================
            this.pnlSep.BackColor = System.Drawing.Color.LightGray;
            this.pnlSep.Location = new System.Drawing.Point(470, 55);
            this.pnlSep.Size = new System.Drawing.Size(1, 315);

            // ==========================================
            // COMPENSACIONES (Sección Derecha - Saldo Original)
            // ==========================================
            this.lblTipoDecl.Text = "Tipo de declaración";
            this.lblTipoDecl.Location = new System.Drawing.Point(490, 60);
            this.lblTipoDecl.Size = new System.Drawing.Size(150, 20);
            this.txtTipoDecl.Location = new System.Drawing.Point(670, 57);
            this.txtTipoDecl.Size = new System.Drawing.Size(150, 25);

            this.lblNumOp2.Text = "Número de operación";
            this.lblNumOp2.Location = new System.Drawing.Point(490, 95);
            this.lblNumOp2.Size = new System.Drawing.Size(150, 20);
            this.txtNumOp2.Location = new System.Drawing.Point(670, 92);
            this.txtNumOp2.Size = new System.Drawing.Size(150, 25);

            this.lblMontoSaldo.Text = "Monto del saldo a favor";
            this.lblMontoSaldo.Location = new System.Drawing.Point(490, 130);
            this.lblMontoSaldo.Size = new System.Drawing.Size(150, 20);
            this.txtMontoSaldo.Location = new System.Drawing.Point(670, 127);
            this.txtMontoSaldo.Size = new System.Drawing.Size(150, 25);

            this.lblRemanHist.Text = "Remanente histórico";
            this.lblRemanHist.Location = new System.Drawing.Point(490, 165);
            this.lblRemanHist.Size = new System.Drawing.Size(150, 20);
            this.txtRemanHist.Location = new System.Drawing.Point(670, 162);
            this.txtRemanHist.Size = new System.Drawing.Size(150, 25);

            this.lblFechaDecl.Text = "Fecha de presentación";
            this.lblFechaDecl.Location = new System.Drawing.Point(490, 200);
            this.lblFechaDecl.Size = new System.Drawing.Size(150, 20);
            this.txtFechaDecl.Location = new System.Drawing.Point(670, 197);
            this.txtFechaDecl.Size = new System.Drawing.Size(150, 25);

            this.lblRemanAct.Text = "Remanente actualizado";
            this.lblRemanAct.Location = new System.Drawing.Point(490, 235);
            this.lblRemanAct.Size = new System.Drawing.Size(150, 20);
            this.txtRemanAct.Location = new System.Drawing.Point(670, 232);
            this.txtRemanAct.Size = new System.Drawing.Size(150, 25);

            // ==========================================
            // BOTONES DE CONTROL DE ABAJO
            // ==========================================
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(630, 400);
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(730, 400);
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);

            // ==========================================
            // PROPIEDADES DEL FORMULARIO
            // ==========================================
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Text = "Captura Detalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitulo, this.lblTipoEstimulo, this.cmbTipoEstimulo, this.lblPorAplicar, this.txtPorAplicar,
                this.lblTipo, this.cmbTipo, this.lblPeriodicidad, this.txtPeriodicidad, this.lblPeriodo, this.txtPeriodo,
                this.lblEjercicio, this.txtEjercicio, this.lblFechaCausacion, this.txtFechaCausacion, this.lblNumOp1, this.txtNumOp1,
                this.lblConcepto, this.txtConcepto, this.lblSaldoAplicar, this.txtSaldoAplicar, this.btnContinuar, this.btnEliminar,
                this.pnlSep, this.lblTipoDecl, this.txtTipoDecl, this.lblNumOp2, this.txtNumOp2, this.lblMontoSaldo, this.txtMontoSaldo,
                this.lblRemanHist, this.txtRemanHist, this.lblFechaDecl, this.txtFechaDecl, this.lblRemanAct, this.txtRemanAct,
                this.btnCancelar, this.btnGuardar
            });
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

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
        private System.Windows.Forms.Panel pnlSep;
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
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTipoEstimulo;
        private System.Windows.Forms.ComboBox cmbTipoEstimulo;
        private System.Windows.Forms.Label lblPorAplicar;
        private System.Windows.Forms.TextBox txtPorAplicar;
    }
}