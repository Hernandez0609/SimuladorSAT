using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public static class ResponsiveHelper
    {
        
        private static readonly Size DisenoBase = new Size(1366, 768);

        private class EstadoControl
        {
            public Rectangle Bounds;
            public float FontSize;
            public bool AutoSize;
            public AnchorStyles Anchor;
            public DockStyle Dock;
        }

        private static readonly Dictionary<Control, EstadoControl> Estados =
            new Dictionary<Control, EstadoControl>();

        // ============================================================
        // MÉTODO PRINCIPAL
        // ============================================================
        public static void Aplicar(Form formulario)
        {
            if (formulario == null || formulario.IsDisposed)
                return;

            try
            {
                // Obtenemos el área real disponible de la pantalla,
                // respetando la barra de tareas de Windows.
                Rectangle area = Screen.FromControl(formulario).WorkingArea;

                // Calculamos escala horizontal y vertical.
                float escalaX = (float)area.Width / DisenoBase.Width;
                float escalaY = (float)area.Height / DisenoBase.Height;

                // Utilizamos la menor para mantener proporciones.
                float escala = Math.Min(escalaX, escalaY);

                // En pantallas grandes NO ampliamos el diseño.
                if (escala > 1f)
                    escala = 1f;

                // Evitamos escalas extremadamente pequeñas.
                // Esto protege la legibilidad en resoluciones muy reducidas.
                if (escala < 0.65f)
                    escala = 0.65f;

                // El formulario ocupa el área de trabajo disponible.
                formulario.StartPosition = FormStartPosition.Manual;
                formulario.WindowState = FormWindowState.Normal;
                formulario.Bounds = area;

                // Guardamos y escalamos todos los controles.
                EscalarControles(formulario, escala);

                // Actualizamos el layout.
                formulario.PerformLayout();
                formulario.Invalidate(true);
                formulario.Update();
            }
            catch
            {
               
            }
        }

        // ============================================================
        // ESCALADO DE CONTROLES
        // ============================================================
        private static void EscalarControles(Control padre, float escala)
        {
            foreach (Control control in padre.Controls)
            {
                GuardarEstadoOriginal(control);
                EstadoControl estado = Estados[control];

                // 1) La fuente se escala PRIMERO. Para controles AutoSize=true esto
                //    es lo que en realidad define su tamaño final; hacerlo después
                //    del Bounds es lo que estaba revirtiendo el ajuste de ancho.
                float nuevoTamano = Math.Max(7f, estado.FontSize * escala);
                try
                {
                    if (Math.Abs(control.Font.Size - nuevoTamano) > 0.1f)
                        control.Font = new Font(control.Font.FontFamily, nuevoTamano, control.Font.Style);
                }
                catch { }

                // 2) Posición y tamaño, YA con la fuente definitiva aplicada.
                if (control.Dock == DockStyle.None)
                {
                    Rectangle original = estado.Bounds;
                    int x = (int)Math.Round(original.X * escala);
                    int y = (int)Math.Round(original.Y * escala);

                    if (control.AutoSize)
                    {
                        // No forzamos ancho/alto en controles AutoSize: dejamos que
                        // WinForms lo calcule según la fuente nueva. Solo reubicamos.
                        control.Location = new Point(x, y);
                    }
                    else
                    {
                        int ancho = Math.Max(1, (int)Math.Round(original.Width * escala));
                        int alto = Math.Max(1, (int)Math.Round(original.Height * escala));
                        control.Bounds = new Rectangle(x, y, ancho, alto);
                    }
                }

                if (control is TableLayoutPanel tabla)
                    EscalarTableLayout(tabla, escala);

                if (control.HasChildren)
                    EscalarControles(control, escala);
            }
        }

        // ============================================================
        // GUARDAR ESTADO ORIGINAL
        // ============================================================
        private static void GuardarEstadoOriginal(Control control)
        {
            if (Estados.ContainsKey(control))
                return;

            Estados[control] = new EstadoControl
            {
                Bounds = control.Bounds,
                FontSize = control.Font.Size,
                AutoSize = control.AutoSize,
                Anchor = control.Anchor,
                Dock = control.Dock
            };
        }

        // ============================================================
        // TABLELAYOUTPANEL
        // ============================================================
        private static void EscalarTableLayout(
            TableLayoutPanel tabla,
            float escala)
        {
            foreach (ColumnStyle columna in tabla.ColumnStyles)
            {
                if (columna.SizeType == SizeType.Absolute)
                {
                    columna.Width *= escala;
                }
            }

            foreach (RowStyle fila in tabla.RowStyles)
            {
                if (fila.SizeType == SizeType.Absolute)
                {
                    fila.Height *= escala;
                }
            }
        }

       
        public static void Limpiar(Form formulario)
        {
            if (formulario == null)
                return;

            LimpiarControles(formulario);
        }

        private static void LimpiarControles(Control padre)
        {
            foreach (Control control in padre.Controls)
            {
                Estados.Remove(control);

                if (control.HasChildren)
                    LimpiarControles(control);
            }
        }
    }
}