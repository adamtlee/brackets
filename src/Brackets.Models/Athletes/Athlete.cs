namespace Brackets.Models.Athletes
{
    public class Athlete
    {
        public string Academy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegisteredWeight { get; set; }
        public double CurrentWeight { get; set; }
        public int Win {  get; set; }
        public int Loss { get; set; }
        public int Draw { get; set; }
        public int TotalMatches { get; set; }
        public bool OnWeight { get; set; }
        public int Matches { get; set; }
        public bool IsChampion { get; set; }
    }
}
