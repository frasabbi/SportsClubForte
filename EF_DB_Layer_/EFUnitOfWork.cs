using Microsoft.EntityFrameworkCore;
using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DB_Layer
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public IChallengeRepository ChallengeRepository { get; set; }
        public IFieldRepository FieldRepository { get; set; }
        public IReservationRepository ReservationRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        private DbContext context;

        public EFUnitOfWork(IChallengeRepository challenge, IFieldRepository field, IReservationRepository reservation, IUserRepository user, DbContext ctx)
        {
            ChallengeRepository = challenge;
            FieldRepository = field;
            ReservationRepository = reservation;
            UserRepository = user;
            context = ctx;
        }

        public bool AddUser(User user)
        {
            try
            {
                UserRepository.AddUser(user);
                context.SaveChanges();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public bool AddReservation(Reservation reservation)
        {
            try
            {
                ReservationRepository.AddReservation(reservation);
                context.SaveChanges();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public bool AddField(Field field)
        {
            try
            {
                FieldRepository.AddField(field);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
