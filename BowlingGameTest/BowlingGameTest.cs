using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTest
{
    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void TestAllZeroHitsGame()
        {
            var game = SetUp();
            RollDownPins(game,20, 0);
            Assert.AreEqual(0,game.Score());
        }

  
        [TestMethod]
        public void TestOnePinPerRoll()
        {
            var game = SetUp();
            RollDownPins(game, 20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            var game = SetUp();
            RollSpare(game);
            game.Roll(3);

            RollDownPins(game, 17, 0);
            Assert.AreEqual(16, game.Score());
        }

       
        [TestMethod]
        public void TestOneStrike()
        {
            var game = SetUp();
            RollStrike(game);
            game.Roll(3);
            game.Roll(4);
            RollDownPins(game, 16, 0);
            Assert.AreEqual(24, game.Score());
        }

        [TestMethod]
        public void TestAllStrike()
        {
            var game = SetUp();
       
            RollDownPins(game, 12, 10);
            Assert.AreEqual(300 , game.Score());
        }
      

        #region Private Methods

        private Game SetUp()
        {
            return new Game();
        }

        private void RollDownPins(Game game, int numberofRolls, int pinsHitperRoll)
        {
            for (int i = 0; i < numberofRolls; i++)
            {
                game.Roll(pinsHitperRoll);
            }
        }

        private void RollSpare(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike(Game game)
        {
            game.Roll(10);
        }

        #endregion

    }
}
