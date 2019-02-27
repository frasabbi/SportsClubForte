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
        Task<Reservation[]> GetAllReservationsAsync();
        Task<Reservation[]> GetReservationsByField(int fieldId);
        Task<Reservation[]> GetReservationsByUserId(int userId);
        Task<Reservation[]> GetReservationsByDate(DateTime start, DateTime end);
    }
}
