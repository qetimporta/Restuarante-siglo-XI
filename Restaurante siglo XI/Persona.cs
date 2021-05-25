using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Persona
    {
        public int id_persona { get; set; }
        public String rutpersona{ get; set; }
        public String Nombre_persona{ get; set; }
        public String APaterno_persona{ get; set; }
        public String AMaterno_persona { get; set; }
        public int Telefono { get; set; }
        public String Correo_persona { get; set; }
        public String activo{ get; set; }
        public int cargo_id  { get; set; }

        public int comuna_id{ get; set; }
        public Cargo Cargo{ get; set; }
        public Comuna Comuna { get; set; }

        RestauranteEntities db = new RestauranteEntities();


        public List<Persona> ReadAll()
        {
            return this.db.PERSONA.Select(p => new Persona() {
                id_persona = (int)p.ID_PERSONA,
                rutpersona = p.RUT_PERSONA,
                Nombre_persona= p.NOMBRE_PERSONA,
                APaterno_persona = p.APATERNO_PERSONA,
                AMaterno_persona = p.AMATERNO_PERSONA,
                Telefono = (int)p.TELEFONO_PERSONA,
                Correo_persona = p.CORREO_PERSONA,
                activo = p.ACTIVO_PERSONA,
                cargo_id = (int)p.ID_CARGO_PERSONA,
                Cargo = new Cargo {
                    id = (int)p.ID_CARGO_PERSONA,
                    nombre_cargo = p.CARGO.NOMBRE_CARGO
                },
                comuna_id = (int)p.ID_COMUNA_PERSONA,
                Comuna = new Comuna()
                {
                    id_comuna = (int)p.ID_COMUNA_PERSONA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).ToList();
        }



        public bool GuardarCliente()
        {
            

            try
            {
 //               db.SP_CREATE_PERSONA(this.rutpersona,this.Nombre_persona,this.APaterno_persona,this.AMaterno_persona,this.Telefono,this.Correo_persona,"1",2,this.comuna_id);
                db.SP_CREATE_PERSONA(this.rutpersona,this.Nombre_persona,this.APaterno_persona,this.AMaterno_persona,this.Telefono,this.Correo_persona,"1",2,this.comuna_id);
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }

        public bool ModificarCliente()
        {
            try
            {
                db.SP_UPDATE_PERSONA(this.id_persona,this.rutpersona,this.Nombre_persona, this.APaterno_persona, this.AMaterno_persona,
                  this.Telefono, this.Correo_persona, "1", this.cargo_id, this.comuna_id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Persona buscarRUTcliente(String run)
        {
            try
            {
                var varRut = (from r in db.PERSONA where r.RUT_PERSONA == run && r.ID_CARGO_PERSONA == 2 select r.ID_PERSONA);
                //var asd = db.PERSONA.Select(p => new Persona() { id_persona = (int)p.ID_PERSONA}).Where(p => p.rutpersona == run).FirstOrDefault();
                //return asd;
                //db.PERSONA.Select(p => new Persona() 
                //{id_persona = (int)p.ID_PERSONA}).Where(per_e => per_e.rutpersona == run).First();
                return (Persona)varRut;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Persona buscarIdCargoCliente()
        {
            return db.PERSONA.Select(p => new Persona() 
            {
                id_persona = (int)p.ID_PERSONA,
                rutpersona = p.RUT_PERSONA,
                Nombre_persona = p.NOMBRE_PERSONA,
                APaterno_persona = p.APATERNO_PERSONA,
                AMaterno_persona = p.AMATERNO_PERSONA,
                Telefono = (int)p.TELEFONO_PERSONA,
                Correo_persona = p.CORREO_PERSONA,
                activo = p.ACTIVO_PERSONA,
                cargo_id = (int)p.ID_CARGO_PERSONA,
                Cargo = new Cargo
                {
                    id = (int)p.ID_CARGO_PERSONA,
                    nombre_cargo = p.CARGO.NOMBRE_CARGO
                },
                comuna_id = (int)p.ID_COMUNA_PERSONA,
                Comuna = new Comuna()
                {
                    id_comuna = (int)p.ID_COMUNA_PERSONA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).Where(pc => pc.cargo_id== 2).FirstOrDefault();
        }


        public Persona buscar(int id)
        {
            return this.db.PERSONA.Select(p => new Persona()
            {
                id_persona = (int)p.ID_PERSONA,
                rutpersona = p.RUT_PERSONA,
                Nombre_persona = p.NOMBRE_PERSONA,
                APaterno_persona = p.APATERNO_PERSONA,
                AMaterno_persona = p.AMATERNO_PERSONA,
                Telefono = (int)p.TELEFONO_PERSONA,
                Correo_persona = p.CORREO_PERSONA,
                activo = p.ACTIVO_PERSONA,
                cargo_id = (int)p.ID_CARGO_PERSONA,
                Cargo = new Cargo
                {
                    id = (int)p.ID_CARGO_PERSONA,
                    nombre_cargo = p.CARGO.NOMBRE_CARGO
                },
                comuna_id = (int)p.ID_COMUNA_PERSONA,
                Comuna = new Comuna()
                {
                    id_comuna = (int)p.ID_COMUNA_PERSONA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).Where(p => p.id_persona == id).FirstOrDefault();
        }

        public bool BorrarCliente(int id)
        {
            try
            {
                db.SP_DELETE_PERSONA(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
