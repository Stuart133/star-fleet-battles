using StarFleetBattles.Game.Enums;
using System;
using System.Collections.Generic;

namespace StarFleetBattles.Game
{
    public class Hex
    {
        private readonly Board _board;

        public Hex(Board board, int q, int r)
        {
            Q = q;
            R = r;
            _board = board;
        }

        public Hex GetNeighbour(Facing facing)
        {
            return facing switch
            {
                Facing.Up => _board[Q, R - 1],
                Facing.UpRight => _board[Q + 1, R - 1],
                Facing.DownRight => _board[Q + 1, R],
                Facing.Down => _board[Q, R + 1],
                Facing.DownLeft => _board[Q - 1, R - 1],
                Facing.UpLeft => _board[Q - 1, R],
                _ => throw new ArgumentException("Unexpected facing"),
            };
        }

        public ICollection<Unit> Units = new HashSet<Unit>();

        // Q & R for the axial coordinates. S provides the 3rd cubic coordinate for certain algorithms
        public int Q { get; }
        public int R { get; }
        public int S => -Q - R;
    }
}
