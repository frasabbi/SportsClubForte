using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubModel
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser(User user);
        void RemoveUser(int userId);
        IQueryable<User> GetAllUsers();
        IQueryable<User> GetAllUsersByLastNameAsync(string token);
        IQueryable<User> GetUsersByDateOfBirthRange(DateTime start, DateTime end);
        User GetUserById(int userId);
        //Task<IQueryable<User>> GetBestWinner();
    }
}
