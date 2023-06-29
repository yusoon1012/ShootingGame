using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public class Title
    {
        public static bool isResetGame;
        public void gameTitle()
        {
            int titleTimer =0;
            int titleCheck = 0;
            Ranking ranking = new Ranking();
            Field.bossClear = false;
            while(true)
            {
                ClearBuffer();
                Console.CursorVisible = false;
            ConsoleKeyInfo inputKey;
            //Console.WriteLine("아무키나 눌러서 게임시작");
            CursorPosition(0, 0);
            DrawTitle();
            CursorPosition(35, 35);
            Console.Write("Press Any Key");
                Thread.Sleep(300);
                CursorPosition(35, 35);
            Console.Write("             ");
                Thread.Sleep(300);

                //Thread.Sleep(10);

                if (Console.KeyAvailable)
                {
                inputKey = Console.ReadKey();
                    break;
                }
                else
                {
                    if(titleTimer==0)
                    {
                        titleTimer=System.Environment.TickCount;
                    }
                    titleCheck=System.Environment.TickCount;
                    if (titleCheck - titleTimer < 10000)
                    { }
                    else
                    { 
                    ranking.RankBoard();
                        titleTimer = 0;
                    }


                }
                isResetGame = false;
            }
        }
        public void CursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }
        public void DrawTitle()
        {
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("          ┌──────┐     ┌──────┐             ┌──────┐     ┌────────────┐           ");
            Console.WriteLine("          │      │   ┌         ─┐          ┌┘      │     │            │           ");
            Console.WriteLine("          │      │  │            ┐        ┌┘       │     │            │           ");
            Console.WriteLine("          │      │  │     ──┐    │       ┌┘        │     │     ───────┘           ");
            Console.WriteLine("          └─┐    │  │    │  │    │      ┌┘         │     │    │                   ");
            Console.WriteLine("            │    │  │    │  │    │     ┌┘    ┌┐    │     │    │                   ");
            Console.WriteLine("            │    │  │    └──     │    ┌┘    ┌┘│    │     │    └─────┐             ");
            Console.WriteLine("            │    │  └┐           │   ┌┘    ┌┘ │    │     │          └┐            ");
            Console.WriteLine("            │    │   └┐          │  ┌┘    ┌┘  │    │     │            │           ");
            Console.WriteLine("            │    │    └─────┐    │  │     └───┘    └──┐  └───────┐    │           ");
            Console.WriteLine("            │    │          │    │  │                 │          │    │           ");
            Console.WriteLine("            │    │  ┌────┐  │    │  │                 │  ┌────┐  │    │           ");
            Console.WriteLine("            │    │  │    │  │    │  └─────────┐    ┌──┘  │    │  │    │           ");
            Console.WriteLine("            │    │  │    └──     │            │    │     │    └──     │           ");
            Console.WriteLine("            │    │  │            │            │    │     │            │           ");
            Console.WriteLine("            │    │   ─┐         ┌┘            │    │      ─┐         ┌┘           ");
            Console.WriteLine("            └────┘     └───────┘              └────┘        └───────┘             ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");






        }
    }
}
