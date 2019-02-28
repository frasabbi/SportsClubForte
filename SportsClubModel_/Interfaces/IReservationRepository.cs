using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubModel
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> Reservations { get; }
        void AddReservation(Reservation reservation);
        void RemoveReservation(int reservationId);
        Task<IQueryable<Reservation>> GetAllReservationsAsync();
        Task<IQueryable<Reservation>> GetReservationsByField(int fieldId);
        Task<IQueryable<Reservation>> GetReservationsByUserId(int userId);
        Task<IQueryable<Reservation>> GetReservationsByDate(DateTime start, DateTime end);
    }
}
