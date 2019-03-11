using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsClubModel
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime DateOfRegistration { get; set; }
        [Required]
        public string Address { get; set; }
        public int Reservations { get; set; }
        public decimal SpentMoney { get; set; }
        public int Challenge { get; set; }
        public int Wins { get; set; }

        public User() { }

        public User(string firstName, string lastName, DateTime birthdate, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthdate.Date;
            DateOfRegistration = DateTime.Now.Date;
            Address = address;
            Reservations = 0;
            SpentMoney = 0;
            Challenge = 0;
            Wins = 0;
        }
     }

}
