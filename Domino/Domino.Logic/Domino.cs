using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public class Domino
    {
        private List<Player> _players;
        private IDominoRepository _dominoRepository;

        private Well _well;

        public Domino(IDominoRepository dominoRepository, IWellRepository wellRepository)
        {
            _dominoRepository = dominoRepository;
            _players = new List<Player>();
            _dominoRepository.WellRepository = wellRepository;
        }

        public void SetPiecesPlayers(int players)
        {
            _dominoRepository.SetPiecesPlayers(players);
            
        }

        public List<Player> GetPlayers()
        {
            return _dominoRepository.GetPlayers();
        }

        public List<Piece> GetPiecesPlayer(int player)
        {
            return _dominoRepository.GetPiecesPlayer(player);
        }

        public Stack<Piece> GetPiecesFromWell()
        {
            return _dominoRepository.WellRepository.GetPieces();
        }

        public void InitialWell()
        {
            _dominoRepository.WellRepository.SetInitialPieces();
        }

        public void SetRandomOrderPiecesWell(int seed)
        {
            _dominoRepository.WellRepository.SetRandomOrder(seed);
        }

        public Piece GetDoublePieceGreater(int playerNumber)
        {
            return _dominoRepository.GetDoublePieceGreater(playerNumber);
        }

        public Player GetPlayerWithDoublePieceGreater()
        {
            return _dominoRepository.GetPlayerWithDoublePieceGreater();
        }

        public Player GetPlayerWithSumPieceGreater()
        {
            return _dominoRepository.GetPlayerWithSumPieceGreater();
        }

        public Player GetPlayer(int playerNumber)
        {
            return _dominoRepository.GetPlayer(playerNumber);
        }

        public Player GetPlayerCurrentTurn()
        {
            return _dominoRepository.GetPlayerCurrentTurn();
        }

        public void CurrentPlayerMovePieceToBeginTable(Piece pieceToMove)
        {
            _dominoRepository.CurrentPlayerMovePieceToBeginTable(pieceToMove);
        }

        public void CurrentPlayerMovePieceToEndTable(Piece pieceToMove)
        {
            _dominoRepository.CurrentPlayerMovePieceToEndTable(pieceToMove);
        }

        public void SetTurnPlayer(int playerNumber)
        {
            _dominoRepository.SetTurnPlayer(playerNumber);
        }

        public void CurrentPlayerTakePieceFromWell()
        {
            _dominoRepository.CurrentPlayerTakePieceFromWell();
        }

        public object GetPlayNumberWin()
        {
            return _dominoRepository.GetPlayNumberWin();
        }

        public void SaveStadisticGame()
        {
            _dominoRepository.SaveStadisticGame();
        }
    }
}
