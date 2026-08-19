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
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Evento Load para forzar la pantalla completa respetando la barra de tareas
            this.Load += (s, e) =>
            {
                ActualizarInfoDeclaracion();
            };
            NavegacionHelper.CargarEncabezadoUsuario(this.lblInfoIzquierda);
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
            NavegacionHelper.CargarEncabezadoUsuario(this.lblInfoIzquierda);
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
            ActualizarInfoDeclaracion();
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
            lblMontoIsrFisicas.Text = $"A pagar:\n${montoIsrFisicas:N0}";

            lblMontoIsrSalarios.Visible = isrSalariosCompletado;
            lblMontoIsrSalarios.Text = $"A pagar:\n${montoIsrSalarios:N0}";

            lblMontoIva.Visible = ivaSimplificadoCompletado;
            lblMontoIva.Text = $"A pagar:\n${montoIvaSimplificado:N0}";
        }

        private void PosicionarCirculosVisibles()
        {
            var visibles = new System.Collections.Generic.List<(Button btn, Label nombre, Label monto)>();

            if (btnIsrFisicas.Visible)
                visibles.Add((btnIsrFisicas, lblIsrFisicas, lblMontoIsrFisicas));

            if (btnIsrSalarios.Visible)
                visibles.Add((btnIsrSalarios, lblIsrSalarios, lblMontoIsrSalarios));

            if (btnIvaSimplificado.Visible)
                visibles.Add((btnIvaSimplificado, lblIvaSimplificado, lblMontoIva));

            if (visibles.Count == 0)
                return;

           
            float escala = Math.Min(
                (float)pnlIconosSecciones.Width / 900f,
                (float)pnlIconosSecciones.Height / 350f
            );

            escala = Math.Max(0.65f, Math.Min(escala, 1f));

            int circleWidth = Math.Max(
                55,
                (int)Math.Round(80 * escala)
            );

            int gap;

            if (visibles.Count == 1)
            {
                gap = 0;
            }
            else
            {
                int espacioDisponible = pnlIconosSecciones.Width -
                                        (visibles.Count * circleWidth);

                gap = espacioDisponible / (visibles.Count + 1);

                gap = Math.Max(20, Math.Min(gap, 180));
            }

            int totalWidth;

            if (visibles.Count == 1)
            {
                totalWidth = circleWidth;
            }
            else
            {
                totalWidth =
                    (visibles.Count * circleWidth) +
                    ((visibles.Count - 1) * gap);
            }

            int startX =
                Math.Max(
                    0,
                    (pnlIconosSecciones.Width - totalWidth) / 2
                );

            int y = btnIsrFisicas.Top;

            // ------------------------------------------------------------
            // COLOCACIÓN DE CONTROLES
            // ------------------------------------------------------------
            for (int i = 0; i < visibles.Count; i++)
            {
                int x;

                if (visibles.Count == 1)
                {
                    x = startX;
                }
                else
                {
                    x = startX + i * (circleWidth + gap);
                }

                // Botón circular
                visibles[i].btn.Left = x;
                visibles[i].btn.Top = y;
                visibles[i].btn.Width = circleWidth;
                visibles[i].btn.Height = circleWidth;

                // --------------------------------------------------------
                // CENTRAR NOMBRE
                // --------------------------------------------------------
                visibles[i].nombre.Left =
                    x - (visibles[i].nombre.Width - circleWidth) / 2;

                // Evitamos que el label se vaya fuera del panel.
                if (visibles[i].nombre.Left < 0)
                    visibles[i].nombre.Left = 0;

                if (visibles[i].nombre.Right > pnlIconosSecciones.Width)
                {
                    visibles[i].nombre.Left =
                        pnlIconosSecciones.Width -
                        visibles[i].nombre.Width;
                }

                // --------------------------------------------------------
                // MONTO
                // --------------------------------------------------------
                visibles[i].monto.Left =
                    x - (visibles[i].monto.Width - circleWidth) / 2;

                if (visibles[i].monto.Left < 0)
                    visibles[i].monto.Left = 0;

                if (visibles[i].monto.Right > pnlIconosSecciones.Width)
                {
                    visibles[i].monto.Left =
                        pnlIconosSecciones.Width -
                        visibles[i].monto.Width;
                }

                // El monto queda debajo del nombre.
                visibles[i].monto.Top =
                    visibles[i].nombre.Top +
                    visibles[i].nombre.Height +
                    2;

                visibles[i].monto.BringToFront();
                visibles[i].nombre.BringToFront();
                visibles[i].btn.BringToFront();
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

                float tamanoFuente = Math.Max(8f, btn.Width * 0.20f);

                using (Font font = new Font(
                    "Arial",
                    tamanoFuente,
                    FontStyle.Bold))
                using (Brush brushText = new SolidBrush(Color.White))
                {
                    SizeF size = e.Graphics.MeasureString("✓", font);

                    e.Graphics.DrawString(
                        "✓",
                        font,
                        brushText,
                        (btn.Width - size.Width) / 2,
                        (btn.Height - size.Height) / 2
                    );
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
            Program.formResico.ActualizarDesdeModelo();   
            NavegacionHelper.MostrarSinParpadeo(Program.formResico, this);
        }

        private void btnIsrFisicas_Click(object sender, EventArgs e)
        {
            if (Program.formIsrFisicasIngresos == null || Program.formIsrFisicasIngresos.IsDisposed)
            {
                Program.formIsrFisicasIngresos = new fmIsrFisicasIngresos();
            }
            Program.formIsrFisicasIngresos.ActualizarDesdeModelo();  
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrFisicasIngresos, this);
        }

        private void btnIsrSalarios_Click(object sender, EventArgs e)
        {
            if (Program.formIsrSalarios == null || Program.formIsrSalarios.IsDisposed)
            {
                Program.formIsrSalarios = new fmIsrRetencionesSalarios();
            }
            Program.formIsrSalarios.ActualizarDesdeModelo(); 
            NavegacionHelper.MostrarSinParpadeo(Program.formIsrSalarios, this);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
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