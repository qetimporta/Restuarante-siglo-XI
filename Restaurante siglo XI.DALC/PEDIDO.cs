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
    
    public partial class PEDIDO
    {
        public decimal ID_PEDIDO { get; set; }
        public decimal ID_MESA { get; set; }
        public decimal ID_CONSUMIBLE_PEDIDO { get; set; }
        public decimal ID_ESTADO { get; set; }
        public decimal ID_MENU { get; set; }
    
        public virtual CONSUMIBLE CONSUMIBLE { get; set; }
        public virtual ESTADOPEDIDO ESTADOPEDIDO { get; set; }
        public virtual MENU MENU { get; set; }
        public virtual MESA MESA { get; set; }
    }
}
