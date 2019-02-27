using Microsoft.EntityFrameworkCore;
using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public async Task<Reservation[]> GetAllReservationsAsync()
        {
            return await context.Reservations.ToArrayAsync();
        }

        public async Task<Reservation[]> GetReservationsByField(int fieldId)
        {
            return await context.Reservations.Where(r => r.FieldId == fieldId).ToArrayAsync();
        }

        public async Task<Reservation[]> GetReservationsByUserId(int userId)
        {
            return await context.Reservations.Where(r => r.UserId == userId).ToArrayAsync();
        }

        public async Task<Reservation[]> GetReservationsByDate(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;

            return await context.Reservations.Where(r => r.Date > start && r.Date < end).ToArrayAsync();

        }
    }
}
