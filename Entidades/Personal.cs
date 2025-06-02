using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("personal")]
    public class Personal
    {
        [Key]
        [Column("personalid")]
        public int PersonalId { get; set; }

        [Required]
        [Column("nombres")]
        public string Nombres { get; set; }

        [Required]
        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Column("numerodocumento")]
        public string NumeroDocumento { get; set; }

        [Required]
        [Column("tipodocumento")]
        public string TipoDocumento { get; set; }

        [Column("fechanacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("genero")]
        public string Genero { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("fechaingreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("rol")]
        public string Rol { get; set; }

        [Column("especialidadid")]
        public int? EspecialidadId { get; set; }

        [Required]
        [Column("usuario")]
        public string Usuario { get; set; }

        [Required]
        [Column("contrasena")]
        public string Contrasena { get; set; }

        [Column("fechacreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}

