using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("auditoria")]
    public class Auditoria
    {
        [Key]
        [Column("auditoriaid")]
        public int AuditoriaId { get; set; }

        [Column("usuario")]
        public string Usuario { get; set; }

        [Column("tabla")]
        public string Tabla { get; set; }

        [Column("accion")]
        public string Accion { get; set; }

        [Column("detalle")]
        public string Detalle { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }
    }
}
