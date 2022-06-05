using Brackets.Models.Athletes;

namespace Brackets.Services
{
    public class MatchService
    {
        public List<Match> CreateMatches(List<Athlete> listOfAthletes)
        {
            var matches = new List<Match>();
            // TODO: Refactor this nasty brute force.
            for (int i = 0; i < listOfAthletes.Count; i++)
            {
                for (int j = i + 1; j < listOfAthletes.Count; j++)
                {
                    if (listOfAthletes[i].RegisteredWeight == listOfAthletes[j].RegisteredWeight)
                    {
                        var match = PairMatch(listOfAthletes[i], listOfAthletes[j]);
                        matches.Add(match);
                    }
                }
            }
            return matches;
        }

        private Match PairMatch(Athlete athleteOne, Athlete athleteTwo)
        {
            var match = new Match()
            {
                athleteOne = athleteOne,
                athleteTwo = athleteTwo
            };
            athleteOne.Matches += 1;
            athleteTwo.Matches += 1;
            return match;
        }
    }
}
