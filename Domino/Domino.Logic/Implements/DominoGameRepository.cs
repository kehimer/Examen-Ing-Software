using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domino.Logic.Interfaces;
using Domino.Logic.Logic;

namespace Domino.Logic.Implements
{
    public class DominoGameRepository : IDominoGameRepository
    {
        private readonly List<Player> _players = new List<Player>();
        private readonly List<Tile> _tableTiles = new List<Tile>();
        public IStackRepository StackRepository { get; set; }

        private const int TilesAmountByPlayer = 7;

        private int _currentPlayerTurn = 1;

        public void SetPlayerTile(int players)
        {
            var stackTiles = StackRepository.GetTiles();

            for (var playerNumber = 1; playerNumber <= players; playerNumber++)
            {
                var newPlayer = new Player();
                for (var i = 0; i < TilesAmountByPlayer; i++)
                {
                    newPlayer.AddTile(stackTiles.Pop());
                }
                newPlayer.SetNumber(playerNumber);
                _players.Add(newPlayer);
            }
        }

        public List<Tile> GetPlayerTiles(int playerNumber)
        {
            var player = _players.First(x => x.GetNumber().Equals(playerNumber));
            if (player == null)
                throw new Exception(string.Format("El jugador {0} no existe", playerNumber));

            return player.GetTiles();
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public Player GetPlayer(int playerNumber)
        {
            var player = _players.First(x => x.GetNumber().Equals(playerNumber));
            if (player == null)
                throw new Exception(string.Format("El jugador {0} no existe", playerNumber));

            return player;
        }

        public Tile GetDoubleGreaterTile(int playerNumber)
        {
            var player = GetPlayer(playerNumber);
            for (var i = 6; i >= 0; i--)
            {
                if (player.HasThisTile(i, i))
                    return player.GetTile(i, i);
            }
            return null;
        }

        public Player GetPlayerWithDoubleGreaterTile()
        {
            var greaterPiece = new Tile {SideOne = -1, SideTwo = -1};
            var tempPlayer = new Player();
            tempPlayer.SetNumber(-1);

            foreach (var player in _players)
            {
                var tempPiece = GetDoubleGreaterTile(player.GetNumber());
                if (tempPiece == null)
                    continue;

                if (tempPiece.SideOne <= greaterPiece.SideOne) continue;
                greaterPiece = tempPiece;
                tempPlayer = player;
            }

            return tempPlayer.GetNumber() == -1 ? null : tempPlayer;
        }

        public Tile GetTileWithMaxSum(int playerNumber)
        {
            var playerTiles = GetPlayerTiles(playerNumber);
            var maxTile = playerTiles.Max(x => (x.SideOne + x.SideTwo));
            var tile = playerTiles.First(x => (x.SideOne + x.SideTwo).Equals(maxTile));
            return tile;
        }

        public Tile GetTile(int playerNumber, int side1, int side2)
        {
            var playerTiles = GetPlayerTiles(playerNumber);
            return playerTiles.Find(x => (x.SideOne.Equals(side1) && x.SideTwo.Equals(side2)));
        }


        public Player GetPlayerWithMaxSumTile()
        {
            var maxValue = _players.Max(x => x.GetTiles().Sum(p => p.SideOne + p.SideTwo));
            return _players.First(x => x.GetTiles().Sum(p => p.SideOne + p.SideTwo).Equals(maxValue));
        }

        public Player GetPlayerCurrentTurn()
        {
            return GetPlayer(_currentPlayerTurn);
        }

        public void SetTileAtTheBeginingOfTheStack(Tile tile)
        {
            var currentPlayer = GetPlayerCurrentTurn();

            if (!currentPlayer.HasThisTile(tile.SideOne, tile.SideTwo))
                throw new Exception("El jugador de turno no tiene la pieza que desea mover");

            _tableTiles.Insert(0, tile);
            currentPlayer.RemoveTile(tile.SideOne, tile.SideTwo);
        }

        public void SetTileAtTheEndOfTheStack(Tile tile)
        {
            var currentPlayer = GetPlayerCurrentTurn();

            if (!currentPlayer.HasThisTile(tile.SideOne, tile.SideTwo))
                throw new Exception("El jugador de turno no tiene la pieza que desea mover");

            _tableTiles.Add(tile);
            currentPlayer.RemoveTile(tile.SideOne, tile.SideTwo);
        }

        public void SetPlayerTurn(int numberPlayer)
        {
            _currentPlayerTurn = numberPlayer;
        }

        public int GetCurrentTurnPlayer()
        {
            return _currentPlayerTurn;
        }

        public void TakeATileFromTheStack()
        {
            if (StackRepository.GetTiles().Count == 0)
                throw new Exception("Ya no hay piezas en el pozo");

            var currentPlayer = GetPlayerCurrentTurn();
            currentPlayer.AddTile(StackRepository.GetTiles().Pop());
        }

        public int GetWinnerPlayer()
        {
            var minTilesAmount = _players.Min(x => x.GetTiles().Count);
            var playersWithMinTiles = _players.Where(x => x.GetTiles().Count.Equals(minTilesAmount)).ToList();

            if (playersWithMinTiles.Count() > 1)
                return -1;

            return playersWithMinTiles.First().GetNumber();
        }

        public void SaveGameStatistics()
        {
            var winnerNumberPlayer = GetWinnerPlayer();
            if (winnerNumberPlayer.Equals(-1))
                return;

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments,
            Environment.SpecialFolderOption.Create);
            path = Path.Combine(path, "DominoEstatistics.dat");

            if (!File.Exists(path))
                File.Create(path);

            File.AppendAllText(path, winnerNumberPlayer + Environment.NewLine);
        }

        public List<Tile> GetCurrentTableStack()
        {
            return _tableTiles;
        }

        public int GetNextTurnPlayer()
        {
            return _currentPlayerTurn == 1 ? 2 : 1;
        }
    }
}
