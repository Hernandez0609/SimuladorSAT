using System;
using System.Collections.Generic;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace SimuladorSAT
{
    public static class clsGeneradorAcuse
    {
        public static string GenerarPdf(ModeloDeclaracion d, string matricula, string nombre, string rutaDestino)
        {
            var doc = new PdfDocument();
            var page = doc.AddPage();
            page.Width = XUnit.FromPoint(612);  // Carta
            page.Height = XUnit.FromPoint(792);

            var gfx = XGraphics.FromPdfPage(page);

            var fontTituloChico = new XFont("Arial", 7, XFontStyle.Regular);
            var fontTitulo = new XFont("Arial", 10, XFontStyle.Regular);
            var fontLabel = new XFont("Arial", 9, XFontStyle.Bold);
            var fontValor = new XFont("Arial", 9, XFontStyle.Regular);
            var fontTexto = new XFont("Arial", 8, XFontStyle.Regular);

            double margenIzq = 45;
            double margenDer = 567;
            double y = 35;

            // ===== Encabezado con logos reales =====
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string rutaLogoIzq = Path.Combine(baseDir, "logouthh.png");
            string rutaLogoDer = Path.Combine(baseDir, "escudo.png");

            double altoLogo = 30;

            if (File.Exists(rutaLogoIzq))
            {
                var imgIzq = XImage.FromFile(rutaLogoIzq);
                double anchoLogoIzq = altoLogo * (imgIzq.PixelWidth / (double)imgIzq.PixelHeight);
                gfx.DrawImage(imgIzq, margenIzq, y, anchoLogoIzq, altoLogo);
            }

            if (File.Exists(rutaLogoDer))
            {
                var imgDer = XImage.FromFile(rutaLogoDer);
                double anchoLogoDer = altoLogo * (imgDer.PixelWidth / (double)imgDer.PixelHeight);
                gfx.DrawImage(imgDer, margenDer - anchoLogoDer, y, anchoLogoDer, altoLogo);
            }

            // Título centrado sobre el ancho REAL de la página, no entre logos —
            // así siempre queda perfectamente centrado sin importar el ancho de cada logo.
            gfx.DrawString("ACUSE DE RECIBO", fontTitulo, XBrushes.Black,
                new XRect(0, y, page.Width.Point, 16), XStringFormats.TopCenter);
            gfx.DrawString("DECLARACIÓN PROVISIONAL O DEFINITIVA DE IMPUESTOS FEDERALES", fontTituloChico, XBrushes.Black,
                new XRect(0, y + 15, page.Width.Point, 16), XStringFormats.TopCenter);

            y += altoLogo + 15;

            // ===== Matrícula / Nombre =====
            gfx.DrawString("Matrícula:", fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
            gfx.DrawString(matricula, fontValor, XBrushes.Black, new XPoint(margenIzq + 90, y));
            gfx.DrawString("Hoja 1 de 1", fontValor, XBrushes.Black, new XPoint(margenDer - 60, y));
            y += 15;

            gfx.DrawString("Nombre:", fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
            gfx.DrawString(nombre, fontValor, XBrushes.Black, new XPoint(margenIzq + 90, y));
            y += 20;

            gfx.DrawLine(XPens.Black, margenIzq, y, margenDer, y);
            y += 15;

            // ===== Datos generales (2 columnas) =====
            double colIzqLabel = margenIzq;
            double colIzqValor = margenIzq + 110;
            double colDerLabel = 310;
            double colDerValor = 460;

            void FilaDoble(string labelIzq, string valorIzq, string labelDer, string valorDer)
            {
                gfx.DrawString(labelIzq, fontLabel, XBrushes.Black, new XPoint(colIzqLabel, y));
                gfx.DrawString(valorIzq, fontValor, XBrushes.Black, new XPoint(colIzqValor, y));
                if (labelDer != null)
                {
                    gfx.DrawString(labelDer, fontLabel, XBrushes.Black, new XPoint(colDerLabel, y));
                    gfx.DrawString(valorDer, fontValor, XBrushes.Black, new XPoint(colDerValor, y));
                }
                y += 16;
            }

            FilaDoble("Tipo de declaración:", d.TipoDeclaracion, null, null);
            FilaDoble("Periodicidad:", d.Periocidad, "Período de la declaración:", d.Periodo);
            FilaDoble("Ejercicio:", d.Ejercicio.ToString(), "Fecha y hora de presentación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            FilaDoble("Medio de presentación:", "Internet", "Vencimiento Obligación:", d.CalcularVencimiento().ToString("dd/MM/yyyy"));
            FilaDoble("Número de operación:", d.NumeroOperacion, null, null);

            y += 10;
            gfx.DrawLine(XPens.Black, margenIzq, y, margenDer, y);
            y += 20;

            // ===== Impuestos que declara =====
            gfx.DrawString("Impuestos que declara:", fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
            y += 18;

            var conceptos = new List<(string nombre, decimal monto, bool seleccionado)>
            {
                ("ISR simplificado de confianza. Personas físicas", d.MontoIsrFisicas, d.ModuloIsrFisicasSeleccionado),
                ("ISR retenciones por salarios", d.MontoIsrSalarios, d.ModuloIsrSalariosSeleccionado),
                ("IVA simplificado de confianza", d.MontoIva, d.ModuloIvaSimplificadoSeleccionado)
            };

            int numeroConcepto = 1;
            decimal totalAPagar = 0;   // <-- NUEVO: acumulador del total
            foreach (var c in conceptos)
            {
                if (!c.seleccionado) continue;
                string etiquetaSaldo = c.monto >= 0 ? "A cargo:" : "A favor:";
                decimal montoAbsoluto = Math.Abs(c.monto);
                gfx.DrawString($"Concepto de pago {numeroConcepto}:", fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
                gfx.DrawString(c.nombre, fontValor, XBrushes.Black, new XPoint(colDerLabel - 30, y));
                y += 14;
                gfx.DrawString(etiquetaSaldo, fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
                gfx.DrawString(montoAbsoluto.ToString("N0"), fontValor, XBrushes.Black,
                    new XRect(margenIzq, y, margenDer - margenIzq, 14), XStringFormats.TopRight);
                y += 14;
                gfx.DrawString("Cantidad a cargo:", fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
                gfx.DrawString(c.monto > 0 ? c.monto.ToString("N0") : "0", fontValor, XBrushes.Black,
                    new XRect(margenIzq, y, margenDer - margenIzq, 14), XStringFormats.TopRight);
                y += 14;
                gfx.DrawString("Cantidad a pagar:", fontLabel, XBrushes.Black, new XPoint(margenIzq, y));
                gfx.DrawString(c.monto > 0 ? c.monto.ToString("N0") : "0", fontValor, XBrushes.Black,
                    new XRect(margenIzq, y, margenDer - margenIzq, 14), XStringFormats.TopRight);
                y += 18;
                if (c.monto > 0) totalAPagar += c.monto;   // <-- NUEVO: solo suma lo que es "a cargo"
                numeroConcepto++;
            }

            // ===== NUEVO: Total a pagar (suma de todos los módulos declarados) =====
            y += 6;
            gfx.DrawLine(XPens.Black, margenIzq, y, margenDer, y);
            y += 12;
            var fontTotal = new XFont("Arial", 10, XFontStyle.Bold);
            gfx.DrawString("Total a pagar:", fontTotal, XBrushes.Black, new XPoint(margenIzq, y));
            gfx.DrawString(totalAPagar.ToString("N0"), fontTotal, XBrushes.Black,
                new XRect(margenIzq, y, margenDer - margenIzq, 14), XStringFormats.TopRight);
            y += 20;

            y += 10;
            string[] textosLegales = new[]
            {
                "Es responsabilidad del contribuyente verificar la información de los importes de las facturas emitidas y recibidas. En caso de diferencias deberá de realizar las correcciones correspondientes.",
                "Declaro bajo protesta decir verdad, que los datos manifestados en esta declaración son verídicos.",
                "Quedan a salvo las facultades de revisión de la autoridad fiscal, de conformidad con lo establecido por el artículo 42 del Código Fiscal de la Federación vigente.",
                "Es recomendable verificar que el importe calculado de la parte actualizada esté correcto, en virtud de que puede haber cambiado el índice nacional de precios al consumidor y el cálculo debe estar basado en el último publicado.",
                "Los datos personales son incorporados y protegidos en los sistemas del SAT, de conformidad con las disposiciones legales en la materia.",
                "Para modificar o corregir datos personales visita sat.gob.mx.",
                "Este acuse es emitido sin prejuzgar la veracidad de los datos asentados ni el cumplimiento dentro de los plazos establecidos. Quedan a salvo las facultades de revisión de la autoridad fiscal.",
                "ESTE DOCUMENTO ES UN COMPROBANTE GENERADO EN UN SIMULADOR EDUCATIVO Y NO TIENE VALIDEZ OFICIAL ANTE EL SAT NI ANTE NINGUNA AUTORIDAD FISCAL."
            };

            var rectTexto = new XRect(margenIzq, y, margenDer - margenIzq, 400);
            var tf = new XTextFormatter(gfx);

            foreach (var texto in textosLegales)
            {
                tf.DrawString(texto, fontTexto, XBrushes.Black, rectTexto, XStringFormats.TopLeft);
                // Aproximar altura ocupada según longitud del texto (ajuste simple)
                double lineas = Math.Ceiling(gfx.MeasureString(texto, fontTexto).Width / (rectTexto.Width));
                y += (lineas * 11) + 10;
                rectTexto = new XRect(margenIzq, y, margenDer - margenIzq, 400);
            }

            doc.Save(rutaDestino);
            return rutaDestino;
        }
    }
}