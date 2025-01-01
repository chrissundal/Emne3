namespace UnitTestStigespill.Test
{
    public class GameTest
    {
        [Test]
        public void TestStartAt0AndMultiplePlayers()
        {
            var game = new Game(4);
            var position = game.GetPlayerPosition(0);
            Assert.That(0,Is.EqualTo(position));
        }
        
        [Test]
        public void TestInitialMove()
        {
            var game = new Game(4);
            game.Move(0, 4);
            var position = game.GetPlayerPosition(0);
            Assert.That(4,Is.EqualTo(position));
        }
        
        [Test]
        public void TestMultiplePlayerPositions()
        {
            var game = new Game(2);
            game.Move(0, 3);
            game.Move(1, 4);
            Assert.That(3,Is.EqualTo(game.GetPlayerPosition(0)));
            Assert.That(4,Is.EqualTo(game.GetPlayerPosition(1)));
        }

        //[Test]
        //public void TestLadderFrom1To40()
        //{
        //    var game = new Game(1);
        //    game.Move(0, 1);
        //    Assert.That(40,Is.EqualTo(game.GetPlayerPosition(0)));
        //}

        //[Test]
        //public void TestLadderFrom36To52()
        //{
        //    var game = new Game(1);
        //    game.Move(0, 36);
        //    Assert.That(52,Is.EqualTo(game.GetPlayerPosition(0)));
        //}

        [TestCase(1,40)]
        [TestCase(36,52)]
        [TestCase(24,5)]
        public void TestLadder(int posFrom, int posTo)
        {
            var game = new Game(1);
            game.Move(0, posFrom);
            Assert.That(posTo, Is.EqualTo(game.GetPlayerPosition(0)));
        }

        [Test]
        public void TestDiceMax6()
        {
            var game = new Game(1);
            game.Move(0, 7);
            Assert.That(0, Is.EqualTo(game.GetPlayerPosition(0)));
        }
        
        [Test]
        public void TestWinning()
        {
            var game = new Game(1);
            game.Move(0, 1);
            game.Move(0, 3);
            game.Move(0, 3);
            game.Move(0, 6);
            game.Move(0, 2);
            var winner = game.GetWinner();
            Assert.That(0, Is.EqualTo(winner));
        }
        [Test]
        public void TestNotWinning()
        {
            var game = new Game(1);
            game.Move(0, 2);
            var winner = game.GetWinner();
            Assert.That(winner, Is.Null);
        }
    }
}
