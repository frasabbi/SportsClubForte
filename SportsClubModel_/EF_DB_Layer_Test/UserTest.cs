using EF_DB_Layer;
using Microsoft.EntityFrameworkCore;
using SportsClubModel;
using System;
using System.Linq;
using Xunit;

namespace EF_DB_Layer_Test
{
    public class UserTest
    {
        [Fact]
        public void Add_User_Test()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Add_User_Test").Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Users.Add(new User() { UserId = 1, FirstName = "Federico", LastName = "Pessina", BirthDate = DateTime.Now, Address = "Porto Antico" });
                context.Users.Add(new User() { UserId = 2, FirstName = "Valerio", LastName = "Passerini", BirthDate = DateTime.Now, Address = "Quarto" });
                context.Users.Add(new User() { UserId = 3, FirstName = "Nicoletta", LastName = "Magi", BirthDate = DateTime.Now, Address = "Savona" });

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                EFUserRepository repository = new EFUserRepository(context);

                var user = repository.Users.Where(r => r.LastName == "Magi").First();

                
                //var pippo = singleMatches.Where(r => r.CourtId == 2);

                //Console.WriteLine(singleMatches.Count());

                Assert.Equal("Magi", user.LastName);
                Assert.NotEqual("Maggi", user.LastName);
            }
        }

        [Fact]
        public void Remove_User_Test()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Remove_User_Test").Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Users.Add(new User() { UserId = 4, FirstName = "Federico", LastName = "Pessina", BirthDate = DateTime.Now, Address = "Porto Antico" });
                context.Users.Add(new User() { UserId = 5, FirstName = "Valerio", LastName = "Passerini", BirthDate = DateTime.Now, Address = "Quarto" });
                context.Users.Add(new User() { UserId = 6, FirstName = "Nicoletta", LastName = "Magi", BirthDate = DateTime.Now, Address = "Savona" });

                context.SaveChanges();
            }
            using (var context = new ApplicationDbContext(options))
            {
                EFUserRepository repository = new EFUserRepository(context);

                var user = repository.Users.Where(r => r.UserId == 4).First();
                int count = context.Users.Count();
                Console.WriteLine(count);
                context.Remove(user);
                context.SaveChanges();
                //var pippo = singleMatches.Where(r => r.CourtId == 2);
                //Console.WriteLine(singleMatches.Count());

                Assert.Equal(count - 1, context.Users.Count());
            }
        }
    }
}
