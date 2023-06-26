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
        bool isRestart=false;
        
        public void OverDisplay()
        {
            int count = 10;
            while(isRestart==false)
            { 
            CursorPosition(20, 30);
            Console.WriteLine("GAME OVER");
                CursorPosition(20, 31);

                Console.WriteLine("이어하려면 ENTER 키를 누르세요.");
                CursorPosition(24, 32);

                Console.Write("{0} ",count);
                if(Console.KeyAvailable)
                { 
                restartKey = Console.ReadKey();
            if(restartKey.Key==ConsoleKey.Enter)
                {
                    break;
                }
            
                        continue;
                }
                Thread.Sleep(1000);
                if (count == 0)
                {

                }
                count -= 1;
            }

        }
        public void CursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
    
}
