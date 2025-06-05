using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("pagos")]
    public class Pago
    {
        [Key]
        [Column("pagoid")]
        public int PagoId { get; set; }

        [Required]
        [Column("facturaid")]
        public int FacturaId { get; set; }

        [Required]
        [Column("metodopagoid")]
        public int MetodoPagoId { get; set; }

        [Required]
        [Column("monto")]
        public decimal Monto { get; set; }

        [Required]
        [Column("fechapago")]
        public DateTime FechaPago { get; set; }

        [Column("numeroreferencia")]
        public string NumeroReferencia { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
