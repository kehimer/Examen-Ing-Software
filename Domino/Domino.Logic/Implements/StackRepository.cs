using System;
using System.Collections.Generic;
using Domino.Logic.Interfaces;
using Domino.Logic.Logic;

namespace Domino.Logic.Implements
{
    public class StackRepository : IStackRepository
    {
        private Stack<Tile> _tiles = new Stack<Tile>();

        public void SetInitialTiles()
        {
            var side1 = 0;
            var side2 = 0;
            for (var numberTile = 1; numberTile <= 28; numberTile++)
            {
                var newTile = new Tile
                {
                    SideOne = side1,
                    SideTwo = side2
                };
                _tiles.Push(newTile);

                side2++;
                if (side2 <= 6) continue;
                side1++;
                side2 = 0;
            }
        }

        public Stack<Tile> GetTiles()
        {
            return _tiles;
        }

        public void SetRandomOrder(int seed)
        {
            var tiles = new List<Tile>();
            var randomTiles = new Stack<Tile>();
            var side1 = 0;
            var side2 = 0;
            for (var numberTile = 1; numberTile <= 28; numberTile++)
            {
                var newTile = new Tile
                {
                    SideOne = side1,
                    SideTwo = side2
                };
                tiles.Add(newTile);

                side2++;
                if (side2 <= 6) continue;
                side1++;
                side2 = 0;
            }

            var random = new Random(seed);
            while (tiles.Count > 0)
            {
                var newRandom = random.Next(0, tiles.Count - 1);
                var tile = tiles[newRandom];
                tiles.Remove(tile);
                randomTiles.Push(tile);
            }
            _tiles.Clear();
            _tiles = randomTiles;
        }
    }
}
