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
    public class DominoRepositoryMockGame : IDominoRepository
    {
        private List<Player> _players = new List<Player>();
        private List<Piece> _pieces =  new List<Piece>();
        private List<Piece> _piecesTable = new List<Piece>();
        public IWellRepository WellRepository { get; set; }
        
        private const int CantPiecesByPlayer = 7;

        private int _currentPlayerTurn = 1;
        
        public void SetPiecesPlayers(int players)
        {
            var wellPieces = WellRepository.GetPieces();

            for (int contador = 1; contador <= players; contador++)
            {
                var newPlayer = new Player();
                for (int i = 0; i < CantPiecesByPlayer; i++)
                {
                    newPlayer.AddPiece(wellPieces.Pop());
                }
                newPlayer.SetNumber(contador);
                _players.Add(newPlayer);
            }
        }

        public List<Piece> GetPiecesPlayer(int playerNumber)
        {
            var player = _players.First(x => x.GetNumber().Equals(playerNumber));
            if(player == null)
                throw new Exception(string.Format("El jugador {0} no existe", playerNumber));

            return player.GetPieces();
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

        public Piece GetDoublePieceGreater(int playerNumber)
        {
            var player = GetPlayer(playerNumber);
            for (int i = 6; i >= 0; i--)
            {
                if (player.HasPiece(i, i))
                    return player.GetPiece(i, i);
            }
            return null;
        }

        public Player GetPlayerWithDoublePieceGreater()
        {
            var greaterPiece = new Piece {FaceOne = -1, FaceTwo = -1};
            var tempPlayer = new Player();
            tempPlayer.SetNumber(-1);

            foreach (var player in _players)
            {
                var tempPiece = GetDoublePieceGreater(player.GetNumber());
                if(tempPiece == null)
                    continue;

                if (tempPiece.FaceOne > greaterPiece.FaceOne)
                {
                    greaterPiece = tempPiece;
                    tempPlayer = player;
                }
            }
            
            return tempPlayer.GetNumber() == -1 ? null : tempPlayer;
        }

        public Player GetPlayerWithSumPieceGreater()
        {
            var maxValue = _players.Max(x => x.GetPieces().Sum(p => p.FaceOne + p.FaceTwo));
            return _players.First(x => x.GetPieces().Sum(p => p.FaceOne + p.FaceTwo).Equals(maxValue));
        }

        public Player GetPlayerCurrentTurn()
        {
            return GetPlayer(_currentPlayerTurn);
        }

        public void CurrentPlayerMovePieceToBeginTable(Piece piece)
        {
            var currentPlayer = GetPlayerCurrentTurn();
            
            if(!currentPlayer.HasPiece(piece.FaceOne, piece.FaceTwo))
                throw new Exception("El jugador de turno no tiene la pieza que desea mover");

            _piecesTable.Insert(0, piece);
            currentPlayer.RemovePiece(piece.FaceOne, piece.FaceTwo);
        }

        public void CurrentPlayerMovePieceToEndTable(Piece piece)
        {
            var currentPlayer = GetPlayerCurrentTurn();

            if (!currentPlayer.HasPiece(piece.FaceOne, piece.FaceTwo))
                throw new Exception("El jugador de turno no tiene la pieza que desea mover");

            _piecesTable.Add(piece);
            currentPlayer.RemovePiece(piece.FaceOne, piece.FaceTwo);
        }

        public void SetTurnPlayer(int playerNumber)
        {
            _currentPlayerTurn = playerNumber;
        }

        public void CurrentPlayerTakePieceFromWell()
        {
            if (WellRepository.GetPieces().Count == 0)
                throw new Exception("Ya no hay piezas en el pozo");

            var currentPlayer = GetPlayerCurrentTurn();
            currentPlayer.AddPiece(WellRepository.GetPieces().Pop());
        }

        public int GetPlayNumberWin()
        {
            var minPieces = _players.Min(x => x.GetPieces().Count);
            var playersWithMinPieces = _players.Where(x => x.GetPieces().Count.Equals(minPieces)).ToList();

            if (playersWithMinPieces.Count() > 1)
                return -1;

            return playersWithMinPieces.First().GetNumber();
        }

        public void SaveStadisticGame()
        {
            var numberPlayerWin = GetPlayNumberWin();
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
