//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientPolicy
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PolicyId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    
        public virtual Policy Policy { get; set; }
        public virtual Client Client { get; set; }
    }
}
