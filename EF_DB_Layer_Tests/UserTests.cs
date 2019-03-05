using System;
using Xunit;
using SportsClubModel;
using Microsoft.EntityFrameworkCore;
using EF_DB_Layer;
using System.Linq;

namespace EF_DB_Layer_Tests
{
    public class UserTests
    {
        [Fact]
        public void Add_User()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Add_User").Options;            using (var context = new ApplicationDbContext(options))            {                context.Users.Add(new User("Federico", "Pessina", DateTime.Now, "Via le dita dal naso"));                context.Users.Add(new User("Valerio", "Passerini", DateTime.Now, "Piazza la bomba e scappa"));                context.Users.Add(new User("Nicoletta", "Magi", DateTime.Now, "Via delle Vie"));                context.SaveChanges();            }            using (var context = new ApplicationDbContext(options))            {                var res = new EFReservationRepository(context);
                var fie = new EFFieldRepository(context);
                var use = new EFUserRepository(context);
                var cha = new EFChallengeRepository(context);

                EFUnitOfWork unitOfWork = new EFUnitOfWork(cha, fie, res, use, context);

                var count = unitOfWork.UserRepository.Users.Count();

                var user = new User("Stefano", "Beltrami", DateTime.Now, "Via Vai");
                var result = unitOfWork.AddUserAsync(user);

                Assert.Equal(count + 1, context.Users.Count());                Assert.Equal(user.LastName, unitOfWork.UserRepository.Users.Last().LastName);                      }
        }
    }
}
