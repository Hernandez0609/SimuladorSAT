using System.Windows.Forms;

namespace SimuladorSAT
{
    public static class clsValidacionNumerica
    {
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}