using System.Collections.Generic;
using System.Linq;

namespace Domino.Logic.Logic
{
    public class Player
    {
        private readonly List<Tile> _tiles;
        private int _number;

        public Player()
        {
            _tiles = new List<Tile>();
            _number = 0;
        }

        public void SetNumber(int number)
        {
            _number = number;
        }

        public int GetNumber()
        {
            return _number;
        }

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

        public Tile GetTile(int side1, int side2)
        {
            return _tiles.First(tile => tile.SideOne.Equals(side1) && tile.SideTwo.Equals(side2));
        }

        public void RemoveTile(int face1, int face2)
        {
            _tiles.Remove(GetTile(face1, face2));
        }
    }
}
