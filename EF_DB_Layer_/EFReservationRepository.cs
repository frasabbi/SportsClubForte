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

        public async Task<IQueryable<Reservation>> GetAllReservationsAsync()
        {
            var listAsync = await context.Reservations.ToListAsync();
            return listAsync.AsQueryable();
        }

        public async Task<IQueryable<Reservation>> GetReservationsByField(int fieldId)
        {
           var listAsync = await context.Reservations.Where(r => r.FieldId == fieldId).ToListAsync();
            return listAsync.AsQueryable();
        }

        public async Task<IQueryable<Reservation>> GetReservationsByUserId(int userId)
        {
            var listAsync = await context.Reservations.Where(r => r.UserId == userId).ToListAsync();
            return listAsync.AsQueryable();
        }

        public async Task<IQueryable<Reservation>> GetReservationsByDate(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;

            var o = await context.Reservations.Where(r => r.Date > start && r.Date < end).ToListAsync();
            return o.AsQueryable();
        }

        public void RemoveReservation(int reservationId)
        {

            var res = context.Reservations.Where(r => r.ReservationId == reservationId).Single();

            if(res.IsChallenge)
            {
                var cha = context.Challenges.Where(c => c.ChallengeId == res.ChallengeId).Single();
                context.Challenges.Remove(cha);
            }
            context.Reservations.Remove(res);
   
        }
    }
}
