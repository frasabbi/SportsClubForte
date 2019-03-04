using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubModel
{
    public interface IUnitOfWork
    {
        //General
        IChallengeRepository ChallengeRepository { get; set; }
        IFieldRepository FieldRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
        IUserRepository UserRepository { get; set; }

        Task<bool> SaveChangesAsync();

        //User
        Task<bool> AddUser(User user);
        Task<bool> RemoveUser(int userId);
        Task<User> GetUserAsync(int userId);

        //Reservation
        Task<bool> AddReservation(Reservation reservation);
        Task<bool> RemoveReservation(int reservationId);

        //Challange
        Task<bool> RemoveChallenge(int challengeId);

        //Field
        Task<bool> AddField(Field field);
        //Task<bool> RemoveField(int fieldId);




    }
}
