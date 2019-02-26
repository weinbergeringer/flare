using System;
using System.Collections.Generic;

namespace Battleship
{
    /* 
     * Contains all information for a position such as row, column and if it has been hit.
    */
    public class Position
    {

        Ship ship;
        int row;
        int column;
        bool hit;

        public Position(int row, int column, bool hit)
        {
            Row = row;
            Column = column;
            Hit = hit;
        }

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public Ship Ship { get => ship; set => ship = value; }
        public bool Hit { get => hit; set => hit = value; }

        public static IList<int> GetMiddlePositions(int startRow, int startColumn, int endRow, int endColumn)
        {
            IList<int> middlePositios = new List<int>();

            if (endRow == startRow && endColumn == startColumn)
            {
                return middlePositios;
            }
            else if (endRow > startRow)
            {
                if (startRow == 0)
                {
                    for (int i = 0; i < endRow - 1; i++)
                    {
                        middlePositios.Add(i + 1);
                    }
                }
                else
                {
                    for (int i = 1; i < endRow - startRow; i++)
                    {
                        middlePositios.Add(startRow + i);
                    }
                }
            }
            else if (endColumn > startColumn)
            {
                if (startColumn == 0)
                {
                    for (int i = 0; i < endColumn - 1; i++)
                    {
                        middlePositios.Add(i + 1);
                    }
                }
                else
                {
                    for (int i = 1; i < endColumn - startColumn; i++)
                    {
                        middlePositios.Add(startColumn + i);
                    }
                }
            }
            return middlePositios;
        }
    }
}
