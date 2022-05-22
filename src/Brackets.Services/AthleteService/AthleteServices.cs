namespace Brackets.Services.AthleteService
{
    public class AthleteServices
    {
        public int CalculateTotalMatches(int win, int loss, int draw)
        {
            return win + loss + draw;
        }
    }
}
