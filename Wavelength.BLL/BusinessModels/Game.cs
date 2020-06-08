using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavelength.DAL.DomainModels;

namespace Wavelength.BLL.BusinessModels {
    public class Game : Base {
        public string Code { get; set; }
        public State State { get; set; }
    }

    public static partial class Translations {
        public static Game ToLogic(this GameData Data) {
            Game Logic = new Game();

            Logic.Code = Data.Code;
            Logic.State = (State)Data.State;

            Logic.id = Data.id;
            Logic.DateAdded = Data.DateAdded;
            Logic.DateUpdated = Data.DateUpdated;

            return Logic;
        }

        public static List<Game> ToLogicList(this IQueryable<GameData> DataList) {
            List<Game> LogicList = new List<Game>();
            foreach (GameData Data in DataList) {
                Game Logic = new Game();

                Logic.Code = Data.Code;
                Logic.State = (State)Data.State;

                Logic.id = Data.id;
                Logic.DateAdded = Data.DateAdded;
                Logic.DateUpdated = Data.DateUpdated;

                LogicList.Add(Logic);
            }
            return LogicList;
        }
    }
}