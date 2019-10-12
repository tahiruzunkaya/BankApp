using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppApi.WebApi.Models
{
    public class LoginModel
    {
        public string TcKimlikNo { get; set; }
        public string Sifre { get; set; }
    }
}
