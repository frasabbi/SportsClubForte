using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using SportsClubWeb;
using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace EF_DB_Layer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Challenge> Challenges { get; set; }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args) =>
            Program.BuildWebHost(args).Services.GetRequiredService<ApplicationDbContext>();
    }
}
