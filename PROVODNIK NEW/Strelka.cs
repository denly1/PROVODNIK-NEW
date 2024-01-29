using System;
using System.Collections.Generic;
using System.Text;

namespace Provodnik
{
    public class Arrow
    {

        public int upperBound = 2;
        public int bottomBound;
        public int max;

        public Arrow(int ColichestvoDirs, int ColichestvoFiles)
        {
            max = ColichestvoDirs + ColichestvoFiles + upperBound;

        }
        public Arrow()
        {

        }
        public void SetCursorToStart(ref int StrelkaPosition)
        {
            StrelkaPosition = upperBound;
            Console.SetCursorPosition(0, upperBound);
            Console.WriteLine("->");
        }
        public void Down(ref int StrelkaPosition)
        {
            if (StrelkaPosition != max)
            {
                Console.SetCursorPosition(0, StrelkaPosition);
                Console.WriteLine("  ");
                StrelkaPosition++;
                Console.SetCursorPosition(0, StrelkaPosition);
                Console.WriteLine("->");
            }
        }
        public void Up(ref int StrelkaPosition)
        {
            if (StrelkaPosition != upperBound)
            {
                Console.SetCursorPosition(0, StrelkaPosition);
                Console.WriteLine("  ");
                StrelkaPosition--;
                Console.SetCursorPosition(0, StrelkaPosition);
                Console.WriteLine("->");
            }
        }
    }
}
