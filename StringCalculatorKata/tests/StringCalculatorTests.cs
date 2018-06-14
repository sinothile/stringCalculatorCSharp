using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Add_GivenAnEmptyNullAndWhiteSpaceNumber_ShouldReturn0(string numbers)
        {
            //Arrange
            var createStringCalculator = new StringCalculator();

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            int expected = 0;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        public void Add_GivenANumber_ShouldReturnANumber(string numbers, int expected)
        {
            //Arrange
            var createStringCalculator = new StringCalculator();

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase("4,3", 7)]
        [TestCase("5,5", 10)]
        [TestCase("2,13", 15)]
        public void Add_GivenTwoNumbers_ShouldReturnTheSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var createStringCalculator = new StringCalculator();

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase("4,3,4", 11)]
        [TestCase("5,5,5", 15)]
        [TestCase("2,13,1", 16)]
        public void Add_GivenThreeNumbers_ShouldReturnTheSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var createStringCalculator = new StringCalculator();

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNumbersWithNewLinesInBetween_ShouldReturnTheSumOfNumbers()
        {
            //Arrange
            var createStringCalculator = new StringCalculator();
            var numbers = "1\n2,3";

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            var expected = 6;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;5", 8)]
        [TestCase("//;\n1\n0;2;5", 8)]
        public void Add_GivenNumbersWithNewLineInBetweenandSingleDelimeter_ShouldReturnTheSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var createStringCalculator = new StringCalculator();
 
            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        
        [TestCase("//[***]\n1***2***3" ,6)]
        [TestCase("//[*]\n1*2*3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[**********][%]\n1**********2%%%%%%%%%%3", 6)]
        public void Add_GivenNumbersWithNewLineInBetweenandAndMultipleDelimeters_ShouldReturnTheSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var createStringCalculator = new StringCalculator();

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowed()
        {
            //Arrange
            var createStringCalculator = new StringCalculator();
            var numbers = "1\n-2,-3";

            //Act
            var expected = Assert.Throws<Exception>(() => createStringCalculator.Add(numbers));

            //Assert

            Assert.AreEqual("Negatives not allowed -2 -3", expected.Message);
        }

        [Test]
        public void Add_GivenNumberGreaterThan1000_ShouldIgnoreThatNumberAndReturnTheSumOfNumbers()
        {
            //Arrange
            var createStringCalculator = new StringCalculator();
            var numbers = "1002,3";

            //Act
            var actual = createStringCalculator.Add(numbers);

            //Assert
            var expected = 3;
            Assert.AreEqual(actual, expected);
        }
    }
}
