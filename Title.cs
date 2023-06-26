using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Title
    {
        public void gameTitle()
        {
            ConsoleKeyInfo inputKey;

            Console.WriteLine("아무키나 눌러서 게임시작");
            inputKey = Console.ReadKey();

        }
        public void CursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
