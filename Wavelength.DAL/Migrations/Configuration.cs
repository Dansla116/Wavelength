using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Wavelength.DAL.DomainModels;

namespace Wavelength.DAL.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<Wavelength.DAL.Context.DatabaseContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Wavelength.Models.ApplicationDbContext";
        }

        protected override void Seed(Wavelength.DAL.Context.DatabaseContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<CardData> Cards = new List<CardData>();
            Cards.Add(new CardData() {
                id = 0,
                Left = "",
                Right = ""
            });
        }
    }
}