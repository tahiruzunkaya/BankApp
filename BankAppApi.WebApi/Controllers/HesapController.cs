﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAppApi.DataAccess.Abstract;
using BankAppApi.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BankAppApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HesapController : ControllerBase
    {
        private IUnitOfWork uow;

        public HesapController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [Route("HesapAc")]
        [HttpPost]
        public IActionResult HesapAc([FromBody]Hesap h)
        {
            var tc = User.Claims.FirstOrDefault().Value;
            var musteri = uow.Musteriler.Find(x => x.TcKimlikNo.Equals(tc)).FirstOrDefault();


            var hesap = uow.Hesaplar.Find(x => x.MusteriNo == musteri.MusteriNo).LastOrDefault();

            if (hesap == null)
            {
                Hesap m = new Hesap();
                m.MusteriNo = musteri.MusteriNo;
                m.Bakiye = h.Bakiye;
                m.Aktif = true;
                m.EkNo = 1001;

                uow.Hesaplar.Add(m);
                uow.SaveChanges();
                return Ok(new
                {
                    hesapno = m.MusteriNo.ToString() + " " + m.EkNo.ToString()
                });
            }
            else
            {
                Hesap m = new Hesap();
                m.MusteriNo = musteri.MusteriNo;
                m.Bakiye = h.Bakiye;
                m.Aktif = true;
                m.EkNo = hesap.EkNo + 1;
                uow.Hesaplar.Add(m);
                uow.SaveChanges();
                return Ok(new
                {
                    hesapno = m.MusteriNo.ToString() + " " + m.EkNo.ToString()
                });
            }

            return BadRequest();
        }


        [Route("HesapListele")]
        [HttpGet]
        public IActionResult HesapListele()
        {
            var tc = User.Claims.FirstOrDefault().Value;
            var musteri = uow.Musteriler.Find(x => x.TcKimlikNo.Equals(tc)).FirstOrDefault();
            var hesaplar = uow.Hesaplar.Find(x => x.MusteriNo == musteri.MusteriNo).ToList();
            if (hesaplar.Any())
            {
                return Ok(hesaplar);
            }
            else
            {
                return NotFound(
                    new
                    {
                        data = "Hiçbir Hesap Bulunamadı."
                    }
                    );
            }

        }

        [Route("Virman")]
        [HttpPost]
        public IActionResult Virman([FromBody]Virman v)
        {
            var tc = User.Claims.FirstOrDefault().Value;
            var musteri = uow.Musteriler.Find(x => x.TcKimlikNo.Equals(tc)).FirstOrDefault();
            if (musteri.MusteriNo == v.AliciHesapNo && musteri.MusteriNo == v.GonderenHesapNo)
            {


                var aliciHesap = uow.Hesaplar.Find(x => x.MusteriNo == v.AliciHesapNo && x.EkNo == v.AliciEkNo).FirstOrDefault();
                var gonderenHesap = uow.Hesaplar.Find(x => x.MusteriNo == v.GonderenHesapNo && x.EkNo == v.GonderenEkNo).FirstOrDefault();

                if (aliciHesap != null && gonderenHesap != null)
                {
                    aliciHesap.Bakiye += v.Tutar;
                    gonderenHesap.Bakiye -= v.Tutar;

                    uow.Virmanlar.Add(v);
                    uow.SaveChanges();
                    uow.Hesaplar.Edit(aliciHesap);
                    uow.Hesaplar.Edit(gonderenHesap);
                    uow.SaveChanges();

                    return Ok(
                        new
                        {
                            data = "virman işlemi başarıyla gerçekleşti."
                        }
                        );
                }
                else
                {
                    return NotFound(
                        new
                        {
                            error = "Hesap bulunamadı"
                        }
                        );
                }
            }
            else
            {
                return BadRequest(
                        new
                        {
                            error="Hesap numarası size ait değildir."
                        }
                    );
            }
        }

        [Route("Havale")]
        [HttpPost]
        public IActionResult Havale([FromBody]Havale ha)
        {
            return Ok();
        }

    }
}