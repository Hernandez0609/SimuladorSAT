using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmDeclaracionesPendientes : Form
    {
        public fmDeclaracionesPendientes()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
        }

        private void fmDeclaracionesPendientes_Load(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void pnlContenedorPrincipal_Resize(object sender, EventArgs e)
        {
            AplicarCentradoPendientes();
        }

        private void SeleccionarDeclaracion(ModeloDeclaracion d)
        {
            Program.declaracionActual = d;
            d.FechaUltimaModificacion = DateTime.Now;

            var conexion = new clsConexion();
            conexion.ActualizarFechaModificacion(d.Id);
            conexion.CargarModulosEnMemoria(d.Id);
            Program.formAdmin.AplicarModulosDeclaracionActual();
            NavegacionHelper.MostrarSinParpadeo(Program.formAdmin, this);
        }

        public void ActualizarLista()
        {
            pnlListaContenedor.Controls.Clear();
            pnlListaContenedor.BorderStyle = BorderStyle.None; // Ya no es un solo panel gigante
            pnlListaContenedor.AutoScroll = true;

            int y = 0;
            int cardHeight = 75;
            int cardWidth = 700;

            var conexion = new clsConexion();
            var pendientes = conexion.ObtenerDeclaracionesPendientes(Program.contribuyenteId);

            // Sincroniza la lista en memoria con lo que acabamos de traer de la BD
            Program.listaDeclaraciones.Clear();
            Program.listaDeclaraciones.AddRange(pendientes);

            foreach (var d in pendientes)
            {
                var card = new Panel
                {
                    Location = new Point(0, y),
                    Size = new Size(cardWidth, cardHeight),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = d
                };

                var lblInfo1 = new Label
                {
                    Text = $"{d.Ejercicio} - {d.TipoDeclaracion} / {d.Periodo}",
                    Font = new Font("Arial", 10F, FontStyle.Bold),
                    Location = new Point(15, 10),
                    AutoSize = true
                };

                var lblInfo2 = new Label
                {
                    Text = $"Creación: {d.FechaCreacion:dd/MM/yyyy hh:mm tt} - Última modificación: {d.FechaUltimaModificacion:dd/MM/yyyy hh:mm tt}",
                    Font = new Font("Arial", 9F),
                    ForeColor = Color.Gray,
                    Location = new Point(15, 35),
                    AutoSize = true
                };

                var btnEliminar = new Button
                {
                    Text = "🗑",
                    Location = new Point(cardWidth - 55, 18),
                    Size = new Size(36, 36),
                    FlatStyle = FlatStyle.Flat,
                    Tag = d
                };
                btnEliminar.Click += BtnEliminarDeclaracion_Click;

                card.Controls.Add(lblInfo1);
                card.Controls.Add(lblInfo2);
                card.Controls.Add(btnEliminar);

                // Conectar clics para abrir la declaración
                card.Click += (s, e) => SeleccionarDeclaracion(d);
                lblInfo1.Click += (s, e) => SeleccionarDeclaracion(d);
                lblInfo2.Click += (s, e) => SeleccionarDeclaracion(d);

                pnlListaContenedor.Controls.Add(card);
                y += cardHeight + 15; // Separación entre tarjetas
            }

            // El panel contenedor mide justo lo necesario (con tope máximo para scroll)
            int alturaNecesaria = Math.Max(y, cardHeight);
            pnlListaContenedor.Size = new Size(cardWidth + 20, Math.Min(alturaNecesaria, 500));

            AplicarCentradoPendientes();
        }

        private void AplicarCentradoPendientes()
        {
            int gap = 40;
            int contentWidth = pnlListaContenedor.Width + gap + btnNuevaDeclaracion.Width;
            int baseX = Math.Max(46, (pnlContenedorPrincipal.Width - contentWidth) / 2);

            pnlListaContenedor.Left = baseX;
            btnNuevaDeclaracion.Left = baseX + pnlListaContenedor.Width + gap;
        }

        private void BtnEliminarDeclaracion_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var d = (ModeloDeclaracion)btn.Tag;
            var confirm = MessageBox.Show("¿Deseas eliminar esta declaración?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var conexion = new clsConexion();
                conexion.EliminarDeclaracion(d.Id);
                Program.listaDeclaraciones.Remove(d);

                if (Program.declaracionActual != null && Program.declaracionActual.Id == d.Id)
                    Program.declaracionActual = null;   // ← LÍNEA NUEVA

                if (Program.listaDeclaraciones.Count == 0)
                {
                    Program.formConfiguracionDeclaracion.ReiniciarFormulario();
                    NavegacionHelper.MostrarSinParpadeo(Program.formConfiguracionDeclaracion, this);
                }
                else
                {
                    ActualizarLista();
                }
            }
        }

        private void btnNuevaDeclaracion_Click(object sender, EventArgs e)
        {
            Program.formConfiguracionDeclaracion.ReiniciarFormulario();
            NavegacionHelper.MostrarSinParpadeo(Program.formConfiguracionDeclaracion, this);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formPresentar, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            NavegacionHelper.MostrarSinParpadeo(Program.formInicio, this);
        }
    }
}