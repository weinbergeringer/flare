using NUnit.Framework;
using System;
namespace Battleship
{
    [TestFixture()]
    public class BoardTest
    {
        [Test()]
        public void TestIsInBoard() 
        {
            Board Board = new Board();

            bool result = Board.IsInBoard(1, 2, 2, 4);
            Assert.IsTrue(result);

            result = Board.IsInBoard(1, 11, 2, 2);
            Assert.IsFalse(result);

        }

        [Test()]
        public void TestIsInBoardEndColumnIsSmallerThanStartColumn()
        {
            Board Board = new Board();

            bool result = Board.IsInBoard(1, 2, 1, 1);
            Assert.IsFalse(result);
        }

        [Test()]
        public void TestIsInBoardEndRowIsSmallerThanStartRow()
        {
            Board Board = new Board();

            bool result = Board.IsInBoard(2, 1, 1, 1);
            Assert.IsFalse(result);
        }
    }
}
