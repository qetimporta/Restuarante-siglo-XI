using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Pedido
    {
        public int id_pedido { get; set; }
        public int id_mesa { get; set; }
        public String pedidoAdicional{ get; set; }
        [Required]
        public int id_estado { get; set; }
        public int id_menu { get; set; }

        public Mesa mesas { get; set; }
        public Estado estado { get; set; }
        public Menu menu { get; set; }



        RestauranteEntities db = new RestauranteEntities();



        public List<Pedido> LeerAll()
        {
            return db.PEDIDO.Select(pe => new Pedido()
            {
                id_pedido= (int)pe.ID_PEDIDO,
                id_menu = (int)pe.ID_MENU,
                pedidoAdicional = pe.PEDIDOADICIONAL,
                menu = new Menu() { id_menu = (int)pe.ID_MENU,nombre_menu=pe.MENU.NOMBRE_MENU },
                id_estado = (int)pe.ID_ESTADO,
                estado = new Estado() { id_estado = (int)pe.ID_ESTADO, nombre_estado = pe.ESTADOPEDIDO.NOMBRE_ESTADO},
                id_mesa = (int)pe.ID_MENU,
                mesas = new Mesa() { id_mesa = (int)pe.ID_MENU, numeroMesa = (int)pe.MESA.NUMEROMESA, maxima_comensales= (int)pe.MESA.MAX_COMENSALES_MESA, mesaUsada = pe.MESA.USADO_MESA, id_ubicacion = (int) pe.MESA.ID_UBICACION}
            }).ToList();

        }

        public Pedido BuscarPedido(int pedi) 
        {
            return db.PEDIDO.Select(pe => new Pedido()
            {
                id_pedido = (int)pe.ID_PEDIDO,
                id_menu = (int)pe.ID_MENU,
                pedidoAdicional = pe.PEDIDOADICIONAL,
                menu = new Menu() { id_menu = (int)pe.ID_MENU, nombre_menu = pe.MENU.NOMBRE_MENU },
                id_estado = (int)pe.ID_ESTADO,
                estado = new Estado() { id_estado = (int)pe.ID_ESTADO, nombre_estado = pe.ESTADOPEDIDO.NOMBRE_ESTADO },
                id_mesa = (int)pe.ID_MENU,
                mesas = new Mesa() { id_mesa = (int)pe.ID_MENU, numeroMesa = (int)pe.MESA.NUMEROMESA, maxima_comensales = (int)pe.MESA.MAX_COMENSALES_MESA, mesaUsada = pe.MESA.USADO_MESA, id_ubicacion = (int)pe.MESA.ID_UBICACION }
            }).Where(pe => pe.id_pedido == pedi).FirstOrDefault();
        }


        public bool AgregarPedido() 
        {
            try
            {
                db.SP_CREATE_PEDIDO(this.pedidoAdicional, this.id_mesa,this.id_menu);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModificarPedido() 
        {
            
            try
            {
                db.SP_UPDATE_PEDIDO(this.id_pedido,this.id_estado);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
