namespace SimuladorSAT
{
    public class ModeloIsrRetencionesSalarios
    {
        // Determinación — los 4 primeros serán automáticos desde el Excel (por ahora en 0/placeholder)
        public int NumeroTrabajadores { get; set; }
        public decimal PagoSueldos { get; set; }
        public decimal PagosExentos { get; set; }
        public decimal IsrRetenidoSueldos { get; set; }

        // Único campo capturable en Determinación
        public decimal IsrRetenidoRegistroContribuyente { get; set; }
        public bool IsrRetenidoRegistroCapturado { get; set; } = false;

        public decimal ImpuestoACargo { get; set; }
        public bool DeterminacionCompleta { get; set; } = false;

        // Pago
        public decimal SubsidioParaElEmpleo { get; set; }

        // Reservado: por ahora solo visual, sin lógica, hasta que se confirme si aplica
        public bool TieneEstimulos { get; set; } = false;
        public decimal Estimulos { get; set; } = 0;

        public decimal TotalAplicaciones { get; set; }
        public decimal CantidadACargo { get; set; }
        public decimal CantidadAPagar { get; set; }
    }
}