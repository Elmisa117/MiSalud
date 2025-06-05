using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("servicios")]
    public class Servicio
    {
        [Key]
        [Column("servicioid")]
        public int ServicioId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column("costo")]
        public decimal Costo { get; set; }

        [Column("costopacienteasegurado")]
        public decimal? CostoPacienteAsegurado { get; set; }

        [Column("requiereprescripcion")]
        public bool? RequierePrescripcion { get; set; }

        [Column("fechacreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }
}
