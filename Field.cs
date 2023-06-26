using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class Field
    {
            const int tickRate = 1000 / 60;
        public void Play()
        {


            int lastTick = 0;
            int currentTick;
            Console.SetWindowSize(81, 51);
            int[,] board = new int[50, 40];
            const int PLAYER = 50;
            const int ENEMY = 40;
            const int BULLET = 30;
            const int POWER = 44;
            int pos_X = 20;
            int pos_Y = 45;
            int bullet_X = pos_X;
            int score = 0;
            int bombCount = 0;
            int bombPer;
            int bomb_X = 10;
            int bomb_Y = 20;
            bool isBomb_Explode = false;
            int powerUP_X = 10;
            int powerUP_Y = 10;
            int powerCount = 0;
            int autoFireTick = 0;


            List<Bullet> playerBulletList = new List<Bullet>();
            List<Enemy> enemyList = new List<Enemy>();
            Random rnd = new Random();

            int enemyHp = 100;


            bool autoFire = false;
            Console.CursorVisible = false;
            ConsoleKeyInfo inputKey;
            while (true)
            {

                int shootCount = 0;
                int shootDelay = 0;
                ClearBuffer();
                currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < tickRate)
                {
                    continue;
                }
                else
                {

                    CursorPosition(0, 0);
                    for (int y = 0; y < 50; y++)
                    {
                        for (int x = 0; x < 40; x++)
                        {
                            board[y, x] = 0;
                            foreach (var bullet in playerBulletList)
                            {
                                board[bullet.Y, bullet.X] = 50;


                            }

                            foreach (var enemy in enemyList)
                            {
                                board[enemy.enemyPos_Y, enemy.enemyPos_X] = 30;
                            }

                            board[bomb_Y, bomb_X] = 99;
                            board[powerUP_Y, powerUP_X] = POWER;



                            if (pos_X == x && pos_Y == y)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("▲");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("§");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == 30)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▼");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == POWER)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("Ｐ");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == 99)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Ｂ");
                                Console.ResetColor();
                            }
                            else
                            {

                                Console.Write("  ");
                            }
                        }
                        Console.WriteLine();

                    }

                    if (enemyList.Count < 3)
                    {

                        int randE_X = rnd.Next(1, 15);
                        int randE_Y = rnd.Next(1, 3);
                        enemyList.Add(new Enemy(randE_X, randE_Y));
                    }
                    if (pos_X == bomb_X && pos_Y == bomb_Y && bombCount < 3)
                    {
                        bombCount += 1;
                        bomb_X = 0;
                        bomb_Y = 0;
                    }
                    else if (pos_X == bomb_X && pos_Y == bomb_Y)
                    {
                        bomb_X = 0;
                        bomb_Y = 0;
                    }


                    if (pos_X == powerUP_X && pos_Y == powerUP_Y)
                    {
                        powerCount += 1;
                    }



                    for (int i = playerBulletList.Count - 1; i >= 0; i--)
                    {
                        if (autoFire == true)
                        {
                            if (currentTick - autoFireTick <= 300)
                            {
                                
                            }
                            else
                            {
                                while (shootCount < 4)
                                {

                                    if (playerBulletList.Count < 40)
                                    {

                                        playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
                                        if (powerCount >= 1)
                                        {
                                            if (pos_X > 0)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X - 1, pos_Y - shootCount - shootDelay + 1));
                                            }
                                            if (pos_X < 39)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X + 1, pos_Y - shootCount - shootDelay + 1));

                                            }

                                        }

                                    }
                                    shootCount++;
                                    shootDelay++;
                                }
                                autoFireTick = currentTick;
                            }
                        }

                        var bullet = playerBulletList[i];
                        bullet.Y -= 1;
                        for (int j = enemyList.Count - 1; j >= 0; j--)
                        {
                            var enemy = enemyList[j];
                           
                            if (bullet.Y == enemy.enemyPos_Y && bullet.X == enemy.enemyPos_X)
                            {
                                enemy.enemyHp -= 50;
                                playerBulletList.RemoveAt(i);

                                if (enemy.enemyHp <= 0)
                                {
                                    enemyList.RemoveAt(j);
                                    score += 1000;
                                    bombPer = rnd.Next(0, 100);
                                    if (bombPer > 0 && bombPer < 10)
                                    {
                                        bomb_X = enemy.enemyPos_X;
                                        bomb_Y = enemy.enemyPos_Y + 10;
                                    }
                                }
                                break;
                            }
                        }

                        if (bullet.Y <= 0)
                        {
                            playerBulletList.RemoveAt(i);
                        }

                    }
                    //CursorPosition(0, 60);
                    //Console.WriteLine("SCORE {0}         ", score);
                    //CursorPosition(0, 61);
                    //Console.WriteLine("BombCount {0}", bombCount);


                    //Thread.Sleep(10);

                    if (Console.KeyAvailable)
                    {

                        inputKey = Console.ReadKey(true);

                        switch (inputKey.Key)
                        {

                            case ConsoleKey.LeftArrow:
                                if (pos_X > 0)
                                {
                                    pos_X -= 1;


                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (pos_X < 39)
                                {

                                    pos_X += 1;

                                }
                                break;
                            case ConsoleKey.UpArrow:
                                if (pos_Y > 1)
                                {
                                    pos_Y -= 1;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (pos_Y < 49)
                                {
                                    pos_Y += 1;
                                }
                                break;
                            case ConsoleKey.Z:


                                while (shootCount < 4)
                                {

                                    if (playerBulletList.Count < 40)
                                    {

                                        playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
                                        if (powerCount >= 1)
                                        {
                                            if (pos_X > 0)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X - 1, pos_Y - shootCount - shootDelay + 1));
                                            }
                                            if (pos_X < 39)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X + 1, pos_Y - shootCount - shootDelay + 1));

                                            }

                                        }

                                    }
                                    shootCount++;
                                    shootDelay++;
                                }
                                break;
                            case ConsoleKey.X:
                                if (bombCount > 0)
                                {
                                    isBomb_Explode = true;

                                }
                                if (isBomb_Explode == true && bombCount > 0)
                                {
                                    for (int y = 0; y < pos_Y; y++)
                                    {
                                        for (int x = pos_X-5; x < pos_X+5; x++)
                                        {
                                            playerBulletList.Add(new Bullet(x, y));
                                        }
                                    }
                                    isBomb_Explode = false;
                                }
                                if (bombCount > 0)
                                {
                                    bombCount -= 1;

                                }
                                break;
                            case ConsoleKey.A:
                                if (autoFire == true)
                                {
                                    autoFire = false;
                                }
                                else
                                {
                                    autoFire = true;

                                }
                                break;
                            default:
                                break;

                        }
                    }
                }
            }

        }//main
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
    }


}


