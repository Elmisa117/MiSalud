using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("huellasdactilares")]
    public class HuellaDactilar
    {
        [Key]
        [Column("huellaid")]
        public int HuellaId { get; set; }

        [Required]
        [Column("pacienteid")]
        public int PacienteId { get; set; }

        [Column("mano")]
        public string Mano { get; set; }

        [Column("dedo")]
        public string Dedo { get; set; }

        [Required]
        [Column("template")]
        public byte[] Template { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }
    }
}
