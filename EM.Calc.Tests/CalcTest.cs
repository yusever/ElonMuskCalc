using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Calc.Tests
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            //arrange
            var calc = new Core.Calc();
            var sum = 10;

            //act
            var result = calc.Sum(new[] { 5, 3, 2 });

            //assert
            Assert.AreEqual(sum, result);
        }

        [TestMethod]
        public void TestSub()
        {
            var calc = new Core.Calc();
            var sub = 1;

            var result = calc.Sub(new[] { 6, 3, 2 });

            Assert.AreEqual(sub, result);
        }

        [TestMethod]
        public void TestPow()
        {
            var calc = new Core.Calc();
            var pow = 15625;

            var result = calc.Pow(new[] { 5, 3, 2 });

            Assert.AreEqual(pow, result);
        }
    }
}
