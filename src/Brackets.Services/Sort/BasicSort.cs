using Brackets.Models.Athletes;
namespace Brackets.Services.Sort
{
    public class BasicSort
    {
        public List<Athlete> SortWeight(List<Athlete> athletes)
        {
            athletes.Sort(delegate (Athlete x, Athlete y)
            {
                return x.Weight.CompareTo(y.Weight);
            });
            
            return athletes;
        }
    }
}
