using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hello_UnitTests
{
    /// <summary>
    /// Summary description for BirdTest
    /// </summary>
    [TestClass]
    public class BirdTest
    {   
       
        [TestMethod]
        public void IsBird()
        {
            //arrage
            var expected = true;

            //act
            var bird = new Bird();

            //assert
            
            Assert.AreNotEqual(expected, bird is IFish);
            Assert.AreEqual(expected, bird is IBird);
        
        }
    }

    internal interface IFish
    {
    }

    internal interface IBird
    {
    }

 
}
