using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorSAT
{
    internal static class Program
    {
        public static Form1 form1;
        public static fmPresentarDeclaracion formPresentar;
        public static fmAdminDeclaracion formAdmin;
        public static fmIsrRetencionesSalarios formIsrSalarios;
        public static fmResico formResico;
        public static fmPagoIVA formPagoIva;
        public static fmPagoISR formPagoIsr;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }

    }
}
