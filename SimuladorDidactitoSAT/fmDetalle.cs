using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalle : Form
    {
        public fmDetalle(string titulo, string mesActual)
        {
            InitializeComponent();

            // Centrar contenido de todas las celdas en tiempo de ejecución
            this.dgvTabla1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Centrar los encabezados
            this.dgvTabla1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTabla2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Size = new System.Drawing.Size(1400, 700);

            if (dgvTabla1.Rows.Count == 0)
                dgvTabla1.Rows.Add();
            if (dgvTabla2.Rows.Count == 0)
                dgvTabla2.Rows.Add();

            this.dgvTabla1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla1.ColumnHeadersHeight = 40;
            this.dgvTabla2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla2.ColumnHeadersHeight = 40;
            this.dgvTabla1.RowTemplate.Height = 40;
            this.dgvTabla2.RowTemplate.Height = 40;

            // =========================================================================
            // 1. ELIMINAR EL AZUL AL DAR CLIC EN AMBAS TABLAS
            // =========================================================================
            this.dgvTabla1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvTabla1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTabla2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvTabla2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // Enlazar los eventos que pintarán de forma automática todas las celdas de datos
            this.dgvTabla1.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvTabla1_CellFormatting);
            this.dgvTabla2.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvTabla2_CellFormatting);

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
                this.lblDescripcion.Text =
                    "A continuación se muestra el detalle de prellenado de IVA no cobrado por devoluciones, " +
                    "descuentos y bonificaciones de ventas, este detalle lo puedes consultar en el visor " +
                    "de facturas emitidas y recibidas.";

                // Cambia el texto de la tabla 1 a "tipo egreso"
                this.lblTextoTabla1.Text = "Suma de facturas emitidas de tipo egreso del mes con método de pago " +
                    "\"Pago en una sola exhibición\" (PUE).";

                // Cambia encabezados de las columnas finales de tabla 1
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Impuestos Trasladados IVA 8%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Impuestos Trasladados IVA 16%";
                this.dgvTabla1.Columns["dataGridViewTextBoxColumn14"].Visible = true;

                // Ocultar tabla 2 completa y su label
                this.dgvTabla2.Visible = false;
                this.lblTextoTabla2.Visible = false;

                // Labels de abajo
                this.lblCampo1.Text = "IVA 8% de facturas emitidas de tipo egreso";
                this.lblCampo2.Text = "IVA 16% de facturas emitidas de tipo egreso";
                this.lblCampo3.Text = "IVA no cobrado por devoluciones, descuentos y bonificaciones de ventas";

                // Subir los campos de abajo porque falta la tabla 2
                this.lblCampo1.Location = new System.Drawing.Point(30, 230);
                this.txtCampo1.Location = new System.Drawing.Point(700, 227);
                this.lblCampo2.Location = new System.Drawing.Point(30, 270);
                this.lblSigno2.Location = new System.Drawing.Point(660, 273);
                this.txtCampo2.Location = new System.Drawing.Point(700, 269);
                this.lblCampo3.Location = new System.Drawing.Point(30, 310);
                this.lblSigno3.Location = new System.Drawing.Point(660, 313);
                this.txtCampo3.Location = new System.Drawing.Point(700, 309);

                // Botón Cerrar también sube
                this.btnCerrar.Location = new System.Drawing.Point(1260, 540);

                // Reducir altura del form
                this.Size = new System.Drawing.Size(1400, 510);
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

        // MÉTODOS PARA PINTAR TODAS LAS CELDAS (INCLUYENDO EL MES) EN GRIS FIGMA (#EEEEEE)
        // =========================================================================
        private void dgvTabla1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Color Gris exacto (#EEEEEE)
            System.Drawing.Color grisFigma = System.Drawing.Color.FromArgb(238, 238, 238);

            if (e.RowIndex >= 0)
            {
                // Pintamos ABSOLUTAMENTE TODAS las celdas de la fila en gris
                e.CellStyle.BackColor = grisFigma;
                e.CellStyle.SelectionBackColor = grisFigma; // Evita el azul al dar clic
            }
        }

        private void dgvTabla2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Color Gris exacto (#EEEEEE)
            System.Drawing.Color grisFigma = System.Drawing.Color.FromArgb(238, 238, 238);

            if (e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = grisFigma;
                e.CellStyle.SelectionBackColor = grisFigma; // Evita el azul al dar clic
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}