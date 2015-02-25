using System.Collections.Generic;
using Domino.Logic.Logic;

namespace Domino.Logic.Interfaces
{
    public interface ITileRepository
    {
        void SetInitialTiles();
        Stack<Tile> GetTiles();
        void SetRandomOrder(int seed);
    }
}
