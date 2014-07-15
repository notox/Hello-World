using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
    public class StoneGame
    {
        public string Play(int[] stones)
        {
            const string win = "Win";
            const string lost = "Lost";

            if (stones.Length%2 == 1)
            {
                if (stones.All(stone => stone == 1))
                {
                    return win;
                }
                return lost;
            }
            else
            {
                if (stones.All(stone => stone == 1))
                {
                    return lost;
                }
                return win;
            }

            return lost;
        }
    }

    [TestClass]
    public class StoneGameTest
    {
        readonly StoneGame game = new StoneGame();

        [TestMethod]
        public void OneOneWin()
        {
            var actual = game.Play(new[] {1});
            Assert.AreEqual("Win", actual);
        }

        [TestMethod]
        public void TwoOneOneLost()
        {
            var actual = game.Play(new[] { 1, 1 });
            Assert.AreEqual("Lost", actual);
        }

        [TestMethod]
        public void TwoTwoOneWin()
        {
            var actual = game.Play(new[] { 2, 1 });
            Assert.AreEqual("Win", actual);
        }

        [TestMethod]
        public void TwoTwoTwoLost()
        {
            var actual = game.Play(new[] { 2, 2 });
            Assert.AreEqual("Lost", actual);
        }

        [TestMethod]
        public void TwoThreeTwoWin()
        {
            var actual = game.Play(new[] { 3, 2 });
            Assert.AreEqual("Win", actual);
        }

        [TestMethod]
        public void ThreeOneOneOneWin()
        {
            var actual = game.Play(new[] { 1, 1, 1 });
            Assert.AreEqual("Win", actual);
        }

        [TestMethod]
        public void ThreeTwoOneOneWin()
        {
            var actual = game.Play(new[] { 2, 1, 1 });
            Assert.AreEqual("Win", actual);
        }

        [TestMethod]
        public void ThreeTwoTwoOneWin()
        {
            var actual = game.Play(new[] { 2, 2, 1 });
            Assert.AreEqual("Win", actual);
        }

        //[TestMethod]
        //public void ThreeTwoTwoTwoWin()
        //{
        //    var actual = game.Play(new[] { 2, 2, 2 });
        //    Assert.AreEqual("Win", actual);
        //}
    }
}