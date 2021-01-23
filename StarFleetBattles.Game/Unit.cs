using StarFleetBattles.Game.Enums;
using StarFleetBattles.Game.Movement;
using System;

namespace StarFleetBattles.Game
{
    public class Unit
    {
        private readonly IMovement _movement = new NormalMovement();
        private Hex _hex;

        public Unit(Hex hex)
        {
            Id = Guid.NewGuid();
            _hex = hex;
        }

        public void Move(int impulse)
        {
            Hex = _movement.Move(Hex, impulse);
        }

        public Hex Hex
        {
            get => _hex;
            private set
            {
                // Move unit to new hex
                Hex.Units.Remove(this);
                _hex = value;
                Hex.Units.Add(this);
            }
        }
        public Guid Id { get; }
        public Facing Facing => _movement.Facing;
        public int Speed
        {
            get => _movement.Speed;
            set
            {
                _movement.Speed = value;
            }
        }
    }
}
