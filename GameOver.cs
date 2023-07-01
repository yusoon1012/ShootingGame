using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public class GameOver
    {
        ConsoleKeyInfo restartKey;
        bool isRestart = false;

        public void OverDisplay()
        {
            int count = 10;
            while (isRestart == false)
            {
                
               
                
                DrawGameOver();
                CursorPosition(20, 22);
                Console.WriteLine("이어하려면 ENTER 키를 누르세요.");
               
                if (count == 10)
                {
                    DrawTen();
                }
                else if (count == 9)
                {
                    DrawNine();
                }
                else if (count == 8)
                {
                    DrawEight();
                }
                else if (count == 7)
                {
                    DrawSeven();
                }
                else if (count == 6)
                {
                    DrawSix();
                }
                else if (count == 5)
                {
                    DrawFive();
                }
                else if (count == 4)
                {
                    DrawFour();
                }
                else if (count == 3)
                {
                    DrawThree();
                }
                else if (count == 2)
                {
                    DrawTwo();
                }
                else if (count == 1)
                {
                    DrawOne();
                }
                
                    
                
                if (Console.KeyAvailable)
                {
                    restartKey = Console.ReadKey();
                    if (restartKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        if (count > 0)
                        {
                            count -= 1;
                            ClearBuffer();

                            Thread.Sleep(300);
                        }

                    }
                    
                }
                else
                {
                    if (count > 0)
                    {
                        count -= 1;
                        ClearBuffer();
                        Thread.Sleep(1000);
                    }
                   
                }
             
                if (count == 0)
                {
                    DrawZero();
                    Thread.Sleep (1000);
                    DrawBlank();
                    
                    Console.Clear();
                    Title.isResetGame = true;
                    break;
                }
                




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
        private void DrawBlank()
        {
            Console.Write("              ");
            Console.Write("              ");
            Console.Write("              ");
            Console.Write("              ");
            Console.Write("              ");

        }
        private void DrawGameOver()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            CursorPosition(3, 6);
            Console.Write("   _____            __  __  ______    ____ __      __ ______  _____   ");
            CursorPosition(3, 7);
            Console.Write("  / ____|    /\\    |  \\/  ||  ____|  / __ \\\\ \\    / /|  ____||  __ \\  ");
            CursorPosition(3, 8);
            Console.Write(" | |  __    /  \\   | \\  / || |__    | |  | |\\ \\  / / | |__   | |__) | ");
            CursorPosition(3, 9);
            Console.Write(" | | |_ |  / /\\ \\  | |\\/| ||  __|   | |  | | \\ \\/ /  |  __|  |  _  /  ");
            CursorPosition(3, 10);
            Console.Write("  \\_____|/_/    \\_\\|_|  |_||______|  \\____/    \\/    |______||_|  \\_\\ ");
            CursorPosition(3, 11);
            Console.Write("                                                                      ");

            Console.ResetColor();
        }
        private void DrawTen()
        {
            CursorPosition(27, 15);
            Console.Write("■■  ■■■■");
            CursorPosition(27, 16);
            Console.Write("  ■  ■    ■");
            CursorPosition(27, 17);
            Console.Write("  ■  ■    ■");
            CursorPosition(27, 18);
            Console.Write("  ■  ■    ■");
            CursorPosition(27, 19);
            Console.Write("  ■  ■■■■");

        }
        private void DrawNine()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("         ■   ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
        private void DrawEight()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
        private void DrawSeven()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 17);
            Console.Write("         ■   ");
            CursorPosition(27, 18);
            Console.Write("         ■   ");
            CursorPosition(27, 19);
            Console.Write("         ■   ");

        }
        private void DrawSix()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("   ■         ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
        private void DrawFive()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("   ■         ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("         ■   ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
        private void DrawFour()
        {
            CursorPosition(27, 15);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 16);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("         ■   ");
            CursorPosition(27, 19);
            Console.Write("         ■   ");

        }
        private void DrawThree()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("         ■   ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("         ■   ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
        private void DrawTwo()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("         ■   ");
            CursorPosition(27, 17);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 18);
            Console.Write("   ■         ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
        private void DrawOne()
        {
            CursorPosition(27, 15);
            Console.Write("       ■■   ");
            CursorPosition(27, 16);
            Console.Write("         ■   ");
            CursorPosition(27, 17);
            Console.Write("         ■   ");
            CursorPosition(27, 18);
            Console.Write("         ■   ");
            CursorPosition(27, 19);
            Console.Write("         ■   ");

        }
        private void DrawZero()
        {
            CursorPosition(27, 15);
            Console.Write("   ■■■■   ");
            CursorPosition(27, 16);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 17);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 18);
            Console.Write("   ■    ■   ");
            CursorPosition(27, 19);
            Console.Write("   ■■■■   ");

        }
    }
    

}
