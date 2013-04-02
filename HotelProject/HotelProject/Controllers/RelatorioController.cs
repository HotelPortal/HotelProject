using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using HotelProject.ModeloView;
using HotelProject.Models;

namespace HotelProject.Controllers
{
    [Authorize]
    public class RelatorioController : Controller
    {


        private HotelDBContext db = ConnectionHelper.getContextInstance();

        public ActionResult Modelo()
        {


            return View("EscolhaDatas");
        }

        [HttpPost]
        public ActionResult Modelo(RelatorioModelo modelo)
        {

            var d1 = modelo.DataIni;

            var d2 = modelo.DataFim;
            decimal total = 0;

            var login = System.Web.HttpContext.Current.User.Identity.Name;

            var funcionariologado = db.funcionarios.Single(c => c.Login == login);

            ViewBag.Funcionario = funcionariologado.Nome;
            ViewBag.DataInicio = d1;
            ViewBag.DataFim = d2;

            IEnumerable<checkin> resultados = db.checkins;
            IEnumerable<checkin> realizados = (resultados.Where(resultado => resultado.Data >= Convert.ToDateTime(d1) && resultado.Data <= Convert.ToDateTime(d2)));
            foreach (var realizado in realizados)
            {
                total = total + (decimal)realizado.Valor;
            }
            Session["total"] = total;

            return View(realizados);
        }



        public ActionResult Quartos()
        {

            var login = System.Web.HttpContext.Current.User.Identity.Name;

            var funcionariologado = db.funcionarios.Single(c => c.Login == login);

            ViewBag.Funcionario = funcionariologado.Nome;

            IEnumerable<quarto> quartos = db.quartos;
            IEnumerable<status_quarto> statusQuartos = db.status_quarto;
            IEnumerable<quarto> result = (from quarto in quartos from statusQuarto in statusQuartos where quarto.status_Id == statusQuarto.status_Id && statusQuarto.FlAlugavel.Equals(true) select quarto);

            return View(result);
        }

    }
}
