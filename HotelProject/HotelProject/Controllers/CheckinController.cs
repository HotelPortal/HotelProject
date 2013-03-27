using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelProject.Models;
using Newtonsoft.Json;

namespace HotelProject.Controllers
{
    public class CheckinController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        private List<quarto> quartos = new List<quarto>();

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
            ViewBag.quarto_Id = new SelectList(db.quartos, "quarto_id", "Descricao");
            return View();
        }

        //
        // POST: /Checkin/Create

        [HttpPost]
        public ActionResult Create(String Items)
        {

            checkin checkin_form = JsonConvert.DeserializeObject<checkin>(Items);

            var checkin = new checkin();

            //checkin.Previsao = checkin_form.Previsao;
            db.checkins.Add(checkin);
            db.SaveChanges();


            cliente cli = db.clientes.Find(checkin_form.cliente_id);

            cli.checkins.Add(checkin);
            checkin.cliente_id = cli.cliente_id;

            db.Entry(cli).State = EntityState.Modified;
            db.Entry(checkin).State = EntityState.Modified;

            db.SaveChanges();

            

            
                

           





            if (ModelState.IsValid)
            {
                foreach (var quarto in checkin_form.quartos)
                {
                    var q = db.quartos.Find(quarto.quarto_Id);
                    q.checkins.Add(checkin);

                    db.Entry(q).State = EntityState.Modified;
                }


                db.SaveChanges();
                return Redirect("Index");
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



        public ActionResult AdicionarQuarto(string form, int quartoid)
        {
            var model = JsonConvert.DeserializeObject<checkin>(form);
            var quar = db.quartos.Find(quartoid);
            model.quartos.Add(quar);
            return PartialView("_GridQuarto", model);
        }


        public ActionResult RemoverQuarto(string form, int quartoid)
        {

            var model = JsonConvert.DeserializeObject<checkin>(form);

            quarto quarto_remover = null;

            foreach (var q in model.quartos)
            {
                System.Console.Write(quartoid + " " + q.quarto_Id);

                if (quartoid == q.quarto_Id)
                {

                    quarto_remover = q;
                    quartos.Add(q);
                    break;
                }

            }

     
            model.quartos.Remove(quarto_remover);
            

           // model.quartos = quartos;

            return PartialView("_GridQuarto", model);
        }


        public ActionResult Save(string Items)
        {
            checkin model = JsonConvert.DeserializeObject<checkin>(Items);

            model.Data = DateTime.Today;




                db.checkins.Add(model);
                db.SaveChanges();
                return Redirect("Index");
            
       
        }
    }
}