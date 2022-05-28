using Brackets.Models.Athletes;
using System.Text;

namespace Brackets.Services.CsvService
{
    public class CsvWriter
    {
        public void GenerateBracket(string path, List<Athlete> listOfAthletes)
        {
            StringBuilder sb = new StringBuilder();
            string[] headers = {"Academy", "First Name", "Last Name", "Weight", "Win", "Loss", "Draw", "Total Matches"};
            
            
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
                        listOfAthletes[i].Weight,
                        listOfAthletes[i].Win,
                        listOfAthletes[i].Loss,
                        listOfAthletes[i].Draw,
                        listOfAthletes[i].TotalMatches
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
                Console.WriteLine(athlete.Weight);
                Console.WriteLine(athlete.Win);
                Console.WriteLine(athlete.Loss);
                Console.WriteLine(athlete.Draw);
                Console.WriteLine(athlete.TotalMatches);
            }

        }
    }
}
