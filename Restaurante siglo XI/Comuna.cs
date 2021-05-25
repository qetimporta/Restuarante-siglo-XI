using Restaurante_siglo_XI.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_siglo_XI
{
    public class Comuna
    {
        public decimal id_comuna { get; set; }
        public String nombre_comuna { get; set; }
        public decimal id_region { get; set; }
        public Region region{ get; set; }

        RestauranteEntities db = new RestauranteEntities();
        public List<Comuna> LeerAll()
        {
            return db.COMUNA.Select(com=> new Comuna() { 
                id_comuna = com.ID_COMUNA,
                nombre_comuna = com.NOMBRE_COMUNA,
                id_region = com.ID_REGION,
                region = new Region()
                {
                    id_region = (int)com.ID_REGION,
                    nombre_region = com.REGION.NOMBRE_REGION

                }
            }).ToList(); 
            
        }
    }
}
