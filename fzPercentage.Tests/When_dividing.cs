using System;
using NUnit.Framework;

namespace fzPercentage.Tests
{
    [TestFixture]
    public class When_dividing
    {
        [Test]
        //without forcing users to cast to either double or decimal
        public void Can_multiply_by_long()
        {
            var p = new Percentage(10);

            var result = p / 2L;

            Assert.AreEqual(new Percentage(5), result);
        }

        [Test]
        public void Can_divide_by_double()
        {
            var p = new Percentage(10);

            var result = p / 2d;

            Assert.AreEqual(new Percentage(5), result);
        }

        [Test]
        public void Can_divide_by_decimal()
        {
            var p = new Percentage(10);

            var result = p / 2m;

            Assert.AreEqual(new Percentage(5), result);
        }

        [Test]
        public void Can_multiply_by_percentage()
        {
            var p1 = new Percentage(50);
            var p2 = new Percentage(10);

            var result = p1 / p2;

            Assert.AreEqual(new Percentage(500), result);
        }
    }
}
