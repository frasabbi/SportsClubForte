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
        Task<IQueryable<User>> GetAllUsersAsync();
        Task<IQueryable<User>> GetAllUsersByLastNameAsync(string token);
        Task<IQueryable<User>> GetUsersByDateOfBirthRange(DateTime start, DateTime end);
        //Task<IQueryable<User>> GetBestWinner();
    }
}
