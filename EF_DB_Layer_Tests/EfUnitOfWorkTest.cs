using Xunit;

namespace EF_DB_Layer_Tests
{
    public class EfUnitOfWorkTest
    {

        //Testare solo l'inserimento, non che valori ha la reservation che inseriamo
        [Fact]
        public void Add_Reservation_Integration_Test()
        {
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(databaseName:"AddReservationTest").Options;

            //using (var context = new ApplicationDbContext(options))
            //{
            //    var field1 = new TennisCourt("Wimbledon", Surfaces.Grass, 25.00m);
            //    var user1 = new User("Nicoletta", "Magi", DateTime.Now, "Via Vai");

            //    context.Fields.Add(field1);
            //    context.Users.Add(user1);

            //    context.Reservations.Add(new Reservation(user1.UserId, field1.FieldId, DateTime.Now, "12:00", "13:00", false, false));
            //    context.Reservations.Add(new Reservation(user1.UserId, field1.FieldId, DateTime.Now, "13:00", "14:00", false, false));
            //    context.Reservations.Add(new Reservation(user1.UserId, field1.FieldId, DateTime.Now, "14:00", "15:00", false, false));

            //    context.SaveChanges();
            //}

            //using (var context = new ApplicationDbContext(options))
            //{
            //    var res = new EFReservationRepository(context);
            //    var fie = new EFFieldRepository(context);
            //    var use = new EFUserRepository(context);
            //    var cha = new EFChallengeRepository(context);

            //    var field2 = new TennisCourt("Wimbledon", Surfaces.Grass, 25.00m);
            //    var user2 = new User("Nicoletta", "Magi", DateTime.Now, "Via Vai");

            //    context.Fields.Add(field2);
            //    context.Users.Add(user2);

            //    context.SaveChanges();

            //    EFUnitOfWork unitOfWork = new EFUnitOfWork(cha, fie, res, use, context);

            //    Reservation testRes = new Reservation(user2.UserId,field2.FieldId,DateTime.Now, "17:00", "18:00",true, false);

            //    unitOfWork.AddReservationAsync(testRes);

            //    Assert.Equal(1, unitOfWork.ReservationRepository.Reservations.Where(r => r.ReservationId == testRes.ReservationId).Count());
            //    Assert.True(testRes.IsDouble);
            //    Assert.NotEmpty(unitOfWork.ReservationRepository.Reservations);

            //    var testResWithCh = new Reservation(user2.UserId, field2.FieldId, DateTime.Now, "19:00", "20:00", false, true);
            //    var resultAdd2 = unitOfWork.AddReservationAsync(testResWithCh);


            //    Assert.NotNull(testResWithCh.Challenge);
            //    Assert.NotEmpty(unitOfWork.ChallengeRepository.Challenges);
            //    Assert.Equal(testResWithCh.Challenge.UserId, unitOfWork.ReservationRepository.Reservations.Where(r => r.UserId == user2.UserId).Single().UserId);
            //    //Assert.NotEqual(0, testResWithCh.ChallengeId);
        }



        //Fare Add Reservation Unit Test, testiamo i controlli e i metodi della AddReservation della Unit of Work
        //Usare mock Objects
        /*[Fact]
        public void Add_Reservation_Unit_Test()
        {*/


        [Fact]
        public void Remove_Reservation()
        {
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(databaseName: "RemoveReservationTest").Options;

            //using (var context = new ApplicationDbContext(options))
            //{
            //    var res = new EFReservationRepository(context);
            //    var fie = new EFFieldRepository(context);
            //    var use = new EFUserRepository(context);
            //    var cha = new EFChallengeRepository(context);
            //    EFUnitOfWork unitOfWork = new EFUnitOfWork(cha, fie, res, use, context);



            //unitOfWork.AddReservation(testRes);

            //unitOfWork.RemoveReservation(testRes.ReservationId);

            //Assert.Empty(unitOfWork.ReservationRepository.Reservations);

            //unitOfWork.AddReservation(testRes);

            //unitOfWork.AddReservation(testRes2);

            //var count = unitOfWork.ReservationRepository.Reservations.Count();

            //unitOfWork.RemoveReservation(testRes.ReservationId);

            //Assert.Equal(count -1, unitOfWork.ReservationRepository.Reservations.Count());
        }
    }
}