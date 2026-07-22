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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            _regimen = regimen;
            this.WindowState = FormWindowState.Maximized;
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
            if (Program.listaDeclaraciones.Count > 0)
            {
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
            NavegacionHelper.MostrarSinParpadeo(Program.form1, this);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.form1, this);
        }
    }
}
