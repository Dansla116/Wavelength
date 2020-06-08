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
            Bind<ISelectOptionService>().To<SelectOptionService>();
            Bind<ICardService>().To<CardService>();
            Bind<IPlayService>().To<PlayService>();
        }
    }

    public class DALModule : NinjectModule {
        public override void Load() {
            //Context
            Bind<IDBContext>().To<DatabaseContext>();

            //Domain Models
            Bind<ICardData>().To<CardData>();
            Bind<IGameData>().To<GameData>();
            Bind<IUserData>().To<UserData>();

            //Repositories
            Bind(typeof(IRepository<>)).To(typeof(GenericRepo<>)).Named("Repo");
            Bind<ICardRepo>().To<CardRepo>();
            Bind<IGameRepo>().To<GameRepo>();
            Bind<IUserRepo>().To<UserRepo>();
        }
    }
}