using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Coordinates
    {
        int      m_Row = -1;
        int      m_Col = -1;

        public Coordinates(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        public int Row
        {
            get
            {
                return m_Row;
            }
            set
            {
                m_Row = value;
            }
        }

        public int Col
        {
            get
            {
                return m_Col;
            }
            set
            {
                m_Col = value;
            }
        }

        public static bool isLegalCoordinate(int i_Row, int i_Col, int i_BoardSize)
        {
            if(i_Row < 0 || i_Row > i_BoardSize - 1)
            {
                return false;
            }
            else if(i_Col < 0 || i_Col > i_BoardSize - 1)
            {
                return false;
            }

            return true;
        }

        public bool isLegalCoordinate(int i_BoardSize)
        {
            return isLegalCoordinate(m_Row, m_Col, i_BoardSize);
        }

        public static bool foundCoordinatesInArray(Coordinates i_Coordinates, List<Coordinates> i_CoordinatesArray)
        {
            foreach(Coordinates coordinate in i_CoordinatesArray)
            {
                if(coordinate.m_Row == i_Coordinates.m_Row && coordinate.m_Col == i_Coordinates.m_Col)
                {
                    return true;
                }
            }

            return false;
        }

        public static Coordinates parseCoordinates(string i_coordinatesStr)    
        {
            Coordinates o_Coordinates = null;
            int rowValue, collValue;
            char row, coll;

            row = i_coordinatesStr[0];
            rowValue = row - '0' - 1;

            if (i_coordinatesStr.Length > 2)
            {
                coll = i_coordinatesStr[2];
            }
            else
            {
                coll = i_coordinatesStr[1];
            }

            if(coll >= 'A' && coll <= 'H')
            {
                collValue = coll - 'A';
            }
            else if(coll >= 'a' && coll <= 'h')
            {
                collValue = coll - 'a';
            }
            else
            {                                    // assuming that board measures issue (6*6 instead 8*8) or illegal value will be taken care of in 'isLegalCoordinate'
                collValue = coll - '0' - 1;

            }

            o_Coordinates = new Coordinates(rowValue, collValue);
            return o_Coordinates;
        }



    }
}