using System;
using NUnit.Framework;

namespace fzPercentage.Tests
{
    [TestFixture]
    public class When_comparing
    {
        [Test]
        public void Can_compare_with_null()
        {
            var p = new Percentage(5);

            Assert.AreNotEqual(p, null);
        }

        [Test]
        public void Can_compare_with_other_equal_percentage()
        {
            var p1 = new Percentage(5);
            var p2 = new Percentage(5);

            Assert.AreEqual(p1, p2);
        }

        [Test]
        public void Can_compare_with_other_not_equal_percentage()
        {
            var p1 = new Percentage(5);
            var p2 = new Percentage(55);

            Assert.AreNotEqual(p1, p2);
        }

        [Test]
        public void Can_compare_with_null_using_iequatable()
        {
            IEquatable<Percentage> p = new Percentage(5);

            Assert.AreNotEqual(p, null);
        }

        [Test]
        public void Can_compare_with_other_equal_percentage_using_iequatable()
        {
            IEquatable<Percentage> p1 = new Percentage(5);
            IEquatable<Percentage> p2 = new Percentage(5);

            Assert.AreEqual(p1, p2);
        }

        [Test]
        public void Can_compare_with_other_not_equal_percentage_using_iequatable()
        {
            IEquatable<Percentage> p1 = new Percentage(5);
            IEquatable<Percentage> p2 = new Percentage(55);

            Assert.AreNotEqual(p1, p2);
        }

        [Test]
        public void Can_compare_two_nulls_using_operator()
        {
            Percentage p1 = null;
            Percentage p2 = null;

            Assert.IsTrue(p1 == p2);
        }

        [Test]
        public void Can_compare_with_null_using_operator()
        {
            var p = new Percentage(5);

            Assert.IsTrue(p != null);
            Assert.IsTrue(null != p);
        }

        [Test]
        public void Can_compare_with_other_equal_percentage_using_operator()
        {
            var p1 = new Percentage(5);
            var p2 = new Percentage(5);

            Assert.IsTrue(p1 == p2);
        }

        [Test]
        public void Can_compare_with_other_not_equal_percentage_using_operator()
        {
            var p1 = new Percentage(5);
            var p2 = new Percentage(55);

            Assert.IsTrue(p1 != p2);
            Assert.IsTrue(p2 != p1);
        }
    }
}
