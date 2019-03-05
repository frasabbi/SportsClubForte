using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public void RemoveChallenge(int challengeId)
        {
            //conviene usare il metodo di get?
            var chal = context.Challenges.Where(ch => ch.ChallengeId == challengeId).Single();
            context.Remove(chal);
        }

        public Challenge GetChallengeById(int challengeId)
        {
            return context.Challenges.SingleOrDefault(ch => ch.ChallengeId == challengeId);
        }
    }
}
