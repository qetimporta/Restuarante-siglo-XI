using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            
            enviarEstados();
            ViewBag.pedidos = new Pedido().LeerAll();
            return View();
        }
        private void enviarEstados() 
        {
            ViewBag.estados = new Estado().LeerAll();
        }
        // GET: Pedidos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            Pedido pe = new Pedido().BuscarPedido(id);
            if (pe == null)
            {
                TempData["mensaje"] = "el pedido no existe";
                return RedirectToAction("Index");
            }
            enviarEstados();
            return View(pe);
        }

        // POST: Pedidos/Edit/5
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

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidos/Delete/5
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
