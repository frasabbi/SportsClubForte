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

        Task AddUserAsync(User user);
        Task AddReservationAsync(Reservation reservation);
        Task AddFieldAsync(Field field);
        Task AddChallengeAsync(Challenge challenge);
        Task RemoveUserAsync(int userId);
        Task RemoveReservationAsync(int reservationId);
        Task RemoveFieldAsync(int fieldId);
        Task RemoveChallengeAsync(int challengeId);
        Task<bool> SaveChangesAsync();
        Task<User[]> GetAllUsersAsync();
    }
}
