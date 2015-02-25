using System.Collections.Generic;
using Domino.Logic.Interfaces;

namespace Domino.Logic.Logic
{
    public class DominoGame
    {
        private readonly IDominoGameRepository _dominoRepository;

        public DominoGame(IDominoGameRepository dominoRepository, IStackRepository stackRepository)
        {
            _dominoRepository = dominoRepository;
            _dominoRepository.StackRepository = stackRepository;
        }

        public void SetPlayersTiles(int players)
        {
            _dominoRepository.SetPlayerTile(players);
            
        }

        public List<Player> GetPlayers()
        {
            return _dominoRepository.GetPlayers();
        }

        public List<Tile> GetPlayerTiles(int player)
        {
            return _dominoRepository.GetPlayerTiles(player);
        }

        public Stack<Tile> GetTilesFromTheStack()
        {
            return _dominoRepository.StackRepository.GetTiles();
        }

        public void InitializeStack()
        {
            _dominoRepository.StackRepository.SetInitialTiles();
        }

        public void SetRandomOrderStackTiles(int seed)
        {
            _dominoRepository.StackRepository.SetRandomOrder(seed);
        }

        public Tile GetDoubleGreaterTile(int playerNumber)
        {
            return _dominoRepository.GetDoubleGreaterTile(playerNumber);
        }

        public Player GetPlayerWithDoubleGreaterTile()
        {
            return _dominoRepository.GetPlayerWithDoubleGreaterTile();
        }

        public Player GetPlayerWithMaxSumTile()
        {
            return _dominoRepository.GetPlayerWithMaxSumTile();
        }

        public Player GetPlayer(int playerNumber)
        {
            return _dominoRepository.GetPlayer(playerNumber);
        }

        public Player GetPlayerCurrentTurn()
        {
            return _dominoRepository.GetPlayerCurrentTurn();
        }

        public void MoveCurrentPlayerTileAtTheBeginingOfTheStack(Tile tileToMove)
        {
            _dominoRepository.SetTileAtTheBeginingOfTheStack(tileToMove);
        }

        public void MoveCurrentPlayerTileAtTheEndOfTheStack(Tile tileToMove)
        {
            _dominoRepository.SetTileAtTheEndOfTheStack(tileToMove);
        }

        public void SetPlayerTurn(int playerNumber)
        {
            _dominoRepository.SetPlayerTurn(playerNumber);
        }

        public void TakeATileFromTheStack()
        {
            _dominoRepository.TakeATileFromTheStack();
        }

        public object GetWinnerPlayer()
        {
            return _dominoRepository.GetWinnerPlayer();
        }

        public void SaveGameStatistics()
        {
            _dominoRepository.SaveGameStatistics();
        }
    }
}
