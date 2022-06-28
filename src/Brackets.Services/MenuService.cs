namespace Brackets.Services
{
    public class MenuService
    {
        public string prompt()
        {
            Console.WriteLine("What bracket are you creating?");
            Console.WriteLine("Enter [1] for Muay Thai");
            Console.WriteLine("Enter [2] for BJJ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Entering Muay Thai Mode");
                    return "mt";
                case "2":
                    Console.WriteLine("Entering BJJ Mode");
                    return "bjj";
                default:
                    Console.WriteLine("Unrecognized Input");
                    return "na";
            }
        }
    }
}
