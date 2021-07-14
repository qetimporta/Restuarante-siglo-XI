using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    [Authorize]
    public class BoletaController : Controller
    {
        // GET: Boleta
        public ActionResult Index()
        {
            ViewBag.boletas = new Boleta().listartodo();
            return View();
        }
        private void enviarMesas()
        {
            ViewBag.mesas = new Mesa().ListarMesa();
        }
        // GET: Boleta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Boleta/Create
        public ActionResult Create()
        {
            enviarMesas();
            
            return View();
        }

        // POST: Boleta/Create
        [HttpPost]
        public ActionResult Create(Boleta bole)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    enviarMesas();
                    return View(bole);
                }
                //bole.GuardarBoleta();
                if (bole.GuardarBoleta() == true)
                {
                    return RedirectToAction("Index","Pedidos");
                }
                enviarMesas();
                return View(bole);
            }
            catch(Exception)
            {
                throw;
            }
        }

        // GET: Boleta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Boleta/Edit/5
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

        // GET: Boleta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Boleta/Delete/5
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
