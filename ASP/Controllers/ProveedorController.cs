using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class ProveedorController : Controller
    {
        [Authorize]
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.proveedor.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var findProveedor = db.proveedor.Find(id);
                return View(findProveedor);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findProveedor = db.proveedor.Find(id);
                    db.proveedor.Remove(findProveedor);
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

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findProveedor = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findProveedor);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor editProveedor)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var proveedor = db.proveedor.Find(editProveedor.id);

                    proveedor.nombre = editProveedor.nombre;
                    proveedor.direccion = editProveedor.direccion;
                    proveedor.telefono = editProveedor.telefono;
                    proveedor.nombre_contacto = editProveedor.nombre_contacto;

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