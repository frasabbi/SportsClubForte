﻿// <auto-generated />
using System;
using EF_DB_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_DB_Layer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190311122113_mig3")]
    partial class mig3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsClubModel.Challenge", b =>
                {
                    b.Property<int>("ChallengeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayersToInsert");

                    b.Property<int>("ReservationId");

                    b.Property<int>("UserId");

                    b.HasKey("ChallengeId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("SportsClubModel.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Players");

                    b.Property<decimal>("Price");

                    b.Property<int>("Sports");

                    b.Property<int>("Surface");

                    b.HasKey("FieldId");

                    b.ToTable("Fields");

                    b.HasDiscriminator<int>("Sports");
                });

            modelBuilder.Entity("SportsClubModel.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("FieldId");

                    b.Property<bool>("IsChallenge");

                    b.Property<bool>("IsDouble");

                    b.Property<decimal>("Price");

                    b.Property<string>("Sport");

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.Property<int>("UserId");

                    b.HasKey("ReservationId");

                    b.HasIndex("FieldId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("SportsClubModel.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("ChallengeId");

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("Reservations");

                    b.Property<decimal>("SpentMoney");

                    b.Property<int>("Wins");

                    b.HasKey("UserId");

                    b.HasIndex("ChallengeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SportsClubModel.PaddleCourt", b =>
                {
                    b.HasBaseType("SportsClubModel.Field");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("SportsClubModel.SoccerField", b =>
                {
                    b.HasBaseType("SportsClubModel.Field");

                    b.Property<bool>("IsSeven");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("SportsClubModel.TennisCourt", b =>
                {
                    b.HasBaseType("SportsClubModel.Field");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("SportsClubModel.Challenge", b =>
                {
                    b.HasOne("SportsClubModel.Reservation", "Reservation")
                        .WithOne("Challenge")
                        .HasForeignKey("SportsClubModel.Challenge", "ReservationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SportsClubModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsClubModel.Reservation", b =>
                {
                    b.HasOne("SportsClubModel.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsClubModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsClubModel.User", b =>
                {
                    b.HasOne("SportsClubModel.Challenge")
                        .WithMany("Brawlers")
                        .HasForeignKey("ChallengeId");
                });
#pragma warning restore 612, 618
        }
    }
}
