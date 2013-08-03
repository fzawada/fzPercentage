using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace fzPercentage.Tests
{
    [TestFixture]
    public class When_parsing
    {
        [Test]
        [TestCase("5", 5)]
        [TestCase(" 5 ", 5)]
        [TestCase("5%", 5)]
        [TestCase(" 5  % ", 5)]
        [TestCase(" 5,5 ", 5.5)]
        [TestCase("5,5%", 5.5)]
        [TestCase("5,5 %", 5.5)]
        [TestCase(" 5,5   % ", 5.5)]
        public void Can_parse(string value, double numberRepresentation)
        {
            var parsed = Percentage.Parse(value, CultureInfo.GetCultureInfo("PL"));
            var expected = new Percentage(numberRepresentation);
            Assert.AreEqual(expected, parsed);
        }

        [Test]
        [TestCase("%5")]
        [TestCase("5z")]
        [TestCase(" 5 z")]
        [TestCase("5%z")]
        [TestCase("z 5  % ")]
        [TestCase(" 5, 5 ")]
        [TestCase("5, 5%")]
        [TestCase("5, 5 %")]
        [TestCase(" 5, 5   % ")]
        [TestCase(" 5, %5    ")]
        [TestCase(" 5% 5    ")]
        public void Should_not_parse(string value)
        {
            Assert.Throws<FormatException>(() => Percentage.Parse(value, CultureInfo.GetCultureInfo("PL")));
        }
    }
}
