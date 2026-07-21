using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorSAT
{
    internal static class Program
    {
        public static fmInicio formInicio;
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

        //ModeloDeclaracion
        public static List<ModeloDeclaracion> listaDeclaraciones = new List<ModeloDeclaracion>();
        public static ModeloDeclaracion declaracionActual;
        public static fmConfiguracionDeclaracion formConfiguracionDeclaracion;
        public static fmDeclaracionesPendientes formDeclaracionesPendientes;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Instanciamos fmInicio
            formInicio = new fmInicio();

            // 2. Mantenemos TODAS tus instancias originales con su constructor normal sin parámetros
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

            // NUEVA 2.0
            formConfiguracionDeclaracion = new fmConfiguracionDeclaracion();
            formDeclaracionesPendientes = new fmDeclaracionesPendientes();

            // NUEVO — fuerza la creación del handle nativo de cada ventana, "calienta" el JIT
            ForzarCreacionHandle(form1);
            ForzarCreacionHandle(formPresentar);
            ForzarCreacionHandle(formAdmin);
            // ... agrega uno por cada form pesado que uses en el flujo principal ...
            // 3. Ejecutamos iniciando desde formInicio
            Application.Run(formInicio);
        }
        private static void ForzarCreacionHandle(Form f)
        {
            var handle = f.Handle; // esto obliga a WinForms a crear el handle nativo YA, sin esperar al primer Show()
        }
    }
}
