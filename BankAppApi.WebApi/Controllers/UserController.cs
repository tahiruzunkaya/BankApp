using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BankAppApi.DataAccess.Abstract;
using BankAppApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAppApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUnitOfWork uow;

        public UserController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        [HttpPost]
        public HttpResponseMessage AddMusteri([FromBody]Musteri entity)
        {
            
                uow.Musteriler.Add(entity);
                uow.SaveChanges();
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
           
        }

    }
}