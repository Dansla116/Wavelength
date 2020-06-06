using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavelength.DAL.DomainModels;

namespace Wavelength.BLL.BusinessModels {
    public class Card : Base {
        public string Left { get; set; }
        public string Right { get; set; }
        public bool Advanced { get; set; }
    }

    public static partial class Translations {
        public static Card ToLogic(this CardData Data) {
            Card Logic = new Card();

            Logic.Left = Data.Left;
            Logic.Right = Data.Right;
            Logic.Advanced = Data.Advanced;

            Logic.id = Data.id;
            Logic.DateAdded = Data.DateAdded;
            Logic.DateUpdated = Data.DateUpdated;
            Logic.UserAdded = Data.UserAdded;
            Logic.UserUpdated = Data.UserUpdated;

            return Logic;
        }

        public static List<Card> ToLogicList(this IQueryable<CardData> DataList) {
            List<Card> LogicList = new List<Card>();
            foreach (CardData Data in DataList) {
                Card Logic = new Card();

                Logic.Left = Data.Left;
                Logic.Right = Data.Right;
                Logic.Advanced = Data.Advanced;

                Logic.id = Data.id;
                Logic.DateAdded = Data.DateAdded;
                Logic.DateUpdated = Data.DateUpdated;
                Logic.UserAdded = Data.UserAdded;
                Logic.UserUpdated = Data.UserUpdated;

                LogicList.Add(Logic);
            }
            return LogicList;
        }
    }
}