using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelProject.Models;
using Newtonsoft.Json;


namespace HotelProject.Controllers
{
    [Authorize]
    public class CheckinController : Controller
    {
        private HotelDBContext db = new HotelDBContext();

        private List<quarto> quartos = new List<quarto>();

        //
        // GET: /Checkin/

        public ActionResult Index()
        {
            //var checkins = db.checkins.Include(c => c.cliente).Include(c => c.funcionario);
            var checkins = db.checkins.ToList();
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
        // GET: /Checkin/Details/5

        public ActionResult ChekinsPorCliente(long id = 0)
        {
            var checkin = db.checkins.Where(c => c.cliente.cliente_id.Equals(id));

            var lista = checkin.ToList();

            return View(lista);
        }



        //
        // GET: /Checkin/Create

        
        public ActionResult Create()
        {
            ViewBag.cliente_id = new SelectList(db.clientes, "cliente_id", "Nome");
            ViewBag.funcionario_Id = new SelectList(db.funcionarios, "funcionario_Id", "Descricao");
            ViewBag.quarto_Id = new SelectList(db.quartos.Where(c => c.status_quarto.FlAlugavel.Equals(true)), "quarto_id", "Descricao");
            return View();
        }

        //
        // POST: /Checkin/Create

        [HttpPost]
        public JsonResult Create(String Items)
        {

            checkin checkin_form = JsonConvert.DeserializeObject<checkin>(Items);

            var login = System.Web.HttpContext.Current.User.Identity.Name;

            var funcionariologado = db.funcionarios.Single(c => c.Login == login);

            db.Entry(funcionariologado).State = EntityState.Unchanged;

            checkin_form.funcionario_Id = funcionariologado.funcionario_Id;

            checkin_form.Data = DateTime.Now;
            quartos = new List<quarto>();

            float valor = 0;
            foreach (var quarto in checkin_form.quartos)
            {

                db.Entry(quarto).State = EntityState.Unchanged;

                valor += quarto.ValorDia * float.Parse(checkin_form.Previsao.ToString());
            }
            checkin_form.Valor = valor;

            db.checkins.Add(checkin_form);

            db.SaveChanges();


            foreach (var quarto in checkin_form.quartos)
            {

                quarto.status_quarto = db.status_quarto.Single(c => c.FlAlugavel.Equals(false));

                db.Entry(quarto).State = EntityState.Modified;

                valor += quarto.ValorDia * float.Parse(checkin_form.Previsao.ToString());
            }

            db.SaveChanges();

            return Json(true);
           
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
            ViewBag.quarto_Id = new SelectList(db.quartos, "quarto_id", "Descricao");
            return View(checkin);
        }

        //
        // POST: /Checkin/Edit/5

        [HttpPost]
        public JsonResult Edit(string Items)
        {
            if (ModelState.IsValid)
            {


                checkin checkin_form = JsonConvert.DeserializeObject<checkin>(Items);

                var checkin = db.checkins.Find(checkin_form.checkin_Id);

                checkin.quartos = new Collection<quarto>();

                foreach (var quarto in checkin_form.quartos)
                {
                    db.Entry(quarto).State = EntityState.Unchanged;
                    checkin.quartos.Add(quarto);
                }

                db.Entry(checkin).State = EntityState.Modified;
    
                db.SaveChanges();
            }
            
            return Json(true);
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
        // GET: /Checkin/ChechOut/5

        public ActionResult ChechOut(long id = 0)
        {
            checkin checkin = db.checkins.Find(id);
            if (checkin != null)
            {
                checkin.Saida = DateTime.Now;

                db.Entry(checkin).State = EntityState.Modified;

                db.SaveChanges();


                foreach (var quarto in checkin.quartos)
                {

                    quarto.status_quarto = db.status_quarto.Single(c => c.FlAlugavel.Equals(true));

                    db.Entry(quarto).State = EntityState.Modified;


                }

                db.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
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



            if (ModelState.IsValid)
            {
      
                var quar = db.quartos.Find(quartoid);
                model.quartos.Add(quar);

                float valor = 0;
                foreach (var quarto in model.quartos)
                {
                    db.Entry(quarto).State = EntityState.Unchanged;
                    valor += quarto.ValorDia*float.Parse(model.Previsao.ToString());
                }
                model.Valor = valor;

            }
        

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
    }
}