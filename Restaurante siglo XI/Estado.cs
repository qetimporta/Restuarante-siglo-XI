using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Estado
    {
        public int id_estado { get; set; }
        public String nombre_estado { get; set; }


        RestauranteEntities db = new RestauranteEntities();

        public List<Estado> LeerAll()
        {
            return db.ESTADOPEDIDO.Select(es => new Estado()
            {
                id_estado = (int)es.ID_ESTADO,
                nombre_estado = es.NOMBRE_ESTADO
            }).ToList();
        }
    }
}
