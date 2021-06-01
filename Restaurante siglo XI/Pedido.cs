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
        public int id_consumible { get; set; }
        [Required]
        public int id_estado { get; set; }
        public int id_menu { get; set; }

        public Mesa mesas { get; set; }
        public Producto consumible { get; set; }
        public Estado estado { get; set; }
        public Menu menu { get; set; }



        RestauranteEntities db = new RestauranteEntities();



        public List<Pedido> LeerAll()
        {
            return db.PEDIDO.Select(pe => new Pedido()
            {
                id_pedido= (int)pe.ID_PEDIDO,
                id_menu = (int)pe.ID_MENU,
                menu = new Menu() { id_menu = (int)pe.ID_MENU,nombre_menu=pe.MENU.DESCRIPCION_MENU },
                id_consumible = (int)pe.ID_CONSUMIBLE_PEDIDO,
                consumible = new Producto() { id_producto = (int)pe.ID_CONSUMIBLE_PEDIDO, nombre_producto=pe.CONSUMIBLE.NOMBRE_CONSUMIBLE, Stock =(int)pe.CONSUMIBLE.STOCK },
                id_estado = (int)pe.ID_ESTADO,
                estado = new Estado() { id_estado = (int)pe.ID_ESTADO, nombre_estado = pe.ESTADOPEDIDO.NOMBRE_ESTADO},
                id_mesa = (int)pe.ID_MENU,
                mesas = new Mesa() { id_mesa = (int)pe.ID_MENU, ubicacion_mesa = pe.MESA.UBICACION_MESA, maxima_comensales= (int)pe.MESA.MAX_COMENSALES_MESA, mesaUsada = pe.MESA.USADO_MESA }
            }).ToList();

        }

        public Pedido BuscarPedido(int pedi) 
        {
            return db.PEDIDO.Select(pe => new Pedido()
            {
                id_pedido = (int)pe.ID_PEDIDO,
                id_menu = (int)pe.ID_MENU,
                menu = new Menu() { id_menu = (int)pe.ID_MENU, nombre_menu = pe.MENU.DESCRIPCION_MENU },
                id_consumible = (int)pe.ID_CONSUMIBLE_PEDIDO,
                consumible = new Producto() { id_producto = (int)pe.ID_CONSUMIBLE_PEDIDO, nombre_producto = pe.CONSUMIBLE.NOMBRE_CONSUMIBLE, Stock = (int)pe.CONSUMIBLE.STOCK },
                id_estado = (int)pe.ID_ESTADO,
                estado = new Estado() { id_estado = (int)pe.ID_ESTADO, nombre_estado = pe.ESTADOPEDIDO.NOMBRE_ESTADO },
                id_mesa = (int)pe.ID_MENU,
                mesas = new Mesa() { id_mesa = (int)pe.ID_MENU, ubicacion_mesa = pe.MESA.UBICACION_MESA, maxima_comensales = (int)pe.MESA.MAX_COMENSALES_MESA, mesaUsada = pe.MESA.USADO_MESA }
            }).Where(pe => pe.id_pedido == pedi).FirstOrDefault();
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
