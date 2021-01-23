using StarFleetBattles.Game.Enums;
using System;

namespace StarFleetBattles.Game.Movement
{
    public class NormalMovement : IMovement
    {
        private int _speed = 0;

        public Hex Move(Hex currentHex, int impulse)
        {
            // TODO: Speed/Impulse lookup
            return currentHex.GetNeighbour(Facing);
        }

        public void TurnLeft()
        {
            // TODO: Turn mode logic
        }

        public void TurnRight()
        {
            // TODO: Turn mode logic
        }

        public Facing Facing { get; private set; }
        public int Speed
        {
            get => _speed;
            set
            {
                if (value > 31 || value < 0)
                {
                    throw new ArgumentException("Speed cannot be above 31 or below 0");
                }
                else
                {
                    _speed = value;
                }
            }
        }
    }
}
