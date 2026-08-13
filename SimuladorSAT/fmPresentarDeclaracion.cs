using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public enum TipoRegimen
    {
        SueldosYSalarios,
        PersonasFisicas,
        RegimenSimplificado,
        Arrendamiento
    }

    public partial class fmPresentarDeclaracion : Form
    {
        private TipoRegimen _regimen;

        public fmPresentarDeclaracion(TipoRegimen regimen)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Suscripción al evento Load para forzar la pantalla completa respetando la barra de tareas
            this.Load += (s, e) =>
            {
                this.WindowState = FormWindowState.Normal;
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            };
            NavegacionHelper.CargarEncabezadoUsuario(lblDatosIzq);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            _regimen = regimen;
           
            ConfigurarSegunRegimen();
            btnPresentar.Click += BtnPresentar_Click;
            btnInicio.Click += BtnInicio_Click;
            btnCerrar.Click += BtnCerrar_Click;
           
        }

        private void ConfigurarSegunRegimen()
        {
            switch (_regimen)
            {
                case TipoRegimen.SueldosYSalarios:
                    this.Text = "Simulador SAT - Sueldos y Salarios"; break;
                case TipoRegimen.PersonasFisicas:
                    this.Text = "Simulador SAT - Personas Físicas"; break;
                case TipoRegimen.RegimenSimplificado:
                    this.Text = "Simulador SAT - Régimen Simplificado de Confianza"; break;
                case TipoRegimen.Arrendamiento:
                    this.Text = "Simulador SAT - Arrendamiento"; break;
            }
        }

        private void BtnPresentar_Click(object sender, EventArgs e)
        {
            switch (_regimen)
            {
                case TipoRegimen.RegimenSimplificado:
                    IrAFlujoDeclaracion();
                    break;
                    // ... resto de los cases igual
            }
        }

        private void IrAFlujoDeclaracion()
        {
            var conexion = new clsConexion();
            var pendientes = conexion.ObtenerDeclaracionesPendientes(Program.contribuyenteId);

            if (pendientes.Count > 0)
            {
                Program.listaDeclaraciones.Clear();
                Program.listaDeclaraciones.AddRange(pendientes);

                Program.formDeclaracionesPendientes.ActualizarLista();
                NavegacionHelper.MostrarSinParpadeo(Program.formDeclaracionesPendientes, this);
            }
            else
            {
                Program.formConfiguracionDeclaracion.ReiniciarFormulario();
                NavegacionHelper.MostrarSinParpadeo(Program.formConfiguracionDeclaracion, this);
            }
        }

        private void IrAAdminDeclaracion()
        {
            if (Program.formAdmin == null || Program.formAdmin.IsDisposed)
            {
                Program.formAdmin = new fmAdminDeclaracion();
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }
    }
}
