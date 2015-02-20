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
        public static Tile CreatePiece(int face1, int face2)
        {
            var newPiece = new Tile();
            newPiece.SideOne = face1;
            newPiece.SideTwo = face2;
            return newPiece;
        }
    }
}
