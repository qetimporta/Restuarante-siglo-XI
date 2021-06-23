using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Bodega
    {


        public int id_bodega { get; set; }
        public String nombreBodega { get; set; }



        RestauranteEntities db = new RestauranteEntities();


        public List<Bodega> LeerTodo()
        {
            return db.BODEGA.Select(bod=> new Bodega(){
            id_bodega = (int)bod.ID_BODEGA,
            nombreBodega = bod.NOMBRE_BODEGA
            }).ToList();
        }
    }
}
