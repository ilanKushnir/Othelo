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
        public bool m_BoardIsFull = false;

        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
        }

        public int Size
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }
/*
        public Coordinates[] getLegalCoordinates(Player i_currentPlayer) { }
        public void addToken(Player i_currentPlayer) { }
        public void updatePoints() { }
        public void restartBoard() { }
        */

    }
}
/*  
 *  
 * 
 * public Board(int i_BoardSize)
 * public Board()
 * public Coordinates[] getLegalCoordinates(Player i_currentPlayer)
 * public void addToken(Player i_currentPlayer)
 * public void updatePoints()
 * public void restartBoard()
 * 
 * 
 * 
 */
