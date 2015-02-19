using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public interface IPlayerRepository
    {
        void AddPiece(Piece newPiece);
        List<Piece> GetPieces();
        Boolean HasPiece(int face1, int face2);

    }
}
