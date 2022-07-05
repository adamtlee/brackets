using Brackets.Services;

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
            MenuService menuService = new MenuService();

            var menu = menuService.prompt();

            if (menu.ToLower() == "mt")
            {
                MuayThaiService mtService = new MuayThaiService();
                mtService.execute(inputPath, sortedOutputPath, bracketOutputPath);
            }

            if (menu.ToLower() == "bjj")
            {
                BjjService bjjService = new BjjService();
                bjjService.execute(inputPath, sortedOutputPath, bracketOutputPath);
            }

            if (menu.ToLower() == "na")
            {
                Console.WriteLine("Unrecognized Command");
            }
            
          
            
            Console.ReadKey();
        }
    }
}

