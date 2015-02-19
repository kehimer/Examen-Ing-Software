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
        private List<Piece> _pieces = new List<Piece>();
        public void AddPiece(Piece newPiece)
        {
            _pieces.Add(newPiece);
        }

        public List<Piece> GetPieces()
        {
            return _pieces;
        }

        public bool HasPiece(int face1, int face2)
        {
            return _pieces.Any(piece => piece.FaceOne.Equals(face1) && piece.FaceTwo.Equals(face2));
        }
    }
}
