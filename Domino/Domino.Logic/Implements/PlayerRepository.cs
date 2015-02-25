using System.Collections.Generic;
using System.Linq;
using Domino.Logic.Interfaces;
using Domino.Logic.Logic;

namespace Domino.Logic.Implements
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Tile> _tiles = new List<Tile>();

        public void AddTile(Tile newTile)
        {
            _tiles.Add(newTile);
        }

        public List<Tile> GetTiles()
        {
            return _tiles;
        }

        public bool HasThisTile(int side1, int side2)
        {
            return _tiles.Any(tile => tile.SideOne.Equals(side1) && tile.SideTwo.Equals(side2));
        }

        public bool RemoveTile(Tile tile)
        {
            if (!HasThisTile(tile.SideOne, tile.SideTwo)) return false;
            _tiles.Remove(tile);
            return true;
        }

        public Tile GetTile(int side1, int side2)
        {
            return _tiles.Find(x => (x.SideOne.Equals(side1) && x.SideTwo.Equals(side2)));
        }
    }
}