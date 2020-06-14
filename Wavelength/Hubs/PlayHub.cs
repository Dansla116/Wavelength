using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Wavelength.BLL.BusinessModels;

namespace Wavelength.Hubs {
    public class PlayHub : Hub {
        public async Task SendUsers(List<User> Users) {
            await Clients.All.SendAsync("UpdateUsers", Users);
        }

        public async Task NewState(Game Game) {
            await Clients.All.SendAsync("NewState", Game);
        }
    }
}