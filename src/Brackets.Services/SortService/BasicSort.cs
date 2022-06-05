using Brackets.Models.Athletes;

namespace Brackets.Services.SortService
{
    public class BasicSort
    { 
        public List<Athlete> SortWeight(List<Athlete> athletes)
        {
            athletes.Sort(delegate (Athlete x, Athlete y)
            {
                return x.RegisteredWeight.CompareTo(y.RegisteredWeight);
            });
            
            return athletes;
        }
    }
}
