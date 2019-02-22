using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
