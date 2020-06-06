using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Wavelength.BLL.BusinessModels;
using Wavelength.DAL.DomainModels;
using Wavelength.DAL.Repository;

namespace Wavelength.BLL.Services {
    public interface ICardService {
        ServiceResponse<Card> Create(Card Model);
        ServiceResponse<List<Card>> ReadAll();
        ServiceResponse<Card> Delete(int id);
        ServiceResponse<List<Card>> Search(string Query);
    }
    public class CardService : ICardService {
        #region Generic
        private ServiceResponse<Card> Response = new ServiceResponse<Card>();
        private ServiceResponse<List<Card>> ResponseList = new ServiceResponse<List<Card>>();
        private ICardRepo Repo;

        public CardService(
            ICardRepo CardRepo
        ) {
            Repo = CardRepo;
        }

        public ServiceResponse<Card> Create(Card Model) {
            try {
                var Data = new CardData {
                    /* Change */
                    Left = Model.Left,
                    Right = Model.Right,
                    Advanced = Model.Advanced,
                    /* END Change */

                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    /*UserAdded = CurrentUser.id,
                    UserUpdated = CurrentUser.id*/
                };
                Data = Repo.Create(Data);
                Repo.Save();
                Response.data = Data.ToLogic();
                Response.successful("Success!");
            } catch (Exception ex) {
                Debug.Write(ex.Message);
                Response.failed("Error in Card service.");
            }
            return Response;
        }
        public ServiceResponse<List<Card>> ReadAll() {
            try {
                ResponseList.data = Repo.ReadAll().ToLogicList();
                ResponseList.successful("Success!");
            } catch (Exception ex) {
                Debug.Write(ex.Message);
                ResponseList.failed("Error in Card service.");
            }
            return ResponseList;
        }

        public ServiceResponse<Card> Delete(int id) {
            try {
                Repo.Delete(id);
                Repo.Save();
                Response.successful("Success!");
            } catch (Exception ex) {
                Debug.Write(ex.Message);
                Response.failed("Error in Card service.");
            }
            return Response;
        }
        #endregion

        public ServiceResponse<List<Card>> Search(string Query) {
            try {
                List<string> searches = Query.Split(' ').ToList();

                List<CardData> cardContains = new List<CardData>();

                foreach (string search in searches) {
                    cardContains.AddRange(Repo.Read(a => a.Left.Contains(search) || a.Right.Contains(search)));
                }
                ResponseList.data = cardContains.AsQueryable().ToLogicList();
                ResponseList.successful("Success!");
            } catch (Exception ex) {
                Debug.Write(ex.Message);
                ResponseList.failed("Error in Card service.");
            }
            return ResponseList;
        }
    }
}