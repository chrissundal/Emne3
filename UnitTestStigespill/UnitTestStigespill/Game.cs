using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestStigespill
{
    public class Game
    {
        private int[] _positions;
        private readonly Ladder[] _ladders;

        public Game(int playerCount)
        {
            _positions = new int[playerCount];
            _ladders = new[]
            {
                new Ladder(1, 40),
                new Ladder(8, 10),
                new Ladder(36, 52),
                new Ladder(43, 62),
                new Ladder(49, 79),
                new Ladder(65, 82),
                new Ladder(68, 85),
                new Ladder(87, 70),
                new Ladder(74, 12),
                new Ladder(64, 27),
                new Ladder(56, 37),
                new Ladder(42, 30),
                new Ladder(33, 3),
                new Ladder(24, 5),
            };
        }

        public int GetPlayerPosition(int playerIndex)
        {
            return _positions[playerIndex];
        }

        public void Move(int playerIndex, int moveCount)
        {
            var pos = _positions[playerIndex] += moveCount;
            var ladder = FindLadder(pos);
            if (ladder != null)
            {
                _positions[playerIndex] = ladder.PositionTo;
            }
        }

        private Ladder FindLadder(int pos)
        {
            return _ladders.FirstOrDefault(l => l.PositionFrom == pos);
        }

        public int? GetWinner()
        {
            return null;
        }
    }
}
