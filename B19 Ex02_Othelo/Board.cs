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

        public int getTokenByMatrixCoordinate(Coordinates i_coordinates)
        {
            return m_Board[i_coordinates.Row, i_coordinates.Col];
        }

        public List<Coordinates> getCurrentLegalMovesArray(Player i_currentPlayer, Player i_otherPlayer)
        {
            List<Coordinates> o_LegalMovesArray = new List<Coordinates>(); ;

            for(int i = 1; i < m_BoardSize-1; i++)
            {
                for (int j = 1; j < m_BoardSize-1; j++)
                {
                    List<Coordinates> o_LegalSurroundingCoordinates = new List<Coordinates>();
                    Coordinates coordinateToCheck = new Coordinates(-1, -1);
                    Coordinates legalCoordinate = null;

                    coordinateToCheck.Row = i;
                    coordinateToCheck.Col = j;
                    if(m_Board[i,j] == (int)i_otherPlayer.Color)
                    {

                        if((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              1, 0, 0, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              1, 0, 1, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              0, 0, 1, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              0, 1, 1, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              0, 1, 0, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              0, 1, 0, 1)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              0, 0, 0, 1)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(
                                              coordinateToCheck,
                                              i_currentPlayer,
                                              i_otherPlayer,
                                              1, 0, 0, 1)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                    }
                }
            }

            i_currentPlayer.LegaLMovesCount = o_LegalMovesArray.Count;
            return o_LegalMovesArray;
        }

        private Coordinates getLegalCoordinateForDirection(Coordinates i_CoordinateToCheck,
                                         Player i_currentPlayer,
                                         Player i_otherPlayer,
                                         int N, int S, int E, int W)
        {
            Coordinates inDirection = new Coordinates(i_CoordinateToCheck.Row + (N + S),
                                                      i_CoordinateToCheck.Col + (E + W));
            Coordinates counterDirection = new Coordinates(i_CoordinateToCheck.Row - (N + S),
                                                           i_CoordinateToCheck.Col - (E + W));

            if (getTokenByMatrixCoordinate(inDirection) == 0 ||
                getTokenByMatrixCoordinate(counterDirection) != 0)
            {
                return null;
            }

            //////// check direction

            return counterDirection;
        }
}
/*  
 *  
 * 
 * public Board(int i_BoardSize)
 * public Board()
 * public void addToken(Player i_currentPlayer)
 * public void updatePoints()
 * public void restartBoard()
 * 
 * 
 * 
 */
