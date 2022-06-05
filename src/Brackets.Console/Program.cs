using Brackets.Services.AthleteService;
using Brackets.Services.CsvService;
using Brackets.Services.MatchService;
using Brackets.Services.SortService;

namespace Brackets.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Brackets Tool.");

            string inputPath = "C:/Brackets/athletes.csv";
            string sortedOutputPath = "C:/Brackets/sorted_roster.csv";
            var bracketOutputPath = "C:/Brackets/bracket.csv";

            AthleteService athleteService = new AthleteService(); 
            CsvReader csvReader = new CsvReader();

            Console.WriteLine($"Reading data from file: {inputPath}");
            var rows = csvReader.ReadLines(inputPath);

            Console.WriteLine("Mapping data into objects..."); 
            var listOfAthletes = athleteService.AthleteMapper(rows);

            CsvWriter csvWriter = new CsvWriter();

            Console.WriteLine("Sorting athletes by weight...");
            BasicSort bs = new BasicSort();
            var sortedListByWeight = bs.SortWeight(listOfAthletes);

            Console.WriteLine($"Generating sorted list of athletes by weight to file: {sortedOutputPath}");
            csvWriter.GenerateRoster(sortedOutputPath, sortedListByWeight);

            MatchService matchService = new MatchService();
            Console.WriteLine("Creating matches...");
            var matches = matchService.CreateMatches(listOfAthletes);

            Console.WriteLine($"Generating matches to file: {bracketOutputPath}");
            csvWriter.GenerateBracket(bracketOutputPath, matches);
            
            Console.ReadKey();
        }
    }
}

