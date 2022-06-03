
using Brackets.Models.Athletes;
using Brackets.Services.AthleteService;
using Brackets.Services.CsvService;
using Brackets.Services.SortService;

namespace Brackets.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brackets Tool.");

            string path = "C:/Brackets/athletes.csv";
            string outputPath = "C:/Brackets/sorted_roster.csv"; 

            List<Athlete> listOfAthletes = new List<Athlete>();
            AthleteServices athleteServices = new AthleteServices(); 

            CsvReader csvReader = new CsvReader();
            var result = csvReader.ReadLines(path);

            foreach(var val in result)
            {
                string[] parts = val.Split(',');

                var athlete = new Athlete
                {
                    Academy = parts[0],
                    FirstName = parts[1],
                    LastName = parts[2],
                    CurrentWeight = double.Parse(parts[3]),
                    // Todo: Convert to decimal or double.
                    Weight = int.Parse(parts[4]),
                    Win = int.Parse(parts[5]),
                    Loss = int.Parse(parts[6]),
                    Draw = int.Parse(parts[7]),
                    
                };
                athlete.TotalMatches = athleteServices.CalculateTotalMatches(athlete.Win, athlete.Loss, athlete.Draw);
                listOfAthletes.Add(athlete);

            }

            CsvWriter csvWriter = new CsvWriter();
            csvWriter.PrintCSVResult(listOfAthletes);

            BasicSort bs = new BasicSort();
            var sortedListByWeight = bs.SortWeight(listOfAthletes);

            csvWriter.GenerateRoster(outputPath, sortedListByWeight);

            var matches = new List<Match>();
            // TODO: Refactor this nasty brute force.
            for(int i = 0; i < listOfAthletes.Count; i++)
            {
                for(int j = i+1; j < listOfAthletes.Count; j++)
                {
                    if(listOfAthletes[i].Weight == listOfAthletes[j].Weight)
                    {
                        var match = athleteServices.PairMatch(listOfAthletes[i], listOfAthletes[j]);
                        matches.Add(match);
                    }
                }
            }

            var bracketOutputPath = "C:/Brackets/bracket.csv";
            csvWriter.GenerateBracket(bracketOutputPath, matches);

            Console.WriteLine();
            Console.WriteLine("Sorted List");
            Console.WriteLine("___________________________________");
            foreach(var m in matches)
            {
                Console.WriteLine($"{m.athleteOne.FirstName} {m.athleteOne.LastName} vs {m.athleteTwo.FirstName} {m.athleteTwo.LastName}");
                Console.WriteLine();
            }
            
            // csvWriter.PrintCSVResult(sortedListByWeight);
            Console.ReadKey();
        }
    }
}

