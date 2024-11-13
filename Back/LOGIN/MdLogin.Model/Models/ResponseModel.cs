using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Model.Models
{
    public class ResponseModel
    {
        public ResponseModel() {

            Date = DateTime.Now;
            
        }
        public DateTime Date { get; set; }
        public Object Response { get; set; }
        public bool Result { get; set; }
        public string Error { get; set; }
        public string Rol { get; set; }
        public string UrlDestino { get; set; }
        public string UserName { get; set; }


    }
}
