//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurante_siglo_XI.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class UBICACION_MESA
    {
        public UBICACION_MESA()
        {
            this.MESA = new HashSet<MESA>();
        }
    
        public decimal ID_UBICACION { get; set; }
        public string NOMBREUBICACION { get; set; }
    
        public virtual ICollection<MESA> MESA { get; set; }
    }
}
