using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;
namespace Restaurante_siglo_XI
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        [Required]
        public String rutcliente{ get; set; }
        [Required]
        public String nombre_cliente { get; set; }
        [Required]
        public String apellidoP { get; set; }
        [Required]
        public String apellidoM { get; set; }
        [Required]
        public String correoCliente { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public int id_comuna{ get; set; }
        public Comuna  comuna{ get; set; }

        RestauranteEntities db = new RestauranteEntities();

        public Cliente buscarCliente(int id)
        {
            return this.db.CLIENTE.Select(p => new Cliente()
            {
                id_cliente = (int)p.ID_CLIENTE,
                rutcliente = p.RUTCLIENTE,
                nombre_cliente = p.NOMBRE,
                apellidoP = p.APELLIDOPATERNO,
                apellidoM = p.APELLIDOMATERNO,
                correoCliente = p.CORREO_ELECTRONICO,
                Password = p.CONTRASENIA,
                id_comuna = (int)p.COMUNA_ID_COMUNA,
                comuna = new Comuna()
                {
                    id_comuna = (int)p.COMUNA_ID_COMUNA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).Where(p => p.id_cliente == id).FirstOrDefault();
        }
        public Cliente buscarClientecorreo(string correo)
        {
            return this.db.CLIENTE.Select(p => new Cliente()
            {
                id_cliente = (int)p.ID_CLIENTE,
                rutcliente = p.RUTCLIENTE,
                nombre_cliente= p.NOMBRE,
                apellidoP = p.APELLIDOPATERNO,
                apellidoM = p.APELLIDOMATERNO,
                correoCliente = p.CORREO_ELECTRONICO,
                id_comuna = (int)p.COMUNA_ID_COMUNA,
                comuna = new Comuna()
                {
                    id_comuna = (int)p.COMUNA_ID_COMUNA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).Where(p => p.correoCliente == correo).FirstOrDefault();
        }

        public List<Cliente> listar()
        {
            return this.db.CLIENTE.Select(p => new Cliente()
            {
                id_cliente = (int)p.ID_CLIENTE,
                rutcliente = p.RUTCLIENTE,
                nombre_cliente = p.NOMBRE,
                apellidoP = p.APELLIDOPATERNO,
                apellidoM = p.APELLIDOMATERNO,
                correoCliente = p.CORREO_ELECTRONICO,
                Password = p.CONTRASENIA,
                id_comuna = (int)p.COMUNA_ID_COMUNA,
                comuna = new Comuna()
                {
                    id_comuna = (int)p.COMUNA_ID_COMUNA,
                    nombre_comuna = p.COMUNA.NOMBRE_COMUNA
                }
            }).ToList();
        }

        public bool guardarUsuario()
        {
            try
            { 
                db.SP_CREATE_CLIENTE(this.nombre_cliente,this.rutcliente,this.apellidoP,this.apellidoM,this.correoCliente,this.Password,this.id_comuna);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool modificarCLiente()
        {
            try
            {
                db.SP_UPDATE_CLIENTE(this.id_cliente,this.rutcliente,this.nombre_cliente,this.apellidoP,this.apellidoM,this.Password, this.id_comuna);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AutenticarCLiente()
        {
            return db.CLIENTE.Where(u => u.CORREO_ELECTRONICO == this.correoCliente&& u.CONTRASENIA== this.Password)
                .FirstOrDefault() != null;
        }
    }
}
