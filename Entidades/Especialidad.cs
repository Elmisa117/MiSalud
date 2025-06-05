using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("especialidades")]
    public class Especialidad
    {
        [Key]
        [Column("especialidadid")]
        public int EspecialidadId { get; set; }

        [Column("nombrespecialidad")]
        public string NombreEspecialidad { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("fechacreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}


