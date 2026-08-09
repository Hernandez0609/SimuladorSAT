namespace SimuladorSAT
{
    public class ModeloIva
    {
        // Determinación
        public decimal ActividadesGravadas16 { get; set; }
        public decimal ActividadesGravadas0 { get; set; }
        public decimal ActividadesExentas { get; set; }
        public decimal ActividadesNoObjeto { get; set; }
        public decimal IvaACargo16 { get; set; }
        public decimal TotalIvaACargo { get; set; }
        public decimal IvaNoCobradoDevoluciones { get; set; }
        public decimal IvaRetenido { get; set; }
        public decimal IvaAcreditablePeriodo { get; set; }
        public decimal IvaPorDevolucionesGastos { get; set; }
        public decimal CantidadACargo { get; set; }
        public decimal AcreditamientoSaldoFavorAnterior { get; set; }
        public decimal ImpuestoFinal { get; set; }
        public bool EsImpuestoAFavor { get; set; }

        public bool ActividadesGravadas0Capturado { get; set; } = false;
        public bool IvaAcreditablePeriodoCapturado { get; set; } = false;
        public bool DeterminacionCompleta { get; set; } = false;
        public int DetalleDevolucionesFacturasCanceladas { get; set; }
        public int DetalleDevolucionesFacturasVigentes { get; set; }
        public decimal DetalleDevolucionesSubtotal { get; set; }
        public decimal DetalleDevolucionesDescuento { get; set; }
        public decimal Iva8PorcentoEgresos { get; set; }
        public decimal Iva16PorcentoEgresos { get; set; }
        // Pago
        public bool TieneCompensaciones { get; set; } = false;
        public decimal Compensaciones { get; set; }
        public bool TieneEstimulos { get; set; } = false;
        public decimal Estimulos { get; set; }
        public decimal TotalAplicaciones { get; set; }
        public decimal CantidadACargoPago { get; set; }
        public decimal CantidadAPagar { get; set; }

        public decimal Tasa0Nacional { get; set; }
        public decimal Tasa0Exportacion { get; set; }
        public decimal AcreditableGravado16 { get; set; }
        public decimal AcreditableMixtas { get; set; }
    }
}