using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmInicio : Form
    {
        // Colores para el efecto hover del navbar
        private readonly Color ColorNavbarNormal = Color.White;
        private readonly Color ColorNavbarHover = Color.FromArgb(180, 220, 225); // celeste claro sutil

        public fmInicio()
        {
            InitializeComponent();

            // Doble buffer — evita el parpadeo al navegar entre fmInicio y Form1
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.WindowState = FormWindowState.Maximized;

            AsignarEfectoHover(btnNavInicio);
            AsignarEfectoHover(btnNavPersonas);
            AsignarEfectoHover(btnNavEmpresa);
        }

        private void fmInicio_Load(object sender, EventArgs e)
        {
            picUserIcon.Image = CrearIconoUsuario(60, 60);
            AjustarPosicionesResponsivas();
        }

        private void fmInicio_Resize(object sender, EventArgs e)
        {
            AjustarPosicionesResponsivas();
        }

        // ====================================================================
        // Efecto hover: al pasar el cursor, el texto cambia de color
        // ====================================================================
        private void AsignarEfectoHover(Label lbl)
        {
            Font fontNormal = lbl.Font;
            Font fontHover = new Font(lbl.Font, FontStyle.Bold | FontStyle.Underline);

            lbl.MouseEnter += (s, e) => {
                lbl.Font = fontHover;
            };
            lbl.MouseLeave += (s, e) => {
                lbl.Font = fontNormal;
            };
        }

        private Bitmap CrearIconoUsuario(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (Pen pen = new Pen(Color.White, 3.0f))
                {
                    g.DrawEllipse(pen, 18, 8, 24, 24);
                    GraphicsPath path = new GraphicsPath();
                    path.AddArc(10, 38, 40, 26, 180, 180);
                    g.DrawPath(pen, path);
                }
            }
            return bmp;
        }

        private void AjustarPosicionesResponsivas()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0) return;

            lblBienvenida.Left = (this.ClientSize.Width - lblBienvenida.Width) / 2;
            picLogoCentral.Left = (this.ClientSize.Width - picLogoCentral.Width) / 2;

            int espacioDisponible = this.ClientSize.Height - pnlNavbar.Height - pnlFooter.Height;
            lblBienvenida.Top = pnlNavbar.Height + (int)(espacioDisponible * 0.08);
            picLogoCentral.Top = lblBienvenida.Bottom + 15;

            picUserIcon.Left = this.ClientSize.Width - picUserIcon.Width - 60;
        }

        private void btnNavInicio_Click(object sender, EventArgs e)
        {
            // Ya nos encontramos en Inicio
        }

        private void btnNavPersonas_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.form1, this);
        }

        private void picUserIcon_Click(object sender, EventArgs e)
        {
            // Abre pantalla flotante de login/registro
        }
    }
}