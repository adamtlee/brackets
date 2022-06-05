using Brackets.Models.Athletes;

namespace Brackets.Services.AthleteService
{
    public class AthleteService
    {
        public int CalculateTotalMatches(int win, int loss, int draw)
        {
            return win + loss + draw;
        }

        public bool OnWeight(int registeredWeight, double actualWeight)
        {
            if(registeredWeight >= actualWeight)
            {
                return true; 
            }
            return false;
        }

        public Match PairMatch(Athlete athleteOne, Athlete athleteTwo)
        {
            var match = new Match()
            {
                athleteOne = athleteOne,
                athleteTwo = athleteTwo
            };

            return match;
        }
    }
}
