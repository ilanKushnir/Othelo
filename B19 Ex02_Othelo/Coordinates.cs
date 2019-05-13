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

        public static bool foundCoordinatesInArray(Coordinates i_Coordinates, Coordinates [] i_CoordinatesArray)
        {
            Coordinates FoundCoordinates;
            FoundCoordinates = Array.Find(i_CoordinatesArray, c => c.m_Row == i_Coordinates.m_Row && c.m_Col == i_Coordinates.m_Col);
            return FoundCoordinates.m_Col == i_Coordinates.m_Col && FoundCoordinates.m_Row == i_Coordinates.m_Row ;
        }

        public static Coordinates parseCoordinates(string i_coordinatesStr)    //////////////////////////////
        {
            Coordinates o_Coordinates = null;
            return o_Coordinates;
        }



    }
}