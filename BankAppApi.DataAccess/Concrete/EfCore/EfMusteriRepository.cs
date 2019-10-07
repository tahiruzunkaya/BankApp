using BankAppApi.DataAccess.Abstract;
using BankAppApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppApi.DataAccess.Concrete.EfCore
{
    public class EfMusteriRepository:EfGenericRepository<Musteri>,IMusteriRepository
    {
        public EfMusteriRepository(BankAppContext context) : base(context)
        {

        }
        public BankAppContext EContext
        {
            get { return context as BankAppContext; }
        }
    }
}
