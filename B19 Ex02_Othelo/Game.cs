using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Game
    {
        public Player       m_Player1 = null;               // allways Black & takes first turn!
        public Player       m_Player2 = null;
        public Player       m_CurrentPlayer = null;         // ref??
        private int         m_Player1LegalMovesCount = 0;
        private int         m_Player2LegalMovesCount = 0;
        Board               m_gameBoard;

        public Game()
        {
            string player1Name, player2Name;
            int boardSize;
            bool isMultiplayer;

            Display.initGame(out player1Name, out player2Name, out boardSize, out isMultiplayer);   
            m_Player1 = new Player(player1Name, ePlayerColor.Black, false);
            m_Player2 = new Player(player2Name, ePlayerColor.White, isMultiplayer);
            m_gameBoard = new Board(boardSize);
            m_CurrentPlayer = m_Player1;
            Display.updateUI("asdfasfd", m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
        }

        public void startGame()
        {

        }



        public bool isGameOver()
        {
            if(m_Player1LegalMovesCount == 0 && m_Player2LegalMovesCount == 0 && m_gameBoard.m_BoardIsFull)
            {
                return true;
            }

            return false;
        }

        public void endGame()                                       ///////////////////
        {
            if(m_CurrentPlayer.Equals(m_Player1))
            {
                if(m_Player1LegalMovesCount == 0)
                {
                    m_CurrentPlayer = m_Player2;
                }
            }
            if (m_CurrentPlayer.Equals(m_Player2))
            {
                if (m_Player2LegalMovesCount == 0)
                {
                    m_CurrentPlayer = m_Player1;
                }
            }

        }

        public void restartGame()
        {
            Ex02.ConsoleUtils.Screen.Clear();


        }
    }
}

/* Player m_Player1
 * Player m_Player2
 * Player m_CurrentPlayer
 * int m_Player1LegalMovesCount
 * int m_Player2LegalMovesCount
 * Board m_gameBoard
 * 
 * public Game()
 * public void startGame()
 * public bool isGameOver()
 * public void endGame()
 * public void restartGame()
 * 
 */
