using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Producto
    {
        public int id_producto { get; set; }
        [Required]
        public String nombre_producto{ get; set; }
        public String decripcion_producto { get; set; }
        [Required]
        public int  Stock{ get; set; }
        [Required]
        public int precioProducto{ get; set; }
        [Required]
        public int id_categoria{ get; set; }
        //public int  id_menu{ get; set; }
        public categoria categoria { get; set; }
        public int id_bodega { get; set; }
        public Bodega bodega { get; set; }

        //public Menu menu{ get; set; }

        RestauranteEntities db = new RestauranteEntities();

        public List<Producto> readAllProducto()
        {
            return this.db.CONSUMIBLE.Select(prod => new Producto() {
              id_producto = (int)prod.ID_CONSUMIBLE,
              nombre_producto = prod.NOMBRE_CONSUMIBLE,
              decripcion_producto = prod.DESCRIPCION_CONSUMIBLE,
              Stock =(int) prod.STOCK,
              precioProducto = (int)prod.PRECIO_CONSUMIBLE,
              id_categoria = (int)prod.ID_TIPO_CONSUMIBLE,
              categoria = new categoria() { id_categoria =(int) prod.ID_TIPO_CONSUMIBLE, nombre_categoria = prod.TIPO_CONSUMIBLE.NOMBRE_TIPO_CONSUMIBLE},
              id_bodega = (int) prod.ID_BODEGA,
              bodega = new Bodega() { id_bodega = (int)prod.ID_BODEGA, nombreBodega = prod.BODEGA.NOMBRE_BODEGA}
            }).ToList();
        }

        public Producto BuscarProducto(int id_pr)
        {
            return this.db.CONSUMIBLE.Select(prod => new Producto()
            {
                id_producto = (int)prod.ID_CONSUMIBLE,
                nombre_producto = prod.NOMBRE_CONSUMIBLE,
                decripcion_producto = prod.DESCRIPCION_CONSUMIBLE,
                Stock = (int)prod.STOCK,
                precioProducto = (int)prod.PRECIO_CONSUMIBLE,
                id_categoria = (int)prod.ID_TIPO_CONSUMIBLE,
                categoria = new categoria() { id_categoria = (int)prod.ID_TIPO_CONSUMIBLE, nombre_categoria = prod.TIPO_CONSUMIBLE.NOMBRE_TIPO_CONSUMIBLE},
                id_bodega = (int)prod.ID_BODEGA,
                bodega = new Bodega() { id_bodega = (int)prod.ID_BODEGA, nombreBodega = prod.BODEGA.NOMBRE_BODEGA }
                //id_menu = (int)prod.ID_MENU,
                //menu = new Menu() { id_menu = (int)prod.ID_MENU, nombre_menu = prod.MENU.NOMBRE_MENU, descripcion_menu = prod.MENU.DESCRIPCION_MENU }
            }).Where(p=> p.id_producto == id_pr).FirstOrDefault();
        }


        public bool modificarProducto()
        {
            try
            {
                db.SP_UPDATE_CONSUMIBLE(this.id_producto,this.nombre_producto,this.decripcion_producto,this.Stock,this.id_categoria,this.precioProducto,this.id_bodega);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool guardarProducto()
        {
            try
            {
                db.SP_CREATE_CONSUMIBLE(this.nombre_producto, this.decripcion_producto, this.precioProducto,this.Stock, this.id_categoria, this.id_bodega);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool borraProd(int id_pr) {
            try
            {
                db.SP_DELETE_CONSUMIBLE(id_pr);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        
        }
    }

}
