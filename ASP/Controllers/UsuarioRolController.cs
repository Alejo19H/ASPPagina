using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuariorol.ToList());
            }

        }

        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }

        public static string NombreRol(int idRol)
        {
            using (var db = new inventario2021Entities())
            {
                return db.roles.Find(idRol).descripcion;
            }
        }

        public ActionResult ListarUsuario()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public ActionResult ListarRol()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.roles.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usuariorol usuariorol)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.usuariorol.Add(usuariorol);
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
                return View(db.usuariorol.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                usuariorol editUsuarioRol = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                return View(editUsuarioRol);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usuariorol editUsuarioRol)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldUsuarioRol = db.usuariorol.Find(editUsuarioRol.id);
                    oldUsuarioRol.idUsuario = editUsuarioRol.idUsuario;
                    oldUsuarioRol.idRol = editUsuarioRol.idRol;
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
                    usuariorol usuariorol = db.usuariorol.Find(id);
                    db.usuariorol.Remove(usuariorol);
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