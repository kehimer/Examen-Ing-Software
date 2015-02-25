using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Logic;

namespace Domino
{
    public interface IDrawnGame
    {
        void InitGame();
        //void PrintPlayerTiles(int numberPlayer);
       // void PrintStack(List<Tile> stack);
       // void PrintWinnerPlayer(int winnerPlayer);
        void Render();
    }
}
