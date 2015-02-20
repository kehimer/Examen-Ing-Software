﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;
using Domino.Test.Factories;
using Rhino.Mocks.Constraints;

namespace Domino.Test.Mocks
{
    public class WellRepositoryMockSortRandom : ITileRepository
    {
        private Stack<Tile> _pieces = new Stack<Tile>();

        public void SetInitialTiles()
        {
            var face1 = 0;
            var face2 = 0;
            for (int contador = 1; contador <= 28; contador++)
            {
                var newPiece = PieceFactory.CreatePiece(face1, face2);
                _pieces.Push(newPiece);

                face2++;
                if (face2 > 6)
                {
                    face1++;
                    face2 = 0;
                }
            }
        }

        public Stack<Tile> GetTiles()
        {
            return _pieces;
        }

        public void SetRandomOrder(int seed)
        {
            var pieces = new List<Tile>();
            var piecesRandom = new Stack<Tile>();
            var face1 = 0;
            var face2 = 0;
            for (int contador = 1; contador <= 28; contador++)
            {
                var newPiece = PieceFactory.CreatePiece(face1, face2);
                pieces.Add(newPiece);

                face2++;
                if (face2 > 6)
                {
                    face1++;
                    face2 = 0;
                }
            }

            var random = new Random(seed);
            while (pieces.Count > 0)
            {
                var newRandom = random.Next(0, pieces.Count - 1);
                var piece = pieces[newRandom];
                pieces.Remove(piece);
                piecesRandom.Push(piece);
            }
            _pieces.Clear();
            _pieces = piecesRandom;
        }        
    }
}
