using System;
using Xunit;
using SportsClubModel;
using Microsoft.EntityFrameworkCore;
using EF_DB_Layer;
using System.Linq;

namespace EF_DB_Layer_Tests
{
    public class ReservationTests
    {
        [Fact]
        public void Add_Reservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName:"AddReservationTest").Options;

            using (var context = new ApplicationDbContext(options))
            {
                var res = new EFReservationRepository(context);
                var fie = new EFFieldRepository(context);
                var use = new EFUserRepository(context);
                var cha = new EFChallengeRepository(context);
                EFUnitOfWork unitOfWork = new EFUnitOfWork(cha, fie, res, use, context);
                var testRes = new Reservation(1, 1, DateTime.Now.Date,"15:00","16:00", Reservation.ReservationsType.Double, false);

                unitOfWork.AddReservation(testRes);
                Assert.Equal(testRes.ReservationId, unitOfWork.ReservationRepository.Reservations.Last().ReservationId);
                Assert.NotEqual(Reservation.ReservationsType.Single, testRes.ReservationType);
                Assert.Equal(testRes.Sport, unitOfWork.ReservationRepository.Reservations.Last().Sport);
                Assert.NotEmpty(unitOfWork.ReservationRepository.Reservations);

                var testResWithCh = new Reservation(1, 1, DateTime.Now.Date, "15:00", "16:00", Reservation.ReservationsType.Double, true);

                Assert.Equal(testResWithCh.Challenge.UserId, unitOfWork.ReservationRepository.Reservations.Where(r => r.UserId == 1).Single().UserId);

            }
        }

        [Fact]
        public void Remove_Reservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RemoveReservationTest").Options;

            using (var context = new ApplicationDbContext(options))
            {
                var res = new EFReservationRepository(context);
                var fie = new EFFieldRepository(context);
                var use = new EFUserRepository(context);
                var cha = new EFChallengeRepository(context);
                EFUnitOfWork unitOfWork = new EFUnitOfWork(cha, fie, res, use, context);
                var testRes = new Reservation(1, 1, DateTime.Now.Date, "15:00", "16:00", Reservation.ReservationsType.Double, false);
                var testRes2 = new Reservation(1, 1, DateTime.Now.Date, "17:00", "18:00", Reservation.ReservationsType.Double, false);


                unitOfWork.AddReservation(testRes);
                
                unitOfWork.RemoveReservation(testRes.ReservationId);

                Assert.Empty(unitOfWork.ReservationRepository.Reservations);

                unitOfWork.AddReservation(testRes);
               
                unitOfWork.AddReservation(testRes2);

                unitOfWork.RemoveReservation(testRes.ReservationId);

                Assert.NotEqual(testRes.ReservationId, unitOfWork.ReservationRepository.Reservations.Last().ReservationId);
            }
        }
    }
}
