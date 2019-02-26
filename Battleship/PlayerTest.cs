using NUnit.Framework;
using System;
namespace Battleship
{
    [TestFixture()]
    public class PlayerTest
    {


        [Test()]
        public void TestAttack()
        {

            Board board = new Board();
            Ship ship = new Ship();
            ship.positions.Add(board.cells[0][1]);
            board.cells[0][1].Ship = ship;

            // Hit
            bool result = Player.Attack("B1", board);
            Assert.IsTrue(result);

            //No hit
            result = Player.Attack("A1", board);
            Assert.IsFalse(result);

            result = Player.Attack("A10", board);
            Assert.IsFalse(result);

        }
    }
}
