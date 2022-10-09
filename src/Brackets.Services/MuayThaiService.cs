using Brackets.Services.CsvService;

namespace Brackets.Services
{
    public class MuayThaiService : IMuayThaiService
    {
        private readonly AthleteService _athleteService;
        private readonly CsvReader _csvReader;
        private readonly CsvWriter _csvWriter;

        public MuayThaiService(AthleteService athleteService, CsvReader csvReader, CsvWriter csvWriter)
        {
            _athleteService = athleteService;
            _csvReader = csvReader;
            _csvWriter = csvWriter;
        }
        public void generateReportMT(string inputPath, string sortedOutputPath, string bracketOutputPath)
        {
            try
            {
                Console.WriteLine($"Reading data from file: {inputPath}");
                var rows = _csvReader.ReadLines(inputPath);

                Console.WriteLine("Mapping data into objects...");
                var listOfAthletes = _athleteService.AthleteMapper(rows);

                Console.WriteLine("Sorting athletes by weight...");
                var sortedListByWeight = _athleteService.SortWeight(listOfAthletes);

                MatchService matchService = new MatchService();
                Console.WriteLine("Creating matches...");
                var matches = matchService.CreateMatches(listOfAthletes);

                Console.WriteLine("Filtering single competitors...");
                _athleteService.isSingleCompetitor(sortedListByWeight);

                Console.WriteLine($"Generating sorted list of athletes by weight to file: {sortedOutputPath}");
                _csvWriter.GenerateRoster(sortedOutputPath, sortedListByWeight);

                Console.WriteLine($"Generating matches to file: {bracketOutputPath}");
                _csvWriter.GenerateBracket(bracketOutputPath, matches);
                Console.WriteLine("Bracket Generation Complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
