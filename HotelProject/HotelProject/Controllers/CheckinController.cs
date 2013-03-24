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
    public class CheckinController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        //
        // GET: /Checkin/

        public ActionResult Index()
        {
            var checkins = db.checkins.Include(c => c.cliente).Include(c => c.funcionario);
            return View(checkins.ToList());
        }

        //
        // GET: /Checkin/Details/5

        public ActionResult Details(long id = 0)
        {
            checkin checkin = db.checkins.Find(id);
            if (checkin == null)
            {
                return HttpNotFound();
            }
            return View(checkin);
        }

        //
        // GET: /Checkin/Create

        public ActionResult Create()
        {
            ViewBag.cliente_id = new SelectList(db.clientes, "cliente_id", "Nome");
            ViewBag.funcionario_Id = new SelectList(db.funcionarios, "funcionario_Id", "Descricao");
            return View();
        }

        //
        // POST: /Checkin/Create

        [HttpPost]
        public ActionResult Create(checkin checkin)
        {
            if (ModelState.IsValid)
            {
                db.checkins.Add(checkin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente_id = new SelectList(db.clientes, "cliente_id", "Nome", checkin.cliente_id);
            ViewBag.funcionario_Id = new SelectList(db.funcionarios, "funcionario_Id", "Descricao", checkin.funcionario_Id);
            return View(checkin);
        }

        //
        // GET: /Checkin/Edit/5

        public ActionResult Edit(long id = 0)
        {
            checkin checkin = db.checkins.Find(id);
            if (checkin == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente_id = new SelectList(db.clientes, "cliente_id", "Nome", checkin.cliente_id);
            ViewBag.funcionario_Id = new SelectList(db.funcionarios, "funcionario_Id", "Descricao", checkin.funcionario_Id);
            return View(checkin);
        }

        //
        // POST: /Checkin/Edit/5

        [HttpPost]
        public ActionResult Edit(checkin checkin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente_id = new SelectList(db.clientes, "cliente_id", "Nome", checkin.cliente_id);
            ViewBag.funcionario_Id = new SelectList(db.funcionarios, "funcionario_Id", "Descricao", checkin.funcionario_Id);
            return View(checkin);
        }

        //
        // GET: /Checkin/Delete/5

        public ActionResult Delete(long id = 0)
        {
            checkin checkin = db.checkins.Find(id);
            if (checkin == null)
            {
                return HttpNotFound();
            }
            return View(checkin);
        }

        //
        // POST: /Checkin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            checkin checkin = db.checkins.Find(id);
            db.checkins.Remove(checkin);
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