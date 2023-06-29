using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ChooseCharacter
    {
        const int P_38 = 155;
        const int SPITFIRE = 156;
        const int J7W_SHINDEN = 157;

        Field field;

        public void Select()
        {

            field = new Field();
            int cursorPos_x = 16;
            int cursorPos_y = 40;
            bool characterSelect=false;
            Console.CursorVisible = false;
            Console.Clear();
            Player player = new Player();   
            while (characterSelect==false)
            {
                Console.CursorVisible = false;
                DrawInterface();
                CursorPosition(0, 0);
                ConsoleKeyInfo selectInfo;
                Console.WriteLine("기체를 선택");
                DrawP38();
                    CursorPosition(15, cursorPos_y - 2);
                   Console.Write("P_38");

                DrawSpitfire();
                    CursorPosition(35, cursorPos_y - 2);
                    Console.Write("SPITFIRE");


                Drawj7w();
                    CursorPosition(54, cursorPos_y - 2);
                    Console.Write("J7W_SHINDEN");


                CursorPosition(cursorPos_x, cursorPos_y);
                Console.Write("▲");
                
               
                selectInfo = Console.ReadKey();
                
                switch (selectInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if(cursorPos_x==16)
                        {
                            Field.unitType = P_38;

                        }
                        if(cursorPos_x==38)
                        {
                            Field.unitType = SPITFIRE;
                        }
                        if(cursorPos_x==59)
                        {
                            Field.unitType = J7W_SHINDEN;
                        }
                        characterSelect = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorPos_x > 16&&cursorPos_x<=38)
                        {
                            cursorPos_x -= 22;
                            CursorPosition(cursorPos_x + 22, cursorPos_y);
                            Console.Write("  ");

                        }
                        else if(cursorPos_x>38)
                        {
                            cursorPos_x -= 21;
                            CursorPosition(cursorPos_x + 21, cursorPos_y);
                            Console.Write("  ");
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorPos_x < 38)
                        {
                            cursorPos_x += 22;
                            CursorPosition(cursorPos_x - 22, cursorPos_y);
                            Console.Write("  ");
                        }
                        else if(cursorPos_x ==38)
                        {
                            cursorPos_x += 21;
                            CursorPosition(cursorPos_x - 21, cursorPos_y);
                            Console.Write("  ");
                        }

                        break;
                    default:
                        break;

                }
                CursorPosition(10, 10);
                Console.WriteLine("좌표값 X : {0} 좌표값 Y : {1}",cursorPos_x,cursorPos_y);

            }
        }
        public void CursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void DrawP38()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            CursorPosition(14, 33);
            Console.Write("  ▲  ");
            Console.ForegroundColor= ConsoleColor.Gray;
            CursorPosition(14, 34);

            Console.Write("■■■");
            CursorPosition(14, 35);

            Console.Write("  ■");
            Console.ResetColor();
        }
        public void DrawSpitfire()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            CursorPosition(36, 33);
            Console.Write("■");
            CursorPosition(38, 33);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("▲");
            CursorPosition(40, 33);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("■");
            CursorPosition(38, 34);
            Console.Write("■");
            CursorPosition(38, 35);
            Console.Write("■");
            Console.ResetColor();
        }
        public void Drawj7w()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CursorPosition(59, 33);
                Console.Write("∥");
            CursorPosition(59, 34);
            Console.Write("■");
            CursorPosition(57, 35);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("◀");
            CursorPosition(59, 35);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("■");

            CursorPosition(61, 35);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("▶");
            Console.ResetColor();

        }

        public void DrawInterface()
        {
            //Y4~28
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
