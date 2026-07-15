using System;

namespace SimuladorSAT
{
    public class ModeloIsrPersonasFisicas
    {
        // Apartado: Ingresos
        public bool EsCopropiedad { get; set; } = false;
        public decimal TotalIngresosCobrados { get; set; }
        public decimal Descuentos { get; set; }
        public bool TieneIngresosADisminuir { get; set; } = false;
        public decimal IngresosADisminuir { get; set; }
        public bool TieneIngresosAdicionales { get; set; } = false;
        public decimal IngresosAdicionales { get; set; }
        public decimal TotalIngresosPercibidos { get; set; }

        // NUEVO — Apartado: Determinación
        public decimal TasaAplicable { get; set; }
        public decimal ImpuestoMensual { get; set; }
        public decimal IsrRetenidoPersonasMorales { get; set; }
        public decimal ImpuestoACargo { get; set; }

        // NUEVO — Apartado: Pago
        public decimal SubsidioParaElEmpleo { get; set; }
        public bool TieneCompensaciones { get; set; } = false;
        public decimal Compensaciones { get; set; }
        public bool TieneEstimulos { get; set; } = false;
        public decimal Estimulos { get; set; }
        public decimal TotalAplicaciones { get; set; }
        public decimal CantidadACargo { get; set; }
        public decimal CantidadAPagar { get; set; }
        // Aquí se irán agregando propiedades de Datos adicionales
    }
}