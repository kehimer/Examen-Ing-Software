using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public interface IWellRepository
    {
        void SetInitialPieces();
        Stack<Piece> GetPieces();
        void SetRandomOrder(int seed);
    }
}
