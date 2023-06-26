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


        public void Select()
        {
            
            Field field = new Field();
            int cursorPos_x = 16;
            int cursorPos_y = 40;
            bool characterSelect=false;
            Console.CursorVisible = false;
            Console.Clear();
            Player player = new Player();   
            while (characterSelect==false)
            {
                CursorPosition(0, 0);
                ConsoleKeyInfo selectInfo;
                Console.WriteLine("기체를 선택");
               
                    CursorPosition(14, cursorPos_y - 2);
                   Console.Write("P_38");
                 
               
                    CursorPosition(30, cursorPos_y - 2);
                    Console.Write("SPITFIRE");

              
                
                    CursorPosition(44, cursorPos_y - 2);
                    Console.Write("J7W_SHINDEN");


                CursorPosition(cursorPos_x, cursorPos_y);
                Console.Write("↑");
                
                if (cursorPos_x > 48)
                {
                    CursorPosition(cursorPos_x - 16, cursorPos_y);

                }
                Console.Write("  ");
                selectInfo = Console.ReadKey();

                switch (selectInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if(cursorPos_x==16)
                        {
                            field.unitType = P_38;

                        }
                        if(cursorPos_x==32)
                        {
                            field.unitType = SPITFIRE;
                        }
                        if(cursorPos_x==48)
                        {
                            field.unitType = J7W_SHINDEN;
                        }
                        characterSelect = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorPos_x > 16)
                        {
                            cursorPos_x -= 16;
                            CursorPosition(cursorPos_x + 16, cursorPos_y);
                            Console.Write("  ");

                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorPos_x < 48)
                        {
                            cursorPos_x += 16;
                            CursorPosition(cursorPos_x - 16, cursorPos_y);
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
    }
}
