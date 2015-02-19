using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public interface IDominoRepository
    {
        IWellRepository WellRepository { set; get; }
        void SetPiecesPlayers(int players);
        List<Piece> GetPiecesPlayer(int player);
        List<Player> GetPlayers();
        Player GetPlayer(int playerNumber);
        Piece GetDoublePieceGreater(int playerNumber);
        Player GetPlayerWithDoublePieceGreater();
        Player GetPlayerWithSumPieceGreater();
        Player GetPlayerCurrentTurn();
        void CurrentPlayerMovePieceToBeginTable(Piece piece);
        void CurrentPlayerMovePieceToEndTable(Piece piece);
        void SetTurnPlayer(int playerNumber);
        void CurrentPlayerTakePieceFromWell();
        int GetPlayNumberWin();
        void SaveStadisticGame();
    }
}
