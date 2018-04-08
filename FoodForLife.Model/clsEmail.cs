using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForLife.Model
{
    public class clsEmail
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string Smtp { get; set; }
        public string Body { get; set; }
    }
}
