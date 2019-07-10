using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassWork_01;
using TestAutoImplementation;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {        
        [TestMethod]
        [TestProperty("MyCalcDivision", "2.0")]
        [TestCategory("MyCalcDivision")]
        public void Check_Correct_Division()
        {
            ////arrange
            //double arg1 = 4.0;
            //double arg2 = 2.0;
   
            //double expected = 2.0;
            ////act
            //double actual  = Calculator.Div(arg1, arg2);
            ////assert
            //Assert.AreEqual(expected, actual);

        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Check_Exception_Devision()
        {
            // arrange
            double arg1 = 4.0;
            double arg2 = 0.0;
            // act
            double actual = Calculator.Div(arg1, arg2);
            // assert
        }
    }
}
