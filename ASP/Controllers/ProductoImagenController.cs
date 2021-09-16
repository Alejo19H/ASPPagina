using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class ProductoImagenController : Controller
    {
        [Authorize]
        // GET: ProductoImagen
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.ToList());
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
            using (var db = new inventario2021Entities())
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

        public ActionResult Create(producto_imagen productoImg)
        {
            if(!ModelState.IsValid)
            return View();
            
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_imagen.Add(productoImg);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                producto_imagen editProductoImg = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                return View(editProductoImg);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen editProducto)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldProductoImg = db.producto_imagen.Find(editProducto.id);
                    oldProductoImg.imagen = editProducto.imagen;
                    oldProductoImg.id_producto = editProducto.id_producto;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
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
                    producto_imagen productoImg = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(productoImg);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}