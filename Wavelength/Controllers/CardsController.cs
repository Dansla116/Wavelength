using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wavelength.BLL.BusinessModels;
using Wavelength.BLL.Services;

namespace Wavelength.Controllers {
    public class CardsController : Controller {
        private ICardService Service;

        public CardsController(
            ICardService _CardService    
        ) {
            Service = _CardService;
        }

        // GET: Cards
        public ActionResult Index() {
            List<Card> response = Service.ReadAll().data;
            return View("~/Views/Home/Cards.cshtml", response);
        }

        public ActionResult Create(Card Model) {
            var response = Service.Create(Model);
            return Json(response);
        }
    }
}