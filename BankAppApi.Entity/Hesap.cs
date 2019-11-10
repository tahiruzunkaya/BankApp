using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankAppApi.Entity
{
    public class Hesap
    {
        [Key]
        public int HesapNo { get; set; }
        public int EkNo { get; set; }
        public decimal Bakiye { get; set; }
        public bool Aktif { get; set; }

        public int MusteriNo { get; set; }
        public Musteri Musteri { get; set; }
    }
}
