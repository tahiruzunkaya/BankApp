using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankAppApi.Entity
{
    public class Havale
    {
        [Key]
        public int ID { get; set; }
        public int GonderenMusteriNo { get; set; }
        public int GonderenHesapNo { get; set; }
        public int GonderenEkNo { get; set; }
        public int AliciHesapNo { get; set; }
        public int AliciEkNo { get; set; }
        public decimal Tutar { get; set; }
    }
}
