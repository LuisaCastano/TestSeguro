using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Data
{
    class PolicyMetadata
    {

        [Required]
        [Display(Name = "Nombre de la póliza")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Porcentaje de obertura")]
        [Range(0, 100,
        ErrorMessage = "Valor para {0} entre {1} y {2}.")]
        public short Coverage { get; set; }

        [Required]
        [Display(Name = "Tipo de Cobertura")]
        public int CoverageKindId { get; set; }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Por favor ingrese solo números")]
        [Display(Name = "Precio")]
        public long Prize { get; set; }

        [Required]
        [Range(0, 100,
        ErrorMessage = "Valor para {0} entre {1} y {2}.")]
        [Display(Name = "Periodo")]
        public short Period { get; set; }

        [Required]
        [Display(Name = "Tipo de Riesgo")]
        public int RiskKind { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
    [MetadataType(typeof(PolicyMetadata))]
    public partial class Policy
    {
    }
}
