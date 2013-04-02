using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelProject.Models;

namespace HotelProject.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var clientes = db.clientes.Include(c => c.cidade);
            return View(clientes.ToList());
        }


        [HttpPost]
        public ActionResult Busca(FormCollection f)
        {
            var nome = f["nome"];
            var clientes = db.clientes.Where(c => c.Nome.Contains(nome));
            return View(clientes.ToList());
        }



        //
        // GET: /Cliente/Details/5

        public ActionResult Details(long id = 0)
        {
            cliente cliente = db.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao");
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(cliente cliente)
        {
            if (ModelState.IsValid)
            {

                cliente.DtRegistro = DateTime.Now;

                db.clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao", cliente.cidade_id);
            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(long id = 0)
        {
            cliente cliente = db.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao", cliente.cidade_id);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao", cliente.cidade_id);
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(long id = 0)
        {
            cliente cliente = db.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            cliente cliente = db.clientes.Find(id);
            db.clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}