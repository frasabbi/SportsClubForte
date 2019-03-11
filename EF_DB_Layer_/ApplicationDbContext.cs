using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace EF_DB_Layer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; } 

        public DbSet<User> Users { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Field>().ToTable("Fields")
                .HasDiscriminator<int>("Sports")
                .HasValue<PaddleCourt>((int)Sports.Paddle)
                .HasValue<TennisCourt>((int)Sports.Tennis)
                .HasValue<SoccerField>((int)Sports.Soccer);

            //modelbuilder.Entity<Challenge>()
            //    .HasOne(c => c.Reservation)
            //    .WithOne(r => r.Challenge)
            //    .HasForeignKey<Challenge>(c => c.ReservationId)
            //    .IsRequired().OnDelete(DeleteBehavior.Restrict);

           


            modelbuilder.Entity<Reservation>()
                .HasOne(r => r.Challenge)
                .WithOne(c => c.Reservation)
                .OnDelete(DeleteBehavior.Restrict);

            
                
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=SportsClub; Trusted_Connection=True; MultipleActiveResultSets=true");
            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
