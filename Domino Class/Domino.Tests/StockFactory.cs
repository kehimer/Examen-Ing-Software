using System.Collections.Generic;
using Domino.Logic;

namespace Domino.Tests
{
    public class StockFactory
    {
        public static List<Tile> GenerateShuffledTilesSample()
        {
            var tiles = Stock.GetInitialSetOfTiles();
            tiles[0] = new Tile {Head = 0, Tail = 3};
            tiles[3] = new Tile {Head = 0, Tail = 0};
            tiles[4] = new Tile {Head = 1, Tail = 1};
            tiles[7] = new Tile {Head = 0, Tail = 4};
            tiles[10] = new Tile {Head = 3, Tail = 5};
            tiles[20] = new Tile {Head = 1, Tail = 4};
            return tiles;
        }
    }
}