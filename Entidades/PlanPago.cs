using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("planespago")]
    public class PlanPago
    {
        [Key]
        [Column("planpagoid")]
        public int PlanPagoId { get; set; }

        [Required]
        [Column("facturaid")]
        public int FacturaId { get; set; }

        [Required]
        [Column("fechainicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Column("fechafin")]
        public DateTime FechaFin { get; set; }

        [Required]
        [Column("numerocuotas")]
        public int NumeroCuotas { get; set; }

        [Required]
        [Column("montototal")]
        public decimal MontoTotal { get; set; }

        [Column("interes")]
        public decimal? Interes { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }
}
