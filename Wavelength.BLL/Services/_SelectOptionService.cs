using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavelength.BLL.BusinessModels;

namespace Wavelength.BLL.Services {
    public interface ISelectOptionService {
        List<SelectOption> Roles();
        List<SelectOption> States();
    }

    public class SelectOptionService : ISelectOptionService {
        public SelectOptionService(
        ) {
        }


        #region Enums
        public List<SelectOption> Roles() {
            List<SelectOption> result = new List<SelectOption>();

            Array Options = Enum.GetValues(typeof(Role));
            foreach (object Option in Options) {
                result.Add(new SelectOption(Option.ToString(), ((int)Option).ToString()));
            }
            return result;
        }

        public List<SelectOption> States() {
            List<SelectOption> result = new List<SelectOption>();

            Array Options = Enum.GetValues(typeof(State));
            foreach (object Option in Options) {
                result.Add(new SelectOption(Option.ToString(), ((int)Option).ToString()));
            }
            return result;
        }
        #endregion
    }
}