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
        public static ModeloIsrPersonasFisicas modeloIsrFisicas = new ModeloIsrPersonasFisicas();

        // NUEVA — instancia del formulario de Ingresos
        public static fmIsrFisicasIngresos formIsrFisicasIngresos;
        public static fmIsrFisicasDeterminacion formIsrFisicasDeterminacion;
        public static fmIsrFisicasPago formIsrFisicasPago;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form1 = new Form1();
            formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            formAdmin = new fmAdminDeclaracion();
            formIsrSalarios = new fmIsrRetencionesSalarios();
            formPagoIsr = new fmPagoISR();
            formPagoIva = new fmPagoIVA();
            formResico = new fmResico(formAdmin);
            // NUEVA
            formIsrFisicasIngresos = new fmIsrFisicasIngresos();
            formIsrFisicasDeterminacion = new fmIsrFisicasDeterminacion();
            formIsrFisicasPago = new fmIsrFisicasPago();

            Application.Run(form1);
        }
    }
}
