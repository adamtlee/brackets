using Brackets.Services.AthleteService;
using NUnit.Framework;
using System;

namespace Brackets.Tests.AthleteServicesTest
{
    public class AthleteServicesTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateTotalMatches_Should_Pass()
        {
            // Arrange
            AthleteServices athleteServices = new AthleteServices(); 

            Random randomIntGenerator = new Random();
            var wins = randomIntGenerator.Next();
            var losses = randomIntGenerator.Next();
            var draws = randomIntGenerator.Next();
            var total = wins + losses + draws;

            // Act
            var result = athleteServices.CalculateTotalMatches(wins, losses, draws);

            // Assert
            Assert.AreEqual(total, result);
            
        }

        [Test]
        public void CalculateTotalMatches_Should_Fail()
        {
            // Arrange
            AthleteServices athleteServices = new AthleteServices();
          
            var wins = 5;
            var losses = 5;
            var draws = 5;
            var total = wins + losses + draws + 1;

            // Act
            var result = athleteServices.CalculateTotalMatches(wins, losses, draws);

            // Assert
            Assert.AreNotEqual(total, result);
        }
    }
}
