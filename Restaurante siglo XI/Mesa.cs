using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Mesa
    {
        public int id_mesa { get; set; }
        [Required]
        public String ubicacion_mesa{ get; set; }
        [Required]
        public int maxima_comensales { get; set; }
        public String mesaUsada{ get; set; }


        RestauranteEntities db = new RestauranteEntities();


        public bool GuardarMesa()
        {
            try
            {

                db.SP_CREATE_MESA(this.ubicacion_mesa,this.maxima_comensales,"0");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }




        public List<Mesa> ListarMesa() 
        {
            return this.db.MESA.Select(m=> new Mesa() {
                id_mesa =(int) m.ID_MESA,
                ubicacion_mesa = m.UBICACION_MESA,
                maxima_comensales = (int)m.MAX_COMENSALES_MESA,
                mesaUsada = m.USADO_MESA
            }).ToList();
        }


        public Mesa buscaMesa(int id_mes) 
        {
            return this.db.MESA.Select(m => new Mesa()
            {
                id_mesa = (int)m.ID_MESA,
                ubicacion_mesa = m.UBICACION_MESA,
                maxima_comensales = (int)m.MAX_COMENSALES_MESA,
                mesaUsada = m.USADO_MESA
            }).Where(me => me.id_mesa == id_mes).FirstOrDefault();
        }

        public bool ModificarMesa() 
        {
            try
            {

                db.SP_UPDATE_MESA(this.id_mesa,this.ubicacion_mesa,this.maxima_comensales,this.mesaUsada);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool EliminarMesa(int id_mesa) 
        {
            try
            {
                db.SP_DELETE_MESA(id_mesa);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
