using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("hospitalizaciones")]
    public class Hospitalizacion
    {
        [Key]
        [Column("hospitalizacionid")]
        public int HospitalizacionId { get; set; }

        [Required]
        [Column("pacienteid")]
        public int PacienteId { get; set; }

        [Required]
        [Column("habitacionid")]
        public int HabitacionId { get; set; }

        [Required]
        [Column("personalid")]
        public int PersonalId { get; set; }

        [Required]
        [Column("fechaingreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("fechaalta")]
        public DateTime? FechaAlta { get; set; }

        [Column("tipoaltaid")]
        public int? TipoAltaId { get; set; }

        [Column("diagnostico")]
        public string Diagnostico { get; set; }

        [Column("tratamientoaplicado")]
        public string TratamientoAplicado { get; set; }

        [Column("motivohospitalizacion")]
        public string MotivoHospitalizacion { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
