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
        public int id_cliente{ get; set; }
        [Required]
        public int id_mesa_reserva { get; set; }

        public Cliente cliente{ get; set; }
        public Mesa mesa { get; set; }

        RestauranteEntities db = new RestauranteEntities();

        // lista todas la reservas creadas 
        public List<Reserva> listarReservas()
        {
            return this.db.RESERVA.Select(r => new Reserva() { 
            
            id_reserva = (int) r.ID_RESERVA,
            fecha_reserva = (DateTime)r.FECHA_RESERVA,
                id_cliente = (int)r.ID_CLIENTE,
                cliente = new Cliente() { id_cliente = (int)r.ID_CLIENTE,rutcliente = r.CLIENTE.RUTCLIENTE, nombre_cliente= r.CLIENTE.NOMBRE, apellidoM= r.CLIENTE.APELLIDOMATERNO
            ,apellidoP= r.CLIENTE.APELLIDOPATERNO, correoCliente= r.CLIENTE.CORREO_ELECTRONICO, id_comuna= (int)r.CLIENTE.COMUNA_ID_COMUNA},

            id_mesa_reserva = (int)r.ID_MESA,
            mesa = new Mesa() { id_mesa = (int)r.ID_MESA, numeroMesa= (int)r.MESA.NUMEROMESA, maxima_comensales = (int)r.MESA.MAX_COMENSALES_MESA, mesaUsada = r.MESA.USADO_MESA}

            }).ToList();

        }
            
        //metodo para guardar reservas que el cliente hace
        public bool GuardarReserva() 
        {
            try
            {
                db.SP_CREATE_RESERVA(this.fecha_reserva, this.id_mesa_reserva,this.id_cliente);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }


        // busca por medio de un id la reserva creada
        public Reserva buscar(int id) {

            return this.db.RESERVA.Select(r => new Reserva()
            {

                id_reserva = (int)r.ID_RESERVA,
                fecha_reserva = (DateTime)r.FECHA_RESERVA,
                id_cliente = (int)r.ID_CLIENTE,
                cliente = new Cliente()
                {
                    id_cliente = (int)r.ID_CLIENTE,
                    rutcliente = r.CLIENTE.RUTCLIENTE,
                    nombre_cliente = r.CLIENTE.NOMBRE,
                    apellidoM = r.CLIENTE.APELLIDOMATERNO
            ,
                    apellidoP = r.CLIENTE.APELLIDOPATERNO,
                    correoCliente = r.CLIENTE.CORREO_ELECTRONICO,
                    id_comuna = (int)r.CLIENTE.COMUNA_ID_COMUNA
                },

                id_mesa_reserva = (int)r.ID_MESA,
                mesa = new Mesa() { id_mesa = (int)r.ID_MESA, numeroMesa = (int)r.MESA.NUMEROMESA, maxima_comensales = (int)r.MESA.MAX_COMENSALES_MESA, mesaUsada = r.MESA.USADO_MESA }

            }).Where(re => re.id_reserva == id).FirstOrDefault();
        }


        public List<Reserva> buscarReservaCLiente(int id)
        {

            return this.db.RESERVA.Select(r => new Reserva()
            {

                id_reserva = (int)r.ID_RESERVA,
                fecha_reserva = (DateTime)r.FECHA_RESERVA,
                id_cliente = (int)r.ID_CLIENTE,
                cliente = new Cliente()
                {
                    id_cliente = (int)r.ID_CLIENTE,
                    rutcliente = r.CLIENTE.RUTCLIENTE,
                    nombre_cliente = r.CLIENTE.NOMBRE,
                    apellidoM = r.CLIENTE.APELLIDOMATERNO,
                    apellidoP = r.CLIENTE.APELLIDOPATERNO,
                    correoCliente = r.CLIENTE.CORREO_ELECTRONICO,
                    id_comuna = (int)r.CLIENTE.COMUNA_ID_COMUNA
                },

                id_mesa_reserva = (int)r.ID_MESA,
                mesa = new Mesa() { id_mesa = (int)r.ID_MESA, numeroMesa = (int)r.MESA.NUMEROMESA, maxima_comensales = (int)r.MESA.MAX_COMENSALES_MESA, mesaUsada = r.MESA.USADO_MESA }

            }).Where(re => re.id_cliente == id).ToList();
        }





        public bool ModificarReserva() 
        {
            try
            {
                db.SP_UPDATE_RESERVA(this.id_reserva, this.fecha_reserva, this.id_mesa_reserva,this.id_cliente);
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
