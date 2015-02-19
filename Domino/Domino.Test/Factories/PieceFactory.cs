using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;

namespace Domino.Test.Factories
{
    public class PieceFactory
    {
        public static Piece CreatePiece(int face1, int face2)
        {
            var newPiece = new Piece();
            newPiece.FaceOne = face1;
            newPiece.FaceTwo = face2;
            return newPiece;
        }
    }
}
