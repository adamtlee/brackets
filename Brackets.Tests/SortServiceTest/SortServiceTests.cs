using Brackets.Models.Athletes;
using Brackets.Services.AthleteService;
using Brackets.Services.Sort;
using NUnit.Framework;
using System.Collections.Generic;

namespace Brackets.Tests.SortServiceTest
{
    public class SortServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SortAthletesByWeightClass_Should_Pass()
        {
            // Arrange

            BasicSort basicSort = new BasicSort();
            AthleteServices athleteService = new AthleteServices();
            List<Athlete> listofAthletes = new List<Athlete>()
            {
                new Athlete()
                {
                    Academy = "Ip Man",
                    FirstName = "Bruce",
                    LastName = "Lee",
                    Win = 100,
                    Loss = 0,
                    Draw = 0,
                    Weight = 125
                },
                new Athlete()
                {
                    Academy = "McDojo",
                    FirstName = "Krabby",
                    LastName = "Patty",
                    Win = 22,
                    Loss = 3,
                    Draw = 1,
                    Weight = 285
                },
                new Athlete()
                {
                    Academy = "Easton",
                    FirstName = "Adam",
                    LastName = "Lee",
                    Win = 245,
                    Loss = 1,
                    Draw = 3,
                    Weight = 145
                }
            };

            // Act
            var result = basicSort.SortWeight(listofAthletes); 

            // Assert

        }
    }
}
