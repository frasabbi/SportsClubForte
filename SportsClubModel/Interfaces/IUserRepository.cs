using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsClubModel
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser(User user);
    }
}
