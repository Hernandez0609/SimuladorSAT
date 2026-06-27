using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmCapturar : Form
    {
        // Guardamos el color gris bajito de Figma
        private Color grisFigma = Color.FromArgb(238, 238, 238);
        private Color blanco = Color.White;

        public fmCapturar(string modoPantalla)
        {
            InitializeComponent();
            ConfigurarPantalla(modoPantalla);
        }

        private void ConfigurarPantalla(string modo)
        {
            if (modo == "Tasa0")
            {
                // ── CONFIGURACIÓN: ACTIVIDADES A LA TASA DEL 0% ──
                this.Text = "Actividades gravadas a la tasa del 0%";
                this.lblTitulo.Text = "Actividades gravadas a la tasa del 0%";
                this.lblDescripcion.Text = "Detalla el importe de las actividades gravadas a la tasa del 0%";

                this.lblCampo1.Text = "Actividades gravadas a la tasa del 0%";
                this.lblCampo2.Text = "Monto por detallar";
                this.lblCampo3.Text = "Monto detallado";
                this.lblCampo4.Text = "Actividades nacionales gravadas a la tasa del 0%";
                this.lblCampo5.Text = "Actividades de exportación gravadas a la tasa del 16%"; // Nota: el texto del SAT dice 16% en esa última etiqueta de la tasa 0%

                // En esta pantalla, el botón de Detalle SÍ se ve
                this.btnDetalleCampo1.Visible = true;

                // Todos los campos son informativos/gris en este estado inicial
                ConfigurarEstiloCampo(txtCampo1, true, "0");
                ConfigurarEstiloCampo(txtCampo2, true, "0");
                ConfigurarEstiloCampo(txtCampo3, true, "0");
                ConfigurarEstiloCampo(txtCampo4, true, "0");
                ConfigurarEstiloCampo(txtCampo5, true, "0");
            }
            else if (modo == "IvaAcreditable")
            {
                // ── CONFIGURACIÓN: IVA ACREDITABLE DEL PERIODO ──
                this.Text = "IVA acreditable del periodo";
                this.lblTitulo.Text = "IVA acreditable del periodo";
                this.lblDescripcion.Text = ""; // Esta pantalla no lleva texto de descripción arriba

                this.lblCampo1.Text = "IVA pagado en gastos y adquisiciones";
                this.lblCampo2.Text = "*IVA acreditable por actividades gravadas a tasa 16% u 8% y tasa 0%";
                this.lblCampo3.Text = "*IVA acreditable por actividades mixtas";
                this.lblCampo4.Text = "IVA acreditable del periodo";
                this.lblCampo5.Text = "IVA no acreditable";

                // En esta pantalla NO hay botón de detalle
                this.btnDetalleCampo1.Visible = false;

                // Configuración de colores específica del SAT:
                ConfigurarEstiloCampo(txtCampo1, true, "0");      // Gris con 0
                ConfigurarEstiloCampo(txtCampo2, false, "");     // Blanco VACÍO (Obligatorio)
                ConfigurarEstiloCampo(txtCampo3, false, "");     // Blanco VACÍO (Obligatorio)
                ConfigurarEstiloCampo(txtCampo4, true, "0");      // Gris con 0
                ConfigurarEstiloCampo(txtCampo5, false, "0");     // Blanco con 0
            }
        }

        private void ConfigurarEstiloCampo(TextBox txt, bool esGris, string valorInicial)
        {
            txt.Text = valorInicial;
            if (esGris)
            {
                txt.BackColor = grisFigma;
                txt.ReadOnly = true;
            }
            else
            {
                txt.BackColor = blanco;
                txt.ReadOnly = false; // Permite escritura para simular los obligatorios más adelante
            }
        }

        // Eventos de cierre de la ventana
        private void btnCerrarX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalleCampo1_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario genérico que ya tienes pasándole el título de la Tasa 0%
            // Tu código genérico ya sabe qué hacer si el título contiene "tasa del 0%"
            using (fmDetalle ventanaDetalle = new fmDetalle("Actividades gravadas a la tasa del 0%", "Junio"))
            {
                // Esto abrirá la pantalla gris con las dos tablas prellenadas
                ventanaDetalle.ShowDialog(this);
            }
        }
    }
}
