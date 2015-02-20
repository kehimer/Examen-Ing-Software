using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;

namespace Domino.Test.Mocks
{
    public class PlayerRepositoryMockAsignPieces : IPlayerRepository
    {
        private List<Tile> _pieces = new List<Tile>();
        public void AddTile(Tile newTile)
        {
            _pieces.Add(newTile);
        }

        public List<Tile> GetTiles()
        {
            return _pieces;
        }

        public bool HasThisTile(int side1, int side2)
        {
            return _pieces.Any(piece => piece.SideOne.Equals(side1) && piece.SideTwo.Equals(side2));
        }
    }
}
