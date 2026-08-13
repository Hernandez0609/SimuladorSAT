using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmConfiguracionDeclaracion : Form
    {
        private readonly Color ColorGrisBase = Color.FromArgb(200, 200, 200);
        private readonly Color ColorAzulNavbar = Color.FromArgb(13, 78, 92);

        private bool _isrFisicasSel = false;
        private bool _isrSalariosSel = false;
        private bool _ivaSel = false;

        private bool _completadoIsrFisicas = false;
        private bool _completadoIsrSalarios = false;
        private bool _completadoIva = false;

        public fmConfiguracionDeclaracion()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            NavegacionHelper.CargarEncabezadoUsuario(lblDatosIzquierda);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            ConfigurarCirculos();
            CargarAnios();
        }

        public void ReiniciarFormulario()
        {
            cmbEjercicio.SelectedIndex = 0;         
            cmbPeriocidad.SelectedIndex = 0;
            cmbPeriocidad.Enabled = true;           
            OcultarDesde(lblPeriodo);
            _isrFisicasSel = _isrSalariosSel = _ivaSel = false;
            Invalidate(true);
        }

        private void CargarAnios()
        {
            cmbEjercicio.Items.Clear();
            int anioActual = DateTime.Now.Year;
            for (int anio = anioActual; anio >= 2022; anio--)
                cmbEjercicio.Items.Add(anio.ToString());

            cmbEjercicio.SelectedIndex = 0;
        }

        private void ConfigurarCirculos()
        {
            AsignarEfectoCircular(btnCircIsrFisicas, () => _isrFisicasSel);
            AsignarEfectoCircular(btnCircIsrSalarios, () => _isrSalariosSel);
            AsignarEfectoCircular(btnCircIva, () => _ivaSel);
        }

        private void AsignarEfectoCircular(Button btn, Func<bool> estadoSeleccionado)
        {
            bool mouseHover = false;

            btn.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Se activa si está seleccionado O si el cursor está encima
                bool activo = estadoSeleccionado() || mouseHover;
                Color fondo = activo ? ColorAzulNavbar : ColorGrisBase;

                using (Brush brush = new SolidBrush(fondo))
                    e.Graphics.FillEllipse(brush, 0, 0, btn.Width - 1, btn.Height - 1);

                if (activo)
                {
                    using (Font font = new Font("Arial", 16F, FontStyle.Bold))
                    using (Brush brushText = new SolidBrush(Color.White))
                    {
                        SizeF size = e.Graphics.MeasureString("✓", font);
                        e.Graphics.DrawString("✓", font, brushText, (btn.Width - size.Width) / 2, (btn.Height - size.Height) / 2);
                    }
                }
            };

            btn.MouseEnter += (s, e) => { mouseHover = true; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { mouseHover = false; btn.Invalidate(); };
        }

        private void cmbEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEjercicio.SelectedIndex >= 0)
            {
                cmbPeriocidad.Enabled = true; // ← Desbloquea el combo de periodicidad
                if (cmbPeriocidad.SelectedIndex > 0)
                {
                    CargarMeses();
                }
                else
                {
                    ResetearDesdePeriodo();
                }
            }
            else
            {
                cmbPeriocidad.Enabled = false;
                ResetearDesdePeriocidad();
            }
        }

        private void cmbPeriocidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbPeriocidad.SelectedIndex > 0;

            // Muestra u oculta los controles de Periodo según la selección
            lblPeriodo.Visible = hay;
            cmbPeriodo.Visible = hay;

            if (hay)
            {
                CargarMeses();
            }
            else
            {
                ResetearDesdePeriodo();
            }
        }

        private void ResetearDesdePeriocidad()
        {
            cmbPeriocidad.SelectedIndex = 0;
            ResetearDesdePeriodo();
        }

        private void ResetearDesdePeriodo()
        {
            lblPeriodo.Visible = false;
            cmbPeriodo.Visible = false;
            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.Add("-Seleccione-");
            cmbPeriodo.SelectedIndex = 0;
            ResetearDesdeTipoDeclaracion();
        }

        private void ResetearDesdeTipoDeclaracion()
        {
            cmbTipoDeclaracion.SelectedIndex = 0;
            _completadoIsrFisicas = _completadoIsrSalarios = _completadoIva = false;
            OcultarModulosYSiguiente();
        }

        private void CargarMeses()
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
              "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.Add("-Seleccione-");

            if (cmbEjercicio.SelectedItem != null && int.TryParse(cmbEjercicio.SelectedItem.ToString(), out int anioSeleccionado))
            {
                int mesActual = DateTime.Now.Month;
                int limite = (anioSeleccionado == DateTime.Now.Year) ? mesActual : 12;

                for (int i = 0; i < limite; i++)
                    cmbPeriodo.Items.Add(meses[i]);
            }

            cmbPeriodo.SelectedIndex = 0;
            ResetearDesdeTipoDeclaracion(); // ← Oculta/reinicia todo lo que esté más abajo
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hay = cmbPeriodo.SelectedIndex > 0;
            lblTipoDeclaracion.Visible = hay;
            cmbTipoDeclaracion.Visible = hay;
            ResetearDesdeTipoDeclaracion();

            if (hay)
            {
                ActualizarOpcionesTipoDeclaracion();
            }
        }

        private void ActualizarOpcionesTipoDeclaracion()
        {
            int ejercicio = int.Parse(cmbEjercicio.SelectedItem.ToString());
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                               "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            int periodoId = Array.IndexOf(meses, cmbPeriodo.SelectedItem.ToString()) + 1;

            var conexion = new clsConexion();
            int tipoNormalId = conexion.ObtenerIdCatalogo("cat_tipos_declaracion", "descripcion", "Normal");

            conexion.ObtenerModulosCompletados(ejercicio, periodoId, tipoNormalId, Program.contribuyenteId,
                out _completadoIsrFisicas, out _completadoIsrSalarios, out _completadoIva);

            bool hayAlgoQueEditar = _completadoIsrFisicas || _completadoIsrSalarios || _completadoIva;

            cmbTipoDeclaracion.Items.Clear();
            cmbTipoDeclaracion.Items.Add("-Seleccione-");
            cmbTipoDeclaracion.Items.Add("Normal");

            if (hayAlgoQueEditar)
            {
                cmbTipoDeclaracion.Items.Add("Complementaria");
            }

            cmbTipoDeclaracion.SelectedIndex = 0;
        }

        private void cmbTipoDeclaracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarModulosYSiguiente();
            lblTipoComplementaria.Visible = false;
            cmbTipoComplementaria.Visible = false;
            cmbTipoComplementaria.SelectedIndex = 0;

            if (cmbTipoDeclaracion.SelectedItem?.ToString() == "Normal")
            {
                MostrarCirculosParaNormal();
            }
            else if (cmbTipoDeclaracion.SelectedItem?.ToString() == "Complementaria")
            {
                lblTipoComplementaria.Visible = true;
                cmbTipoComplementaria.Visible = true;
                // Los círculos NO se muestran aquí — esperan a que elijan el tipo
            }

            AplicarCentrado();
        }

        private void cmbTipoComplementaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoComplementaria.SelectedIndex > 0)
            {
                MostrarCirculosParaComplementaria();
            }
            else
            {
                OcultarModulosYSiguiente();
            }

            AplicarCentrado();
        }

        private void MostrarCirculosParaNormal()
        {
            btnCircIsrFisicas.Visible = true;
            lblCircIsrFisicas.Visible = true;
            btnCircIsrSalarios.Visible = true;
            lblCircIsrSalarios.Visible = true;
            btnCircIva.Visible = true;
            lblCircIva.Visible = true;

            btnCircIsrFisicas.Enabled = true;
            btnCircIsrSalarios.Enabled = true;
            btnCircIva.Enabled = true;

            _isrFisicasSel = _isrSalariosSel = _ivaSel = false;
            Invalidate(true);
            AplicarCentrado();
        }

        private void MostrarCirculosParaComplementaria()
        {
            btnCircIsrFisicas.Visible = _completadoIsrFisicas;
            lblCircIsrFisicas.Visible = _completadoIsrFisicas;
            btnCircIsrSalarios.Visible = _completadoIsrSalarios;
            lblCircIsrSalarios.Visible = _completadoIsrSalarios;
            btnCircIva.Visible = _completadoIva;
            lblCircIva.Visible = _completadoIva;

            btnCircIsrFisicas.Enabled = false;
            btnCircIsrSalarios.Enabled = false;
            btnCircIva.Enabled = false;

            _isrFisicasSel = _completadoIsrFisicas;
            _isrSalariosSel = _completadoIsrSalarios;
            _ivaSel = _completadoIva;

            Invalidate(true);
            btnSiguiente.Visible = _isrFisicasSel || _isrSalariosSel || _ivaSel;
        }

        // ====================================================================
        // Toggle de círculos (solo aplica en modo Normal)
        // ====================================================================
        private void btnCircIsrFisicas_Click(object sender, EventArgs e)
        {
            _isrFisicasSel = !_isrFisicasSel;
            btnCircIsrFisicas.Invalidate();
            ActualizarVisibilidadSiguiente();
            AplicarCentrado();
        }

        private void btnCircIsrSalarios_Click(object sender, EventArgs e)
        {
            _isrSalariosSel = !_isrSalariosSel;
            btnCircIsrSalarios.Invalidate();
            ActualizarVisibilidadSiguiente();
            AplicarCentrado();
        }

        private void btnCircIva_Click(object sender, EventArgs e)
        {
            _ivaSel = !_ivaSel;
            btnCircIva.Invalidate();
            ActualizarVisibilidadSiguiente();
            AplicarCentrado();
        }

        private void ActualizarVisibilidadSiguiente()
        {
            btnSiguiente.Visible = _isrFisicasSel || _isrSalariosSel || _ivaSel;
        }

        // ====================================================================
        // Helpers de ocultamiento en cascada
        // ====================================================================
        private void OcultarDesde(Control control)
        {
            lblPeriodo.Visible = false;
            cmbPeriodo.Visible = false;
            lblTipoDeclaracion.Visible = false;
            cmbTipoDeclaracion.Visible = false;
            cmbTipoDeclaracion.SelectedIndex = 0;
            lblTipoComplementaria.Visible = false;
            cmbTipoComplementaria.Visible = false;
            OcultarModulosYSiguiente();
        }

        private void OcultarModulosYSiguiente()
        {
            btnCircIsrFisicas.Visible = false;
            lblCircIsrFisicas.Visible = false;
            btnCircIsrSalarios.Visible = false;
            lblCircIsrSalarios.Visible = false;
            btnCircIva.Visible = false;
            lblCircIva.Visible = false;
            btnSiguiente.Visible = false;
            _isrFisicasSel = _isrSalariosSel = _ivaSel = false;
            AplicarCentrado();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            var conexion = new clsConexion();
            int ejercicio = int.Parse(cmbEjercicio.SelectedItem.ToString());
            string periocidadTexto = cmbPeriocidad.SelectedItem.ToString();
            string periodoTexto = cmbPeriodo.SelectedItem.ToString();
            string tipoDeclaracionTexto = cmbTipoDeclaracion.SelectedItem.ToString();

            int periodicidadId = conexion.ObtenerIdCatalogo("cat_tipos_periodicidad", "descripcion", periocidadTexto);
            int tipoDeclaracionId = conexion.ObtenerIdCatalogo("cat_tipos_declaracion", "descripcion", tipoDeclaracionTexto);

            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                               "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            int periodoId = Array.IndexOf(meses, periodoTexto) + 1;

            int declaracionExistenteId;
            bool existe = conexion.ExisteDeclaracionPendiente(ejercicio, periodoId, tipoDeclaracionId, Program.contribuyenteId, out declaracionExistenteId);

            ModeloDeclaracion nueva = null;

            if (existe)
            {
                using (Form cortinaOscura = new Form())
                {
                    cortinaOscura.StartPosition = FormStartPosition.Manual;
                    cortinaOscura.FormBorderStyle = FormBorderStyle.None;
                    cortinaOscura.Opacity = 0.50d;
                    cortinaOscura.BackColor = System.Drawing.Color.Black;
                    cortinaOscura.Bounds = this.Bounds;
                    cortinaOscura.ShowInTaskbar = false;
                    cortinaOscura.Show(this);

                    using (fmConfirmarReemplazo dialogoConfirmar = new fmConfirmarReemplazo())
                    {
                        dialogoConfirmar.ShowDialog(cortinaOscura);

                        if (dialogoConfirmar.SeEligioReemplazar)
                        {
                            conexion.EliminarDeclaracion(declaracionExistenteId);
                            // Quita de la lista en memoria la que acabamos de borrar de la BD
                            Program.listaDeclaraciones.RemoveAll(d => d.Id == declaracionExistenteId);

                            int nuevoId = conexion.InsertarDeclaracion(
                                Program.contribuyenteId, ejercicio, periodicidadId, periodoId, tipoDeclaracionId,
                                _isrFisicasSel, _isrSalariosSel, _ivaSel);

                            nueva = new ModeloDeclaracion
                            {
                                Id = nuevoId,
                                ContribuyenteId = Program.contribuyenteId,
                                Ejercicio = ejercicio,
                                Periocidad = periocidadTexto,
                                Periodo = periodoTexto,
                                TipoDeclaracion = tipoDeclaracionTexto,
                                TipoComplementaria = cmbTipoComplementaria.Visible ? cmbTipoComplementaria.SelectedItem?.ToString() : "",
                                ModuloIsrFisicasSeleccionado = _isrFisicasSel,
                                ModuloIsrSalariosSeleccionado = _isrSalariosSel,
                                ModuloIvaSimplificadoSeleccionado = _ivaSel,
                                FechaCreacion = DateTime.Now,
                                FechaUltimaModificacion = DateTime.Now,
                                Concluida = false
                            };

                            Program.listaDeclaraciones.Add(nueva);
                        }
                        else
                        {
                            // Continuar: busca si ya está en memoria (evita duplicar);
                            // si no está (ej. la app se reinició), la carga de la BD una sola vez
                            nueva = Program.listaDeclaraciones.FirstOrDefault(d => d.Id == declaracionExistenteId);

                            if (nueva == null)
                            {
                                nueva = conexion.ObtenerDeclaracionPorId(declaracionExistenteId);
                                nueva.Id = declaracionExistenteId;
                                Program.listaDeclaraciones.Add(nueva);
                            }
                            conexion.CargarModulosEnMemoria(declaracionExistenteId);
                        }
                    }

                    cortinaOscura.Close();
                }
            }
            else
            {
                int nuevoId = conexion.InsertarDeclaracion(
                    Program.contribuyenteId, ejercicio, periodicidadId, periodoId, tipoDeclaracionId,
                    _isrFisicasSel, _isrSalariosSel, _ivaSel);
                    
                nueva = new ModeloDeclaracion
                {
                    Id = nuevoId,
                    ContribuyenteId = Program.contribuyenteId,
                    Ejercicio = ejercicio,
                    Periocidad = periocidadTexto,
                    Periodo = periodoTexto,
                    TipoDeclaracion = tipoDeclaracionTexto,
                    TipoComplementaria = cmbTipoComplementaria.Visible ? cmbTipoComplementaria.SelectedItem?.ToString() : "",
                    ModuloIsrFisicasSeleccionado = _isrFisicasSel,
                    ModuloIsrSalariosSeleccionado = _isrSalariosSel,
                    ModuloIvaSimplificadoSeleccionado = _ivaSel,
                    FechaCreacion = DateTime.Now,
                    FechaUltimaModificacion = DateTime.Now,
                    Concluida = false
                };

                Program.listaDeclaraciones.Add(nueva);
            }

            Program.declaracionActual = nueva;
            Program.formAdmin.AplicarModulosDeclaracionActual();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
            AplicarCentrado();
        }

        //CENTRAR
        private void fmConfiguracionDeclaracion_Load(object sender, EventArgs e)
        {
            AplicarCentrado();
        }

        private void pnlContenedorPrincipal_Resize(object sender, EventArgs e)
        {
            AplicarCentrado();
        }

        private void AplicarCentrado()
        {
            int contentWidth = 700; // ancho de referencia: fila de combos (Ejercicio→Periodo)
            int baseX = Math.Max(46, (pnlContenedorPrincipal.Width - contentWidth) / 2);

            lblEjercicio.Left = baseX;
            cmbEjercicio.Left = baseX;

            lblPeriocidad.Left = baseX;
            cmbPeriocidad.Left = baseX;

            lblPeriodo.Left = baseX + 354;
            cmbPeriodo.Left = baseX + 354;

            lblTipoDeclaracion.Left = baseX;
            cmbTipoDeclaracion.Left = baseX;

            lblTipoComplementaria.Left = baseX + 354;
            cmbTipoComplementaria.Left = baseX + 354;

            PosicionarCirculosYSiguiente(baseX, contentWidth);
        }

        private void PosicionarCirculosYSiguiente(int baseX, int contentWidth)
        {
            var visibles = new System.Collections.Generic.List<(Button btn, Label lbl)>();
            if (btnCircIsrFisicas.Visible) visibles.Add((btnCircIsrFisicas, lblCircIsrFisicas));
            if (btnCircIsrSalarios.Visible) visibles.Add((btnCircIsrSalarios, lblCircIsrSalarios));
            if (btnCircIva.Visible) visibles.Add((btnCircIva, lblCircIva));

            int circleWidth = 80, gap = 130; // antes 94 — un poco más de separación, igual para los 3
            int totalWidth = visibles.Count > 0 ? (visibles.Count * circleWidth + (visibles.Count - 1) * gap) : 0;
            int startX = baseX + (contentWidth - totalWidth) / 2;

            for (int i = 0; i < visibles.Count; i++)
            {
                int x = startX + i * (circleWidth + gap);
                visibles[i].btn.Left = x;
                // Centra el texto respecto al círculo usando el ancho REAL del label
                visibles[i].lbl.Left = x - (visibles[i].lbl.Width - circleWidth) / 2;
            }

            btnSiguiente.Left = baseX + (contentWidth - btnSiguiente.Width) / 2;
        }

        // ====================================================================
        // Navegación general
        // ====================================================================
        private void btnInicio_Click(object sender, EventArgs e)
        {
            GuardarSiHayDeclaracionActiva();
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            GuardarSiHayDeclaracionActiva();
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }

        // Guarda los 3 módulos en BD si ya hay una declaración activa en memoria.
        // En esta pantalla normalmente no habrá nada que guardar (declaracionActual
        // se define hasta btnSiguiente_Click), pero si se regresa aquí a medio flujo,
        // esto evita perder cualquier avance ya capturado.
        private void GuardarSiHayDeclaracionActiva()
        {
            if (Program.declaracionActual != null)
                new clsConexion().GuardarTodosLosModulos(Program.declaracionActual);
        }
    }
}