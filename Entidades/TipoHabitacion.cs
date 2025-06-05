using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("tiposhabitacion")]
    public class TipoHabitacion
    {
        [Key]
        [Column("tipohabitacionid")]
        public int TipoHabitacionId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column("costodiario")]
        public decimal CostoDiario { get; set; }

        [Column("fechacreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
