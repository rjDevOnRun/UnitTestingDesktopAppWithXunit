using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;

namespace XUnitTests.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_SimpleValuesShouldCalculate()
        {
            // Arrange
            double expected = 5;

            // Act
            double actual = Calculator.Add(3, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 3, 7)]
        [InlineData(21, 5.25, 26.25)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void Add_SimpleValuesShouldCalculateTheory(double x, double y, double expected)
        {
            // Arrange
            // Pass data thorugh inline method

            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
