using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        // GET: Persona
        
        public ActionResult Index()
        {
            ViewBag.personas = new Personal().ReadAll();
            return View();
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            EnviarBodega();
            EnviarCargos(); 
            EnviarComunas();
            return View();
        }
        private void EnviarBodega()
        {
            ViewBag.bodega = new Bodega().LeerTodo();
        }
        private void EnviarCargos()
        {
            ViewBag.cargo = new Cargo().LeerAll();
        }
        private void EnviarComunas()
        {
            ViewBag.comunas = new Comuna().LeerAll();
        }
        [Authorize]
        public ActionResult homeAdmin(string correo)
        {
            Personal p = new Personal();
            ViewBag.personal = p.buscarCorreoAdmin(correo);
            return View();
        }
        [Authorize]
        //GET
        public ActionResult homeUser(String correo)
        {
            Cliente c = new Cliente();
           ViewBag.cliente = c.buscarClientecorreo(correo);
            return View();
        }


        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(Personal persona)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    EnviarBodega();
                    EnviarComunas();
                    return View(persona);
                }

                if (persona.GuardarClienteADmin() == true)
                {
                    return RedirectToAction("homeAdmin");
                }
                EnviarBodega();
                EnviarCargos();
                EnviarComunas();
                return View();
            }
            catch
            {
                EnviarBodega();
                EnviarCargos();
                EnviarComunas();
                return View(persona);
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            Personal pe = new Personal().buscar(id);
            if (pe == null)
            {
                TempData["mensaje"] = "el cliente no existe";
                return RedirectToAction("Index");
            }
            EnviarBodega();
            EnviarCargos();
            EnviarComunas();
            return View(pe);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(Personal persona)
        {
            try
            {
                // TODO: Add update logic here
                persona.ModificarCliente();
                TempData["mensaje"] = "modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(persona);
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Personal().buscar(id)== null)
            {
                TempData["mensaje"] = "no se encontro";
                return RedirectToAction("Index");
            }
            if (new Personal().BorrarCliente(id))
            {
                TempData["mensaje"] = "elimiando correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se ha podido eliminar";
            return View();
        }

        // POST: Persona/Delete/5
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
