using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;
namespace Restaurante_siglo_XI
{
    public class Usuario
    {
        public int id { get; set; }
        public String Nombre_usuario{ get; set; }
        public String Password { get; set; }
        public int persona_id { get; set; }
        public Persona persona{ get; set; }

        RestauranteEntities db = new RestauranteEntities();

        public bool guardarUsuario()
        {
            try
            { 
                db.SP_CREATE_USUARIO(this.Nombre_usuario,this.Password,this.persona_id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool Autenticar()
        {
            return db.USUARIO.Where(u => u.NOMBRE_USUARIO == this.Nombre_usuario && u.CONTRASENIA_USUARIO == this.Password)
                .FirstOrDefault() != null;
        }
    }
}
