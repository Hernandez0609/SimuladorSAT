using System;
using System.Collections.Generic;

namespace SimuladorSAT
{
    public class ModeloDeclaracion
    {
        public int Id { get; set; }
        public int ContribuyenteId { get; set; }
        public int Ejercicio { get; set; }
        public string Periocidad { get; set; }
        public string Periodo { get; set; }
        public string TipoDeclaracion { get; set; } // "Normal" o "Complementaria"
        public string TipoComplementaria { get; set; }
        public bool ModuloIsrFisicasSeleccionado { get; set; }
        public bool ModuloIsrSalariosSeleccionado { get; set; }
        public bool ModuloIvaSimplificadoSeleccionado { get; set; }
        public bool ModuloIsrFisicasCompletado { get; set; }
        public bool ModuloIsrSalariosCompletado { get; set; }
        public bool ModuloIvaSimplificadoCompletado { get; set; }
        public decimal MontoIsrFisicas { get; set; }
        public decimal MontoIsrSalarios { get; set; }
        public decimal MontoIva { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public bool Concluida { get; set; } = false;
        public string NumeroOperacion { get; set; }

        public string NombreMes()
        {
            return Periodo; // Periodo ya guarda el nombre del mes directamente
        }

        //  Cálculo de la fecha de vencimiento
        //  Día 17 del mes siguiente al periodo declarado.
        //  Si cae en día inhábil (viernes, sábado, domingo o festivo
        //  oficial), se recorre al siguiente día hábil.
        public DateTime CalcularVencimiento()
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            int mesPeriodo = Array.IndexOf(meses, Periodo) + 1;
            if (mesPeriodo == 0) mesPeriodo = DateTime.Now.Month; // fallback de seguridad

            int anioVencimiento = Ejercicio;
            int mesVencimiento = mesPeriodo + 1;

            if (mesVencimiento > 12)
            {
                mesVencimiento = 1;
                anioVencimiento++;
            }

            DateTime vencimiento = new DateTime(anioVencimiento, mesVencimiento, 17);

            while (EsDiaInhabil(vencimiento))
            {
                vencimiento = vencimiento.AddDays(1);
            }

            return vencimiento;
        }

        //  Días inhábiles: viernes, sábado, domingo y días festivos
        //  oficiales (Art. 74 Ley Federal del Trabajo)
        private static bool EsDiaInhabil(DateTime fecha)
        {
            if (fecha.DayOfWeek == DayOfWeek.Friday ||
                fecha.DayOfWeek == DayOfWeek.Saturday ||
                fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return ObtenerDiasFestivos(fecha.Year).Contains(fecha.Date);
        }

        private static HashSet<DateTime> ObtenerDiasFestivos(int anio)
        {
            var festivos = new HashSet<DateTime>
            {
                new DateTime(anio, 1, 1),              // Año nuevo
                PrimerLunes(anio, 2),                   // Conmemoración 5 de febrero
                TercerLunes(anio, 3),                   // Conmemoración 21 de marzo
                new DateTime(anio, 5, 1),               // Día del trabajo
                new DateTime(anio, 5, 5),               // 5 de mayo
                new DateTime(anio, 9, 16),              // Día de la independencia
                TercerLunes(anio, 11),                  // Conmemoración 20 de noviembre
                new DateTime(anio, 12, 25)              // Navidad
            };

            // 1 de diciembre cada 6 años: transmisión del Poder Ejecutivo
            // (años de toma de posesión: 2024, 2030, 2036...)
            if ((anio - 2024) % 6 == 0)
            {
                festivos.Add(new DateTime(anio, 12, 1));
            }

            return festivos;
        }

        private static DateTime PrimerLunes(int anio, int mes)
        {
            DateTime fecha = new DateTime(anio, mes, 1);
            while (fecha.DayOfWeek != DayOfWeek.Monday)
                fecha = fecha.AddDays(1);
            return fecha;
        }

        private static DateTime TercerLunes(int anio, int mes)
        {
            return PrimerLunes(anio, mes).AddDays(14);
        }
    }
}