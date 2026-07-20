using System;

namespace SimuladorSAT
{
    public class ModeloDeclaracion
    {
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
        // ==========================================================
        //  ¡PROPIEDADES NUEVAS AGREGADAS PARA LOS MONTOS! 
        // ==========================================================
        public decimal MontoIsrFisicas { get; set; }
        public decimal MontoIsrSalarios { get; set; }
        public decimal MontoIva { get; set; }
        // ==========================================================

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public bool Concluida { get; set; } = false;

        public string NombreMes()
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            int idx = Array.IndexOf(meses, Periodo);
            return Periodo; // Periodo ya guarda el nombre del mes directamente
        }
    }
}