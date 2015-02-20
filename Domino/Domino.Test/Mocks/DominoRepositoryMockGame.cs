using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;

namespace Domino.Test.Mocks
{
    public class DominoRepositoryMockGame : IDominoGameRepository
    {
        private List<Player> _players = new List<Player>();
        private List<Tile> _pieces =  new List<Tile>();
        private List<Tile> _piecesTable = new List<Tile>();
        public ITileRepository TileRepository { get; set; }
        
        private const int CantPiecesByPlayer = 7;

        private int _currentPlayerTurn = 1;
        
        public void SetPlayerTile(int players)
        {
            var wellPieces = TileRepository.GetTiles();

            for (int contador = 1; contador <= players; contador++)
            {
                var newPlayer = new Player();
                for (int i = 0; i < CantPiecesByPlayer; i++)
                {
                    newPlayer.AddTile(wellPieces.Pop());
                }
                newPlayer.SetNumber(contador);
                _players.Add(newPlayer);
            }
        }

        public List<Tile> GetPlayerTiles(int playerNumber)
        {
            var player = _players.First(x => x.GetNumber().Equals(playerNumber));
            if(player == null)
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
            for (int i = 6; i >= 0; i--)
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
                if(tempPiece == null)
                    continue;

                if (tempPiece.SideOne > greaterPiece.SideOne)
                {
                    greaterPiece = tempPiece;
                    tempPlayer = player;
                }
            }
            
            return tempPlayer.GetNumber() == -1 ? null : tempPlayer;
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
            
            if(!currentPlayer.HasThisTile(tile.SideOne, tile.SideTwo))
                throw new Exception("El jugador de turno no tiene la pieza que desea mover");

            _piecesTable.Insert(0, tile);
            currentPlayer.RemoveTile(tile.SideOne, tile.SideTwo);
        }

        public void SetTileAtTheEndOfTheStack(Tile tile)
        {
            var currentPlayer = GetPlayerCurrentTurn();

            if (!currentPlayer.HasThisTile(tile.SideOne, tile.SideTwo))
                throw new Exception("El jugador de turno no tiene la pieza que desea mover");

            _piecesTable.Add(tile);
            currentPlayer.RemoveTile(tile.SideOne, tile.SideTwo);
        }

        public void SetPlayerTurn(int numberPlayer)
        {
            _currentPlayerTurn = numberPlayer;
        }

        public void TakeATileFromTheStack()
        {
            if (TileRepository.GetTiles().Count == 0)
                throw new Exception("Ya no hay piezas en el pozo");

            var currentPlayer = GetPlayerCurrentTurn();
            currentPlayer.AddTile(TileRepository.GetTiles().Pop());
        }

        public int GetWinnerPlayer()
        {
            var minPieces = _players.Min(x => x.GetTiles().Count);
            var playersWithMinPieces = _players.Where(x => x.GetTiles().Count.Equals(minPieces)).ToList();

            if (playersWithMinPieces.Count() > 1)
                return -1;

            return playersWithMinPieces.First().GetNumber();
        }

        public void SaveGameStatistics()
        {
            var numberPlayerWin = GetWinnerPlayer();
            if(numberPlayerWin.Equals(-1))
                return;

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create);
            path = Path.Combine(path, "DominoEstadistic.dat");

            if (!File.Exists(path))
                File.Create(path);

            File.AppendAllText(path, numberPlayerWin.ToString() + Environment.NewLine);

            //var stream = File.AppendText(path);
            //stream.Write(numberPlayerWin);

            //stream.FlushAsync();
            //stream.Close();
        }
    }
}
