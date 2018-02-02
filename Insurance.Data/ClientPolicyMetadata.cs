using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Data
{
    class ClientPolicyMetadata
    {
        [Required]
        [Display(Name = "Nombre Cliente")]
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Nombre Póliza")]
        public int PolicyId { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha de inicio debe ser aaaa/mm/dd")]
        public System.DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Fecha de fin")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha de fin debe ser aaaa/mm/dd")]
        public System.DateTime EndTime { get; set; }
    }
    [MetadataType(typeof(ClientPolicyMetadata))]
    public partial class ClientPolicy
    {
    }
}
