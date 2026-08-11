using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmPagoISR : Form, IInfoDeclaracion
    {
        public fmPagoISR()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            CargarImagenesCabecera();
            AsignarEventosNavegacion();

            txtSubsidio.TextChanged += (s, e) => { GuardarSubsidioDesdeTexto(); RecalcularPago(); };
            cmbEstimulos.SelectedIndexChanged += (s, e) =>
            {
                Program.modeloIsrSalarios.TieneEstimulos = cmbEstimulos.SelectedIndex == 1;
                RecalcularPago();
            };
            txtSubsidio.Enter += SeleccionarTextoAlEntrar;
            CargarValoresDesdeModelo();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void SeleccionarTextoAlEntrar(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BeginInvoke((MethodInvoker)delegate { txt.SelectAll(); });
            }
        }
        public void ActualizarInfoDeclaracion()
        {
            if (Program.declaracionActual == null) return;
            var d = Program.declaracionActual;
            DateTime vencimiento = d.CalcularVencimiento();
            lblDatosDerecha.Text =
                $"Ejercicio: {d.Ejercicio} / periodo: {d.Periodo}\r\n" +
                $"Declaración: {d.TipoDeclaracion}\r\n" +
                $"Vencimiento: {vencimiento:dd/MM/yy}";
        }

        public void ActualizarDesdeModelo()
        {
            CargarValoresDesdeModelo();
        }

        private void CargarImagenesCabecera()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string rutaEscudo = Path.Combine(baseDir, "escudo.png");
                string rutaLogo = Path.Combine(baseDir, "logouthh.png");
                if (File.Exists(rutaLogo)) picLogoUthh.Image = Image.FromFile(rutaLogo);
                if (File.Exists(rutaEscudo)) picEscudoUthh.Image = Image.FromFile(rutaEscudo);
            }
            catch { }
        }

        private void CargarValoresDesdeModelo()
        {
            var m = Program.modeloIsrSalarios;

            // Subsidio empieza vacío si no se ha capturado nada; no es obligatorio
            txtSubsidio.Text = m.SubsidioParaElEmpleo > 0 ? m.SubsidioParaElEmpleo.ToString("N0") : "";
            cmbEstimulos.SelectedIndex = m.TieneEstimulos ? 1 : 0;

            AplicarVisibilidadAplicaciones();
            RecalcularPago();
            ActualizarEstadoPestañas();
        }

        // Subsidio y Estímulos solo aparecen si el ISR a cargo (de Determinación) es mayor a 0
        private void AplicarVisibilidadAplicaciones()
        {
            var m = Program.modeloIsrSalarios;
            bool mostrar = m.ImpuestoACargo > 0;

            lblSubsidio.Visible = mostrar;
            txtSubsidio.Visible = mostrar;
            lblTieneEstimulos.Visible = mostrar;
            cmbEstimulos.Visible = mostrar;

            tlpCamposSat.RowStyles[2] = mostrar
                ? new RowStyle(SizeType.Absolute, 48F)
                : new RowStyle(SizeType.Absolute, 0F);
            tlpCamposSat.RowStyles[3] = mostrar
                ? new RowStyle(SizeType.Absolute, 48F)
                : new RowStyle(SizeType.Absolute, 0F);
        }
        private void GuardarSubsidioDesdeTexto()
        {
            string limpio = txtSubsidio.Text.Replace("$", "").Replace(",", "").Trim();
            Program.modeloIsrSalarios.SubsidioParaElEmpleo = decimal.TryParse(limpio, out decimal v) ? v : 0;
        }

        private void RecalcularPago()
        {
            var m = Program.modeloIsrSalarios;

            AplicarVisibilidadAplicaciones();

            decimal subsidio = m.ImpuestoACargo > 0 ? m.SubsidioParaElEmpleo : 0;
            m.TotalAplicaciones = subsidio; // Estímulos: solo visual por ahora, no se suma

            decimal cantidad = m.ImpuestoACargo - m.TotalAplicaciones;
            if (cantidad < 0) cantidad = 0;

            m.CantidadACargo = cantidad;
            m.CantidadAPagar = cantidad;

            txtACargo.Text = m.ImpuestoACargo.ToString("N0");
            txtTotalContribuciones1.Text = m.ImpuestoACargo.ToString("N0");
            txtTotalAplicaciones1.Text = m.TotalAplicaciones.ToString("N0");
            txtTotalContribuciones2.Text = m.ImpuestoACargo.ToString("N0");
            txtTotalAplicaciones2.Text = m.TotalAplicaciones.ToString("N0");
            txtCantidadACargo.Text = m.CantidadACargo.ToString("N0");
            txtCantidadAPagar.Text = m.CantidadAPagar.ToString("N0");
        }

        public void ActualizarEstadoPestañas()
        {
            EstadoPestanasHelper.Aplicar(btnTabDeterminacion, "Determinación", true, true, esPaginaActual: false);
        }

        private void AsignarEventosNavegacion()
        {
            btnTabDeterminacion.Click -= BtnTabDeterminacion_Click;
            btnTabDeterminacion.Click += BtnTabDeterminacion_Click;
            btnInicio.Click += (s, e) => IrAPresentarDeclaracion();
            btnCerrar.Click += (s, e) => IrAInicio();
            btnAdministracion.Click += (s, e) => IrAAdminDeclaracion();
        }
        private void IrAInicio()   
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }
        private void BtnTabDeterminacion_Click(object sender, EventArgs e)
        {
            if (Program.formIsrSalarios == null || Program.formIsrSalarios.IsDisposed)
            {
                Program.formIsrSalarios = new fmIsrRetencionesSalarios();
            }
            Program.formIsrSalarios.ActualizarDesdeModelo();
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrSalarios, this);
        }

        private void IrAAdminDeclaracion()
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);

            if (Program.formAdmin == null || Program.formAdmin.IsDisposed)
            {
                Program.formAdmin = new fmAdminDeclaracion();
            }
            Program.formAdmin.WindowState = FormWindowState.Maximized;
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void IrAPresentarDeclaracion()
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);

            if (Program.formPresentar == null || Program.formPresentar.IsDisposed)
            {
                Program.formPresentar = new fmPresentarDeclaracion(TipoRegimen.RegimenSimplificado);
            }
            Program.formPresentar.WindowState = FormWindowState.Maximized;
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            GuardarYMarcarCompletado();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        private void GuardarYMarcarCompletado()
        {
            if (Program.declaracionActual == null) return;
            var conexion = new clsConexion();

            Program.declaracionActual.ModuloIsrSalariosCompletado = true;
            Program.declaracionActual.MontoIsrSalarios = Program.modeloIsrSalarios.CantidadAPagar;

            conexion.GuardarTodosLosModulos(Program.declaracionActual);
            conexion.MarcarModuloCompletado(Program.declaracionActual.Id, "modulo_isr_salarios_completado");
            conexion.GuardarMontosDeclaracion(Program.declaracionActual.Id,
                Program.declaracionActual.MontoIsrFisicas, Program.declaracionActual.MontoIsrSalarios, Program.declaracionActual.MontoIva);

            Program.formAdmin.AplicarModulosDeclaracionActual();
            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}