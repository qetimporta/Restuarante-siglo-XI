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
    
    public partial class PERSONAL
    {
        public decimal ID_PERSONAL { get; set; }
        public string RUT_PERSONAL { get; set; }
        public string NOMBREPERSONAL { get; set; }
        public string APELLIDOSPERSONAL { get; set; }
        public string CORRREOEMPRESA { get; set; }
        public string ACTIVO_PERSONAL { get; set; }
        public string CONTRASENIAP { get; set; }
        public decimal CARGO_ID_CARGO { get; set; }
        public decimal COMUNA_ID_COMUNA { get; set; }
        public decimal BODEGA_ID_BODEGA { get; set; }
    
        public virtual BODEGA BODEGA { get; set; }
        public virtual CARGO CARGO { get; set; }
        public virtual COMUNA COMUNA { get; set; }
    }
}
