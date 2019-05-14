using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Game
    {
        public Player       m_Player1 = null;               
        public Player       m_Player2 = null;
        public Player       m_CurrentPlayer = null;        
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
            startGame();
        }

        public void startGame()
        {
            List<Coordinates> legalCoordinates;
            Coordinates playerCoordinates;
            string coordinatesStr;
            bool isCoordinatesInArray;

            while (isGameOver() == false)
            {
                Player otherPlayer = (m_CurrentPlayer == m_Player1) ? m_Player2 : m_Player1;
                legalCoordinates = m_gameBoard.getCurrentLegalMovesArray(m_CurrentPlayer, otherPlayer);      // check available options for next move
                m_CurrentPlayer.LegalMovesCount = legalCoordinates.Count;

                if(m_CurrentPlayer.LegalMovesCount == 0)                                        // if no available moves the other player takes the turn
                {
                    switchPlayer();
                }

                m_gameBoard.addCurrentLegalMovesToBoard(legalCoordinates);
                Display.updateUI("{0}, Please choose cell in the following format: \n{Row number},{Col letter}" + m_CurrentPlayer.Name, m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
                coordinatesStr = Console.ReadLine();
                playerCoordinates = Coordinates.parseCoordinates(coordinatesStr);
                isCoordinatesInArray = Coordinates.foundCoordinatesInArray(playerCoordinates, legalCoordinates);

                while (playerCoordinates.isLegalCoordinate(m_gameBoard.Size) == false || isCoordinatesInArray == false)      // check player coordinates validity
                {
                    Display.updateUI("illegal cell choice, Please choose again using format: \n{Row number},{Col letter}", m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
                    coordinatesStr = Console.ReadLine();
                    playerCoordinates = Coordinates.parseCoordinates(coordinatesStr);
                }

                m_gameBoard.addToken(m_CurrentPlayer, playerCoordinates);       // mark chosen cell on board
                switchPlayer();
            }

            endGame();
        }

        public bool isGameOver()
        {
            if((m_Player1.LegalMovesCount == 0 && m_Player2.LegalMovesCount == 0) || m_gameBoard.BoardFull)
            {
                return true;
            }

            return false;
        }

        public void endGame()            
        {
            bool restartGame = false;
            Player winningPlayer;

            if (m_Player1.Points > m_Player2.Points)
            {
                winningPlayer = m_Player1;
            }
            else if(m_Player1.Points == m_Player2.Points)
            {
                winningPlayer = null;
            }
            else
            {
                winningPlayer = m_Player2;
            }

            restartGame = Display.printEndGame(winningPlayer, m_Player1, m_Player2.IsBot);

            if(restartGame == true)
            {
                this.restartGame(winningPlayer);
            }
        }

        public void restartGame(Player i_WinningPlayer)
        {
            int boardSize = m_gameBoard.Size;

            Ex02.ConsoleUtils.Screen.Clear();
            m_gameBoard = new Board(boardSize);         // restart board
            m_CurrentPlayer = i_WinningPlayer;
            m_Player1.Points = 0;                       // restart players information
            m_Player1.LegalMovesCount = 0;
            m_Player2.Points = 0;
            m_Player2.LegalMovesCount = 0;
            Display.updateUI("New game! {0} takes first turn" + i_WinningPlayer, m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
            this.startGame();
        }

        private void switchPlayer()
        {
            if (m_CurrentPlayer == m_Player1)
            {
                m_CurrentPlayer = m_Player2;
            }
            else
            {
                m_CurrentPlayer = m_Player1;
            }
        }
    }
}

/* 
 * 
 * public Game()
 * public void startGame()
 * public bool isGameOver()
 * public void endGame()
 * public void restartGame()
 * 
 */
