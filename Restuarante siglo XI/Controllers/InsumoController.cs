using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    [Authorize]
    public class InsumoController : Controller
    {
        // GET: Insumo
        public ActionResult Index()
        {

            ViewBag.insumos = new insumos().traerTodo();
            return View();
        }

        // GET: Insumo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Insumo/Create
        public ActionResult Create()
        {
            EnviarBodega();
            return View();
        }
        private void EnviarBodega()
        {
            ViewBag.bodega = new Bodega().LeerTodo();
        }
        // POST: Insumo/Create
        [HttpPost]
        public ActionResult Create(insumos inso)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarBodega();
                    return View(inso);
                }
                if (inso.guardarInsumo() == true)
                {
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
                EnviarBodega();
                return View(inso);
            }
            catch
            {
                EnviarBodega();
                return View(inso);
            }
        }

        // GET: Insumo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Insumo/Edit/5
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

        // GET: Insumo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insumo/Delete/5
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
