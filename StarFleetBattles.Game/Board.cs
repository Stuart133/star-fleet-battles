using System.Collections.Generic;

namespace StarFleetBattles.Game
{
    public class Board
    {
        public Board(int height, int width)
        {
            // Create hexes. This creates a rhombus of hexes - Further shapes TBC
            for (var i = 0; i < width; i++)
            {
                _hexes.Add(new List<Hex>(height));
                for (var j = 0; j < height; j++)
                {
                    _hexes[i].Add(new Hex(this, i, j));
                }
            }
        }

        public Hex this[int q, int r]
        {
            // TODO: Edge of board handling
            get => _hexes[q][r];
        }

        private readonly IList<IList<Hex>> _hexes = new List<IList<Hex>>();
    }
}
