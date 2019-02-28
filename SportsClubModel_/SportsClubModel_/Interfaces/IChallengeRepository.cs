using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsClubModel
{
    public interface IChallengeRepository
    {
        IQueryable<Challenge> Challenges { get; }
        void AddChallenge(Challenge challenge);
        void RemoveChallenge(int challengeId);
    }
}
