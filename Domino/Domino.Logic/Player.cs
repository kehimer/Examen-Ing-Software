using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public class Player
    {
        private List<Piece> _pieces;
        private int _number;

        public Player()
        {
            _pieces = new List<Piece>();
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

        public Piece GetPiece(int face1, int face2)
        {
            return _pieces.First(x => x.FaceOne.Equals(face1) && x.FaceTwo.Equals(face2));
        }

        public void RemovePiece(int face1, int face2)
        {
            _pieces.Remove(GetPiece(face1, face2));
        }
    }
}
