using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("tiposalta")]
    public class TipoAlta
    {
        [Key]
        [Column("tipoaltaid")]
        public int TipoAltaId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("fechacreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
