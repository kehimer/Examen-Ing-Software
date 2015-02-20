using System.Collections.Generic;

namespace Domino.Logic
{
    public interface IDominoGameRepository
    {
        ITileRepository TileRepository { set; get; }
        void SetPlayerTile(int players);
        List<Tile> GetPlayerTiles(int player);
        List<Player> GetPlayers();
        Player GetPlayer(int playerNumber);
        Tile GetDoubleGreaterTile(int playerNumber);
        Player GetPlayerWithDoubleGreaterTile();
        Player GetPlayerWithMaxSumTile();
        Player GetPlayerCurrentTurn();
        void SetTileAtTheBeginingOfTheStack(Tile tile);
        void SetTileAtTheEndOfTheStack(Tile tile);
        void SetPlayerTurn(int numberPlayer);
        void TakeATileFromTheStack();
        int GetWinnerPlayer();
        void SaveGameStatistics();
    }
}
