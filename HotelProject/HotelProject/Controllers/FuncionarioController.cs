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
    public class FuncionarioController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        //
        // GET: /Funcionario/

        public ActionResult Index()
        {
            var funcionarios = db.funcionarios.Include(f => f.cidade);
            return View(funcionarios.ToList());
        }

        //
        // GET: /Funcionario/Details/5

        public ActionResult Details(long id = 0)
        {
            funcionario funcionario = db.funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Create

        public ActionResult Create()
        {
            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao");
            return View();
        }

        //
        // POST: /Funcionario/Create

        [HttpPost]
        public ActionResult Create(funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao", funcionario.cidade_id);
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Edit/5

        public ActionResult Edit(long id = 0)
        {
            funcionario funcionario = db.funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao", funcionario.cidade_id);
            return View(funcionario);
        }

        //
        // POST: /Funcionario/Edit/5

        [HttpPost]
        public ActionResult Edit(funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cidade_id = new SelectList(db.cidades, "cidade_id", "Descricao", funcionario.cidade_id);
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Delete/5

        public ActionResult Delete(long id = 0)
        {
            funcionario funcionario = db.funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // POST: /Funcionario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            funcionario funcionario = db.funcionarios.Find(id);
            db.funcionarios.Remove(funcionario);
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