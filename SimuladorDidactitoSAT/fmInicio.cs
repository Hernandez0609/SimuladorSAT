using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorDidactitoSAT
{
    public partial class fmInicio : Form
    {
        // Importaciones de librerías nativas de Windows para poder arrastrar el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public fmInicio()
        {
            InitializeComponent();
        }

        // Evento para cerrar la ventana modal
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento para minimizar la ventana modal
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Permite mover la ventana haciendo clic y arrastrando el fondo del formulario
        private void fmAlumno_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
