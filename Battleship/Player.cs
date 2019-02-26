using System;
using System.Collections.Generic;

namespace Battleship
{
    /* 
     * Contains player's Board and ship. Also execute any attack.
    */
    public class Player
    {
        Board board;
        IList<Ship> ships;


        public Player()
        {
            board = new Board();
            ships = new List<Ship>();
        }

        public void AddBattleship(string startPosition, string endPosition) 
        {
            Ship myShip = Ship.CreateShip(startPosition , endPosition, board);

            ships.Add(myShip);
            board.ships.Add(myShip);
        
        }

        public String ResolveAttack(string attackPosition) 
        {
            String result;

            if(Attack(attackPosition, board)) 
            {
                result = "Hit!";

                if (Ship.HasSunk(attackPosition, board)) 
                {
                    result += "\nYour ship has sunk";
                }

                if (Ship.AllShipSunk(board))
                {
                    result = "\nAll your ship has sunk and you have lost";
                }
            }
            else 
            {
                result = "Miss!";
            }
            return result;
        }

        public static bool Attack(string attackPosition, Board board)
        {
            int attackColumn = Board.ConvertColumn(attackPosition.Substring(0, 1));
            int attackRow = Board.ConvertRow(attackPosition.Substring(1));
            bool hit = false;

            if (board.cells[attackRow][attackColumn].Ship != null)
            {
                board.cells[attackRow][attackColumn].Hit = true;
                hit = true;
            }


            return hit;
        }


    }
}
