using System.Windows.Forms;

namespace SimuladorSAT
{
    public static class NavegacionHelper
    {
        public static void MostrarSinParpadeo(Form destino, Form origen)
        {
            destino.WindowState = origen.WindowState;
            destino.Opacity = 0; // invisible al inicio
            destino.Show();

            // Deja que termine de pintar todo mientras sigue invisible
            destino.Refresh();

            destino.Opacity = 1; // aparece de golpe, ya completamente dibujado
            origen.Hide();
        }
    }
}