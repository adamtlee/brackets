﻿
using Brackets.Models.Athletes;
using Brackets.Services.Csv;

namespace Brackets.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brackets Tool.");

            string path = "C:/Brackets/athletes.csv";

           List<Athlete > listOfAthletes = new List<Athlete>(); 

            CsvReader csvReader = new CsvReader();
            var result = csvReader.ReadLines(path);

            foreach(var val in result)
            {
                string[] parts = val.Split(',');

                var a = new Athlete
                {
                    Academy = parts[0],
                    FirstName = parts[1],
                    LastName = parts[2],
                    Weight = parts[3]
                };

                listOfAthletes.Add(a);

            }
            

            foreach (var ath in listOfAthletes)
            {
                Console.WriteLine();
                Console.WriteLine("Printing athlete: ");
                Console.WriteLine(ath.Academy);
                Console.WriteLine(ath.FirstName);
                Console.WriteLine(ath.LastName);
                Console.WriteLine(ath.Weight);
            }

            Console.ReadKey();
        }
    }
}

