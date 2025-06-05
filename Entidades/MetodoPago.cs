using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("metodospago")]
    public class MetodoPago
    {
        [Key]
        [Column("metodopagoid")]
        public int MetodoPagoId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("requiereverificacion")]
        public bool? RequiereVerificacion { get; set; }

        [Column("fechacreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
