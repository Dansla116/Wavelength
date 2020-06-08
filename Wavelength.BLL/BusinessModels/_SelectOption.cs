using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wavelength.BLL.BusinessModels {
    [Serializable]
    public class SelectOption {
        public string Text { get; set; }
        public string Value { get; set; }
        public List<KeyValuePair<string, string>> Attributes { get; set; }

        public SelectOption(string text, string value) {
            this.Text = text;
            this.Value = value;
            Attributes = new List<KeyValuePair<string, string>>();
        }

        public SelectOption(string text, string value, string key, string attribute) {
            this.Text = text;
            this.Value = value;
            this.Attributes = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string> (key , attribute)
            };
        }

        public SelectOption() {
            Attributes = new List<KeyValuePair<string, string>>();
        }

        public void AddAttribute(String Name, String Value) {
            KeyValuePair<String, String> kvp = new KeyValuePair<String, String>(Name, Value);
            if (Attributes.Where(x => x.Key == Name).Count() == 0) {
                Attributes.Add(kvp);
            }
        }
    }

    public static partial class Translations {
        public static SelectListItem toSelectListItem(this SelectOption current) {
            var result = new SelectListItem() {
                Text = current.Text,
                Value = current.Value

            };

            return result;
        }

        public static SelectListItem toSelectListItem(this SelectOption current, string _value) {
            if (current.Value == _value || current.Text == _value) {
                var result = new SelectListItem() {
                    Text = current.Text,
                    Value = current.Value,
                    Selected = true
                };

                return result;
            } else {
                var result = new SelectListItem() {
                    Text = current.Text,
                    Value = current.Value
                };

                return result;
            }
        }
    }
}