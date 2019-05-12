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
            ilanMethod(out m_Player1, out m_Player2);       // player1 --> ePlayerColor.Black

            m_Player1 = new Player(name1, ePlayerColor.Black);
            m_Player2 = new Player(name2, ePlayerColor.White);
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
 * 
