using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;
using Domino.Logic.Implement;
using Domino.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;


namespace Domino.Test
{
    [TestClass]
    public class DominoTest
    {
        [TestMethod]
        public void SetRandomOrderWell()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            
            mockWellRepository.SetInitialTiles();
            var originalStackPiece = mockWellRepository.GetTiles();

            mockWellRepository.SetRandomOrder(Environment.TickCount);
            var randomStackPiece = mockWellRepository.GetTiles();

            CollectionAssert.AreNotEqual(originalStackPiece, randomStackPiece, "Las piezas del Pozo deben estar DESORDENADAS");
        }

        [TestMethod]
        public void SetPiecesPlayer1()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var player = 1;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(player);
            var piecesPlayer1 = domino.GetPlayerTiles(player);
            var wellPieces = domino.GetTilesFromTheStack();

            CollectionAssert.AreNotEqual(piecesPlayer1, wellPieces, "Las piezas del Pozo NO deben ser las mismas que tiene asignada el jugador1");
        }


        [TestMethod]
        public void SetPiecesTwoPlayers()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            var piecesPlayer1 = domino.GetPlayerTiles(1);
            var piecesPlayer2 = domino.GetPlayerTiles(2);


            CollectionAssert.AreNotEqual(piecesPlayer1, piecesPlayer2, "Las piezas de cada jugador deben ser distintas");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WhenGetPiecesPlayerNoExists()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            var piecesPlayer1 = domino.GetPlayerTiles(1);
            var piecesPlayer2 = domino.GetPlayerTiles(2);
            var piecesPlayer3 = domino.GetPlayerTiles(3);
        }


        [TestMethod]
        public void WhenTwoPlayersHavePiecesWellHas14Pieces()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            var wellPieces = domino.GetTilesFromTheStack();
            Assert.AreEqual(wellPieces.Count, 14, "Las piezas en el pozo deben ser 14");
        }

        [TestMethod]
        public void StartedPlayer2HasGreaterDoublePiece()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            var startedPlayer = domino.GetPlayerWithDoubleGreaterTile();
            const int numberPlayer = 2;

            Assert.AreEqual(numberPlayer, 2, "El jugador 2 debe iniciar porque tiene la pieza doble mayor");
        }

        [TestMethod]
        public void StartedPlayer1HasGreaterSumPiece()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            var startedPlayer = domino.GetPlayerWithMaxSumTile();
            var numberPlayer = 1;

            Assert.AreEqual(numberPlayer, 1, "El jugador 1 debe iniciar porque tiene la pieza con suma de valores mayor");
        }

        [TestMethod]
        public void Player1MovePieceToBeginTable()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(1);
            var currentPlayer = domino.GetPlayerCurrentTurn();
            var pieceToMove = currentPlayer.GetTiles()[3];

            var piecesBeforMove = currentPlayer.GetTiles().Count;
            domino.MoveCurrentPlayerTileAtTheBeginingOfTheStack(pieceToMove);
            var piecesAferMove = currentPlayer.GetTiles().Count;

            Assert.AreNotEqual(piecesBeforMove, piecesAferMove, "No deben haber las mismas piezas despues del movimiento");
        }

        [TestMethod]
        public void Player1MovePieceToEndTable()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(1);
            var currentPlayer = domino.GetPlayerCurrentTurn();
            var pieceToMove = currentPlayer.GetTiles()[3];

            var piecesBeforMove = currentPlayer.GetTiles().Count;
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(pieceToMove);
            var piecesAferMove = currentPlayer.GetTiles().Count;

            Assert.AreNotEqual(piecesBeforMove, piecesAferMove, "No deben haber las mismas piezas despues del movimiento");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Player1MoveInvalidPieceToTable()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(1);
            var otherPlayer = domino.GetPlayer(2);
            var pieceToMove = otherPlayer.GetTiles()[3];

            var piecesBeforMove = otherPlayer.GetTiles().Count;
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(pieceToMove);
            var piecesAferMove = otherPlayer.GetTiles().Count;

            Assert.AreNotEqual(piecesBeforMove, piecesAferMove, "No deben haber las mismas piezas despues del movimiento");
        }

        [TestMethod]
        public void ChangePlayerTurnAfterMovePiece()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(2);
            var currentPlayerBeforeMove = domino.GetPlayerCurrentTurn();
            var pieceToMove = currentPlayerBeforeMove.GetTiles()[3];
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(pieceToMove);
            domino.SetPlayerTurn(1);
            var currentPlayerAfeterMove = domino.GetPlayerCurrentTurn();

            Assert.AreNotEqual(currentPlayerBeforeMove.GetNumber(), currentPlayerAfeterMove.GetNumber(), "Despues de un movimiento los turnos deben cambiar");
        }

        [TestMethod]
        public void Player1NeedMorePiecesFromWell()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(1);
            var currentPlayer = domino.GetPlayerCurrentTurn();
            
            var piecesBeforMove = currentPlayer.GetTiles().Count;
            domino.TakeATileFromTheStack();
            var piecesAferMove = currentPlayer.GetTiles().Count;
            

            Assert.AreNotEqual(piecesBeforMove, piecesAferMove, "No deben haber las mismas piezas despues del movimiento");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TakePiecesFromEmptyWellIsError()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(1);
            var currentPlayer = domino.GetPlayerCurrentTurn();
            domino.GetTilesFromTheStack().Clear();
            var piecesBeforMove = currentPlayer.GetTiles().Count;
            domino.TakeATileFromTheStack();
            var piecesAferMove = currentPlayer.GetTiles().Count;


            Assert.AreNotEqual(piecesBeforMove, piecesAferMove, "No deben haber las mismas piezas despues del movimiento");
        }

        [TestMethod]
        public void Player1WinBecauseHasLessPieces()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(1);
            var currentPlayer = domino.GetPlayerCurrentTurn();

            domino.GetTilesFromTheStack().Clear();
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(currentPlayer.GetTiles()[3]);
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(currentPlayer.GetTiles()[2]);

            var numberPlay = domino.GetWinnerPlayer();

            Assert.AreEqual(numberPlay, 1, "El jugador 1 debio ganar el Juego");
        }

        [TestMethod]
        public void Player2WinBecauseHasLessPieces()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            domino.SetPlayerTurn(2);
            var currentPlayer = domino.GetPlayerCurrentTurn();

            domino.GetTilesFromTheStack().Clear();
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(currentPlayer.GetTiles()[3]);
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(currentPlayer.GetTiles()[2]);

            var numberPlay = domino.GetWinnerPlayer();

            Assert.AreEqual(numberPlay, 2, "El jugador 2 debio ganar el Juego");
        }

        [TestMethod]
        public void PlayersTiedGame()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);

            
            domino.GetTilesFromTheStack().Clear();
            var numberPlay = domino.GetWinnerPlayer();

            Assert.AreEqual(numberPlay, -1, "Los jugadores debieron empatar el partido");
        }

        [TestMethod]
        public void SaveStadisticWhenPlayerWin()
        {
            var seed = Environment.TickCount;
            var mockWellRepository = new WellRepositoryMockSortRandom();
            var mockDominoRepository = new DominoRepositoryMockGame();
            var domino = new DominoGame(mockDominoRepository, mockWellRepository);

            var players = 2;

            domino.InitializeStack();
            domino.SetRandomOrderStackTiles(seed);
            domino.SetPlayersTiles(players);


            domino.GetTilesFromTheStack().Clear();
            domino.SetPlayerTurn(1);

            var currentPlayer = domino.GetPlayerCurrentTurn();
            domino.MoveCurrentPlayerTileAtTheEndOfTheStack(currentPlayer.GetTiles()[4]);

            var numberPlay = domino.GetWinnerPlayer();
            domino.SaveGameStatistics();


            Assert.AreNotEqual(numberPlay, -1, "Un jugador debio ganar el partido");
        }

    }
}
