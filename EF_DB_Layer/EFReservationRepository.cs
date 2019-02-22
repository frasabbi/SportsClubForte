using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_DB_Layer
{
    public class EFReservationRepository : IReservationRepository
    {
        private ApplicationDbContext context;

        public EFReservationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Reservation> Reservations => context.Reservations;

        public void AddReservation(Reservation reservation)
        {
            context.Add(reservation);
            context.SaveChanges();
        }
    }
}
