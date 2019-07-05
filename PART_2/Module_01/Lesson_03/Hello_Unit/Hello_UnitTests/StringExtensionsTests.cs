using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hello_Unit;

namespace Hello_UnitTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void StringExtensionIsBlueBaseTest()
        {

            // Arrange
            string color = "blue";

            // Act
            bool actual = color.IsBaseColor();

            // Assert
            const bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringExtensionIsBlackBaseTest()
        {

            // Arrange
            string color = "black";

            // Act
            bool actual = color.IsBaseColor();

            // Assert
            const bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringExtensionIsRedBaseTest()
        {

            // Arrange
            string color = "red";

            // Act
            bool actual = color.IsBaseColor();

            // Assert
            const bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringExtensionIsYellowBaseTest()
        {

            // Arrange
            string color = "yellow";

            // Act
            bool actual = color.IsBaseColor();

            // Assert
            const bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
