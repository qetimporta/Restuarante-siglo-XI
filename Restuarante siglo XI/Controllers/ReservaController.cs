using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.reservas = new Reserva().listarReservas();

            return View();
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult reCliente(int id) 
        {


            //se almacena en una lista los datos que se manda a buscar por el id cliente
            ViewBag.cliente = new Cliente().buscarCliente(id);
            ViewBag.listaReserva = new Reserva().buscarReservaCLiente(id);
            return View();
        }


        // GET: Reserva/Create
        public ActionResult Create(int id)
        {
            Cliente c = new Cliente();
            ViewBag.cliente=c.buscarCliente(id);
            
            enviarMesas();
            return View();
        }
        private void enviarMesas()
        {
            ViewBag.mesas = new Mesa().ListarMesa();
        }
        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(Reserva reserva, string correo)
        {
            try
            {
                // TODO: Add insert logic here
                if (reserva.GuardarReserva() == true)
                {
                    // retorna a la pagina del usuario el correo para que pueda buscarlo
                    return RedirectToAction("homeUser","Persona", new { correo = correo });
                }
                return View(reserva);
            }
            catch
            {
                return View(reserva);
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
