using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Cargo
    {
        public int id { get; set; }
        public String nombre_cargo { get; set; }


        RestauranteEntities db = new RestauranteEntities();

        public List<Cargo> LeerAll()
        {
            return db.CARGO.Select(car => new Cargo()
            {
                id = (int)car.ID_CARGO,
                nombre_cargo = car.NOMBRE_CARGO
            }).ToList();

        }

    }



}
