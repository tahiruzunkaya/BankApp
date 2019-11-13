using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAppApi.DataAccess.Abstract;
using BankAppApi.Entity;
using BankAppApi.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAppApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : ControllerBase
    {
        public int aboneNo { get; set; } = 500123;
        public decimal borc { get; set; }
        private IUnitOfWork uow;

        public OdemeController(IUnitOfWork _uow)
        {
            uow = _uow;
            borc = 150;
        }
        [Route("Ode")]
        [HttpPost]
        public IActionResult Ode([FromBody] OdemeModel m)
        {
            var tc = User.Claims.FirstOrDefault().Value;
            var musteri = uow.Musteriler.Find(x => x.TcKimlikNo.Equals(tc)).FirstOrDefault();
            var cekilecekHesap = uow.Hesaplar.Find(x => x.EkNo == m.EkNo && x.MusteriNo == musteri.MusteriNo).FirstOrDefault();
            if (m.aboneNo==aboneNo && borc != 0 && cekilecekHesap.Bakiye>borc)
            {
                cekilecekHesap.Bakiye -= borc;
                
                Haraketler h = new Haraketler()
                {
                    EkNo = m.EkNo,
                    IslemTipi = "Fatura Odeme",
                    Miktar = borc,
                    MusteriNo = musteri.MusteriNo
                };
                borc = 0;
                uow.Hesaplar.Edit(cekilecekHesap);
                uow.SaveChanges();
                uow.Haraketler.Add(h);
                uow.SaveChanges();
                return Ok(new {
                    data="Odeme işlemi başarıyla gerçekleştirildi."
                });
            }
            else
            {
                return NotFound();
            }
        }

        [Route("Sorgula")]
        [HttpGet]
        public IActionResult Sorgula([FromBody] OdemeModel m)
        {
            if (aboneNo == m.aboneNo && borc!=0)
            {

                m.borc = borc;
                return Ok(new {
                    data = m
                });

            }
            else
            {
                return NotFound();
            }
        }
    }
}