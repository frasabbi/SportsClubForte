using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsClubModel;

namespace EF_DB_Layer
{
    public class EFChallengeRepository : IChallengeRepository
    {
        private ApplicationDbContext context;

        public EFChallengeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Challenge> Challenges => context.Challenges;

        public void AddChallenge(Challenge challenge)
        {
            context.Add(challenge);
            context.SaveChanges();
        }
    }
}
