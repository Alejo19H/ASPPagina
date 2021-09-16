using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class ProductoCompraController : Controller
    {
        [Authorize]
        // GET: ProductoCompra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_compra.ToList());
            }

        }

        public static int NombreCompra(int idCompra)
        {
            using (var db = new inventario2021Entities())
            {
                return db.compra.Find(idCompra).id;
            }
        }

        public ActionResult ListarCompra()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }

        public ActionResult ListarProducto()
        {
            using  (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra productoCompra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_compra.Add(productoCompra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                producto_compra editProductoCompra = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(editProductoCompra);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_compra editProductoCompra)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldProducto = db.producto_compra.Find(editProductoCompra.id);
                    oldProducto.id_compra = editProductoCompra.id_compra;
                    oldProducto.id_producto = editProductoCompra.id_producto;
                    oldProducto.cantidad = editProductoCompra.cantidad;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_compra productoCompra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(productoCompra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}