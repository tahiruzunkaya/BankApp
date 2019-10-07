using BankAppApi.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppApi.DataAccess.Concrete.EfCore
{
    public class EfUnitOfWork:IUnitOfWork
    {
        private readonly BankAppContext dbContext;

        public EfUnitOfWork(BankAppContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("Db Context can not be null");

        }

        private IMusteriRepository _musteriler;
        private IHesapRepository _hesaplar;
        private IHavaleRepository _havaleler;
        private IVirmanRepository _virmanlar;

        public IMusteriRepository Musteriler
        {
            get
            {
                return _musteriler ?? (_musteriler = new EfMusteriRepository(dbContext));
            }
        }

        public IHesapRepository Hesaplar
        {
            get
            {
                return _hesaplar ?? (_hesaplar = new EfHesapRepository(dbContext));
            }
        }

        public IHavaleRepository Havaleler
        {
            get
            {
                return _havaleler ?? (_havaleler = new EfHavaleRepository(dbContext));
            }
        }
        public IVirmanRepository Virmanlar
        {
            get
            {
                return _virmanlar ?? (_virmanlar = new EfVirmanRepository(dbContext));
            }
        }
        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
