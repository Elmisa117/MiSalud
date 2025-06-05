using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("hospitalizacionservicios")]
    public class HospitalizacionServicio
    {
        [Key]
        [Column("hospitalizacionservicioid")]
        public int HospitalizacionServicioId { get; set; }

        [Required]
        [Column("hospitalizacionid")]
        public int HospitalizacionId { get; set; }

        [Required]
        [Column("servicioid")]
        public int ServicioId { get; set; }

        [Column("cantidad")]
        public int? Cantidad { get; set; }

        [Required]
        [Column("fechaservicio")]
        public DateTime FechaServicio { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("personalsolicitanteid")]
        public int? PersonalSolicitanteId { get; set; }

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
