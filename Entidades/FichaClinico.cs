using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiSalud.Entidades
{
    [Table("fichaclinico")]
    public class FichaClinico
    {
        [Key]
        [Column("fichaid")]
        public int FichaId { get; set; }

        [Required]
        [Column("pacienteid")]
        public int PacienteId { get; set; }

        [Required]
        [Column("personalid")]
        public int PersonalId { get; set; }

        [Column("fechaapertura")]
        public DateTime? FechaApertura { get; set; }

        [Column("motivoconsulta")]
        public string MotivoConsulta { get; set; }

        [Column("diagnosticoinicial")]
        public string DiagnosticoInicial { get; set; }

        [Column("antecedentespersonales")]
        public string AntecedentesPersonales { get; set; }

        [Column("antecedentesfamiliares")]
        public string AntecedentesFamiliares { get; set; }

        [Column("signosvitales")]
        public string SignosVitales { get; set; }

        [Column("tratamientosugerido")]
        public string TratamientoSugerido { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }
}
