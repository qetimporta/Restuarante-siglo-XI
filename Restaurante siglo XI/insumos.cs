using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class insumos
    {
        public int id_insumos { get; set; }
        [Required]
        public String descripcion { get; set; }
        public int id_bodega { get; set; }
        public Bodega bodega{ get; set; }

        RestauranteEntities db = new RestauranteEntities();

        public List<insumos> traerTodo() 
        {
            return db.INSUMOS.Select(i => new insumos() {
                id_insumos = (int)i.ID_INSUMOS,
                descripcion = i.PEDIDOINSUMO,
                id_bodega = (int)i.ID_BODEGA,
                bodega = new Bodega() { id_bodega = (int)i.ID_BODEGA, nombreBodega = i.BODEGA.NOMBRE_BODEGA}
            }).ToList();
        }

        public bool guardarInsumo() 
        {
            try
            {
                db.SP_CREATE_INSUMOS(this.descripcion, this.id_bodega);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarInsumo(int id)
        {
            try
            {
                var me = db.INSUMOS.SingleOrDefault(x => x.ID_INSUMOS == id);
                db.INSUMOS.Remove(me);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



    }
}
