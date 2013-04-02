using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelProject.Models;

namespace HotelProject.Controllers
{

    public class ContaController : Controller
    {

        private HotelDBContext db = new HotelDBContext();

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(FormCollection f, string returnURL)
        {

            var login = f["login"];
            var senha = f["senha"];

            var funcionarios = db.funcionarios.Single(c => c.Login == login);

            if (funcionarios!=null && senha == funcionarios.Senha)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(login, false);
                return Redirect(returnURL);
            }

            return View();
        }

        [Authorize]
        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("~/Home/Index");
        }
   

    }
}
