using Microsoft.EntityFrameworkCore;
using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_Layer
{
    public class EFUnitOfWork : IUnitOfWork
    {
        //Add all IRepositories
        private IReservationRepository repository;
        private ApplicationDbContext context;

        public EFUnitOfWork(IReservationRepository repo, ApplicationDbContext ctx)
        {
            repository = repo;
            context = ctx;
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
