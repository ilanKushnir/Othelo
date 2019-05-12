using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Game
    {
        Player       m_Player1 = null;
        Player       m_Player2 = null;
        Player       m_CurrentPlayer = null;
        int          m_Player1LegalMovesCount = 0;
        int          m_Player2LegalMovesCount = 0;

        public Game()
        {
            
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
