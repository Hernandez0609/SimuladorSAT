using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalleDescuentosIngresos : Form
    {
        public decimal MontoCapturado { get; private set; } = 0;

        public fmDetalleDescuentosIngresos()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            txtCampo2.KeyPress += clsValidacionNumerica.SoloNumeros;

            dgvTabla.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvTabla.IsCurrentCellDirty)
                    dgvTabla.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgvTabla.CellValueChanged += dgvTabla_CellEndEdit;
            this.dgvTabla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.SuspendLayout();
            CargarDatosTabla();
            CargarValorExistente();
            this.ResumeLayout(true);
        }

        private void CargarDatosTabla()
        {
            dgvTabla.Rows.Clear();
            var m = Program.modeloIsrFisicas;
            string mesActual = Program.declaracionActual != null ? Program.declaracionActual.Periodo : "";
            dgvTabla.Rows.Add(
                mesActual,
                m.DetalleEgresosFacturasCanceladas.ToString(),
                m.DetalleEgresosFacturasVigentes.ToString(),
                m.DetalleEgresosSubtotal.ToString("N0"),
                m.DetalleEgresosDescuento.ToString("N0"),
                (m.DetalleEgresosSubtotal - m.DetalleEgresosDescuento < 0 ? 0 : m.DetalleEgresosSubtotal - m.DetalleEgresosDescuento).ToString("N0")
            );
            if (m.DetalleEgresosSubtotal > 0 || m.DetalleEgresosDescuento > 0)
                txtCampo1.Text = (m.DetalleEgresosSubtotal - m.DetalleEgresosDescuento < 0 ? 0 : m.DetalleEgresosSubtotal - m.DetalleEgresosDescuento).ToString("N0");
        }

        private void CargarValorExistente()
        {
            // El copropiedad (campo2) es el único valor simple que podemos restaurar de una sesión anterior
            decimal valorPrevio = Program.modeloIsrFisicas.DescuentosCopropiedad;
            txtCampo2.Text = valorPrevio > 0 ? valorPrevio.ToString("N0") : "";
            RecalcularTotal();
        }

        private void dgvTabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colFacturasCanceladas.Index || e.ColumnIndex == colFacturasVigentes.Index ||
                e.ColumnIndex == colSubtotal.Index || e.ColumnIndex == colDescuento.Index)
            {
                RecalcularFilaTabla(e.RowIndex);
            }
        }

        private void RecalcularFilaTabla(int filaIndex)
        {
            var fila = dgvTabla.Rows[filaIndex];

            decimal.TryParse(fila.Cells[colSubtotal.Index].Value?.ToString(), out decimal subtotal);
            decimal.TryParse(fila.Cells[colDescuento.Index].Value?.ToString(), out decimal descuento);

            decimal subtotalDescuento = subtotal - descuento;
            if (subtotalDescuento < 0) subtotalDescuento = 0;

            fila.Cells[colSubtotalDescuento.Index].Value = subtotalDescuento.ToString("N0");

            txtCampo1.Text = subtotalDescuento.ToString("N0");
            RecalcularTotal();
        }

        private void txtCampo2_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            decimal.TryParse(txtCampo1.Text, out decimal fiscalesEgresos);
            decimal.TryParse(txtCampo2.Text, out decimal copropiedad);

            decimal total = fiscalesEgresos - copropiedad;
            if (total < 0) total = 0;

            txtCampo3.Text = total.ToString("N0");
        }

        private void GuardarYCerrar()
        {
            decimal.TryParse(txtCampo3.Text, out decimal valor);   
            MontoCapturado = valor;
            Program.modeloIsrFisicas.Descuentos = valor;
            Program.modeloIsrFisicas.DescuentosCapturado = true;

            decimal.TryParse(txtCampo2.Text, out decimal copropiedad);
            Program.modeloIsrFisicas.DescuentosCopropiedad = copropiedad;
            var fila = dgvTabla.Rows[0];
            int.TryParse(fila.Cells[colFacturasCanceladas.Index].Value?.ToString(), out int canceladas);
            int.TryParse(fila.Cells[colFacturasVigentes.Index].Value?.ToString(), out int vigentes);
            decimal.TryParse(fila.Cells[colSubtotal.Index].Value?.ToString(), out decimal subtotal);
            decimal.TryParse(fila.Cells[colDescuento.Index].Value?.ToString(), out decimal descuentoFactura);

            Program.modeloIsrFisicas.DetalleEgresosFacturasCanceladas = canceladas;
            Program.modeloIsrFisicas.DetalleEgresosFacturasVigentes = vigentes;
            Program.modeloIsrFisicas.DetalleEgresosSubtotal = subtotal;
            Program.modeloIsrFisicas.DetalleEgresosDescuento = descuentoFactura;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            GuardarYCerrar();
        }

        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            GuardarYCerrar();
        }
    }
}