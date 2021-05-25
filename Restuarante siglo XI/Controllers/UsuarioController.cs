using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            //Persona persona = new Persona().buscar(id);
            
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

 
        // GET: Usuario/Create
        public ActionResult Create(String rut)
        {
            
                Persona per = new Persona();
                
                if (per.buscarRUTcliente(rut) == null)
                {
                    TempData["mensaje"] ="no existe esa persona";
                    return RedirectToAction("Create", "Persona");
                }
                return View();

        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usua)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(usua);
                }
                if (usua.guardarUsuario() == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(usua);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
