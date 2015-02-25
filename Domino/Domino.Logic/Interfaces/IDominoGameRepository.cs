using System.Collections.Generic;
using Domino.Logic.Logic;

namespace Domino.Logic.Interfaces
{
    public interface IDominoGameRepository
    {
        IStackRepository StackRepository { set; get; }
        void SetPlayerTile(int players);
        List<Tile> GetPlayerTiles(int player);
        List<Tile> GetCurrentTableStack();
        List<Player> GetPlayers();
        Player GetPlayer(int playerNumber);
        Tile GetDoubleGreaterTile(int playerNumber);
        Player GetPlayerWithDoubleGreaterTile();
        Tile GetTileWithMaxSum(int playerNumber);
        Tile GetTile(int playerNumber, int side1, int side2);
        Player GetPlayerWithMaxSumTile();
        Player GetPlayerCurrentTurn();
        void SetTileAtTheBeginingOfTheStack(Tile tile);
        void SetTileAtTheEndOfTheStack(Tile tile);
        void SetPlayerTurn(int numberPlayer);
        int GetNextTurnPlayer();
        int GetCurrentTurnPlayer();
        void TakeATileFromTheStack();
        int GetWinnerPlayer();
        void SaveGameStatistics();
    }
}
