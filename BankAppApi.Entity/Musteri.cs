
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankAppApi.Entity
{
    public class Musteri
    {
        [Key]
        public int MusteriNo { get; set; }
        public string TcKimlikNo { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }

        public List<Hesap> Hesaplar { get; set; }
    }
}
