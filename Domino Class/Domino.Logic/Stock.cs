using System.Collections.Generic;

namespace Domino.Logic
{
    public class Stock
    {

        private IRandom _random;
        public Stock(IRandom random)
        {
            _random = random;
            Tiles = GetInitialSetOfTiles();
        }

        public static List<Tile> GetInitialSetOfTiles()
        {
            List<Tile> initialTiles = new List<Tile>();
            
            const int maxValue = 6;
            for (int headValue = 0; headValue <= maxValue; headValue++)
            {
                for (int tailValue = headValue; tailValue <= maxValue; tailValue++)
                {
                    var currentTile = new Tile {Head = headValue, Tail = tailValue};
                    initialTiles.Add(currentTile);
                }
            }

            return initialTiles;
        }

        public List<Tile> Tiles { get; set; }

        public void Shuffle(int swapsAmount)
        {
            for (int i = 0; i < swapsAmount; i++)
            {
                SwapTilesRandomly();
            }
        }

        private void SwapTilesRandomly()
        {
            int posTile1 = _random.GetRandomPosition();
            int posTile2 = _random.GetRandomPosition();

            var temp = Tiles[posTile1];
            Tiles[posTile1] = Tiles[posTile2];
            Tiles[posTile2] = temp;
        }
    }
}