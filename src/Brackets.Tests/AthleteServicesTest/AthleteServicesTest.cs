using Brackets.Services;
using NUnit.Framework;
using System;

namespace Brackets.Tests.AthleteServicesTest
{
    public class AthleteServicesTest
    {
        // TODO: Rewrite these test cases.
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateTotalMatches_Should_Pass()
        {
            // Arrange
            AthleteService athleteServices = new AthleteService(); 

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
            AthleteService athleteServices = new AthleteService();
          
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
