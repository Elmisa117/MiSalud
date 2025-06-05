using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("consultas")]
    public class Consulta
    {
        [Key]
        [Column("consultaid")]
        public int ConsultaId { get; set; }

        [Required]
        [Column("pacienteid")]
        public int PacienteId { get; set; }

        [Required]
        [Column("personalid")]
        public int PersonalId { get; set; }

        [Required]
        [Column("fechaconsulta")]
        public DateTime FechaConsulta { get; set; }

        [Column("motivocita")]
        public string MotivoCita { get; set; }

        [Column("diagnostico")]
        public string Diagnostico { get; set; }

        [Column("tratamiento")]
        public string Tratamiento { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("costo")]
        public decimal? Costo { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
