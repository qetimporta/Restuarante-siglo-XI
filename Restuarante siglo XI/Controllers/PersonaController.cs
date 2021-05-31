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
            ViewBag.personas = new Persona().ReadAll();
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
            EnviarCargos(); 
            EnviarComunas();
            return View();
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
        public ActionResult homeAdmin()
        {
            return View();
        }
        [Authorize]
        public ActionResult homeUser()
        {
            return View();
        }


        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    EnviarComunas();
                    return View(persona);
                }

                if (persona.GuardarClienteADmin() == true)
                {
                    return RedirectToAction("homeAdmin");
                }
                EnviarCargos();
                EnviarComunas();
                return View();
            }
            catch
            {
                EnviarCargos();
                EnviarComunas();
                return View(persona);
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            Persona pe = new Persona().buscar(id);
            if (pe == null)
            {
                TempData["mensaje"] = "el cliente no existe";
                return RedirectToAction("Index");
            }
            EnviarCargos();
            EnviarComunas();
            return View(pe);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id_persona,rutPersona, nombre_persona, Apaterno_persona, Amaterno_persona, Telefono, Correo_persona, cargo_id,comuna_id")] Persona persona)
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
            if (new Persona().buscar(id)== null)
            {
                TempData["mensaje"] = "no se encontro";
                return RedirectToAction("Index");
            }
            if (new Persona().BorrarCliente(id))
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
