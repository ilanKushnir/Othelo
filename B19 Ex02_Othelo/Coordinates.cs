using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Coordinates
    {
        public int      m_Row = -1;
        public int      m_Col = -1;

        public Coordinates(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
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


    }
}