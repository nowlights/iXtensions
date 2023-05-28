using iXtensions.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace iXtensions.Tests
{
    public class StringExtensionTests
    {


        [Fact]
        public void ToInteger_IsValid()
        {
            // Arrange
            string valueToConvert = "4";

            // Act
            var result = valueToConvert.ToInteger();

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void ToInteger_IsInvalid()
        {
            string valueToConvert = "x";
            Assert.Throws<FormatException>(() => valueToConvert.ToInteger());
        }



        [Fact]
        public void RemoveLast_WithoutLenght_IsValid()
        {
            string valueToRemove = "test ixtension";
            int actualLenght = valueToRemove.Length;
            int resultLenght = actualLenght - 1;

            var result = valueToRemove.RemoveLast();

            Assert.Equal(resultLenght, result.Length);
        }

        [Fact]
        public void RemoveLast_WithPassedLenght_IsValid()
        {
            string valueToRemove = "test ixtension";
            int actualLenght = valueToRemove.Length;
            int resultLenght = actualLenght - 4;

            var result = valueToRemove.RemoveLast(4);

            Assert.Equal(resultLenght, result.Length);
        }

        [Fact]
        public void RemoveLast_WithPassedLenght_IsInvalid()
        {
            string valueToRemove = "test";
            int lenghtToRemove = valueToRemove.Length + 4;
            Assert.Throws<ArgumentOutOfRangeException>(() => valueToRemove.RemoveLast(lenghtToRemove));
        }


    }
}
