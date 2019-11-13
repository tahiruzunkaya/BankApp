using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankAppApi.Entity
{
    public class Haraketler
    {
        [Key]
        public int ID { get; set; }
        public string IslemTipi { get; set; }
        public decimal Miktar { get; set; }
        public int MusteriNo { get; set; }
        public int EkNo { get; set; }
    }
}
