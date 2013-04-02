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
    public class QuartoController : Controller
    {
        private HotelDBContext db = ConnectionHelper.getContextInstance();

        //
        // GET: /Quarto/

        public ActionResult Index()
        {
            var quartos = db.quartos.Include(q => q.status_quarto);
            return View(quartos.ToList());
        }

        //
        // GET: /Quarto/Details/5

        public ActionResult Details(long id = 0)
        {
            quarto quarto = db.quartos.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        //
        // GET: /Quarto/Create

        public ActionResult Create()
        {
            ViewBag.status_Id = new SelectList(db.status_quarto, "status_Id", "Descridao");
            return View();
        }

        //
        // POST: /Quarto/Create

        [HttpPost]
        public ActionResult Create(quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.quartos.Add(quarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.status_Id = new SelectList(db.status_quarto, "status_Id", "Descridao", quarto.status_Id);
            return View(quarto);
        }

        //
        // GET: /Quarto/Edit/5

        public ActionResult Edit(long id = 0)
        {
            quarto quarto = db.quartos.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            ViewBag.status_Id = new SelectList(db.status_quarto, "status_Id", "Descridao", quarto.status_Id);
            return View(quarto);
        }

        //
        // POST: /Quarto/Edit/5

        [HttpPost]
        public ActionResult Edit(quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.status_Id = new SelectList(db.status_quarto, "status_Id", "Descridao", quarto.status_Id);
            return View(quarto);
        }

        //
        // GET: /Quarto/Delete/5

        public ActionResult Delete(long id = 0)
        {
            quarto quarto = db.quartos.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        //
        // POST: /Quarto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            quarto quarto = db.quartos.Find(id);
            db.quartos.Remove(quarto);
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