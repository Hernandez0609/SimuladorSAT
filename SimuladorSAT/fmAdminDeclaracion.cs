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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            CargarImagenesCabecera();
            ConfigurarModulosCirculares();
        }
        public void MarcarIvaSimplificadoCompletado(decimal monto)
        {
            ivaSimplificadoCompletado = true;
            montoIvaSimplificado = monto;
            btnIvaSimplificado.Invalidate();
            decimal total = montoIsrFisicas + montoIsrSalarios + montoIvaSimplificado;
            lblTotalPagar.Text = string.Format("Total a pagar: ${0:N0}", total);
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
            btnIsrFisicas.Click += btnIsrFisicas_Click;
        }

        private void btnIsrSalarios_Click(object sender, EventArgs e)
        {
            if (Program.formIsrSalarios == null || Program.formIsrSalarios.IsDisposed)
            {
                Program.formIsrSalarios = new fmIsrRetencionesSalarios();
            }
            Program.formIsrSalarios.WindowState = this.WindowState;
            Program.formIsrSalarios.Show();
            this.Hide();
        }

        private void btnIsrFisicas_Click(object sender, EventArgs e)
        {
            if (Program.formIsrFisicasIngresos == null || Program.formIsrFisicasIngresos.IsDisposed)
            {
                Program.formIsrFisicasIngresos = new fmIsrFisicasIngresos();
            }
            Program.formIsrFisicasIngresos.WindowState = this.WindowState;
            Program.formIsrFisicasIngresos.Show();
            this.Hide();
        }

        private void AsignarEfectoCircular(Button btn, Func<bool> estadoCompletado)
        {
            // SetStyle es protected, así que se invoca vía Reflection
            typeof(Control).InvokeMember("SetStyle",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance,
                null, btn, new object[] {
            ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
            true
                });
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
            if (Program.formResico == null || Program.formResico.IsDisposed)
            {
                Program.formResico = new fmResico(Program.formAdmin)
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = this.Location,
                    Size = this.Size
                };
            }
            Program.formResico.WindowState = this.WindowState;
            Program.formResico.Show();
            this.Hide();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.formPresentar.WindowState = this.WindowState;
            Program.formPresentar.Show();
            this.Hide();
        }
    }
}