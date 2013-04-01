using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HotelProject.Models;

namespace HotelProject.Controllers
{
    public class RelatorioController : Controller
    {

        private HotelDBContext db = new HotelDBContext();

        public ActionResult Modelo()
        {
            string d1 = "10/02/2013";
            string d2 = "20/04/2013";
            decimal total = 0;
            IEnumerable<checkin> resultados = db.checkins;
            IEnumerable<checkin> realizados = (resultados.Where(resultado => resultado.Data >= Convert.ToDateTime(d1) && resultado.Data <= Convert.ToDateTime(d2)));
            foreach (var realizado in realizados)
            {
                    total = total+(decimal) realizado.Valor;
            }
            Session["total"] = total;

            return View(realizados);
        }

        public ActionResult Quartos()
        {
            IEnumerable<quarto> quartos = db.quartos;
            IEnumerable<status_quarto> statusQuartos = db.status_quarto;
            IEnumerable<quarto> result = (from quarto in quartos from statusQuarto in statusQuartos where quarto.status_Id == statusQuarto.status_Id && statusQuarto.FlAlugavel.Equals(true) select quarto);

            return View(result);
        }

    }
}
