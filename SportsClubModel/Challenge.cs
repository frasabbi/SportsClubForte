using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsClubModel
{
    public class Challenge
    {
        [Key]
        public int ChallengeId { get; set; }
        public Reservation Reservation { get; set; }
        public IEnumerable<User> Team1 { get; set; }
        public IEnumerable<User> Team2 { get; set; }
    }
}
