using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Wavelength.BLL.BusinessModels;
using Wavelength.Controllers;

namespace Wavelength.Hubs {
    public class PlayHub : Hub {
        private IPlayController Controller;

        public async Task Join(string Code, string Name) {
            var result = Controller.Join(Code, Name);
            await Clients.All.SendAsync("UpdateUsers", result);
        }

        public async Task SendUsers(List<User> Users) {
            await Clients.All.SendAsync("UpdateUsers", Users);
        }

        public async Task NewState(Game Game) {
            await Clients.All.SendAsync("NewState", Game);
        }
    }
}