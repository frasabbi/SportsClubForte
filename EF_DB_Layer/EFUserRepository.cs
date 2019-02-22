using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsClubModel;

namespace EF_DB_Layer
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
