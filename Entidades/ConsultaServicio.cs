using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("consultaservicios")]
    public class ConsultaServicio
    {
        [Key]
        [Column("consultaservicioid")]
        public int ConsultaServicioId { get; set; }

        [Required]
        [Column("consultaid")]
        public int ConsultaId { get; set; }

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

        [Column("fecharegistro")]
        public DateTime? FechaRegistro { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
