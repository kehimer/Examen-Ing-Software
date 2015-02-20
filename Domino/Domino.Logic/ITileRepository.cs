using System.Collections.Generic;

namespace Domino.Logic
{
    public interface ITileRepository
    {
        void SetInitialTiles();
        Stack<Tile> GetTiles();
        void SetRandomOrder(int seed);
    }
}
