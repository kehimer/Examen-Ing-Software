using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public class Well
    {
        private readonly IWellRepository _wellRepository;
        private Stack<Piece> _wellPieces;

        public Well(IWellRepository wellRepository)
        {
            _wellRepository = wellRepository;
            _wellPieces = _wellRepository.GetPieces();
        }

        public Stack<Piece> GetAllPieces()
        {
            return _wellPieces;
        }

        public void SetSortedPieces(int seed)
        {
            _wellRepository.SetRandomOrder(seed);
            _wellPieces = _wellRepository.GetPieces();
        }
    }
}
