using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsClubModel
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> Reservations { get; }
        void AddReservation(Reservation reservation);
    }
}
