using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;

namespace ConsoleApp1
{
    public class Field
    {
        public static int unitType;
        
        const int tickRate = 1000 / 60;
            const int P_38 = 155;
            const int SPITFIRE = 156;
            const int J7W_SHINDEN = 157;
        [DllImport("user32.dll")]

        public static extern short GetKeyState(int keyCode);
        public Field()
        {

        }
        public void Play()
        {

            GameOver gameOver = new GameOver();
            int lastTick = 0;
            int currentTick;
            int[,] board = new int[50, 40];
            const int PLAYER_WING = 50;
            const int ENEMY = 40;
            const int BULLET = 30;
            const int POWER = 44;
            const int ENEMY_BULLET = 46;
            const int PLAYER_EXPLODE = 999;
            
            int pos_X = 15;
            int pos_Y = 35;
            int bullet_X = pos_X;
            int score = 0;
            int bombCount = 5;
            int bombPer;
            int bomb_X = 10;
            int bomb_Y = 20;
            bool isBomb_Explode = false;
            int powerUP_X = 10;
            int powerUP_Y = 10;
            int powerCount = 0;
            int autoFireTick = 0;
            int enemyFireTick = 0;
            int playerHp = 3;
            int respawnTick = 0;
            int respawnWaitTime = 0;
            int bulletLimit = 30;
            bool isGodMod = false;
            int moveX = 0;
            int moveY = 0;
            List<Bullet> playerBulletList = new List<Bullet>();
            List<Enemy> enemyList = new List<Enemy>();
            List<Bullet> enemyBulletList = new List<Bullet>();
            Random rnd = new Random();

            int enemyHp = 100;
            int respawnTimeCheck;

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
                            if (x == 31 && y < 41)
                            {
                                Console.Write("□");
                            }
                            if (y == 41 && x < 32)
                            {
                                Console.Write("□");
                                continue;
                            }
                            board[y, x] = 0;
                            foreach (var bullet in playerBulletList)
                            {
                                board[bullet.Y, bullet.X] = BULLET;


                            }
                            foreach (var enemyBullet in enemyBulletList)
                            {
                                board[enemyBullet.Y, enemyBullet.X] = ENEMY_BULLET;
                            }

                            foreach (var enemy in enemyList)
                            {
                                board[enemy.enemyPos_Y, enemy.enemyPos_X] = ENEMY;
                            }

                            board[bomb_Y, bomb_X] = 99;
                            board[powerUP_Y, powerUP_X] = POWER;

                            board[pos_Y + 1, pos_X] = PLAYER_WING;
                            board[pos_Y + 1, pos_X - 1] = PLAYER_WING;
                            board[pos_Y + 1, pos_X + 1] = PLAYER_WING;
                            board[pos_Y + 2, pos_X] = PLAYER_WING;

                            if (pos_X == x && pos_Y == y)
                            {
                                if(isGodMod==true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                else
                                {

                                Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                Console.Write("▲");
                                Console.ResetColor();


                            }
                            else if (board[y, x] == BULLET)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("§");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == ENEMY)
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
                            else if (board[y, x] == PLAYER_WING)
                            {
                                if (isGodMod == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                else 
                                {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                
                                }
                                Console.Write("■");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == ENEMY_BULLET)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("●");
                                Console.ResetColor();
                            }
                            else if (board[y,x]==PLAYER_EXPLODE)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("※");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == 0)
                            {
                                
                                Console.Write("  ");
                               
                            }
                        }
                        Console.WriteLine();

                    }
                    CursorPosition(0, 42);
                    Console.Write("체력 {0} 폭탄 {1} 파워 {2}",playerHp,bombCount,powerCount);
                    if (enemyList.Count < 5)
                    {

                        int randE_X = rnd.Next(1, 29);
                        int randE_Y = rnd.Next(1, 10);
                        enemyList.Add(new Enemy(randE_X, randE_Y));
                        enemyBulletList.Add(new Bullet(randE_X,randE_Y + 1));
                    }
                    
                    //for(int i=enemyList.Count-1;i>=0;i--)
                    //{
                    //    var enemy = enemyList[i];
                    //    enemy.enemyPos_Y += 1;
                    //}
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
                        int powerRand_X=rnd.Next(1, 29);
                        int powerRand_Y = rnd.Next(20, 39);
                        powerCount += 1;
                        powerUP_X = powerRand_X;
                        powerUP_Y = powerRand_Y;
                    }

                    for (int i = enemyList.Count - 1; i >= 0; i--)//적의 공격
                    {
                        if(currentTick-enemyFireTick<=50)
                        {

                        }
                        else
                        {
                        enemyFireTick = currentTick;
                        var eList = enemyList[i];
                        if(enemyBulletList.Count< i)
                        {

                       
                        }
                        for (int j = enemyBulletList.Count - 1; j >= 0; j--)
                        {
                                var eBullet = enemyBulletList[j];
                                
                                eBullet.Y += 1;
                                if (eBullet.Y > 39)
                                {
                                    enemyBulletList.RemoveAt(j);
                                }
                               
                                if (board[eBullet.Y,eBullet.X]==PLAYER_WING||eBullet.X==pos_X&&eBullet.Y==pos_Y)
                                {
                                    enemyBulletList.RemoveAt(j);
                                    if(isGodMod==false)
                                    {
                                         playerHp -= 1;
                                        powerCount = 0;
                                        currentTick= System.Environment.TickCount;
                                        if (currentTick-respawnWaitTime<=200)
                                        {
                                            
                                        }
                                         else
                                        {
                                         respawnTick = currentTick;
                                          
                                         Thread.Sleep(500);
                                         pos_X = 15;
                                         pos_Y = 35;
                                        isGodMod = true;

                                        }
                                        
                                    }

                                }
                            }

                        }
                    }//적의 공격끝

                    if(playerHp==0)
                    {
                        ClearBuffer();
                        gameOver.OverDisplay();
                        playerHp = 3;
                        score -= 10000;
                        bombCount = 2;
                        isGodMod = true;
                    }
                    if(isGodMod == true)
                    {
                        if (respawnTick == 0) // 최초 무적 상태 진입 시간 설정
                        {
                            respawnTick = System.Environment.TickCount;
                        }
                        respawnTimeCheck = System.Environment.TickCount;
                        CursorPosition(0, 40);
                        if (respawnTimeCheck - respawnTick<=3000)
                        {
                        Console.WriteLine("무적");
                            
                        }
                        else
                        {
                            
                            isGodMod=false;

                        respawnTick = 0;
                        }
                    }

                    for (int i = playerBulletList.Count - 1; i >= 0; i--)//플레이어 사격
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

                                    if (playerBulletList.Count < bulletLimit)
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
                                            bulletLimit = 40;

                                        }
                                        if(powerCount>=2)
                                        {

                                            if (pos_X > 1)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X - 2, pos_Y - shootCount - shootDelay + 1));
                                            }
                                            if (pos_X < 39)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X +2, pos_Y - shootCount - shootDelay + 1));

                                            }
                                            bulletLimit = 60;
                                        }

                                    }
                                    shootCount++;
                                    shootDelay++;
                                }
                                autoFireTick = currentTick;
                            }
                        }

                        var bullet = playerBulletList[i];
                        if(unitType==SPITFIRE) 
                        {
                           if(i%2==0&&bullet.Y%6==0)
                            {
                            bullet.X += 1;

                            }
                           if(i % 2 == 1 && bullet.Y % 6 == 0    ) 
                            {
                                bullet.X -= 1;

                            }


                        }

                        if(bullet.X<1||bullet.X>38)
                        {
                            playerBulletList.RemoveAt(i);
                        }
                        bullet.Y -= 1;
                        for (int j = enemyList.Count - 1; j >= 0; j--)
                        {
                            var enemy = enemyList[j];
                            
                            if (bullet.Y == enemy.enemyPos_Y && bullet.X == enemy.enemyPos_X)
                            {
                                if (unitType == SPITFIRE)
                                {
                                    enemy.enemyHp -= 20;

                                }
                                else
                                {
                                    enemy.enemyHp -= 50;

                                }
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
                    CursorPosition(0, 45);
                    Console.Write("SCORE {0}         ", score);
                    //CursorPosition(0, 61);
                    //Console.WriteLine("BombCount {0}", bombCount);
                    if(unitType==P_38)
                    {
                    CursorPosition(0, 46);
                    Console.Write("유닛 타입 : P_38");

                    }
                    else if(unitType==SPITFIRE)
                    {
                        CursorPosition(0,46 );
                        Console.Write("유닛 타입 : SPITFIRE");
                    }
                    else if(unitType==J7W_SHINDEN)
                    {
                        CursorPosition(0, 46);
                        Console.Write("유닛 타입 : J7W_SHINDEN");
                    }
                    else
                    {
                        CursorPosition(0, 46);

                        Console.Write("버그");
                    }
                    //Thread.Sleep(10);
                    

                    if (Console.KeyAvailable)
                    {

                        inputKey = Console.ReadKey(true);

                        switch (inputKey.Key)
                        {

                            case ConsoleKey.LeftArrow:
                                if (pos_X > 1)
                                {
                                    pos_X -= 1;


                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (pos_X < 29)
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
                                if (pos_Y < 39)
                                {
                                    pos_Y += 1;
                                }
                                break;
                            case ConsoleKey.Z:


                                while (shootCount < 4)
                                {

                                    if (playerBulletList.Count < bulletLimit)
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
                                            bulletLimit = 40;

                                        }
                                        if (powerCount >= 2)
                                        {

                                            if (pos_X > 1)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X - 2, pos_Y - shootCount - shootDelay + 1));
                                            }
                                            if (pos_X < 39)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X + 2, pos_Y - shootCount - shootDelay + 1));

                                            }
                                            bulletLimit = 60;
                                        }

                                    }
                                    shootDelay++;
                                    shootCount++;
                                }
                                break;
                            case ConsoleKey.X:
                                if (bombCount > 0)
                                {
                                    isBomb_Explode = true;
                                    enemyBulletList.Clear();

                                }
                                if (isBomb_Explode == true && bombCount > 0)
                                {
                                    for (int y = 0; y < pos_Y - 1; y++)
                                    {
                                        if (pos_X > 35)
                                        {

                                            for (int x = pos_X - 5; x < pos_X; x++)
                                            {

                                                playerBulletList.Add(new Bullet(x, y));
                                            }
                                        }
                                        else if (pos_X < 5)
                                        {
                                            for (int x = pos_X - pos_X; x < pos_X + 5; x++)
                                            {

                                                playerBulletList.Add(new Bullet(x, y));
                                            }
                                        }
                                        else
                                        {
                                            for (int x = pos_X - 5; x < pos_X + 5; x++)
                                            {

                                                playerBulletList.Add(new Bullet(x, y));
                                            }
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
                    }//키입력
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


