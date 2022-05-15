
using Brackets.Services.Csv;

namespace Brackets.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brackets Tool.");
            CsvReader csvReader = new CsvReader();
            csvReader.ReadFile();
      
            string path = "C:/Brackets/athletes.csv";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                foreach (string part in parts)
                {
                    Console.WriteLine(part);
                }
            }

            Console.ReadKey();
        }
    }
}

