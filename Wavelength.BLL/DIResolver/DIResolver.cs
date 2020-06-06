using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavelength.BLL.Services;
using Wavelength.DAL.Context;
using Wavelength.DAL.DomainModels;
using Wavelength.DAL.Repository;

namespace Wavelength.BLL.DIResolver {
    public class BLLModule : NinjectModule {
        public override void Load() {
            //Services
            Bind<ICardService>().To<CardService>();
        }
    }

    public class DALModule : NinjectModule {
        public override void Load() {
            //Context
            Bind<IDBContext>().To<DatabaseContext>();

            //Domain Models
            Bind<ICardData>().To<CardData>();

            //Repositories
            Bind(typeof(IRepository<>)).To(typeof(GenericRepo<>)).Named("Repo");
            Bind<ICardRepo>().To<CardRepo>();
        }
    }
}