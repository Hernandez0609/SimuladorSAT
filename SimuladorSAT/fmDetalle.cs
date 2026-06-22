using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDetalle : Form
    {
        /// <summary>
        /// Constructor genérico del modal de detalle.
        /// </summary>
        /// <param name="titulo">Título que aparece en la franja azul y como encabezado del campo total (ej: "Actividades gravadas a la tasa del 16%")</param>
        /// <param name="mesActual">Mes que se muestra en ambas tablas (ej: "Junio")</param>
        public fmDetalle(string titulo, string mesActual)
        {
            InitializeComponent();

            // Esto obliga a la ventana a medir 1400x700 en ejecución pase lo que pase
            this.Size = new System.Drawing.Size(1400, 700);

            // Agregar la fila si la tabla está vacía
            if (dgvTabla1.Rows.Count == 0)
                dgvTabla1.Rows.Add();
            if (dgvTabla2.Rows.Count == 0)
                dgvTabla2.Rows.Add();

            // Título de la franja azul
            this.lblTituloModal.Text = titulo;
            this.Text = titulo;

            // Texto de descripción dinámico (usa el título recibido)
            this.lblDescripcion.Text =
                $"A continuación se muestra el detalle de prellenado de IVA de las actividades gravadas, " +
                $"este detalle lo puedes consultar en el visor de facturas emitidas y recibidas.";

            // Último campo (el total) toma el mismo texto que el título
            this.lblCampo3.Text = titulo;

            // Mes en ambas tablas
            this.dgvTabla1.Rows[0].Cells["dataGridViewTextBoxColumn7"].Value = mesActual;
            this.dgvTabla2.Rows[0].Cells["dataGridViewTextBoxColumn1"].Value = mesActual;
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
