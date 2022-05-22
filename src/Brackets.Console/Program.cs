
using Brackets.Models.Athletes;
using Brackets.Services.Csv;
using Brackets.Services.Sort;

namespace Brackets.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brackets Tool.");

            string path = "C:/Brackets/athletes.csv";

           List<Athlete> listOfAthletes = new List<Athlete>(); 

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
                    // Todo: Convert to decimal or double.
                    Weight = int.Parse(parts[3]),
                    Win = int.Parse(parts[4]),
                    Loss = int.Parse(parts[5]),
                    Draw = int.Parse(parts[6]),
                };

                listOfAthletes.Add(athlete);

            }

            foreach (var athlete in listOfAthletes)
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
            }

            BasicSort bs = new BasicSort();
            var sortedListByWeight = bs.SortWeight(listOfAthletes);

            Console.WriteLine();
            Console.WriteLine("Sorted List");
            Console.WriteLine("___________________________________");
            foreach (var athlete in sortedListByWeight)
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
            }

            Console.ReadKey();
        }
    }
}

