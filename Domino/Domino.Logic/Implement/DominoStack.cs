﻿using System.Collections.Generic;
using Domino.Logic.Interfaces;

namespace Domino.Logic.Implement
{
    public class DominoStack
    {
        private readonly ITileRepository _stackRepository;
        private Stack<Tile> _tilesStack;

        public DominoStack(ITileRepository stackRepository)
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