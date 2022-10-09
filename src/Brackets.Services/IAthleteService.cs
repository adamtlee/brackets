using Brackets.Models.Athletes;

namespace Brackets.Services
{
    public interface IAthleteService
    {
        bool IsSameAcademy(Athlete athleteOne, Athlete athleteTwo);
        void isSingleCompetitor(List<Athlete> listOfAthletes);
        List<Athlete> AthleteMapper(string[] rows);
        List<Athlete> SortWeight(List<Athlete> athletes);
    }
}