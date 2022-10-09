using Brackets.Models.Athletes;

namespace Brackets.Services
{
    public class AthleteService : IAthleteService
    {
        public List<Athlete> SortWeight(List<Athlete> athletes)
        {
            athletes.Sort(delegate (Athlete x, Athlete y)
            {
                return x.RegisteredWeight.CompareTo(y.RegisteredWeight);
            });

            return athletes;
        }
        public List<Athlete> AthleteMapper(string[] rows)
        {
            List<Athlete> listOfAthletes = new List<Athlete>();
            foreach (var val in rows)
            {
                string[] parts = val.Split(',');

                var athlete = new Athlete
                {
                    Academy = parts[0],
                    FirstName = parts[1],
                    LastName = parts[2],
                    CurrentWeight = double.Parse(parts[3]),
                    RegisteredWeight = double.Parse(parts[4]),
                    Win = int.Parse(parts[5]),
                    Loss = int.Parse(parts[6]),
                    Draw = int.Parse(parts[7]),

                };
                athlete.TotalMatches = CalculateTotalMatches(athlete.Win, athlete.Loss, athlete.Draw);
                athlete.OnWeight = OnWeight(athlete.RegisteredWeight, athlete.CurrentWeight);
                listOfAthletes.Add(athlete);
            }

            return listOfAthletes;
        }
        private int CalculateTotalMatches(int win, int loss, int draw)
        {
            return win + loss + draw;
        }

        private bool OnWeight(double registeredWeight, double actualWeight)
        {
            if (registeredWeight >= actualWeight)
            {
                return true;
            }
            return false;
        }

        public bool IsSameAcademy(Athlete athleteOne, Athlete athleteTwo)
        {
            if (athleteOne.Academy.ToLower() == athleteTwo.Academy.ToLower())
            {
                return true;
            }
            return false;
        }

        public void isSingleCompetitor(List<Athlete> listOfAthletes)
        {
            foreach (var athlete in listOfAthletes)
            {
                if (athlete.Matches == 0)
                {
                    athlete.IsChampion = true;
                }
            }
        }
    }
}
