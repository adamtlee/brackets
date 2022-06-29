using Brackets.Services.CsvService;

namespace Brackets.Services
{
    public class MuayThaiService
    {
        public void execute(string inputPath, string sortedOutputPath, string bracketOutputPath)
        {
            try
            {
                AthleteService athleteService = new AthleteService();
                CsvReader csvReader = new CsvReader();

                Console.WriteLine($"Reading data from file: {inputPath}");
                var rows = csvReader.ReadLines(inputPath);

                Console.WriteLine("Mapping data into objects...");
                var listOfAthletes = athleteService.AthleteMapper(rows);

                CsvWriter csvWriter = new CsvWriter();

                Console.WriteLine("Sorting athletes by weight...");
                var sortedListByWeight = athleteService.SortWeight(listOfAthletes);

                MatchService matchService = new MatchService();
                Console.WriteLine("Creating matches...");
                var matches = matchService.CreateMatches(listOfAthletes);

                Console.WriteLine("Filtering single competitors...");
                athleteService.isSingleCompetitor(sortedListByWeight);

                Console.WriteLine($"Generating sorted list of athletes by weight to file: {sortedOutputPath}");
                csvWriter.GenerateRoster(sortedOutputPath, sortedListByWeight);

                Console.WriteLine($"Generating matches to file: {bracketOutputPath}");
                csvWriter.GenerateBracket(bracketOutputPath, matches);
                Console.WriteLine("Bracket Generation Complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
