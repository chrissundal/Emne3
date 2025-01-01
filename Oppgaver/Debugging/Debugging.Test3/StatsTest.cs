using NUnit.Framework.Legacy;

namespace Debugging.Test3
{
    public class StatsTest
    {

        [Test]
        public void Testwith3And4()
        {
            //arrange
            var stats = new Stats();
            //act
            stats.Add(3);
            stats.Add(4);
            //assert
            Assert.That(2, Is.EqualTo(stats.Count));
            Assert.That(7, Is.EqualTo(stats.Sum));
            Assert.That(4, Is.EqualTo(stats.Max));
            Assert.That(3, Is.EqualTo(stats.Min));
            Assert.That(3.5, Is.EqualTo(stats.Mean));
            //ClassicAssert.AreEqual(2,stats.Count);
            //ClassicAssert.AreEqual(7,stats.Sum);
            //ClassicAssert.AreEqual(4,stats.Max);
            //ClassicAssert.AreEqual(3,stats.Min);
            //ClassicAssert.AreEqual(3.5,stats.Mean,0.0001);
        }
        [Test]
        public void Testwith2And4And9()
        {
            //arrange
            var stats = new Stats();
            //act
            stats.Add(2);
            stats.Add(4);
            stats.Add(9);
            //assert
            Assert.That(3, Is.EqualTo(stats.Count));
            Assert.That(15, Is.EqualTo(stats.Sum));
            Assert.That(9, Is.EqualTo(stats.Max));
            Assert.That(2, Is.EqualTo(stats.Min));
            Assert.That(5, Is.EqualTo(stats.Mean));
            //ClassicAssert.AreEqual(2,stats.Count);
            //ClassicAssert.AreEqual(7,stats.Sum);
            //ClassicAssert.AreEqual(4,stats.Max);
            //ClassicAssert.AreEqual(3,stats.Min);
            //ClassicAssert.AreEqual(3.5,stats.Mean,0.0001);
        }
        [Test]
        public void TestEmptyStats()
        {
            //arrange
            var stats = new Stats();
            //act
            
            //assert
            Assert.That(0, Is.EqualTo(stats.Count));
            Assert.That(0, Is.EqualTo(stats.Sum));
            Assert.That(stats.Max,Is.Null);
            Assert.That(stats.Min,Is.Null);
            //Assert.Throws<DivideByZeroException>(() => { var m = stats.Mean; });
            //Assert.Throws<DivideByZeroException>(Code(stats));
            Assert.That(stats.Mean, Is.NaN);
        }

        private TestDelegate Code(Stats stats)
        {
            return () => { var m = stats.Mean; };
        }
    }
}

