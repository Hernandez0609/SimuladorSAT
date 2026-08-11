using System;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDatos : Form
    {
        public fmDatos()
        {
            InitializeComponent();
            btnGuardar.Click += BtnGuardar_Click;

            // Validaciones para entradas de teclado
            txtMatricula.KeyPress += clsValidacionNumerica.SoloNumeros;
            txtNombre.KeyPress += TxtNombre_KeyPress;
        }

        // Bloquea números y caracteres especiales en el Nombre
        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras, espacios y teclas de control (Backspace/Borrar)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla presionada
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor ingresa el nombre.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matricula))
            {
                MessageBox.Show("Por favor ingresa la matrícula.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            int idObtenido;
            if (clsUsuario.RegistrarOObtener(nombre, matricula, out idObtenido))
            {
                Program.contribuyenteId = idObtenido;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}