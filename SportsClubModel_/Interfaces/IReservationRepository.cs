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
        IQueryable<Reservation> GetAllReservationsAsync();
        IQueryable<Reservation> GetReservationsByField(int fieldId);
        IQueryable<Reservation> GetReservationsByUserId(int userId);
        IQueryable<Reservation> GetReservationsByDate(DateTime start, DateTime end);
        Reservation GetReservationByReservationId(int reservationId);

    }
}
