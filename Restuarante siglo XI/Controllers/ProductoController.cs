using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_siglo_XI;

namespace Restuarante_siglo_XI.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            ViewBag.producto = new Producto().readAllProducto();
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            enviarCategiorias();
            return View();
        }

        private void enviarCategiorias()
        {
            ViewBag.categoria = new categoria().LeerAllCategoria();
        }
        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre_producto, descripcion, Stock,precioProducto,id_categoria")]Producto producto)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    enviarCategiorias();
                    return View(producto);
                }
                if (producto.guardarProducto() == true)
                {
                    return RedirectToAction("Index");

                }
                return View(producto);
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            Producto producto = new Producto().BuscarProducto(id);
            if (producto == null)
            {
                TempData["mensaje"] = "producto no encontrado";
                return RedirectToAction("Index");
            }
            enviarCategiorias();
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id_producto, nombre_producto, decripcion_producto, stock, precioProducto, id_categoria")]Producto producto)
        {
            try
            {
                // TODO: Add update logic here
                producto.modificarProducto();
                TempData["mensaje"] = "modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {

            if (new Producto().BuscarProducto(id)==null)
            {
                TempData["mensaje"] = "no se encontro";
                return RedirectToAction("Index");
            }
            if (new Producto().borraProd(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se puede eliminar";
            return View();
        }

        // POST: Producto/Delete/5
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
