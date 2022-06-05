using Brackets.Models.Athletes;
using System.Text;

namespace Brackets.Services.CsvService
{
    public class CsvWriter
    {
        public void GenerateRoster(string path, List<Athlete> listOfAthletes)
        {
            StringBuilder sb = new StringBuilder();
            string[] headers = {"Academy", "First Name", "Last Name","Current Weight", "Weight", "Win", "Loss", "Draw", "Total Matches", "On Weight", "isChampion"};
            
            
            sb.AppendLine(string.Join("," , headers));
            File.WriteAllText(path, sb.ToString());

            for (int i = 0; i < listOfAthletes.Count; i++)
            {
                sb.AppendLine(
                    string.Join(
                        ",", 
                        listOfAthletes[i].Academy, 
                        listOfAthletes[i].FirstName,
                        listOfAthletes[i].LastName,
                        listOfAthletes[i].CurrentWeight,
                        listOfAthletes[i].RegisteredWeight,
                        listOfAthletes[i].Win,
                        listOfAthletes[i].Loss,
                        listOfAthletes[i].Draw,
                        listOfAthletes[i].TotalMatches,
                        listOfAthletes[i].OnWeight,
                        listOfAthletes[i].IsChampion
                        )
                    );
            }
            File.WriteAllText(path, sb.ToString());
        }

        public void GenerateBracket(string path, List<Match> matches)
        {
            StringBuilder sb = new StringBuilder();
            string[] headers = { "Athlete - Red", "vs", "Athlete - Blue" };
            sb.AppendLine(string.Join(",", headers));
            File.WriteAllText(path, sb.ToString());
            for (int i = 0; i < matches.Count; i++)
            {
                sb.AppendLine(
                    string.Join(
                        ",",
                        matches[i].athleteOne.FirstName + " " + matches[i].athleteOne.LastName,
                        "vs",
                        matches[i].athleteTwo.FirstName + " " + matches[i].athleteTwo.LastName
                        )
                );
            }
            File.WriteAllText(path, sb.ToString());
        }
        public void PrintCSVResult(List<Athlete> athletes)
        {
            foreach (var athlete in athletes)
            {
                Console.WriteLine();
                Console.WriteLine("Printing athlete: ");
                Console.WriteLine(athlete.Academy);
                Console.WriteLine(athlete.FirstName);
                Console.WriteLine(athlete.LastName);
                Console.WriteLine(athlete.CurrentWeight);
                Console.WriteLine(athlete.RegisteredWeight);
                Console.WriteLine(athlete.Win);
                Console.WriteLine(athlete.Loss);
                Console.WriteLine(athlete.Draw);
                Console.WriteLine(athlete.TotalMatches);
            }

        }
    }
}
