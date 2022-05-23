using Brackets.Models.Athletes;

namespace Brackets.Services.CsvService
{
    public class CsvWriter
    {
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
