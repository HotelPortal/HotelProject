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
    public class CidadeController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        //
        // GET: /Cidade/

        public ActionResult Index()
        {
            return View(db.cidades.ToList());
        }

        //
        // GET: /Cidade/Details/5

        public ActionResult Details(long id = 0)
        {
            cidade cidade = db.cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        //
        // GET: /Cidade/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cidade/Create

        [HttpPost]
        public ActionResult Create(cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        //
        // GET: /Cidade/Edit/5

        public ActionResult Edit(long id = 0)
        {
            cidade cidade = db.cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        //
        // POST: /Cidade/Edit/5

        [HttpPost]
        public ActionResult Edit(cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        //
        // GET: /Cidade/Delete/5

        public ActionResult Delete(long id = 0)
        {
            cidade cidade = db.cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        //
        // POST: /Cidade/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            cidade cidade = db.cidades.Find(id);
            db.cidades.Remove(cidade);
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