namespace UnittestCalculator.Test
{
    public class Tests
    {
        
        [Test]
        public void TestLeggsammen()
        {
            var calculator = new Calculator();
            int result = calculator.LeggSammen(15, 10);
            Assert.That(result, Is.EqualTo(25));
        }
        [Test]
        public void TestLeggsammenMax()
        {
            var calculator = new Calculator();
            int result = calculator.LeggSammen(int.MaxValue, 0);
            Assert.That(result, Is.EqualTo(int.MaxValue));
        }
        [Test]
        public void TestLeggsammenMin()
        {
            var calculator = new Calculator();
            int result = calculator.LeggSammen(int.MinValue, 0);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }
        [Test]
        public void TestLeggsammen2()
        {
            var calculator = new Calculator();
            int result = calculator.LeggSammen(-12, 10);
            Assert.That(result, Is.EqualTo(-2));
        }
        [Test]
        public void TestLeggsammenForskjellige()
        {
            var calculator = new Calculator();
            int result = calculator.LeggSammen(2, 10);
            int secondResult = calculator.TrekkFra(2, 10);
            var answer = result + secondResult;
            Assert.That(answer, Is.EqualTo(4));
        }
        
        [Test]
        public void TestTrekkFra()
        {
            var calculator = new Calculator();
            int result = calculator.TrekkFra(15, 10);
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void TestTrekkFra2()
        {
            var calculator = new Calculator();
            int result = calculator.TrekkFra(5, 7);
            Assert.That(result, Is.EqualTo(-2));
        }
        
        [Test]
        public void TestMultipliser()
        {
            var calculator = new Calculator();
            int result = calculator.Multipliser(5, 10);
            Assert.That(result, Is.EqualTo(50));
        }
        [Test]
        public void TestMultipliserZero()
        {
            var calculator = new Calculator();
            int result = calculator.Multipliser(5, 0);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void TestMultipliserEdge()
        {
            var calculator = new Calculator();
            int result = calculator.Multipliser(int.MaxValue, 1);
            Assert.That(result, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void TestDivider()
        {
            var calculator = new Calculator();
            int result = calculator.Divider(301, 3);
            Assert.That(result, Is.EqualTo(100));
        }
        [Test]
        public void TestDividerNegative()
        {
            var calculator = new Calculator();
            int result = calculator.Divider(100, -3);
            Assert.That(result, Is.EqualTo(-33));
        }
        [Test]
        public void TestDividerZero()
        {
            var calculator = new Calculator();
            int result = calculator.Divider(0, 100);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
