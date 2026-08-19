using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalle : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;
        private bool _esDevoluciones = false;
        private decimal _montoMaximo = 0;

        public fmDetalle(string titulo, string mesActual, decimal montoMaximo = 0)
        {
            InitializeComponent();
            _montoMaximo = montoMaximo;
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.SuspendLayout();
            this.dgvTabla1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Size = new System.Drawing.Size(1400, 700);
            if (dgvTabla1.Rows.Count == 0) dgvTabla1.Rows.Add();
            if (dgvTabla2.Rows.Count == 0) dgvTabla2.Rows.Add();
            this.dgvTabla1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla1.ColumnHeadersHeight = 40;
            this.dgvTabla2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla2.ColumnHeadersHeight = 40;
            this.dgvTabla1.RowTemplate.Height = 40;
            this.dgvTabla2.RowTemplate.Height = 40;
            this.dgvTabla1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvTabla1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvTabla1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTabla2.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvTabla2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dgvTabla2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.lblTituloModal.Text = titulo;
            this.Text = titulo;
            this.dgvTabla1.Rows[0].Cells["dataGridViewTextBoxColumn7"].Value = mesActual;
            this.dgvTabla2.Rows[0].Cells["dataGridViewTextBoxColumn1"].Value = mesActual;
            LimpiarCeldasYTextos();

            if (titulo.Contains("exentas") || titulo.Contains("Exentas"))
            {
                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de IVA de las actividades exentas, " +
                    "este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos trasladados Base exento";
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Impuestos trasladados Base IVA 16%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = false;
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn6"].Visible = false;
                this.lblCampo1.Text = "Base IVA exento de facturas emitidas de tipo ingreso";
                this.lblCampo2.Text = "Base IVA exento de facturas emitidas de tipo pago";
                this.lblCampo3.Text = "Actividades exentas";
            }
            else if (titulo.Contains("no objeto") || titulo.Contains("No objeto"))
            {
                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de las actividades no objeto del impuesto, " +
                    "este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos trasladados base no objeto";
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Impuestos trasladados base no objeto";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = false;
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn6"].Visible = false;
                this.lblCampo1.Text = "Base IVA no objeto de facturas emitidas de tipo ingreso";
                this.lblCampo2.Text = "Base IVA no objeto de facturas emitidas de tipo pago";
                this.lblCampo3.Text = "Actividades no objeto del impuesto";
            }
            else if (titulo.Contains("devoluciones") || titulo.Contains("Devoluciones"))
            {
                _esDevoluciones = true;   // ← activa la lógica editable

                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de IVA no cobrado por devoluciones, " +
                    "descuentos y bonificaciones de ventas, este detalle lo puedes consultar en el visor " +
                    "de facturas emitidas y recibidas.";
                this.lblTextoTabla1.Text = "Suma de facturas emitidas de tipo egreso del mes con método de pago " +
                    "\"Pago en una sola exhibición\" (PUE).";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos Trasladados IVA 8%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Impuestos Trasladados IVA 16%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = true;
                this.dgvTabla2.Visible = false;
                this.lblTextoTabla2.Visible = false;
                this.lblCampo1.Text = "IVA 8% de facturas emitidas de tipo egreso";
                this.lblCampo2.Text = "IVA 16% de facturas emitidas de tipo egreso";
                this.lblCampo3.Text = "IVA no cobrado por devoluciones, descuentos y bonificaciones de ventas";
                this.lblCampo1.Location = new System.Drawing.Point(30, 230);
                this.txtCampo1.Location = new System.Drawing.Point(700, 227);
                this.lblCampo2.Location = new System.Drawing.Point(30, 270);
                this.lblSigno2.Location = new System.Drawing.Point(660, 273);
                this.txtCampo2.Location = new System.Drawing.Point(700, 269);
                this.lblCampo3.Location = new System.Drawing.Point(30, 310);
                this.lblSigno3.Location = new System.Drawing.Point(660, 313);
                this.txtCampo3.Location = new System.Drawing.Point(700, 309);
                this.btnCerrar.Location = new System.Drawing.Point(1260, 540);
                this.Size = new System.Drawing.Size(1400, 510);

                // ==== Habilita edición de la tabla, solo en esta rama ====
                dgvTabla1.ReadOnly = false;
                dgvTabla1.Columns["dataGridViewTextBoxColumn7"].ReadOnly = true;   // Mes bloqueado
                dgvTabla1.Columns["dataGridViewTextBoxColumn12"].ReadOnly = true;  // Subtotal-Descuento (calculado)
                dgvTabla1.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvTabla1.CurrentCellDirtyStateChanged += (s, e) =>
                {
                    if (dgvTabla1.IsCurrentCellDirty)
                        dgvTabla1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };
                dgvTabla1.CellValueChanged += DgvTabla1_CellValueChanged_Devoluciones;

                CargarValoresExistentesDevoluciones();
            }
            else if (titulo.Contains("IVA retenido") || titulo.Contains("iva retenido"))
            {
                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de IVA retenido, " +
                    "este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos retenidos IVA";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = false;
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Impuestos retenidos IVA";
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn6"].Visible = false;
                this.lblCampo1.Text = "IVA retenido de facturas emitidas de tipo ingreso";
                this.lblCampo2.Text = "IVA retenido de facturas emitidas de tipo pago";
                this.lblCampo3.Text = "IVA retenido";
            }
            else if (titulo.Contains("bonificaciones en gastos") || titulo.Contains("Bonificaciones en gastos"))
            {
                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de IVA no acreditable por devoluciones, " +
                    "descuentos y bonificaciones en gastos, este detalle lo puedes consultar en el visor " +
                    "de facturas emitidas y recibidas.";
                this.lblTextoTabla1.Text = "Suma de facturas emitidas de tipo egreso del mes con método de pago " +
                    "\"Pago en una sola exhibición\" (PUE).";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos trasladados IVA 8%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Impuestos trasladados IVA 16%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = true;
                this.dgvTabla2.Visible = false;
                this.lblTextoTabla2.Visible = false;
                this.lblCampo1.Text = "IVA 8% de facturas recibidas de tipo egreso";
                this.lblCampo2.Text = "IVA 16% de facturas recibidas de tipo egreso";
                this.lblCampo3.Text = "IVA por devoluciones, descuentos y bonificaciones en gastos";
                this.lblCampo1.Location = new System.Drawing.Point(30, 280);
                this.txtCampo1.Location = new System.Drawing.Point(700, 277);
                this.lblCampo2.Location = new System.Drawing.Point(30, 320);
                this.lblSigno2.Location = new System.Drawing.Point(660, 323);
                this.txtCampo2.Location = new System.Drawing.Point(700, 319);
                this.lblCampo3.Location = new System.Drawing.Point(30, 360);
                this.lblSigno3.Location = new System.Drawing.Point(660, 363);
                this.txtCampo3.Location = new System.Drawing.Point(700, 359);
                this.btnCerrar.Location = new System.Drawing.Point(1265, 420);
                this.Size = new System.Drawing.Size(1400, 510);
            }
            else if (titulo.Contains("tasa del 0%") || titulo.Contains("Tasa del 0%"))
            {
                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de IVA de las actividades gravadas a la tasa del 0%, " +
                    "este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos trasladados Base 0%";
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Impuestos trasladados Base 0%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = false;
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn6"].Visible = false;
                this.lblCampo1.Text = "Bases IVA 0% de facturas emitidas de tipo ingreso";
                this.lblCampo2.Text = "Bases IVA 0% de facturas emitidas de tipo pago";
                this.lblCampo3.Text = "Actividades gravadas a la tasa del 0%";
            }
            else
            {
                this.lblDescripcion.Text =
                    $"A continuación se muestra el detalle de prellenado de IVA de las {titulo.ToLower()}, " +
                    $"este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos trasladados Base IVA 16%";
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Impuestos trasladados Base IVA 16%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = true;
                this.dgvTabla2.Columns["dataGridViewTextBoxColumn6"].Visible = true;
                this.lblCampo1.Text = "Base IVA 16% de facturas emitidas de tipo ingreso";
                this.lblCampo2.Text = "Base IVA 16% de facturas emitidas de tipo pago";
                this.lblCampo3.Text = titulo;
            }
            this.ResumeLayout(true);
        }

        // ==== Lógica exclusiva de la rama "devoluciones" ====
        private void CargarValoresExistentesDevoluciones()
        {
            var m = Program.modeloIva;
            var fila = dgvTabla1.Rows[0];
            fila.Cells["dataGridViewTextBoxColumn8"].Value = m.DetalleDevolucionesFacturasCanceladas.ToString();
            fila.Cells["dataGridViewTextBoxColumn9"].Value = m.DetalleDevolucionesFacturasVigentes.ToString();
            fila.Cells["dataGridViewTextBoxColumn10"].Value = m.DetalleDevolucionesSubtotal.ToString("N0");
            fila.Cells["dataGridViewTextBoxColumn11"].Value = m.DetalleDevolucionesDescuento.ToString("N0");
            decimal subDesc = m.DetalleDevolucionesSubtotal - m.DetalleDevolucionesDescuento;
            if (subDesc < 0) subDesc = 0;
            fila.Cells["dataGridViewTextBoxColumn12"].Value = subDesc.ToString("N0");
            fila.Cells["dataGridViewTextBoxColumn13"].Value = m.Iva8PorcentoEgresos.ToString("N0");
            fila.Cells["dataGridViewTextBoxColumn14"].Value = m.Iva16PorcentoEgresos.ToString("N0");
            txtCampo1.Text = m.Iva8PorcentoEgresos.ToString("N0");
            txtCampo2.Text = m.Iva16PorcentoEgresos.ToString("N0");
            RecalcularTotalDevoluciones();
        }

        private void DgvTabla1_CellValueChanged_Devoluciones(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvTabla1.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvTabla1.Columns["dataGridViewTextBoxColumn10"].Index ||
                e.ColumnIndex == dgvTabla1.Columns["dataGridViewTextBoxColumn11"].Index)
            {
                decimal.TryParse(fila.Cells["dataGridViewTextBoxColumn10"].Value?.ToString(), out decimal subtotal);
                decimal.TryParse(fila.Cells["dataGridViewTextBoxColumn11"].Value?.ToString(), out decimal descuento);
                decimal subDesc = subtotal - descuento;
                if (subDesc < 0) subDesc = 0;
                fila.Cells["dataGridViewTextBoxColumn12"].Value = subDesc.ToString("N0");
            }

            if (e.ColumnIndex == dgvTabla1.Columns["dataGridViewTextBoxColumn13"].Index)
            {
                decimal.TryParse(fila.Cells["dataGridViewTextBoxColumn13"].Value?.ToString(), out decimal iva8);
                txtCampo1.Text = iva8.ToString("N0");
            }

            if (e.ColumnIndex == dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Index)
            {
                decimal.TryParse(fila.Cells["dataGridViewTextBoxColumn14"].Value?.ToString(), out decimal iva16);
                txtCampo2.Text = iva16.ToString("N0");
            }

            RecalcularTotalDevoluciones();
        }

        private void RecalcularTotalDevoluciones()
        {
            decimal.TryParse(txtCampo1.Text, out decimal campo1);
            decimal.TryParse(txtCampo2.Text, out decimal campo2);
            decimal total = campo1 + campo2;

            if (_montoMaximo > 0 && total > _montoMaximo)
            {
                total = _montoMaximo;
                MessageBox.Show($"El monto no puede exceder el Total de IVA a cargo (${_montoMaximo:N0}).",
                    "Límite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtCampo3.Text = total.ToString("N0");
        }

        private void GuardarDevolucionesYCerrar()
        {
            var fila = dgvTabla1.Rows[0];
            int.TryParse(fila.Cells["dataGridViewTextBoxColumn8"].Value?.ToString(), out int canceladas);
            int.TryParse(fila.Cells["dataGridViewTextBoxColumn9"].Value?.ToString(), out int vigentes);
            decimal.TryParse(fila.Cells["dataGridViewTextBoxColumn10"].Value?.ToString(), out decimal subtotal);
            decimal.TryParse(fila.Cells["dataGridViewTextBoxColumn11"].Value?.ToString(), out decimal descuento);
            decimal.TryParse(txtCampo1.Text, out decimal iva8);
            decimal.TryParse(txtCampo2.Text, out decimal iva16);
            decimal.TryParse(txtCampo3.Text, out decimal total);

            var m = Program.modeloIva;
            m.DetalleDevolucionesFacturasCanceladas = canceladas;
            m.DetalleDevolucionesFacturasVigentes = vigentes;
            m.DetalleDevolucionesSubtotal = subtotal;
            m.DetalleDevolucionesDescuento = descuento;
            m.Iva8PorcentoEgresos = iva8;
            m.Iva16PorcentoEgresos = iva16;
            m.IvaNoCobradoDevoluciones = total;

            MontoCapturado = total;
        }

        private void LimpiarCeldasYTextos()
        {
            for (int i = 1; i < dgvTabla1.Columns.Count; i++)
                dgvTabla1.Rows[0].Cells[i].Value = "";
            for (int i = 1; i < dgvTabla2.Columns.Count; i++)
                dgvTabla2.Rows[0].Cells[i].Value = "";
            txtCampo1.Text = "";
            txtCampo2.Text = "";
            txtCampo3.Text = "";
            this.dgvTabla1.ClearSelection();
            this.dgvTabla2.ClearSelection();
        }

        private void dgvTabla1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            System.Drawing.Color grisFigma = System.Drawing.Color.FromArgb(238, 238, 238);
            if (e.RowIndex >= 0 && !_esDevoluciones)   
            {
                e.CellStyle.BackColor = grisFigma;
                e.CellStyle.SelectionBackColor = grisFigma;
            }
        }

        private void dgvTabla2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            System.Drawing.Color grisFigma = System.Drawing.Color.FromArgb(238, 238, 238);
            if (e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = grisFigma;
                e.CellStyle.SelectionBackColor = grisFigma;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (_esDevoluciones) GuardarDevolucionesYCerrar();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            if (_esDevoluciones) GuardarDevolucionesYCerrar();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}