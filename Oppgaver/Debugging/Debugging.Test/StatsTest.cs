using NUnit.Framework;
namespace Debugging.Test
{
    public class StatsTest
    {
        [Test]
        public void Testwith3And4()
        {
            var stats = new Stats();

            stats.Add(3);
            stats.Add(4);

            Assert.AreEqual(2,stats.Count);
        }
    }
}
