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
    public class PlayController : Controller {
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

        public Task Join(string Code, string Name) {
            var response = Service.Join(Code, Name);
/*            await Clients.All.getUsers = 
*/

/*            var context = GlobalHost.ConnectionManager.GetHubContext<PlayHub>();
            context.Clients.All.methodInJavascript(response.data.Users);*/
        }

/*        public ActionResult Start(string Code, List<User> Users) {
            var response = Service.Start(Code);
            return Json(response);
        }*/
    }
}