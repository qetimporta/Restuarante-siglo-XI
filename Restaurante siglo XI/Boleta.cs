using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;


namespace Restaurante_siglo_XI
{
    public class Boleta
    {
        public int id_boleta { get; set; }
        public int totalBoleta { get; set; }

        public DateTime fechaEmision{ get; set; }

        public int id_mesa { get; set; }
        public Mesa mesa { get; set; }

        RestauranteEntities db = new RestauranteEntities();

        public List<Boleta> listartodo() 
        {
            return this.db.BOLETA.Select(b => new Boleta() {
            id_boleta = (int)b.ID_BOLETA,
            totalBoleta = (int)b.TOTAL_BOLETA,
            fechaEmision = b.FECHA_BOLETA,
            id_mesa = (int)b.ID_MESA,
            mesa = new Mesa { id_mesa = (int)b.ID_MESA, numeroMesa=(int) b.MESA.NUMEROMESA }
            
            }).ToList();
        }


        public int Ganancia_total() 
        {
            var result = (from b in db.BOLETA select b).ToList();

            var sumR = result.Sum(r=>(int) r.TOTAL_BOLETA);

            return sumR;
        }

        public bool GuardarBoleta()
        {
            try
            {
                 db.SP_CREATE_BOLETA(totalBoleta,Convert.ToDateTime(DateTime.Now), id_mesa);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
