using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class categoria
    {
        public int id_categoria{ get; set; }
        public String nombre_categoria  { get; set; }


        RestauranteEntities db = new RestauranteEntities();


        public List<categoria> LeerAllCategoria()
        {
            return db.TIPO_CONSUMIBLE.Select(category => new categoria()
            {
                id_categoria = (int)category.ID_TIPO_CONSUMIBLE,
                nombre_categoria = category.NOMBRE_TIPO_CONSUMIBLE
            }).ToList();
        }


    }
}
