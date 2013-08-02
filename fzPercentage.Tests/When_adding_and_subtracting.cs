using NUnit.Framework;

namespace fzPercentage.Tests
{
    [TestFixture]
    public class When_adding_and_subtracting
    {
        [Test]
        public void Can_add_two_percentages()
        {
            var p1 = new Percentage(3);
            var p2 = new Percentage(2);

            var p3 = p1 + p2;

            Assert.AreEqual(new Percentage(5), p3);
        }

        [Test]
        public void Can_subtract_two_percentages()
        {
            var p1 = new Percentage(3);
            var p2 = new Percentage(2);

            var p3 = p1 - p2;

            Assert.AreEqual(new Percentage(1), p3);
        }
    }
}
