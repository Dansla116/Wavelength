using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wavelength.BLL {
    public enum Role {
        New = 0,
        InLobby = 1,
        Offense  = 2,
        Defense = 3,
        Psychic = 4
    }

    public enum State {
        InLobby = 0,
        Psychic = 1,
        Offense = 2,
        Defense = 3

    }
}