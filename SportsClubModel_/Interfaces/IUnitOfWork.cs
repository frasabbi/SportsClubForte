using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubModel
{
    public interface IUnitOfWork
    {
        IChallengeRepository ChallengeRepository { get; set; }
        IFieldRepository FieldRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
        IUserRepository UserRepository { get; set; }

        bool AddUser(User user);
    }
}
