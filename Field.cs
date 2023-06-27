using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;

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
            const int BOMB = 888;
            const int BOSS = 987;

            const int BOSS_LEFT_X = 10;
            const int BOSS_RIGHT_X = 20;
            const int BOSS_TOP_Y = 3;
            const int BOSS_BOTTOM_Y = 6;
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
            int move_X=0;
            int move_Y=0;
            int bombTimer = 0;
            int bombTimerCheck = 0;
            int enemySpawnTimer = 0;
            int enemySpawnCheck = 0;
            int bossHp = 100000;
            int enemyMove_randX;
            int enemyMove_randY;
            bool enemyLeft=false;
            bool enemyRight=false;
            bool enemyTop = false;
            bool enemyBottom = false;
            bool playerLeft = false;
            bool playerRight = false;
            int randE_X=0 ;
            int randE_Y=0;
            int itemTimer = 0;
            int powerTimer = 0;
            bool hardMode = false;
            List<Bullet> playerBulletList = new List<Bullet>();
            List<Enemy> enemyList = new List<Enemy>();
            List<Bullet> enemyBulletList = new List<Bullet>();
            List<Bomb> bombList = new List<Bomb>();
            List<Boss> bossList = new List<Boss>();
            List<PowerUP> powerList = new List<PowerUP>();
            Random rnd = new Random();

            
            int respawnTimeCheck;

            bool autoFire = false;
            Console.CursorVisible = false;
            ConsoleKeyInfo inputKey;
            for (int y = BOSS_TOP_Y; y < BOSS_BOTTOM_Y; y++)
            {
                for (int x = BOSS_LEFT_X; x < BOSS_RIGHT_X; x++)
                {
                    bossList.Add(new Boss(x, y));
                }

            }
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
                            foreach (var bomb in bombList)
                            {
                                board[bomb.bomb_Y, bomb.bomb_X] = BOMB;
                            }
                            foreach (var enemy in enemyList)
                            {
                                board[enemy.enemyPos_Y, enemy.enemyPos_X] = ENEMY;
                            }
                            foreach(var boss in bossList)
                            {
                                board[boss.boss_Y, boss.boss_X] = BOSS;
                            }
                            foreach(var powerItem in powerList)
                            {
                                board[powerItem.item_Y, powerItem.item_X] = POWER;
                            }
                            
                            
                            if(unitType==P_38)
                            { 
                            board[pos_Y + 1, pos_X] = PLAYER_WING;
                            board[pos_Y + 1, pos_X - 1] = PLAYER_WING;
                            board[pos_Y + 1, pos_X + 1] = PLAYER_WING;
                            board[pos_Y + 2, pos_X] = PLAYER_WING;
                            }
                            else if(unitType==SPITFIRE)
                            {
                                board[pos_Y  , pos_X - 1] = PLAYER_WING;
                                board[pos_Y , pos_X +1] = PLAYER_WING;
                                board[pos_Y + 1, pos_X ] = PLAYER_WING;
                                board[pos_Y + 2, pos_X] = PLAYER_WING;
                            }
                            else if (unitType == J7W_SHINDEN)
                            {
                                board[pos_Y+2, pos_X - 1] = PLAYER_WING;
                                board[pos_Y+2, pos_X + 1] = PLAYER_WING;
                                board[pos_Y + 1, pos_X] = PLAYER_WING;
                                board[pos_Y + 2, pos_X] = PLAYER_WING;
                            }

                            if (pos_X == x && pos_Y == y)
                            {
                                if(isGodMod==true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                else if(unitType==P_38)
                                {

                                Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                else if(unitType==SPITFIRE)
                                {
                                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                                }
                                else if(unitType ==J7W_SHINDEN)
                                {
                                    Console.ForegroundColor=ConsoleColor.Green;
                                }
                                Console.Write("▲");
                                Console.ResetColor();


                            }
                            else if (board[y, x] == BULLET)
                            {
                                if(unitType==P_38)
                                {
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                }
                                else if(unitType==SPITFIRE)
                                {
                                    Console.ForegroundColor=ConsoleColor.Blue;
                                }
                                else if(unitType==J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if(unitType==J7W_SHINDEN&&powerCount>=2)
                                {
                                    Console.Write("▲");
                                }
                                else
                                {

                                Console.Write("§");
                                }
                                Console.ResetColor();
                            }
                            else if (board[y,x]==BOSS)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▣");
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
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("Ｐ");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == BOMB)
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
                                else if(unitType==P_38)
                                {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                
                                }
                                else if(unitType==SPITFIRE)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;

                                }
                                else if(unitType==J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

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
                    CursorPosition(0, 43);
                    Console.Write("보스체력 {0}        ",bossHp);
                   


                    if (enemyList.Count < 6)
                    {
                        if( enemySpawnTimer==0&&enemyList.Count==0)
                        {
                            enemySpawnTimer = System.Environment.TickCount;
                        }

                        enemySpawnCheck = System.Environment.TickCount;
                        if (enemySpawnCheck - enemySpawnTimer <= 500)
                        {
                            
                        }
                        else
                        {
                            randE_X = rnd.Next(1, 29);
                             randE_Y = rnd.Next(1, 10);
                        //     if(randE_X < 3)
                        //     {
                        //         enemyList.Add(new Enemy(randE_X+1, randE_Y));
                        //         enemyList.Add(new Enemy(randE_X+2, randE_Y));



                        //     }
                        //     else if(randE_X > 27)
                        //     {
                        //         enemyList.Add(new Enemy(randE_X-1, randE_Y));
                        //         enemyList.Add(new Enemy(randE_X-2, randE_Y));


                        //     }
                        //     else
                        //     {
                        //         enemyList.Add(new Enemy(randE_X - 1, randE_Y));
                        //         enemyList.Add(new Enemy(randE_X +1, randE_Y));

                        //     }
                            enemyList.Add(new Enemy(randE_X, randE_Y));
                            enemyBulletList.Add(new Bullet(randE_X,randE_Y + 1));
                            enemySpawnTimer = 0;
                        }
                    }
                    for (int j = enemyBulletList.Count - 1; j >= 0; j--)
                    {
                        var eBullet = enemyBulletList[j];
                       
                        eBullet.Y += 1;

                        if (eBullet.Y > 39||eBullet.X<1||eBullet.X>29)
                        {
                            enemyBulletList.RemoveAt(j);
                        }

                        if (board[eBullet.Y, eBullet.X] == PLAYER_WING || eBullet.X == pos_X && eBullet.Y == pos_Y)
                        {
                            enemyBulletList.RemoveAt(j);
                            if (isGodMod == false)
                            {
                                playerHp -= 1;
                                powerCount = 0;
                                currentTick = System.Environment.TickCount;
                                if (currentTick - respawnWaitTime <= 200)
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


                    //for(int i=enemyList.Count-1;i>=0;i--)
                    //{
                    //    var enemy = enemyList[i];
                    //    enemy.enemyPos_Y += 1;
                    //}
                    for (int i = bombList.Count - 1; i >= 0; i--)
                    {
                        var bomb = bombList[i];
                        if (pos_X == bomb.bomb_X && pos_Y == bomb.bomb_Y || pos_X - 1 == bomb.bomb_X && pos_Y + 1 == bomb.bomb_Y || pos_X + 1 == bomb.bomb_X && pos_Y + 1 == bomb.bomb_Y)
                        {
                            if (bombCount < 3)
                            {

                                bombCount += 1;
                            }
                            bombList.RemoveAt(i);
                        }
                        if(itemTimer==0)
                        {
                            itemTimer=System.Environment.TickCount;
                        }
                        currentTick = System.Environment.TickCount;
                        if(currentTick-itemTimer<=500)
                        {

                        }
                        else
                        {

                        bomb.bomb_Y += 1;
                            itemTimer = 0;
                        }
                        if(bomb.bomb_Y>39)
                        {
                            bombList.RemoveAt(i);

                        }
                    }

                   

                   

                  

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
                    for(int i=enemyList.Count-1; i>=0;i--)
                    {
                        var enemy = enemyList[i];

                        if(enemySpawnTimer==0)
                        {
                            enemySpawnTimer=System.Environment.TickCount;
                        }
                        enemySpawnCheck = System.Environment.TickCount;
                        if(enemySpawnCheck-enemySpawnTimer<=100)
                        {

                        }
                        else 
                        {
                            if(randE_X>25)
                            {
                                
                            enemy.enemyPos_X -= 1;
                            }
                            else if(randE_X<10)
                            {
                               
                                enemy.enemyPos_X += 1;
                            }
                            else 
                            {
                               
                                enemy.enemyPos_Y += 1;
                            }
                            enemySpawnTimer = 0;
                        }
                        if(hardMode==true)
                        {
                            enemy.enemyPos_X -= 1;
                        }
                        if(i%5==0)
                        {
                            for(int powerup=powerList.Count-1;powerup>=0;powerup--)
                            {
                                var dropItem = powerList[powerup];
                                if (powerTimer == 0)
                                {
                                    powerTimer = System.Environment.TickCount;

                                }
                                currentTick = System.Environment.TickCount;
                                if (currentTick - powerTimer <= 300)
                                {

                                }
                                else 
                                {
                                dropItem.item_Y += 1;
                                    powerTimer = 0;

                                }
                                if (pos_X == dropItem.item_X && pos_Y == dropItem.item_Y || pos_X + 1 == dropItem.item_X && pos_Y + 1 == dropItem.item_Y ||
                                    pos_X - 1 == dropItem.item_X && pos_Y + 1 == dropItem.item_Y || pos_X == dropItem.item_X && pos_Y + 2 == dropItem.item_Y)
                                {
                                    powerCount += 1;
                                    powerList.RemoveAt(powerup);

                                }
                                if (dropItem.item_Y>39)
                                {
                                    powerList.RemoveAt(powerup);
                                }

                            }
                        }

                        if(enemy.enemyPos_X < 1||enemy.enemyPos_X>30||enemy.enemyPos_Y>39)
                        {
                            enemyList.RemoveAt(i);
                            enemySpawnTimer = 0;

                        }
                        if(enemy.enemyPos_X==pos_X)
                        {
                            
                            if(enemyFireTick==0)
                            {
                                enemyFireTick = System.Environment.TickCount;
                            }
                            currentTick = System.Environment.TickCount;
                            if(currentTick-enemyFireTick<500)
                            {

                            }
                            else
                            {
                                enemyFireTick = 0;
                            enemyBulletList.Add(new Bullet(enemy.enemyPos_X , enemy.enemyPos_Y + 1));

                            }
                            
                        }
                        else if(enemy.enemyPos_Y==pos_Y&&enemy.enemyPos_X>pos_X)
                        {
                            if (enemyFireTick == 0)
                            {
                                enemyFireTick = System.Environment.TickCount;
                            }
                            currentTick = System.Environment.TickCount;
                            if (currentTick - enemyFireTick < 500)
                            {

                            }
                            else
                            {
                                enemyFireTick = 0;
                                enemyBulletList.Add(new Bullet(enemy.enemyPos_X-1, enemy.enemyPos_Y));

                            }
                        }
                        else if (enemy.enemyPos_Y == pos_Y && enemy.enemyPos_X < pos_X)
                        {
                            if (enemyFireTick == 0)
                            {
                                enemyFireTick = System.Environment.TickCount;
                            }
                            currentTick = System.Environment.TickCount;
                            if (currentTick - enemyFireTick < 500)
                            {

                            }
                            else
                            {
                                enemyFireTick = 0;
                                enemyBulletList.Add(new Bullet(enemy.enemyPos_X +1, enemy.enemyPos_Y));

                            }
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
                                    if (pos_Y - shootCount - shootDelay > 5)
                                    {

                                        if (playerBulletList.Count < bulletLimit)
                                        {
                                            if (unitType == SPITFIRE)
                                            {
                                                if (pos_X >= 0)
                                                {
                                                    playerBulletList.Add(new Bullet(pos_X - 1, pos_Y - shootCount - shootDelay));

                                                }
                                                if (pos_X < 30)
                                                {
                                                    playerBulletList.Add(new Bullet(pos_X + 1, pos_Y - shootCount - shootDelay));

                                                }

                                            }
                                            else if (unitType == P_38)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));

                                            }
                                            else if (unitType == J7W_SHINDEN)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay - 1));

                                            }
                                            //if(powerCount>=1&&unitType==SPITFIRE)
                                            //{
                                            //    playerBulletList.Add(new Bullet(pos_X , pos_Y - shootCount - shootDelay));

                                            //}
                                            if (powerCount >= 1 && unitType == SPITFIRE)
                                            {
                                                if (pos_X < 28)
                                                {
                                                    playerBulletList.Add(new Bullet(pos_X + 2, pos_Y - shootCount - shootDelay));

                                                }
                                                if (pos_X > 2)
                                                {

                                                    playerBulletList.Add(new Bullet(pos_X - 2, pos_Y - shootCount - shootDelay));
                                                }

                                            }
                                            else if (powerCount >= 2 && unitType == SPITFIRE)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
                                            }
                                            if (powerCount >= 1 && unitType == P_38)
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
                                            if (powerCount >= 2 && unitType == P_38)
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
                                    else
                                    {
                                        break;
                                    }
                                }
                                autoFireTick = currentTick;
                            }
                        }

                        var bullet = playerBulletList[i];

                        for (int l = bossList.Count - 1; l >= 0; l--)
                        {
                            var boss = bossList[l];



                            if (bullet.Y == boss.boss_Y && bullet.X == boss.boss_X)
                            {
                                bossHp -= 50;
                                playerBulletList.RemoveAt(i);
                            }
                            if(bossHp <= 0)
                            {
                                bossList.RemoveAt(l);
                            }


                        }

                        if (bullet.X<1||bullet.X>30||bullet.Y>49||bullet.Y<1)
                        {
                            playerBulletList.RemoveAt(i);
                        }
                        if (unitType == SPITFIRE&&powerCount>=1)
                        {
                            if (i == playerBulletList.Count-5)
                            {
                                bullet.X -= 1;
                            }
                            if (i  == playerBulletList.Count - 4)
                            {
                                bullet.X += 1;
                            }
                            if (i == playerBulletList.Count - 6)
                            {
                                bullet.X -= 1;
                            }
                            if (i == playerBulletList.Count - 7)
                            {
                                bullet.X += 1;
                            }
                        }
                        if(unitType == SPITFIRE && powerCount >= 2)
                        {
                            if(bullet.Y==20)
                            {
                                if (i == playerBulletList.Count - 5)
                                {
                                    bullet.X = pos_X;
                                }
                                if (i == playerBulletList.Count - 4)
                                {
                                    bullet.X =pos_X;
                                }
                                if (i == playerBulletList.Count - 6)
                                {
                                    bullet.X =pos_X;
                                }
                                if (i == playerBulletList.Count - 7)
                                {
                                    bullet.X =pos_X;
                                }
                            }
                        }
                        if(unitType == J7W_SHINDEN&&powerCount>=1)
                        {
                            if(bullet.Y%4==0)
                            {
                                bullet.X -= 1;
                            }
                            if(bullet.Y%4==1)
                            {
                                bullet.X += 1;
                            }
                        }
                        if (isBomb_Explode==true&&unitType==P_38)
                        {
                            
                            if (i%2==0)
                            {
                                bullet.X += 1;
                            }
                            else if(i%2==1) 
                            {
                                bullet.X -= 1;
                            }
                            ;

                        }
                        else 
                        {
                        bullet.Y -= 1;
                        }
                       
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
                                    if(powerList.Count==0)
                                    {
                                    powerList.Add(new PowerUP(enemy.enemyPos_X, enemy.enemyPos_Y + 1));

                                    }
                                    if(bombList.Count==0)
                                    {
                                    bombList.Add(new Bomb(enemy.enemyPos_X, enemy.enemyPos_Y + 2));

                                    }
                                    enemyList.RemoveAt(j);
                                    enemySpawnTimer = 0;
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
                       
                        if (bullet.Y < 1)
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
                    if(isBomb_Explode==true)
                    {

                    if (bombTimer == 0)
                    {
                        bombTimer = System.Environment.TickCount;

                    }
                    bombTimerCheck = System.Environment.TickCount;
                    if (bombTimerCheck - bombTimer <= 800)
                    {

                    }
                    else
                    {
                            isBomb_Explode = false;
                        playerBulletList.Clear();
                        bombTimer = 0;
                    }
                    }

                    if ((GetKeyState((int)ConsoleKey.LeftArrow)&0x8000)!=0)
                    {
                        if (pos_X > 1)
                        {
                            move_X = -1;
                        pos_X += move_X;

                        }
                    }
                     if ((GetKeyState((int)ConsoleKey.RightArrow) & 0x8000)!=0)
                    {
                        if(pos_X<29)
                        {
                        move_X=1;
                            pos_X += move_X;

                        }
                    }
                     if ((GetKeyState((int)ConsoleKey.UpArrow) & 0x8000) != 0)
                    {
                        if(pos_Y>1)
                        {
                        move_Y = -1;
                            pos_Y += move_Y;

                        }
                    }
                     if ((GetKeyState((int)ConsoleKey.DownArrow) & 0x8000) != 0)
                    {
                        if(pos_Y<39)
                        {
                        move_Y=1;
                            pos_Y += move_Y;

                        }
                    }


                        if (Console.KeyAvailable)
                    {
                        
                        inputKey = Console.ReadKey(true);

                        switch (inputKey.Key)
                        {

                            //case ConsoleKey.LeftArrow:
                            //    if (pos_X > 1)
                            //    {
                            //        pos_X -= 1;


                            //    }
                            //    break;
                            //case ConsoleKey.RightArrow:
                            //    if (pos_X < 29)
                            //    {

                            //        pos_X += 1;

                            //    }
                            //    break;
                            //case ConsoleKey.UpArrow:
                            //    if (pos_Y > 1)
                            //    {
                            //        pos_Y -= 1;
                            //    }
                            //    break;
                            //case ConsoleKey.DownArrow:
                            //    if (pos_Y < 39)
                            //    {
                            //        pos_Y += 1;
                            //    }
                            //    break;
                            case ConsoleKey.Q:
                                if(hardMode==false)
                                {
                                    hardMode = true;

                                }
                                else
                                {
                                    hardMode=false;
                                }
                                break;
                            case ConsoleKey.Z:


                                while (shootCount < 4)
                                {
                                    if (pos_Y - shootCount - shootDelay > 5)
                                    {

                                    if (playerBulletList.Count < bulletLimit)
                                    {
                                        if (unitType == SPITFIRE)
                                        {
                                                if(pos_X>=0)
                                                {
                                            playerBulletList.Add(new Bullet(pos_X-1, pos_Y - shootCount - shootDelay));

                                                }
                                                if (pos_X < 30)
                                                {
                                            playerBulletList.Add(new Bullet(pos_X+1, pos_Y - shootCount - shootDelay));

                                                }

                                        }
                                        else if(unitType == P_38)
                                        {
                                            playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));

                                        }
                                        else if(unitType==J7W_SHINDEN)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
                                                playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay-1));

                                            }
                                            //if(powerCount>=1&&unitType==SPITFIRE)
                                            //{
                                            //    playerBulletList.Add(new Bullet(pos_X , pos_Y - shootCount - shootDelay));

                                            //}
                                            if (powerCount >= 1 && unitType == SPITFIRE)
                                        {
                                                if(pos_X<28)
                                                {
                                            playerBulletList.Add(new Bullet(pos_X+2, pos_Y - shootCount - shootDelay));

                                                }
                                                if(pos_X>2)
                                                {

                                            playerBulletList.Add(new Bullet(pos_X - 2, pos_Y - shootCount - shootDelay));
                                                }

                                        }
                                            else if(powerCount >= 2 &&unitType==SPITFIRE)
                                            {
                                                playerBulletList.Add(new Bullet(pos_X , pos_Y - shootCount - shootDelay));
                                                playerBulletList.Add(new Bullet(pos_X , pos_Y - shootCount - shootDelay));
                                            }
                                        if (powerCount >= 1&&unitType==P_38)
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
                                        if (powerCount >= 2&&unitType==P_38)
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
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case ConsoleKey.X:
                                if (bombCount > 0)
                                {
                                    isGodMod = true;
                                    isBomb_Explode = true;
                                    enemyBulletList.Clear();

                                }
                                if (isBomb_Explode == true && bombCount > 0&&unitType==SPITFIRE)
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
                                    




                                    if (bombCount > 0)
                                    {
                                        bombCount -= 1;

                                    }
                                }
                                if (isBomb_Explode == true && bombCount > 0 && unitType == P_38)
                                {
                                    if(pos_X>5&&pos_Y>5)
                                    {
                                        for(int y=pos_Y - 5;y<pos_Y+5;y++)
                                        {
                                        for(int x = pos_X - 5;x < pos_X + 5;x++)
                                            {
                                                playerBulletList.Add(new Bullet(x,y));
                                            }
                                        }

                                    }
                                    else if (pos_X > 0 && pos_Y > 5)
                                    {
                                        for (int y = pos_Y - 5; y < pos_Y + 5; y++)
                                        {
                                            for (int x = pos_X-pos_X ; x < pos_X + 5; x++)
                                            {
                                                playerBulletList.Add(new Bullet(x, y));
                                            }
                                        }

                                    }
                                    else if (pos_X >35 && pos_Y > 5)
                                        {
                                            for (int y = pos_Y - 5; y < pos_Y + 5; y++)
                                            {
                                                for (int x = pos_X - 5; x < pos_X; x++)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));
                                                }
                                            }

                                        }
                                    else if (pos_X > 35 && pos_Y < 5)
                                    {
                                        for (int y = pos_Y-pos_Y; y < pos_Y + 5; y++)
                                        {
                                            for (int x = pos_X - 5; x < pos_X; x++)
                                            {
                                                playerBulletList.Add(new Bullet(x, y));
                                            }
                                        }

                                    }
                                    else if (pos_X >0 && pos_Y < 5)
                                    {
                                        for (int y = pos_Y-pos_Y; y < pos_Y + 5; y++)
                                        {
                                            for (int x = pos_X - pos_X; x < pos_X + 5; x++)
                                            {
                                                playerBulletList.Add(new Bullet(x, y));
                                            }
                                        }

                                    }
                                }
                                if(isBomb_Explode==true&&unitType==J7W_SHINDEN)
                                {
                                    if(pos_Y>9&&pos_X>3)
                                    {
                                    for(int y=pos_Y-9;y<pos_Y;y++)
                                        {   
                                            for(int x=pos_X-3;x<pos_X+4;x++)
                                            {
                                                if(y==pos_Y-9&&x==pos_X)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));

                                                }
                                                else if(y==pos_Y-8&&x>=pos_X-1&&x<=pos_X+1)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));

                                                }
                                                else if(y==pos_Y-7&&x>=pos_X-2&&x<=pos_X+2)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));

                                                }
                                                else if(y>pos_Y-6)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));

                                                }
                                                //playerBulletList.Add(new Bullet(x, y));
                                            }
                                        }

                                    }
                                    else if(pos_Y<27)
                                    {

                                    }
                                    if (bombCount > 0)
                                    {
                                        bombCount -= 1;

                                    }
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


