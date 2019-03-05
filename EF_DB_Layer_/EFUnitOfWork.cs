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
        //I Repository diventano private
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
        public async Task AddUserAsync(User user)
        {
            try
            {
                UserRepository.AddUser(user);
                await context.SaveChangesAsync();
                
            }
            catch(DbUpdateException)
            {
            }
        }

        public async Task RemoveUserAsync(int userId)
        {
            try
            {
                UserRepository.RemoveUser(userId);
                await context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
            }
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            try
            {
                //Usare GetUserById?
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
                        reservation.Price = reservation.Field.Price * ((reservation.TimeEnd.Hour - reservation.TimeStart.Hour) + (reservation.TimeEnd.Minute - reservation.TimeStart.Minute) / 60) * 1.5m;
                        
                    }
                    else
                    {
                        reservation.Price = reservation.Field.Price * ((reservation.TimeEnd.Hour - reservation.TimeStart.Hour)+(reservation.TimeEnd.Minute - reservation.TimeStart.Minute)/60);
                    }
                    user.SpentMoney += reservation.Price;
                }
                if (reservation.IsChallenge)
                {
                    reservation.Challenge = new Challenge(reservation.UserId, reservation.Field.Players);
                    reservation.Challenge.Reservation = reservation;
                    user.ChallengeNumbers++;
                }
                ReservationRepository.AddReservation(reservation);
                await context.SaveChangesAsync();
                user.Reservations++;
            }
            catch(DbUpdateException)
            {
            }
        }

        public async Task RemoveReservationAsync(int reservationId)
        {
            try
            {
                ReservationRepository.RemoveReservation(reservationId);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }
        }

        public async Task AddFieldAsync(Field field)
        {
            try
            {
                FieldRepository.AddField(field);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }
        }

        public async Task RemoveFieldAsync(int fieldId)
        {
            try
            {
                FieldRepository.RemoveField(fieldId);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }
        }

        public async Task AddChallengeAsync(Challenge challenge)
        {
            try
            {
                ChallengeRepository.AddChallenge(challenge);
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
            }
        }

        public async Task RemoveChallengeAsync(int challengeId)
        {
            try
            {
                ChallengeRepository.RemoveChallenge(challengeId);
                //Uso il Metodo Task<bool> SaveChangesAsync creato da noi?
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
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

        public async Task<User[]> GetAllUsersAsync()
        {
            return await UserRepository.GetAllUsers().ToArrayAsync();
        }
    }
}
