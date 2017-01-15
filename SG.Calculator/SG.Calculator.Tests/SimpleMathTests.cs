using NUnit.Framework;
using SG.Calculator.BLL;
using System;

namespace SG.Calculator.Tests
{
    [TestFixture]
    public class SimpleMathTests
    {
        [SetUp]
        public void Init()
        {
            // this code runs before each test
        }

        [TearDown]
        public void Cleanup()
        {
            // this code runs after each test
        }

        [Test]
        public void IntegerDivision1()
        {
            SimpleMath math = new SimpleMath();
            int result = math.Divide(5, 2);

            Assert.AreEqual(2, result);
        }

        [TestCase(4, 2, 2)]
        [TestCase(13, 6, 2)]
        [TestCase(-20, 5, -4)]
        public void IntegerDivision2(int x, int y, int expected)
        {
            SimpleMath math = new SimpleMath();
            int actual = math.Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DividByZeroTest()
        {
            SimpleMath math = new SimpleMath();
            Assert.Throws<DivideByZeroException>(() => math.Divide(5, 0));
        }
    }
}

