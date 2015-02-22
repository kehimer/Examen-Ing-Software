using System;
using Domino.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Domino.Tests
{
    [TestClass]
    public class StockTests
    {
        
        private delegate int RandomPositionDelegate(); 

        [TestMethod]
        public void ShuffleTiles()
        {
            var random = MockRepository.GenerateMock<IRandom>();
            var randomSerie = new int[]{3,0,4,7,10,20};
            var randomSerieIndex = 0;
            
            RandomPositionDelegate randomFunction = () =>
            {
                var value=randomSerie[randomSerieIndex];
                randomSerieIndex++;
                return value;
            };

            random.Stub(x => x.GetRandomPosition()).Do((randomFunction));
            var stock = new Stock(random);
            stock.Shuffle(3);
            var expectedTileSet = StockFactory.GenerateShuffledTilesSample();
            CollectionAssert.AreEqual(expectedTileSet,stock.Tiles);

        }
    }
}
