using System;
using System.Collections.Generic;

namespace SimuladorSAT
{
    public class ModeloIsrPersonasFisicas
    {
        public List<(string TipoEstimulo, decimal PorAplicar)> ListaEstimulos { get; set; } = new List<(string, decimal)>();
        public bool EsImpuestoAFavor { get; set; }
        public List<(string Concepto, decimal Importe)> ListaIngresosADisminuir { get; set; } = new List<(string, decimal)>();
        public List<(string Concepto, decimal Importe)> ListaIngresosAdicionales { get; set; } = new List<(string, decimal)>();
        public List<(string Concepto, decimal Importe)> ListaTotalPercibidosDetalle { get; set; } = new List<(string, decimal)>();
        public decimal ImpuestoAFavor { get; set; }
        public int DetalleEgresosFacturasCanceladas { get; set; }
        public int DetalleEgresosFacturasVigentes { get; set; }
        public decimal DetalleEgresosSubtotal { get; set; }
        public decimal DetalleEgresosDescuento { get; set; }
        // Apartado: Ingresos
        public decimal DescuentosCopropiedad { get; set; }
        public bool EsCopropiedad { get; set; } = false;
        public decimal TotalIngresosCobrados { get; set; }
        public decimal Descuentos { get; set; }
        public bool TieneIngresosADisminuir { get; set; } = false;
        public decimal IngresosADisminuir { get; set; }
        public bool TieneIngresosAdicionales { get; set; } = false;
        public decimal IngresosAdicionales { get; set; }
        // Banderas de captura — indican si el usuario ya abrió y confirmó el diálogo correspondiente
        public bool DescuentosCapturado { get; set; } = false;
        public bool IngresosADisminuirCapturado { get; set; } = false;
        public bool IngresosAdicionalesCapturado { get; set; } = false;

        // Bandera de sección completa — se activa cuando terminemos de programar Determinación
        public bool DeterminacionCompleta { get; set; } = false;
        public bool TotalPercibidosCapturado { get; set; } = false;
        public bool IsrRetenidoCapturado { get; set; } = false;
        public bool CompensacionesCapturado { get; set; } = false;
        public bool EstimulosCapturado { get; set; } = false;
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