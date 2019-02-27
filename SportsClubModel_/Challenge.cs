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
        public int UserId { get; set; }
        public User User { get; set; }
        public List<User> Team1 { get; set; }
        public List<User> Team2 { get; set; }
        public int PlayersToInsert { get; set; }

        public Challenge() { }

        public Challenge(int userId, int playersToInsert)
        {
            UserId = userId;
            PlayersToInsert = playersToInsert;
        }

    }
}
