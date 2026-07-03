using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmAdminDeclaracion : Form
    {
        private readonly Color ColorGrisBase = Color.FromArgb(200, 200, 200);
        private readonly Color ColorAzulNavbar = Color.FromArgb(13, 78, 92);

        private bool isrFisicasCompletado = false, isrSalariosCompletado = false, ivaSimplificadoCompletado = false;
        private decimal montoIsrFisicas = 0, montoIsrSalarios = 0, montoIvaSimplificado = 0;

        public fmAdminDeclaracion()
        {
            InitializeComponent();
            CargarImagenesCabecera();
            ConfigurarModulosCirculares();
        }

        private void CargarImagenesCabecera()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string rutaEscudo = Path.Combine(baseDir, "escudo.png");
                string rutaLogo = Path.Combine(baseDir, "logouthh.png");

                if (File.Exists(rutaEscudo)) picLogoIzquierdo.Image = Image.FromFile(rutaEscudo);
                if (File.Exists(rutaLogo)) picLogoDerecho.Image = Image.FromFile(rutaLogo);
            }
            catch { /* Evita interrupciones en tiempo de diseño */ }
        }

        private void ConfigurarModulosCirculares()
        {
            AsignarEfectoCircular(btnIsrFisicas, () => isrFisicasCompletado);
            AsignarEfectoCircular(btnIsrSalarios, () => isrSalariosCompletado);
            AsignarEfectoCircular(btnIvaSimplificado, () => ivaSimplificadoCompletado);

            btnIvaSimplificado.Click += BtnIvaSimplificado_Click;
            btnIsrFisicas.Click += (s, e) => MessageBox.Show("Módulo ISR Simplificado de Confianza Personas Físicas en desarrollo.", "Aviso");
            btnIsrSalarios.Click += (s, e) => MessageBox.Show("Módulo ISR Retenciones por Salarios en desarrollo.", "Aviso");
        }

        private void AsignarEfectoCircular(Button btn, Func<bool> estadoCompletado)
        {
            bool mouseHover = false;

            btn.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Color fondo = (estadoCompletado() || mouseHover) ? ColorAzulNavbar : ColorGrisBase;

                using (Brush brush = new SolidBrush(fondo))
                    e.Graphics.FillEllipse(brush, 0, 0, btn.Width - 1, btn.Height - 1);

                using (Font font = new Font("Arial", 16F, FontStyle.Bold))
                using (Brush brushText = new SolidBrush(Color.White))
                {
                    SizeF size = e.Graphics.MeasureString("✓", font);
                    e.Graphics.DrawString("✓", font, brushText, (btn.Width - size.Width) / 2, (btn.Height - size.Height) / 2);
                }
            };

            btn.MouseEnter += (s, e) => { mouseHover = true; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { mouseHover = false; btn.Invalidate(); };
        }

        private void BtnIvaSimplificado_Click(object sender, EventArgs e)
        {
            // Pasamos 'this' al constructor de fmResico para enlazar la navegación
            var frmIva = new fmResico(this)
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location,
                Size = this.Size,
                WindowState = this.WindowState
            };

            // Se suscribe al cierre de fmResico para actualizar los datos en caliente cuando regrese
            frmIva.FormClosed += (s, args) => {
                ivaSimplificadoCompletado = true;
                montoIvaSimplificado = 195; // Valor simulado

                btnIvaSimplificado.Invalidate();

                decimal total = montoIsrFisicas + montoIsrSalarios + montoIvaSimplificado;
                lblTotalPagar.Text = string.Format("Total a pagar: ${0:N0}", total);
            };

            frmIva.Show();
            this.Hide(); // Cede el paso ocultando la ventana actual
        }

        private void btnInicio_Click(object sender, EventArgs e) => this.Close();
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}