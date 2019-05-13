using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Board
    {
        private int m_BoardSize = 0;
        private int[,] m_Board = null;
        private bool m_BoardIsFull = false;

        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_Board = new int[i_BoardSize, i_BoardSize];

            // init middle tokens
            m_Board[(m_BoardSize / 2) - 1, (m_BoardSize / 2) - 1] = -1;
            m_Board[m_BoardSize / 2, m_BoardSize / 2] = -1;
            m_Board[(m_BoardSize / 2) - 1, m_BoardSize / 2] = 1;
            m_Board[m_BoardSize / 2, (m_BoardSize / 2) - 1] = 1;
        }

        public int Size
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public bool BoardFull
        {
            get
            {
                return m_BoardIsFull;
            }
        }


        public int getTokenByMatrixCoordinate(int i_row, int i_col)
        {
            return m_Board[i_row, i_col];
        }
        public Coordinates[] getLegalCurrentMovesArray(Player x) { return null; }

        public void addToken(Player i_currentPlayer, Coordinates coor) { }

    }
}
/*  
 *  
 * 
 * public Board(int i_BoardSize)
 * public Board()
 * public Coordinates[] getLegalCoordinates(Player i_currentPlayer)
 * public void addToken(Player i_currentPlayer, coor)
 * public void updatePoints()
 * public void restartBoard()
 * 
 * 
 * 
 */
