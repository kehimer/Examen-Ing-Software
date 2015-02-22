using System;
using System.Collections.Generic;
using Domino.Logic.Implement;

namespace Domino.Logic.Interfaces
{
    public interface IPlayerRepository
    {
        void AddTile(Tile newTile);
        List<Tile> GetTiles();
        Boolean HasThisTile(int side1, int side2);

    }
}
