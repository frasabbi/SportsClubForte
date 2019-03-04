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

        //I metodi non restituiscono bool

        //General
        public async Task<bool> SaveChangesAsync()
        {

            // Only return success if at least one row was changed
            return (await context.SaveChangesAsync()) > 0;
        }

        public string ToSport(string courtName)
        {
            string sport = null;

            if (courtName.Contains("Court"))
            {
                sport = courtName.Replace("Court", "");
            }
            else if (courtName.Contains("Field"))
            {
                sport = courtName.Replace("Field", "");
            }
            return sport;
        }

        //User
        public async Task<bool> AddUser(User user)
        {
            try
            {
                UserRepository.AddUser(user);
                await SaveChangesAsync();
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
                await SaveChangesAsync();
                return true;

            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<User> GetUserAsync(int userId)
        {
            try
            {
                var user = await UserRepository.GetUserById(userId);
                return user;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        //Reservation
        public async Task<bool> AddReservation(Reservation reservation)
        {
            try
            {
                var user = UserRepository.Users.SingleOrDefault(u => u.UserId == reservation.UserId);
                //Creare Eccezione custom
                reservation.User = user ?? throw new Exception();
                var field = FieldRepository.Fields.SingleOrDefault(f => f.FieldId == reservation.FieldId);
                reservation.Field = field ?? throw new Exception();
                reservation.Sport = ToSport(reservation.Field.GetType().Name);

                if (reservation.Price == 0)
                {

                    if (reservation.IsDoubleReservation())
                    {
                        reservation.Field.Players = 4;
                        reservation.Price = reservation.Field.Price * 1.5m;
                    }
                    else
                    {
                        reservation.Price = reservation.Field.Price;
                    }
                }
                if (reservation.IsChallenge)
                {
                    reservation.Challenge = new Challenge(reservation.UserId, reservation.Field.Players);
                    reservation.Challenge.Reservation = reservation;
                }
                ReservationRepository.AddReservation(reservation);
                await SaveChangesAsync();
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
                await SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        //Field
        public async Task<bool> AddField(Field field)
        {
            try
            {
                FieldRepository.AddField(field);
                await SaveChangesAsync();
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

    

        //Challenge
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
