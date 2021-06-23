using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Personal
    {
        public int id_persona { get; set; }
        [Required]
        public String rutpersona{ get; set; }
        [Required]
        public String Nombre_persona{ get; set; }
        [Required]
        public String apellidosPersonal{ get; set; }
        [Required]
        public String Correo_personal { get; set; }
        public String activo{ get; set; }
        [Required]
        public String contrasenia { get; set; }
        [Required]
        public int cargo_id  { get; set; }
        [Required]
        public int comuna_id{ get; set; }
        [Required]
        public int id_bodega { get; set; }
        public Bodega Bodega { get; set; }
        public Cargo Cargo{ get; set; }
        public Comuna Comuna { get; set; }

        RestauranteEntities db = new RestauranteEntities();


        public List<Personal> ReadAll()
        {
            return this.db.PERSONAL.Select(p => new Personal() {
                id_persona = (int)p.ID_PERSONAL,
                rutpersona = p.RUT_PERSONAL,
                Nombre_persona= p.NOMBREPERSONAL,
                apellidosPersonal = p.APELLIDOSPERSONAL,
                Correo_personal = p.CORRREOEMPRESA,
                activo = p.ACTIVO_PERSONAL,
                contrasenia = p.CONTRASENIAP,
                id_bodega = (int)p.BODEGA_ID_BODEGA,
                Bodega = new Bodega { id_bodega = (int)p.BODEGA_ID_BODEGA, nombreBodega = p.BODEGA.NOMBRE_BODEGA},
                cargo_id = (int)p.CARGO_ID_CARGO,
                Cargo = new Cargo {
                    id = (int)p.CARGO_ID_CARGO,
                    nombre_cargo = p.CARGO.NOMBRE_CARGO
                },
                comuna_id = (int)p.COMUNA_ID_COMUNA,
                Comuna = new Comuna()
                {
                    id_comuna = (int)p.COMUNA_ID_COMUNA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).ToList();
        }



        public bool GuardarClienteADmin()
        {


            try
            {
                //               db.SP_CREATE_PERSONA(this.rutpersona,this.Nombre_persona,this.APaterno_persona,this.AMaterno_persona,this.Telefono,this.Correo_persona,"1",2,this.comuna_id);
                db.SP_CREATE_PERSONAL(this.rutpersona,this.Nombre_persona,this.apellidosPersonal,this.Correo_personal,this.contrasenia,this.id_bodega,"1", this.cargo_id,this.comuna_id);
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
                db.SP_UPDATE_PERSONAL(this.id_persona,this.rutpersona,this.Nombre_persona, this.apellidosPersonal, this.contrasenia,
                  this.Correo_personal, this.id_bodega, this.cargo_id, this.comuna_id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AutenticarPersonal()
        {
            return db.PERSONAL.Where(u => u.CORRREOEMPRESA== this.Correo_personal&& u.CONTRASENIAP== this.contrasenia)
                .FirstOrDefault() != null;
        }

        public Personal buscar(int id)
        {
            return this.db.PERSONAL.Select(p => new Personal()
            {
                id_persona = (int)p.ID_PERSONAL,
                rutpersona = p.RUT_PERSONAL,
                Nombre_persona = p.NOMBREPERSONAL,
                apellidosPersonal = p.APELLIDOSPERSONAL,
                Correo_personal = p.CORRREOEMPRESA,
                activo = p.ACTIVO_PERSONAL,
                contrasenia = p.CONTRASENIAP,
                id_bodega = (int)p.BODEGA_ID_BODEGA,
                Bodega = new Bodega { id_bodega = (int)p.BODEGA_ID_BODEGA, nombreBodega = p.BODEGA.NOMBRE_BODEGA },
                cargo_id = (int)p.CARGO_ID_CARGO,
                Cargo = new Cargo
                {
                    id = (int)p.CARGO_ID_CARGO,
                    nombre_cargo = p.CARGO.NOMBRE_CARGO
                },
                comuna_id = (int)p.COMUNA_ID_COMUNA,
                Comuna = new Comuna()
                {
                    id_comuna = (int)p.COMUNA_ID_COMUNA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).Where(p => p.id_persona == id).FirstOrDefault();
        }

        public Personal buscarCorreoAdmin(string correo)
        {
            return this.db.PERSONAL.Select(p => new Personal()
            {
                id_persona = (int)p.ID_PERSONAL,
                rutpersona = p.RUT_PERSONAL,
                Nombre_persona = p.NOMBREPERSONAL,
                apellidosPersonal = p.APELLIDOSPERSONAL,
                Correo_personal = p.CORRREOEMPRESA,
                activo = p.ACTIVO_PERSONAL,
                id_bodega = (int)p.BODEGA_ID_BODEGA,
                Bodega = new Bodega { id_bodega = (int)p.BODEGA_ID_BODEGA, nombreBodega = p.BODEGA.NOMBRE_BODEGA },
                cargo_id = (int)p.CARGO_ID_CARGO,
                Cargo = new Cargo
                {
                    id = (int)p.CARGO_ID_CARGO,
                    nombre_cargo = p.CARGO.NOMBRE_CARGO
                },
                comuna_id = (int)p.COMUNA_ID_COMUNA,
                Comuna = new Comuna()
                {
                    id_comuna = (int)p.COMUNA_ID_COMUNA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).Where(p => p.Correo_personal == correo).FirstOrDefault();
        }


        public bool BorrarCliente(int id)
        {
            try
            {
                db.SP_DELETE_PERSONAL(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
