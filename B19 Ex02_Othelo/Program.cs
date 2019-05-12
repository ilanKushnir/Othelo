using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Program
    {
        public static void Main()
        {
            Coordinates[] legalCoordinates = { new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(3,3) };
            Coordinates playerCoordinates = new Coordinates(3, 3);
            Coordinates x = Array.Find(legalCoordinates, c => c.m_Row == playerCoordinates.m_Row && c.m_Col == playerCoordinates.m_Col);
            Console.WriteLine(x.m_Col == playerCoordinates.m_Col && x.m_Row == playerCoordinates.m_Row);
            //Game x = new Game();
        }

    }
}
