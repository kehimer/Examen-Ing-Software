
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Domino.Logic.Interfaces;
using Domino.Logic.Logic;

namespace Domino
{
    class DrawnGame : IDrawnGame
    {
        private readonly IDominoGameRepository _dominoGame;
        private IPlayerRepository _playerRepository;
        private readonly IStackRepository _stackRepository;

        public DrawnGame(IDominoGameRepository dominoGame, IPlayerRepository playerRepository, IStackRepository stackRepository)
        {
            _dominoGame = dominoGame;
            _playerRepository = playerRepository;
            _stackRepository = stackRepository;
        }

        public void InitGame()
        {
            _stackRepository.SetInitialTiles();
            _stackRepository.SetRandomOrder(6);
            _dominoGame.SetPlayerTile(1);
            _dominoGame.SetPlayerTile(2);
            var firstPlayer = _dominoGame.GetPlayerWithDoubleGreaterTile();
            Tile greaterTile;
            if (firstPlayer != null)
            {
                Console.WriteLine("Comienza el jugador numero " + firstPlayer.GetNumber());
                greaterTile = _dominoGame.GetDoubleGreaterTile(firstPlayer.GetNumber());
            }
            else
            {
                firstPlayer = _dominoGame.GetPlayerWithMaxSumTile();
                Console.WriteLine("Comienza el jugador numero " + firstPlayer.GetNumber());
                greaterTile = _dominoGame.GetTileWithMaxSum(firstPlayer.GetNumber());
            }
            _dominoGame.SetTileAtTheBeginingOfTheStack(greaterTile);
            PrintStack(_dominoGame.GetCurrentTableStack());
        }

        private void PrintPlayerTiles(int numberPlayer)
        {
            Console.WriteLine("Piezas del jugador " + numberPlayer);
            var playerTiles = _dominoGame.GetPlayerTiles(numberPlayer);
            PrintStack(playerTiles);
        }

        private void PrintStack(List<Tile> stack)
        {
            foreach (var tile in stack)
            {

                Console.WriteLine(tile.SideOne + " | " + tile.SideTwo);
            }
        }

        private void PrintWinnerPlayer(int winnerPlayer)
        {
            Console.WriteLine("El jugador " + winnerPlayer + " ha ganado");
        }

        public void Render()
        {
            InitGame();

            var winner = -1;
            do
            {
                winner = _dominoGame.GetWinnerPlayer();
                if (winner != -1)
                {
                    PrintWinnerPlayer(winner);
                    return;
                }
                _dominoGame.SetPlayerTurn(_dominoGame.GetNextTurnPlayer());
                Console.WriteLine("Es turno del jugador: " + _dominoGame.GetCurrentTurnPlayer());
                PrintPlayerTiles(_dominoGame.GetCurrentTurnPlayer());
                Console.WriteLine("Elija la pieza a utilizar: ");
                var side1 = Console.Read();
                var side2 = Console.Read();
                Console.WriteLine("Donde desea colocar la pieza? 1.Principio | 2. Final ");
                var place = Console.Read();
                if(place == 1)
                    _dominoGame.SetTileAtTheBeginingOfTheStack(_dominoGame.GetTile(_dominoGame.GetCurrentTurnPlayer(), side1, side2));
                else
                    _dominoGame.SetTileAtTheEndOfTheStack(_dominoGame.GetTile(_dominoGame.GetCurrentTurnPlayer(), side1, side2));
            } while (winner == -1);
        }
    }
}
