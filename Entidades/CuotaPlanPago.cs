using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("cuotasplanpago")]
    public class CuotaPlanPago
    {
        [Key]
        [Column("cuotaid")]
        public int CuotaId { get; set; }

        [Required]
        [Column("planpagoid")]
        public int PlanPagoId { get; set; }

        [Required]
        [Column("numerocuota")]
        public int NumeroCuota { get; set; }

        [Required]
        [Column("montocuota")]
        public decimal MontoCuota { get; set; }

        [Required]
        [Column("fechavencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [Column("fechapago")]
        public DateTime? FechaPago { get; set; }

        [Column("pagoid")]
        public int? PagoId { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }
    }
}
