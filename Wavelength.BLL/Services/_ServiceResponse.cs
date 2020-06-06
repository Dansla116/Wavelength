using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wavelength.BLL.Services {
    public interface IServiceResponse { }
    public class ServiceResponse<T> : IServiceResponse {
        public bool success { get; set; }
        public string message { get; set; }
        public string redirectTo { get; set; }
        public string html { get; set; }
        public T data { get; set; }
        public Exception error { get; set; }

        public ServiceResponse() {
            this.data = default(T);
            this.success = false;
        }

        public void successful(string message) {
            this.success = true;
            this.message = message;
        }

        public void failed(string message) {
            this.success = false;
            this.message = message;
        }

        public void successful(string message, T data) {
            this.success = true;
            this.message = message;
            this.data = data;
        }

        public void failed(string message, T data) {
            this.success = false;
            this.message = message;
            this.data = data;
        }
    }
}