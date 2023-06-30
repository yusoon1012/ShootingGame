using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public class Ranking
    {
        public static int nowScore;
        public static int highScore;
        List<KeyValuePair<int,string>> scores= new List<KeyValuePair<int, string>>();
        public void RankBoard()
        {
            DrawInterface();
            Console.ReadKey();
        }
        public void RecordRank(int _nowScore)
        {
            nowScore = _nowScore;
        }
        public void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public void CursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        private void DrawInterface()
        {
            CursorPosition(7, 4);
            Console.WriteLine("┌───────────────────────────────────────────────────────────────┐");
            CursorPosition(7, 5);
            Console.WriteLine("│                                                               │");
            CursorPosition(7, 6);
            Console.WriteLine("│                                                               │");
            CursorPosition(7, 7);
            Console.WriteLine("│                                                               │");
            CursorPosition(7, 8);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 9);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 10);
            Console.WriteLine("│                                                               │");


            CursorPosition(7, 11);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 12);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 13);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 14);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 15);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 16);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 17);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 18);
            Console.WriteLine("│                                                               │");


            CursorPosition(7, 19);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 20);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 21);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 22);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 23);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 24);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 25);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 26);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 27);
            Console.WriteLine("│                                                               │");

            CursorPosition(7, 28);
            Console.WriteLine("└───────────────────────────────────────────────────────────────┘");

        }
    }
}
