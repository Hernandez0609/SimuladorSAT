using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            AsignarEfectoHover(lblMenuInicio);
            AsignarEfectoHover(lblMenuPersonas);
            AsignarEfectoHover(lblMenuEmpresa);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            picUserIcon.Image = CrearIconoUsuario(60, 60);
            AjustarPosicionesResponsivas();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AjustarPosicionesResponsivas();
        }

        private void AjustarPosicionesResponsivas()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0) return;

            // Mismo cálculo X e Y exacto que en fmInicio
            picUserIcon.Left = this.ClientSize.Width - picUserIcon.Width - 60;

            picUserIcon.BringToFront();
        }

        // Evita el destello o parpadeo blanco al cambiar entre pantallas
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x0014;
            if (m.Msg == WM_ERASEBKGND)
            {
                m.Result = (IntPtr)1;
                return;
            }
            base.WndProc(ref m);
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
        private void AsignarEfectoHover(Label lbl)
        {
            if (lbl == null) return;

            Font fontNormal = lbl.Font;
            Font fontHover = new Font(lbl.Font, FontStyle.Bold); 

            lbl.MouseEnter += (s, e) => {
                lbl.Font = fontHover;
            };
            lbl.MouseLeave += (s, e) => {
                lbl.Font = fontNormal;
            };
        }
        private void picUserIcon_Click(object sender, EventArgs e)
        {
            // Evento Click
        }

        private void lblIconoArrendamiento_Click(object sender, EventArgs e)
        {
        }

        private void lblIconoConfianza_Click(object sender, EventArgs e)
        {
            IrAPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
        }

        private void lblTextoConfianza_Click(object sender, EventArgs e)
        {
            IrAPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
        }

        private void IrAPresentarDeclaracion(TipoRegimen regimen)
        {
            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(regimen);
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void lblMenuInicio_Click(object sender, EventArgs e)
        {
            if (Program.formInicio == null || Program.formInicio.IsDisposed)
            {
                Program.formInicio = new fmInicio();
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }
    }
}