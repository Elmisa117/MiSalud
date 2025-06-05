using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("facturas")]
    public class Factura
    {
        [Key]
        [Column("facturaid")]
        public int FacturaId { get; set; }

        [Required]
        [Column("pacienteid")]
        public int PacienteId { get; set; }

        [Required]
        [Column("numerofactura")]
        public string NumeroFactura { get; set; }

        [Required]
        [Column("fechaemision")]
        public DateTime FechaEmision { get; set; }

        [Column("fechavencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [Required]
        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("descuento")]
        public decimal? Descuento { get; set; }

        [Column("impuesto")]
        public decimal? Impuesto { get; set; }

        [Required]
        [Column("total")]
        public decimal Total { get; set; }

        [Column("consultaid")]
        public int? ConsultaId { get; set; }

        [Column("hospitalizacionid")]
        public int? HospitalizacionId { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }
}
