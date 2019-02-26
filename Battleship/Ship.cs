using System;
using System.Collections.Generic;

namespace Battleship
{
    /* 
     * Create ship and control if it has sunk.   
    */
    public class Ship
    {
       public IList<Position> positions;
     


        public Ship()
        {
            positions = new List<Position>();

        }



        public static Ship CreateShip(string startPosition, string endPosition, Board board)
        {
            int startColumn = Board.ConvertColumn(startPosition.Substring(0,1));
            int startRow = Board.ConvertRow(startPosition.Substring(1)); 

            int endColumn = Board.ConvertColumn(endPosition.Substring(0,1));
            int endRow = Board.ConvertRow(endPosition.Substring(1));


            bool isInBoard = board.IsInBoard(startColumn, startRow, endColumn, endRow);
            bool isCorrect= CheckShip(startColumn, startRow, endColumn, endRow);

            Ship ship = new Ship(); 

            if(isInBoard && isCorrect) 
            {
                ship.positions.Add(board.cells[startRow][startColumn]);
                board.cells[startRow][startColumn].Ship = ship;

                List<int> middelPositions = new List<int>( Position.GetMiddlePositions(startRow, startColumn, endRow, endColumn));
                if(middelPositions.Count > 0) { 
                    foreach(int p in middelPositions) {
                        if (endRow > startRow){
                            ship.positions.Add(board.cells[p][startColumn]);

                            board.cells[p][startColumn].Ship = ship;
                        }
                        else{
                            ship.positions.Add(board.cells[startRow][p]);
                            board.cells[startRow][p].Ship = ship;
                        }
                    }
                }
                ship.positions.Add(board.cells[endRow ][endColumn]);
            
                board.cells[endRow][endColumn].Ship = ship;  
            }
            return ship;
        }




        public static bool CheckShip(int startRow, int startColumn, int endRow, int endColumn) 
        {
            if (startRow == endRow){
                return true;
            }
            else if (startColumn == endColumn){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool HasSunk(string attackPosition, Board board) 
        {
            int attackColumn = Board.ConvertColumn(attackPosition.Substring(0, 1));
            int attackRow = Board.ConvertRow(attackPosition.Substring(1));
         
            int i = 0;
            foreach (Position position in board.cells[attackRow][attackColumn].Ship.positions) 
            {          
                if (position.Hit) {
                    i = i+1; 
                }
            }
                      

            if(i == board.cells[attackRow][attackColumn].Ship.positions.Count) {
                return true; 
            }
            else {
                return false;
            }
           
        }

        public static bool AllShipSunk (Board board)
        {
            foreach(Ship ship in board.ships) 
            {
                foreach(Position position in ship.positions) 
                {
                    if (!position.Hit) 
                    {
                        return false; 
                    }
                }

            }
            return true;
        }

    }
}
