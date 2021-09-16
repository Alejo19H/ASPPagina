using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class CompraController : Controller
    {
        [Authorize]
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.compra.ToList());
            }

        }

        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }

        public ActionResult ListarUsuario()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public static string NombreCliente(int idCliente)
        {
            using (var db = new inventario2021Entities())
            {
                return db.cliente.Find(idCliente).nombre;
            }
        }

        public ActionResult ListarCliente()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.cliente.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.compra.Add(compra);
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
                return View(db.compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                compra editCompra = db.compra.Where(a => a.id == id).FirstOrDefault();
                return View(editCompra);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(compra editCompra)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldCompra = db.compra.Find(editCompra.id);
                    oldCompra.fecha = editCompra.fecha;
                    oldCompra.total = editCompra.total;
                    oldCompra.id_usuario = editCompra.id_usuario;
                    oldCompra.id_cliente = editCompra.id_cliente;
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
                    compra compra = db.compra.Find(id);
                    db.compra.Remove(compra);
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