using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wavelength.BLL.BusinessModels;
using Wavelength.BLL.Models;
using Wavelength.BLL.Services;
using Wavelength.Hubs;
/*using Wavelength.Hubs;
*/
namespace Wavelength.Controllers {
    public interface IPlayController {
        ActionResult Join(string Code, string Name);
    }

    public class PlayController : Controller, IPlayController {
        private IPlayService Service;
        private ISelectOptionService SelectOptionService;

        public PlayController(
            IPlayService _PlayService,
            ISelectOptionService _SelectOptionService
        ) {
            Service = _PlayService;
            SelectOptionService = _SelectOptionService;
        }

        // GET: Play
        public ActionResult Index() {
            PlayVM response = new PlayVM();
            response.Roles = SelectOptionService.Roles();
            response.States = SelectOptionService.States();

            return View("~/Views/Home/Play.cshtml", response);
        }

        public ActionResult Join(string Code, string Name) {
            var response = Service.Join(Code, Name);
            return Json(response);
        }
    }
}