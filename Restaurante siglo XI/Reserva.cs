using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Reserva
    {
        public  int  id_reserva { get; set; }
        [Required]
        public DateTime fecha_reserva { get; set; }
        [Required]
        public int id_persona{ get; set; }
        [Required]
        public int id_mesa_reserva { get; set; }

        public Persona persona { get; set; }
        public Mesa mesa { get; set; }

        RestauranteEntities db = new RestauranteEntities();


        public List<Reserva> listarReservas()
        {
            return this.db.RESERVA.Select(r => new Reserva() { 
            
            id_reserva = (int) r.ID_RESERVA,
            fecha_reserva = (DateTime)r.FECHA_RESERVA,
            id_persona = (int)r.ID_PERSONA,
            persona = new Persona() { id_persona = (int)r.ID_PERSONA,rutpersona = r.PERSONA.RUT_PERSONA, Nombre_persona = r.PERSONA.NOMBRE_PERSONA, AMaterno_persona = r.PERSONA.AMATERNO_PERSONA
            ,APaterno_persona= r.PERSONA.APATERNO_PERSONA, Correo_persona = r.PERSONA.CORREO_PERSONA, activo = r.PERSONA.ACTIVO_PERSONA,cargo_id = (int)r.PERSONA.ID_CARGO_PERSONA, comuna_id = (int)r.PERSONA.ID_COMUNA_PERSONA},

            id_mesa_reserva = (int)r.ID_MESA_RESERVA,
            mesa = new Mesa() { id_mesa = (int)r.ID_MESA_RESERVA, ubicacion_mesa = r.MESA.UBICACION_MESA, maxima_comensales = (int)r.MESA.MAX_COMENSALES_MESA, mesaUsada = r.MESA.USADO_MESA}

            }).ToList();

        }


        public bool GuardarReserva() 
        {
            try
            {
                db.SP_CREATE_RESERVA(this.fecha_reserva, this.id_mesa_reserva,this.id_persona);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public Reserva buscar(int id) {

            return this.db.RESERVA.Select(r => new Reserva()
            {

                id_reserva = (int)r.ID_RESERVA,
                fecha_reserva = (DateTime)r.FECHA_RESERVA,
                id_persona = (int)r.ID_PERSONA,
                persona = new Persona()
                {
                    id_persona = (int)r.ID_PERSONA,
                    rutpersona = r.PERSONA.RUT_PERSONA,
                    Nombre_persona = r.PERSONA.NOMBRE_PERSONA,
                    AMaterno_persona = r.PERSONA.AMATERNO_PERSONA
            ,
                    APaterno_persona = r.PERSONA.APATERNO_PERSONA,
                    Correo_persona = r.PERSONA.CORREO_PERSONA,
                    activo = r.PERSONA.ACTIVO_PERSONA,
                    cargo_id = (int)r.PERSONA.ID_CARGO_PERSONA,
                    comuna_id = (int)r.PERSONA.ID_COMUNA_PERSONA
                },

                id_mesa_reserva = (int)r.ID_MESA_RESERVA,
                mesa = new Mesa() { id_mesa = (int)r.ID_MESA_RESERVA, ubicacion_mesa = r.MESA.UBICACION_MESA, maxima_comensales = (int)r.MESA.MAX_COMENSALES_MESA, mesaUsada = r.MESA.USADO_MESA }

            }).Where(re => re.id_persona == id).FirstOrDefault();


        }
        public bool ModificarReserva() 
        {
            try
            {
                db.SP_UPDATE_RESERVA(this.id_reserva, this.fecha_reserva, this.id_mesa_reserva,this.id_persona);
                return true;
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public bool BorrarReserva(int id_re) 
        {
            try
            {
                db.SP_DELETE_RESERVA(id_re);
                return true;
            }
            catch (Exception)
            {

                return false;
            }        
        
        }





    }
}
