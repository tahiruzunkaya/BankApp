using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppApi.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IMusteriRepository Musteriler { get; }
        IHesapRepository Hesaplar { get; }
        IHavaleRepository Havaleler { get; }
        IVirmanRepository Virmanlar { get; }

        int SaveChanges();
    }
}
