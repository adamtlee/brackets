using Brackets.Models.Athletes;

namespace Brackets.Services.AthleteService
{
    public class AthleteServices
    {
        public int CalculateTotalMatches(int win, int loss, int draw)
        {
            return win + loss + draw;
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
