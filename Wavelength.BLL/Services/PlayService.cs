using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using System.Web;
using Wavelength.BLL.BusinessModels;
using Wavelength.BLL.Models;
using Wavelength.DAL.DomainModels;
using Wavelength.DAL.Repository;

namespace Wavelength.BLL.Services {
    public interface IPlayService {
        ServiceResponse<PlayVM> Join(string Code, string Name);
    }
    public class PlayService : IPlayService {
        private ServiceResponse<PlayVM> Response = new ServiceResponse<PlayVM>();

        private IGameRepo GameRepo;
        private IUserRepo UserRepo;

        public PlayService(
            IGameRepo _GameRepo,
            IUserRepo _UserRepo
        ) {
            GameRepo = _GameRepo;
            UserRepo = _UserRepo;
        }

        #region Generic
        #endregion

        #region Specific
        public ServiceResponse<PlayVM> Join(string Code, string Name) {
            try {
                using (TransactionScope TransactionScope = new TransactionScope()) {
                    // Check if game exists
                    var exists = GameRepo.ReadAll().FirstOrDefault(g => g.Code == Code);
                    if (exists == null) {
                        // if game does not exist
                        // create game
                        GameData GameData = new GameData {
                            Code = Code,
                            State = (byte)State.InLobby,

                            DateAdded = DateTime.Now,
                            DateUpdated = DateTime.Now
                            /*UserAdded = CurrentUser.id,
                            UserUpdated = CurrentUser.id*/
                        };
                        Response.data = new PlayVM {
                            Game = GameRepo.Create(GameData).ToLogic()
                        };
                        GameRepo.Save();
                    } else {
                        Response.data = new PlayVM {
                            Game = exists.ToLogic()
                        };
                    }
                    // create user and add to game
                    UserData UserData = new UserData {
                        Name = Name,
                        Role = (byte)Role.InLobby,
                        idGame = Response.data.Game.id,

                        DateAdded = DateTime.Now,
                        DateUpdated = DateTime.Now
                        /*UserAdded = CurrentUser.id,
                        UserUpdated = CurrentUser.id*/
                    };
                    Response.data.LocalUser = UserRepo.Create(UserData).ToLogic();

                    Response.data.Users = new List<User>();
                    Response.data.Users.AddRange(UserRepo.Read(u => u.idGame == Response.data.Game.id).ToLogicList());
                    UserRepo.Save();
                    TransactionScope.Complete();
                }
                Response.successful("Success!");
            } catch (Exception ex) {
                Debug.Write(ex.Message);
                Response.failed("Error in Play service.");
            }
            return Response;
        }
        #endregion
    }
}