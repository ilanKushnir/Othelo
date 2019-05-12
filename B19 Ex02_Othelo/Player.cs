using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace B19_Ex02_Othelo
{
    enum ePlayerColor
    {
        White = -1,
        Black = 1
    }

    class Player
    {

        public string       m_Name = null;
        public int          m_Points = 0;
        ePlayerColor        m_Color;

        public Player(string i_Name, ePlayerColor i_Color)
        {
            m_Name = i_Name;
            m_Color = i_Color;
        }

        public int Points
        {
            get
            {
                return m_Points;
            }
            set
            {
                m_Points = value;
            }
        }
    }
}

/*
 * enum ePlayerColor
 * 
 * private String m_Name
 * private int points
 * 
 * public Player()
 * 
 * public String Name // set & get
 * public int Points // set & get
 * 
 */
