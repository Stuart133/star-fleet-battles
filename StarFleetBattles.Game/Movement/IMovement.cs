using StarFleetBattles.Game.Enums;

namespace StarFleetBattles.Game.Movement
{
    public interface IMovement
    {
        Hex Move(Hex currentHex, int impulse);
        void TurnLeft();
        void TurnRight();
        Facing Facing { get; }
        int Speed { get; set; }
    }
}
