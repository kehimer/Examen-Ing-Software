using System.Collections.Generic;
using Domino.Logic.Interfaces;

namespace Domino.Logic.Logic
{
    public class DominoStack
    {
       private readonly IStackRepository _stackRepository;
        private Stack<Tile> _tilesStack;

        public DominoStack(IStackRepository stackRepository)
        {
            _stackRepository = stackRepository;
            _tilesStack = _stackRepository.GetTiles();
        }

        public Stack<Tile> GetAllTiles()
        {
            return _tilesStack;
        }

        public void SetSortedTiles(int seed)
        {
            _stackRepository.SetRandomOrder(seed);
            _tilesStack = _stackRepository.GetTiles();
        }
    }
}
