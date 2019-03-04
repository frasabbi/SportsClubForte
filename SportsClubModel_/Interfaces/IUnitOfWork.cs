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

        Task<bool> AddUser(User user);
        Task<bool> AddReservation(Reservation reservation);
        Task<bool> AddField(Field field);
        Task<bool> RemoveUser(int userId);
        Task<bool> RemoveReservation(int reservationId);
        Task<bool> RemoveChallenge(int challengeId);
        Task<bool> SaveChangesAsync();
        Task<bool> RemoveField(int fieldId);
    }
}
