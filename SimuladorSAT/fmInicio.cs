using System;
using System.Drawing;
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

            // Optimización de renderizado para evitar parpadeos sin desactivar el pintado de Windows
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);

            //this.WindowState = FormWindowState.Maximized;

            AsignarEfectoHover(btnNavInicio);
            AsignarEfectoHover(btnNavPersonas);
            AsignarEfectoHover(btnNavEmpresa);
        }

        private void fmInicio_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            AjustarPosicionesResponsivas();
        }

        private void fmInicio_Resize(object sender, EventArgs e)
        {
            AjustarPosicionesResponsivas();
        }

        private void AsignarEfectoHover(Label lbl)
        {
            Font fontNormal = lbl.Font;
            Font fontHover = new Font(lbl.Font, FontStyle.Bold);

            lbl.MouseEnter += (s, e) => {
                lbl.Font = fontHover;
            };
            lbl.MouseLeave += (s, e) => {
                lbl.Font = fontNormal;
            };
        }

        private void AjustarPosicionesResponsivas()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0) return;

            lblBienvenida.Left = (this.ClientSize.Width - lblBienvenida.Width) / 2;
            picLogoCentral.Left = (this.ClientSize.Width - picLogoCentral.Width) / 2;

            int espacioDisponible = this.ClientSize.Height - pnlNavbar.Height - pnlFooter.Height;
            lblBienvenida.Top = pnlNavbar.Height + (int)(espacioDisponible * 0.08);
            picLogoCentral.Top = lblBienvenida.Bottom + 15;
        }

        // Evento Click del botón Cerrar (✕)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNavInicio_Click(object sender, EventArgs e)
        {
            // Pantalla actual
        }

        private void btnNavPersonas_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.form1, this);
        }
    }
}