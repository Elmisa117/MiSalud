using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("habitaciones")]
    public class Habitacion
    {
        [Key]
        [Column("habitacionid")]
        public int HabitacionId { get; set; }

        [Required]
        [Column("numero")]
        public string Numero { get; set; }

        [Required]
        [Column("tipohabitacionid")]
        public int TipoHabitacionId { get; set; }

        [Column("capacidad")]
        public int? Capacidad { get; set; }

        [Column("disponible")]
        public bool? Disponible { get; set; }

        [Column("fechacreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
