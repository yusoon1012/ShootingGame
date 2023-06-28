using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Title
    {
        public static bool isResetGame;
        public void gameTitle()
        {
            ConsoleKeyInfo inputKey;
            CursorPosition(0, 0);
            Console.WriteLine("아무키나 눌러서 게임시작");
            inputKey = Console.ReadKey();
            isResetGame = false;

        }
        public void CursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
