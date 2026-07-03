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
                    // Redirige limpiamente a la Administración de la declaración
                    var fmAdmin = new fmAdminDeclaracion();
                    fmAdmin.StartPosition = FormStartPosition.Manual;
                    fmAdmin.Location = this.Location;
                    fmAdmin.WindowState = this.WindowState; // Mantiene el estado Maximizado (Responsivo)

                    // Suscribimos al evento FormClosed para que si cierran o regresan desde fmAdminDeclaracion,
                    // esta pantalla (fmPresentarDeclaracion) vuelva a aparecer o se limpie correctamente.
                    fmAdmin.FormClosed += (s, args) => {
                        // Si el usuario cerró la app desde allá con Application.Exit() esto no afectará,
                        // pero si usó "Inicio" para regresar, volverá a mostrar este menú.
                        if (Application.OpenForms.Count > 0)
                        {
                            this.Show();
                        }
                    };

                    fmAdmin.Show();
                    this.Hide(); // Oculta de inmediato la interfaz actual
                    break;

                case TipoRegimen.SueldosYSalarios:
                    MessageBox.Show("Módulo Sueldos y Salarios — próximamente.",
                        "En construcción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case TipoRegimen.PersonasFisicas:
                    MessageBox.Show("Módulo Personas Físicas — próximamente.",
                        "En construcción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case TipoRegimen.Arrendamiento:
                    MessageBox.Show("Módulo Arrendamiento — próximamente.",
                        "En construcción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void BtnInicio_Click(object sender, EventArgs e) => this.Close();
        private void BtnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}