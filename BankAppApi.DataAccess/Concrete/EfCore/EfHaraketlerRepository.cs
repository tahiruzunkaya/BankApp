using BankAppApi.DataAccess.Abstract;
using BankAppApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppApi.DataAccess.Concrete.EfCore
{
    public class EfHaraketlerRepository: EfGenericRepository<Haraketler>, IHaraketlerRepository
    {
        public EfHaraketlerRepository(BankAppContext context) : base(context)
        {

        }
        public BankAppContext EContext
        {
            get { return context as BankAppContext; }
        }
    }
}
