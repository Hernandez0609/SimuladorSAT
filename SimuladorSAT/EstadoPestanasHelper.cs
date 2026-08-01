using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public static class EstadoPestanasHelper
    {
        public static void Aplicar(Button btn, string textoBase, bool habilitado, bool completado, bool esPaginaActual)
        {
            btn.Text = completado ? $"✓ {textoBase}" : textoBase;
            btn.FlatAppearance.BorderSize = 0;

            if (esPaginaActual)
            {
                btn.Enabled = true;
                return; // conserva el teal que ya trae del Designer de esa página
            }

            btn.Enabled = habilitado;
            btn.BackColor = Color.FromArgb(235, 235, 235);
            btn.ForeColor = habilitado ? Color.FromArgb(33, 33, 33) : Color.Silver;
            btn.Font = new Font("Arial", 10F, habilitado ? FontStyle.Bold : FontStyle.Regular);
        }
    }
}