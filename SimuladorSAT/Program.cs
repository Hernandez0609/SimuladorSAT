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

        // Se actualiza automáticamente con el ID real de MySQL / SQLite
        public static int contribuyenteId = 1;

        // Variable global para acceder al usuario en cualquier formulario
        public static clsUsuario usuarioActual;

        public static ModeloIsrRetencionesSalarios modeloIsrSalarios = new ModeloIsrRetencionesSalarios();

        public static ModeloIva modeloIva = new ModeloIva();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- VERIFICACIÓN DE REGISTRO PERSISTENTE ---
            if (clsUsuario.ExisteRegistroLocal())
            {
                // Si la carpeta existe, recupera los datos y asigna el contribuyenteId real
                usuarioActual = clsUsuario.CargarLocal();
                if (usuarioActual != null)
                {
                    contribuyenteId = usuarioActual.Id;
                }
            }
            else
            {
                // Si es la primera vez, solicita los datos al alumno antes de cargar la aplicación
                using (fmDatos formDatos = new fmDatos())
                {
                    if (formDatos.ShowDialog() != DialogResult.OK)
                    {
                        return; // Si cierra sin guardar, se cancela la ejecución
                    }
                }

                // Carga el usuario recién guardado tras cerrar el formulario de datos
                usuarioActual = clsUsuario.CargarLocal();
                if (usuarioActual != null)
                {
                    contribuyenteId = usuarioActual.Id;
                }
            }

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
            formIsrFisicasIngresos = new fmIsrFisicasIngresos();
            formIsrFisicasDeterminacion = new fmIsrFisicasDeterminacion();
            formIsrFisicasPago = new fmIsrFisicasPago();
            formConfiguracionDeclaracion = new fmConfiguracionDeclaracion();
            formDeclaracionesPendientes = new fmDeclaracionesPendientes();

            // Fuerza la creación del handle nativo de cada ventana, "calienta" el JIT
            ForzarCreacionHandle(formInicio);
            ForzarCreacionHandle(form1);
            ForzarCreacionHandle(formPresentar);
            ForzarCreacionHandle(formAdmin);
            ForzarCreacionHandle(formIsrSalarios);
            ForzarCreacionHandle(formPagoIsr);
            ForzarCreacionHandle(formPagoIva);
            ForzarCreacionHandle(formResico);
            ForzarCreacionHandle(formIsrFisicasIngresos);
            ForzarCreacionHandle(formIsrFisicasDeterminacion);
            ForzarCreacionHandle(formIsrFisicasPago);
            ForzarCreacionHandle(formConfiguracionDeclaracion);
            ForzarCreacionHandle(formDeclaracionesPendientes);

            Application.Run(formInicio);
        }

        private static void ForzarCreacionHandle(Form f)
        {
            var handle = f.Handle;
        }
    }
}