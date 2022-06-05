
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

            AthleteService athleteService = new AthleteService(); 

            CsvReader csvReader = new CsvReader();
            var rows = csvReader.ReadLines(path);

            var listOfAthletes = athleteService.AthleteMapper(rows);

            

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
                    if(listOfAthletes[i].RegisteredWeight == listOfAthletes[j].RegisteredWeight)
                    {
                        var match = athleteService.PairMatch(listOfAthletes[i], listOfAthletes[j]);
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

