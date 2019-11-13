using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppApi.WebApi.Models
{
    public class ParaCekModel
    {
        public int EkNo { get; set; }
        public int Miktar { get; set; }
        public string IslemTipi { get; set; }
    }
}
