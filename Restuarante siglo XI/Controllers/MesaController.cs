using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;


namespace Restuarante_siglo_XI.Controllers
{
    public class MesaController : Controller
    {
        // GET: Mesa
        public ActionResult Index()
        {
            ViewBag.mesas = new Mesa().ListarMesa();
            return View();
        }
        [Authorize]
        public ActionResult ListaAdmin()
        {
            ViewBag.mesas = new Mesa().ListarMesa();
            return View();
        }
        // GET: Mesa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public void enviarUbicaciones() 
        {
            ViewBag.ubicacion = new ubicacionMesa().leerTodo();
        }
        // GET: Mesa/Create
        [Authorize]
        public ActionResult Create()
        {
            enviarUbicaciones();
            return View();
        }

        // POST: Mesa/Create
        [HttpPost]
        public ActionResult Create(Mesa mesa)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    enviarUbicaciones();
                    return View(mesa);
                }
                if (mesa.GuardarMesa() == true)
                {
                    return RedirectToAction("ListaAdmin");
                }
                enviarUbicaciones();
                return View(mesa);
            }
            catch
            {
                enviarUbicaciones();
                return View(mesa);
            }
        }

        // GET: Mesa/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Mesa m = new Mesa().buscaMesa(id);
            if (m == null)
            {
                TempData["mensaje"] = "mesa no existe";
                return RedirectToAction("Index");
            }
            enviarUbicaciones();
            return View(m);
        }

        // POST: Mesa/Edit/5
        [HttpPost]
        public ActionResult Edit(Mesa mesa)
        {
            try
            {
                // TODO: Add update logic here
                mesa.ModificarMesa();
                TempData["mensaje"] = "modificado correctamente";
                return RedirectToAction("ListaAdmin");
            }
            catch
            {
                enviarUbicaciones();
                return View(mesa);
            }
        }

        // GET: Mesa/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (new Mesa().buscaMesa(id) == null)
            {
                TempData["mensaje"] = "no se encontro";
                return RedirectToAction("Index");
            }
            if (new Mesa().EliminarMesa(id))
            {
                TempData["mensaje"] = "elimiando correctamente";
                return RedirectToAction("ListaAdmin");
            }
            TempData["mensaje"] = "no se ha podido eliminar";
            return View();
        }

        // POST: Mesa/Delete/5
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
