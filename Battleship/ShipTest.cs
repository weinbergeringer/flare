using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Battleship
{
    [TestFixture]
    public class ShipTest
    {


        [Test()]
        public void TestCheckShip()
        {
            bool result = Ship.CheckShip(1, 2, 1, 3);
            Assert.IsTrue(result);

            result = Ship.CheckShip(4, 2, 1, 3);
            Assert.IsFalse(result);
        }


        [Test()]
        public void TestHasSunk() 
        {
            Board board = new Board();
            Ship ship = new Ship();

            //Sunk
            ship.positions.Add(board.cells[0][1]);
            board.cells[0][1].Ship = ship;
            board.ships.Add(ship);
            board.cells[0][1].Hit = true;

            bool result = Ship.HasSunk("B1", board);
            Assert.IsTrue(result);

            //Not sunked
            ship.positions.Add(board.cells[0][0]);
            board.cells[0][0].Ship = ship;
            ship.positions.Add(board.cells[1][0]);
            board.cells[1][0].Ship = ship;
            board.ships.Add(ship);
            board.cells[0][0].Hit = true;
            result = Ship.HasSunk("A1", board);
            Assert.IsFalse(result);
        }

        [Test()]
        public void TestCreateShip ()
        {
            Board board = new Board();
            Ship result = Ship.CreateShip("A1", "B1", board);

            Assert.IsTrue(result.positions[0].Row == 0);
            Assert.IsTrue(result.positions[0].Column == 0);
            Assert.IsTrue(result.positions[1].Row == 0);
            Assert.IsTrue(result.positions[1].Column == 1);
            Assert.IsTrue(result.positions.Count == 2);
        }

        [Test()]
        public void TestAllShipSunk() 
        {
            Board board = new Board();
            Ship ship = new Ship();

            //All Sunk
            ship.positions.Add(board.cells[1][1]);
            board.cells[1][1].Ship = ship;
            board.ships.Add(ship);
            board.cells[1][1].Hit = true;

            ship.positions.Add(board.cells[0][0]);
            board.cells[0][0].Ship = ship;
            board.ships.Add(ship);
            board.cells[0][0].Hit = true;

            bool result = Ship.AllShipSunk(board);

            Assert.IsTrue(result);

            //Not All Sunk
            ship.positions.Add(board.cells[2][2]);
            board.cells[2][2].Ship = ship;
            board.ships.Add(ship);
            board.cells[2][2].Hit = true;

            ship.positions.Add(board.cells[3][3]);
            board.cells[3][3].Ship = ship;
            board.ships.Add(ship);

            result = Ship.AllShipSunk(board);

            Assert.IsFalse(result);


        }
    }
}
