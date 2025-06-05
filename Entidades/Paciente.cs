using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("pacientes")]
    public class Paciente
    {
        [Key]
        [Column("pacienteid")]
        public int PacienteId { get; set; }

        [Required]
        [Column("nombres")]
        public string Nombres { get; set; }

        [Required]
        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Column("numerodocumento")]
        public string NumeroDocumento { get; set; }

        [Column("tipodocumento")]
        public string TipoDocumento { get; set; }

        [Column("fechanacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("edad")]
        public int? Edad { get; set; }

        [Column("genero")]
        public string Genero { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("gruposanguineo")]
        public string GrupoSanguineo { get; set; }

        [Column("alergias")]
        public string Alergias { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
