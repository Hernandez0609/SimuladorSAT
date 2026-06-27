using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorDidactitoSAT
{
    public partial class fmPago : Form
    {
        public fmPago()
        {
            InitializeComponent();
            ConfigurarLogotipo();
        }

        private void ConfigurarLogotipo()
        {
            try
            {
                // NOTA: Coloca tu imagen en la carpeta bin/Debug o usa los recursos del proyecto.
                // picLogo.Image = Image.FromFile("tu_logo_sat.png");

                // Fondo simulado para el óvalo blanco tenue del ícono central
                picLogo.BackColor = Color.FromArgb(253, 251, 252);
            }
            catch { }
        }

        // Evento encargado de redondear las esquinas del cuadro de búsqueda (Search Bar)
        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath bounds = new GraphicsPath();
            int borderRadius = 18; // Controla la curvatura exacta
            bounds.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            bounds.AddArc(panelSearch.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            bounds.AddArc(panelSearch.Width - borderRadius, panelSearch.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            bounds.AddArc(0, panelSearch.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            panelSearch.Region = new Region(bounds);
        }
    }
}