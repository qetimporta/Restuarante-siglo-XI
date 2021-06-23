using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;


namespace Restaurante_siglo_XI
{
    public class ubicacionMesa
    {

        public int id_ubicacionMesa { get; set; }
        public String nombre_ubicacion { get; set; }


        RestauranteEntities db = new RestauranteEntities();


        public List<ubicacionMesa> leerTodo()
        {
            return db.UBICACION_MESA.Select(ubm => new ubicacionMesa() { 
            
            id_ubicacionMesa = (int)ubm.ID_UBICACION,
            nombre_ubicacion = ubm.NOMBREUBICACION
            }).ToList();

        }



    }
}
