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
    public class StatusQuartoController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        //
        // GET: /StatusQuarto/

        public ActionResult Index()
        {
            return View(db.status_quarto.ToList());
        }

        //
        // GET: /StatusQuarto/Details/5

        public ActionResult Details(long id = 0)
        {
            status_quarto status_quarto = db.status_quarto.Find(id);
            if (status_quarto == null)
            {
                return HttpNotFound();
            }
            return View(status_quarto);
        }

        //
        // GET: /StatusQuarto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StatusQuarto/Create

        [HttpPost]
        public ActionResult Create(status_quarto status_quarto)
        {
            if (ModelState.IsValid)
            {
                db.status_quarto.Add(status_quarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_quarto);
        }

        //
        // GET: /StatusQuarto/Edit/5

        public ActionResult Edit(long id = 0)
        {
            status_quarto status_quarto = db.status_quarto.Find(id);
            if (status_quarto == null)
            {
                return HttpNotFound();
            }
            return View(status_quarto);
        }

        //
        // POST: /StatusQuarto/Edit/5

        [HttpPost]
        public ActionResult Edit(status_quarto status_quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_quarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_quarto);
        }

        //
        // GET: /StatusQuarto/Delete/5

        public ActionResult Delete(long id = 0)
        {
            status_quarto status_quarto = db.status_quarto.Find(id);
            if (status_quarto == null)
            {
                return HttpNotFound();
            }
            return View(status_quarto);
        }

        //
        // POST: /StatusQuarto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            status_quarto status_quarto = db.status_quarto.Find(id);
            db.status_quarto.Remove(status_quarto);
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