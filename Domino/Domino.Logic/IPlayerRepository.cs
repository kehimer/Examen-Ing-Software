using System;
using System.Collections.Generic;

namespace Domino.Logic
{
    public interface IPlayerRepository
    {
        void AddTile(Tile newTile);
        List<Tile> GetTiles();
        Boolean HasThisTile(int side1, int side2);

    }
}
