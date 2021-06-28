using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.menu = new Menu().leer_todo();
            return View();
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(menu);
                }
                if (menu.guardarMenu() == true)
                {
                    return RedirectToAction("homeAdmin","Persona");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            Menu me = new Menu().buscar(id);
            if (me == null)
            {
                return RedirectToAction("Index");
            }
            return View(me);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            try
            {
                // TODO: Add update logic here
                menu.ModificarMenu();
                TempData["mensaje"] = "modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(menu);
            }
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Menu().buscar(id)== null)
            {
                TempData["mensaje"] = "no se encontro";
                return RedirectToAction("Index");
            }
            if (new Menu().eliminarMenu(id))
            {
                TempData["mensaje"] = "elimiando correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se ha podido eliminar";
            return View();
        }

        // POST: Menu/Delete/5
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
