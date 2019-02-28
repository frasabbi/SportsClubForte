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

        public async Task<bool> AddUser(User user)
        {
            try
            {
                UserRepository.AddUser(user);
                await context.SaveChangesAsync();
                return true;
                
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> RemoveUser(int userId)
        {
            try
            {
                UserRepository.RemoveUser(userId);
                await context.SaveChangesAsync();
                return true;

            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> AddReservation(Reservation reservation)
        {
            try
            {
                ReservationRepository.AddReservation(reservation);
                await context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> RemoveReservation(int reservationId)
        {
            try
            {
                ReservationRepository.RemoveReservation(reservationId);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> AddField(Field field)
        {
            try
            {
                FieldRepository.AddField(field);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        //public async Task<bool> RemoveField(int fieldId)
        //{
        //    try
        //    {
        //        FieldRepository.RemoveField(fieldId);
        //        await context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> RemoveChallenge(int challengeId)
        {
            try
            {
                ChallengeRepository.RemoveChallenge(challengeId);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
