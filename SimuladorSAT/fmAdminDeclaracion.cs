using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using PdfSharp.Drawing.Layout;
namespace SimuladorSAT
{
    public partial class fmAdminDeclaracion : Form, IInfoDeclaracion
    {
        private readonly Color ColorGrisBase = Color.FromArgb(200, 200, 200);
        private readonly Color ColorAzulNavbar = Color.FromArgb(13, 78, 92);
        private bool isrFisicasCompletado = false, isrSalariosCompletado = false, ivaSimplificadoCompletado = false;
        private decimal montoIsrFisicas = 0, montoIsrSalarios = 0, montoIvaSimplificado = 0;

        public fmAdminDeclaracion()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            ConfigurarModulosCirculares();
        }
        public void ActualizarInfoDeclaracion()
        {
            if (Program.declaracionActual == null) return;

            var d = Program.declaracionActual;
            DateTime vencimiento = d.CalcularVencimiento();

            lblInfoDerecha.Text =
                $"Ejercicio: {d.Ejercicio} / periodo: {d.Periodo}\r\n" +
                $"Declaración: {d.TipoDeclaracion}\r\n" +
                $"Vencimiento: {vencimiento:dd/MM/yy}";
        }

        private void ConfigurarModulosCirculares()
        {
            AsignarEfectoCircular(btnIsrFisicas, () => isrFisicasCompletado);
            AsignarEfectoCircular(btnIsrSalarios, () => isrSalariosCompletado);
            AsignarEfectoCircular(btnIvaSimplificado, () => ivaSimplificadoCompletado);

            btnIvaSimplificado.Click += BtnIvaSimplificado_Click;
            btnIsrFisicas.Click += btnIsrFisicas_Click;
            btnIsrSalarios.Click += btnIsrSalarios_Click;
        }

        public void AplicarModulosDeclaracionActual()
        {
            var d = Program.declaracionActual;
            if (d == null) return;

            // Configurar visibilidad de ISR Físicas
            btnIsrFisicas.Visible = d.ModuloIsrFisicasSeleccionado;
            btnIsrFisicas.Tag = "isrFisicas";
            lblIsrFisicas.Visible = d.ModuloIsrFisicasSeleccionado;

            // Configurar visibilidad de ISR Salarios
            btnIsrSalarios.Visible = d.ModuloIsrSalariosSeleccionado;
            lblIsrSalarios.Visible = d.ModuloIsrSalariosSeleccionado;

            // Configurar visibilidad de IVA Simplificado
            btnIvaSimplificado.Visible = d.ModuloIvaSimplificadoSeleccionado;
            lblIvaSimplificado.Visible = d.ModuloIvaSimplificadoSeleccionado;

            // Cargar estados completados y montos desde el modelo global
            isrFisicasCompletado = d.ModuloIsrFisicasCompletado;
            isrSalariosCompletado = d.ModuloIsrSalariosCompletado;
            ivaSimplificadoCompletado = d.ModuloIvaSimplificadoCompletado;

            montoIsrFisicas = d.MontoIsrFisicas;
            montoIsrSalarios = d.MontoIsrSalarios;
            montoIvaSimplificado = d.MontoIva;

            // Actualizar la UI
            ActualizarLabelsMonto();
            PosicionarCirculosVisibles();
            ActualizarTotalPagar();
            Invalidate(true);
        }

        private void ActualizarLabelsMonto()
        {
            lblMontoIsrFisicas.Visible = isrFisicasCompletado;
            lblMontoIsrFisicas.Text = $"Cantidad a pagar:\n${montoIsrFisicas:N0}";

            lblMontoIsrSalarios.Visible = isrSalariosCompletado;
            lblMontoIsrSalarios.Text = $"Cantidad a pagar:\n${montoIsrSalarios:N0}";

            lblMontoIva.Visible = ivaSimplificadoCompletado;
            lblMontoIva.Text = $"Cantidad a pagar:\n${montoIvaSimplificado:N0}";
        }

        private void PosicionarCirculosVisibles()
        {
            var visibles = new System.Collections.Generic.List<(Button btn, Label nombre, Label monto)>();
            if (btnIsrFisicas.Visible) visibles.Add((btnIsrFisicas, lblIsrFisicas, lblMontoIsrFisicas));
            if (btnIsrSalarios.Visible) visibles.Add((btnIsrSalarios, lblIsrSalarios, lblMontoIsrSalarios));
            if (btnIvaSimplificado.Visible) visibles.Add((btnIvaSimplificado, lblIvaSimplificado, lblMontoIva));

            if (visibles.Count == 0) return;

            int circleWidth = 80;
            int gap = 180;
            int totalWidth = (visibles.Count * circleWidth) + ((visibles.Count - 1) * gap);
            int startX = (pnlIconosSecciones.Width - totalWidth) / 2;
            int y = btnIsrFisicas.Top;

            for (int i = 0; i < visibles.Count; i++)
            {
                int x = startX + i * (circleWidth + gap);
                visibles[i].btn.Left = x;
                visibles[i].btn.Top = y;

                // Centrar nombres y montos respecto al botón horizontalmente
                visibles[i].nombre.Left = x - (visibles[i].nombre.Width - circleWidth) / 2;
                visibles[i].monto.Left = x - (visibles[i].monto.Width - circleWidth) / 2;

                // POSICIONAMIENTO VERTICAL RESPONSIVO:
                // Coloca la etiqueta del monto a exactamente 2px por debajo de donde finaliza el texto del nombre
                visibles[i].monto.Top = visibles[i].nombre.Top + visibles[i].nombre.Height + 2;

                // Nos aseguramos que el control esté visible por encima
                visibles[i].monto.BringToFront();
            }
        }

        private void ActualizarTotalPagar()
        {
            var d = Program.declaracionActual;
            if (d == null) return;

            // El total a pagar se habilitará únicamente si TODOS los módulos seleccionados están completados
            bool todosCompletos =
                (!d.ModuloIsrFisicasSeleccionado || d.ModuloIsrFisicasCompletado) &&
                (!d.ModuloIsrSalariosSeleccionado || d.ModuloIsrSalariosCompletado) &&
                (!d.ModuloIvaSimplificadoSeleccionado || d.ModuloIvaSimplificadoCompletado);

            if (todosCompletos)
            {
                decimal total = 0;
                if (d.ModuloIsrFisicasSeleccionado) total += montoIsrFisicas;
                if (d.ModuloIsrSalariosSeleccionado) total += montoIsrSalarios;
                if (d.ModuloIvaSimplificadoSeleccionado) total += montoIvaSimplificado;

                lblTotalPagar.Text = $"Total a pagar:${total:N0}";
            }
            else
            {
                lblTotalPagar.Text = "Total a pagar:$0";
            }
        }

        public void MarcarIvaSimplificadoCompletado(decimal monto)
        {
            ivaSimplificadoCompletado = true;
            montoIvaSimplificado = monto;
            btnIvaSimplificado.Invalidate();

            if (Program.declaracionActual != null)
            {
                Program.declaracionActual.ModuloIvaSimplificadoCompletado = true;
                Program.declaracionActual.MontoIva = monto;
                Program.declaracionActual.FechaUltimaModificacion = DateTime.Now; // Corrige el bug de fecha de modificación
            }

            ActualizarLabelsMonto();
            ActualizarTotalPagar();
        }

        // Método comodín para implementar cuando desarrolles el guardado de ISR Físicas
        public void MarcarIsrFisicasCompletado(decimal monto)
        {
            isrFisicasCompletado = true;
            montoIsrFisicas = monto;
            btnIsrFisicas.Invalidate();

            if (Program.declaracionActual != null)
            {
                Program.declaracionActual.ModuloIsrFisicasCompletado = true;
                Program.declaracionActual.MontoIsrFisicas = monto;
                Program.declaracionActual.FechaUltimaModificacion = DateTime.Now;
            }

            ActualizarLabelsMonto();
            ActualizarTotalPagar();
        }

        private void AsignarEfectoCircular(Button btn, Func<bool> estadoCompletado)
        {
            typeof(Control).InvokeMember("SetStyle",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance,
                null, btn, new object[] {
                    ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
                    true
                });

            bool mouseHover = false;

            btn.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Color fondo = (estadoCompletado() || mouseHover) ? ColorAzulNavbar : ColorGrisBase;

                using (Brush brush = new SolidBrush(fondo))
                    e.Graphics.FillEllipse(brush, 0, 0, btn.Width - 1, btn.Height - 1);

                using (Font font = new Font("Arial", 16F, FontStyle.Bold))
                using (Brush brushText = new SolidBrush(Color.White))
                {
                    SizeF size = e.Graphics.MeasureString("✓", font);
                    e.Graphics.DrawString("✓", font, brushText, (btn.Width - size.Width) / 2, (btn.Height - size.Height) / 2);
                }
            };

            btn.MouseEnter += (s, e) => { mouseHover = true; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { mouseHover = false; btn.Invalidate(); };
        }

        private void BtnIvaSimplificado_Click(object sender, EventArgs e)
        {
            if (Program.formResico == null || Program.formResico.IsDisposed)
            {
                Program.formResico = new fmResico(Program.formAdmin)
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = this.Location,
                    Size = this.Size
                };
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formResico, this);
        }

        private void btnIsrFisicas_Click(object sender, EventArgs e)
        {
            if (Program.formIsrFisicasIngresos == null || Program.formIsrFisicasIngresos.IsDisposed)
            {
                Program.formIsrFisicasIngresos = new fmIsrFisicasIngresos();
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasIngresos, this);
        }

        private void btnIsrSalarios_Click(object sender, EventArgs e)
        {
            if (Program.formIsrSalarios == null || Program.formIsrSalarios.IsDisposed)
            {
                Program.formIsrSalarios = new fmIsrRetencionesSalarios();
            }
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrSalarios, this);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }
        private void btnEnviarDeclaracion_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual == null) return;

            var d = Program.declaracionActual;
            var conexion = new clsConexion();

            // Marca como concluida y genera folio en BD
            string folio = conexion.FinalizarDeclaracion(d.Id);
            d.NumeroOperacion = folio;
            d.Concluida = true;

            var (matricula, nombre) = conexion.ObtenerDatosContribuyente(Program.contribuyenteId);

            string carpetaDescargas = Path.Combine(
                     Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            Directory.CreateDirectory(carpetaDescargas);

            string nombreArchivo = $"Acuse.{matricula}.{d.Ejercicio}.pdf";
            string rutaCompleta = Path.Combine(carpetaDescargas, nombreArchivo);

            clsGeneradorAcuse.GenerarPdf(d, matricula, nombre, rutaCompleta);

            MessageBox.Show($"Declaración enviada correctamente.\nAcuse guardado en:\n{rutaCompleta}",
                "Enviar declaración", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Process.Start(rutaCompleta); // Abre el PDF automáticamente
        }
    }
}