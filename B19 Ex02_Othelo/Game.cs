using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    public class Game
    {
        public Player m_Player1 = null;               
        public Player m_Player2 = null;
        public Player m_CurrentPlayer = null;        
        public Board m_gameBoard;

        public Game()
        {
            string player1Name, player2Name;
            int boardSize;
            bool isMultiplayer;

            Display.initGame(out player1Name, out player2Name, out boardSize, out isMultiplayer);   
            m_Player1 = new Player(player1Name, ePlayerColor.Black, false);
            m_Player2 = new Player(player2Name, ePlayerColor.White, !isMultiplayer);
            m_gameBoard = new Board(boardSize);
            m_CurrentPlayer = m_Player1;
            Display.updateUI("Game is set, please wait a second", m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
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

                // if no available moves the other player takes the turn
                if (m_CurrentPlayer.LegalMovesCount == 0)
                { 
                    switchPlayer();
                    legalCoordinates = m_gameBoard.getCurrentLegalMovesArray(m_CurrentPlayer, otherPlayer);      // check available options for next move
                    m_CurrentPlayer.LegalMovesCount = legalCoordinates.Count;
                }

                m_gameBoard.addCurrentLegalMovesToBoard(legalCoordinates);

                // if its computer's turn on single player
                if (m_Player2.IsBot == true && m_CurrentPlayer == m_Player2)
                {
                    Display.updateUI("Computer's turn." + Environment.NewLine + "choosing coordinates...", m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
                    RandomWait(1, 3);
                    Random random = new Random();
                    int randomCoordinateIndex = random.Next(legalCoordinates.Count);
                    playerCoordinates = legalCoordinates[randomCoordinateIndex];
                }
                else
                {
                    Display.updateUI(m_CurrentPlayer.Name + " , Please choose cell in the following format: \n{Row number},{Col letter}", m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
                    coordinatesStr = Console.ReadLine();

                    // if user asked to quit game
                    if (coordinatesStr[0] == 'q' || coordinatesStr[0] == 'Q') 
                    {
                        endGame();
                    }

                    playerCoordinates = Coordinates.parseCoordinates(coordinatesStr);
                    isCoordinatesInArray = Coordinates.foundCoordinatesInArray(playerCoordinates, legalCoordinates);

                    // check player coordinates validity
                    while (isCoordinatesInArray == false || playerCoordinates.isLegalCoordinate(m_gameBoard.Size) == false)      
                    {
                        Display.updateUI("illegal cell choice, Please choose again using format: \n{Row number},{Col letter}", m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
                        coordinatesStr = Console.ReadLine();
                        playerCoordinates = Coordinates.parseCoordinates(coordinatesStr);
                        isCoordinatesInArray = Coordinates.foundCoordinatesInArray(playerCoordinates, legalCoordinates);
                    }
                }

                m_gameBoard.addToken(m_CurrentPlayer, otherPlayer, playerCoordinates);       // mark chosen cell on board
                updatePoints();
                Display.updateUI(string.Empty, m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
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
            m_CurrentPlayer = i_WinningPlayer == null ? m_Player1 : i_WinningPlayer;
            m_Player1.Points = 0;                       // restart players information
            m_Player1.LegalMovesCount = -1;
            m_Player2.Points = 0;
            m_Player2.LegalMovesCount = -1;
            Display.updateUI("New game! {0} takes first turn" + m_CurrentPlayer, m_CurrentPlayer, m_Player1, m_Player2, m_gameBoard);
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

        private void updatePoints()
        {
            int black = 0;
            int white = 0;

            for(int i = 0; i < m_gameBoard.Size; i++)
            {
                for (int j = 0; j < m_gameBoard.Size; j++)
                {
                    if(m_gameBoard.getTokenByMatrixCoordinate(i, j) == 1)
                    {
                        black++;
                    }

                    if (m_gameBoard.getTokenByMatrixCoordinate(i, j) == -1)
                    {
                        white++;
                    }
                }
            }

            m_Player1.Points = m_Player1.Color.Equals(ePlayerColor.Black) ? black : white;
            m_Player2.Points = m_Player2.Color.Equals(ePlayerColor.Black) ? black : white;

            if (black + white == m_gameBoard.Size * m_gameBoard.Size)
            {
                m_gameBoard.BoardFull = true;
            }
        }

        public void RandomWait(int minWait, int maxWait)
        {
            Console.WriteLine("Computer is thinking......");
            Random random = new Random();
            int miliSecondsToWait = random.Next(minWait, maxWait);
            System.Threading.Thread.Sleep(miliSecondsToWait * 1000);
        }
    }
}