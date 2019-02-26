using System;
using System.Collections.Generic;
namespace Battleship
{
    /* Contains all of the cells that makes up a board and the ships.
     */   
    public class Board
    {   
        public IList<IList<Position>> cells;
        public IList<Ship> ships;

        readonly int numberOfColumns = 10;
        readonly int numberOfRows = 10;


        public static Dictionary<string, int> lettersMapping = new Dictionary<string, int>(){
        {"A",0},{"B",1},{"C",2},{"D",3},{"E",4},{"F",5},{"G",6},{"H",7},{"I",8},{"J",9}
        };

        public static int ConvertColumn(string letter)
        {

            int number = Board.lettersMapping[letter];
            return number;
        }

        public static int ConvertRow(string number)
        {
            return Convert.ToInt32(number) - 1 ;
        }

        public Board()
        {
            ships = new List<Ship>();
            cells = new List<IList<Position>>();

            for(int i = 0; i< numberOfRows; i++) 
            {
                IList<Position> row = new Position[10];

                for(int j = 0; j < numberOfColumns; j++) {
                    row[j] = new Position(i,j,false);

                }

                cells.Add(row);

            }
        }

        public bool IsInBoard(int startRow, int startColumn, int endRow, int endColumn)
        {
            if (!IsRowCorrect(startRow, endRow))
            {
                return false;
            }
            else if (!IsColumnCorrect(startColumn, endColumn))
            {
                return false;
            }
            return true;
        }

        public IList<Ship> Ships
        {
            get
            {
                return ships;
            }
            set
            {
                ships = value;
            }
        }

        private bool IsColumnCorrect(int startColumn, int endColumn)
        {
            if (startColumn < 0 || startColumn > numberOfColumns || endColumn < 0 || endColumn > numberOfColumns || endColumn < startColumn)
            {
                return false;
            }
            return true;
        }

        private bool IsRowCorrect(int startRow, int endRow)
        {
            if (startRow < 0 || startRow > numberOfRows || endRow < 0 || endRow > numberOfRows || endRow < startRow)
            {
                return false;
            }
            return true;
        }
    }
}
