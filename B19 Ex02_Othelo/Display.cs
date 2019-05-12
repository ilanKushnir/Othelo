using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Display
    {
        public static void printUI(string message,Player currentPlayer, Player player1, Player player2, Board gameBoard)
        {
            printTitle();
            printDivider(gameBoard.Size);
            printMessage(message);
            printDivider(gameBoard.Size);
            printStats(currentPlayer, player1, player2);
            printDivider(gameBoard.Size);
            printBoard(gameBoard);
            printDivider(0);
            // input goes here
        }
        public static void printDivider(int boardSize = 0)
        {
            if (boardSize != 0)
            {
                Console.Write("--");
                for (int i = 0; i < boardSize; i++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine();
            }
        }
        public static void printTitle()
        {
            Console.WriteLine("Welcome to Othelo game! - by Ofir & Ilan");
        }
        public static void printMessage(string message)
        {
            Console.WriteLine("Message: {0}", message);
        }
        public static void printStats(Player currentPlayer, Player player1, Player player2)
        {
            Console.WriteLine("Turn: {0}, Player 1: {1}, Player 2: {2}", currentPlayer.Name, player1.Points, player2.Points);
        }
        public static void printBoard(Board i_Board)
        {
            int i, j, k, boardSize = i_Board.Size;
            char charToPrint = 'A';

            // Top line (Char coordinates)
            Console.Write("   ");
            for (i = 0; i < boardSize; i++)
            {
                Console.Write(" {0}  ", charToPrint++);
            }
            Console.WriteLine();
            Console.Write("  =");
            for (i = 0; i < boardSize; i++)
            {
                Console.Write("====");
            }
            Console.WriteLine();

            // Counted lines section
            for(i = 0; i < boardSize; i++)
            {
                Console.Write("{0} ", i);
                for (j = 0; j < boardSize; j++)
                {
                    Console.Write("|   ");
                }
                Console.WriteLine("|");

                Console.Write("  ");
                for (k = 0; k < boardSize; k++)
                {
                    Console.Write("====");
                }
                Console.WriteLine("=");
            }

        }
        public static void updateUI(string message, Player currentPlayer, Player player1, Player player2, Board gameBoard)
        {
            // Delay if bot's turn
            Ex02.ConsoleUtils.Screen.Clear();                   // Clear screen
            printUI(message, currentPlayer, player1, player2, gameBoard);
        }
    }
} 
