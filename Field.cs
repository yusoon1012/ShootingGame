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
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;

namespace ConsoleApp1
{
    public class Field
    {
        public static int unitType;
        public static bool bossClear;

        const int tickRate = 1000 / 60;
        const int P_38 = 155;
        const int SPITFIRE = 156;
        const int J7W_SHINDEN = 157;
        const int BOSS_LEFT_X = 10;
        const int BOSS_RIGHT_X = 20;
        const int BOSS_TOP_Y = 3;
        const int BOSS_BOTTOM_Y = 9;
        const int BOSS_CENTER_X = (BOSS_LEFT_X + BOSS_RIGHT_X) / 2;
        const int BOSS_CENTER_Y = (BOSS_TOP_Y + BOSS_BOTTOM_Y) / 2;

        const int BOSS_L_ARM_X_L = 4;
        const int BOSS_L_ARM_X_R = 8;
        const int BOSS_L_ARM_Y_T = 4;
        const int BOSS_L_ARM_Y_B = 10;
        const int BOSS_L_ARM_CENTER_X = (BOSS_L_ARM_X_L + BOSS_L_ARM_X_R) / 2;
        const int BOSS_L_ARM_CENTER_Y = (BOSS_L_ARM_Y_T + BOSS_L_ARM_Y_B) / 2;

        const int BOSS_R_ARM_X_L = 22;
        const int BOSS_R_ARM_X_R = 26;
        const int BOSS_R_ARM_Y_T = 4;
        const int BOSS_R_ARM_Y_B = 10;
        const int BOSS_R_ARM_CENTER_X = (BOSS_R_ARM_X_L + BOSS_R_ARM_X_R) / 2;
        const int BOSS_R_ARM_CENTER_Y = (BOSS_R_ARM_Y_T + BOSS_R_ARM_Y_B) / 2;

        [DllImport("user32.dll")]

        public static extern short GetKeyState(int keyCode);
        public Field()
        {
        }
        public void Play()
        {
            Console.Clear();
            List<Boss> bossList = new List<Boss>();
            List<Boss> bossL_armList = new List<Boss>();
            List<Boss> bossR_armList = new List<Boss>();
            Ranking ranking = new Ranking();
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
            const int BOSS_BULLET = 988;
            const int BOSS_LEFT_ARM = 986;
            const int BOSS_RIGHT_ARM = 985;
            const int LEFT_ARM_BULLET = 940;
            const int RIGHT_ARM_BULLET = 950;
            int pos_X = 15;
            int pos_Y = 35;
            int bullet_X = pos_X;
            int score = 0;
            int bombCount = 3;
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
            int move_X = 0;
            int move_Y = 0;
            int bombTimer = 0;
            int bombTimerCheck = 0;
            int enemySpawnTimer = 0;
            int enemySpawnCheck = 0;
            int bossHp = 50000;
            int enemyMove_randX;
            int enemyMove_randY;
            bool enemyLeft = false;
            bool enemyRight = false;
            bool enemyTop = false;
            bool enemyBottom = false;

            int leftarmcount = 0;
            int rightarmcount = 0;
            int randE_X = 0;
            int randE_Y = 0;
            int itemTimer = 0;
            int powerTimer = 0;
            int enemyPatern = 0 ;
            bool hardMode = false;
            bool bossOn = false;
            bool respawn = false;
            bool clearEnemy = true;
            bool leftarmBreak=false;
            bool rightarmBreak=false;

            int randomPower = 0;
            int randomBomb = 0;
            int bossBulletTimer = 0;
            int bossBulletCheck = 0;

            int boss_L_X = BOSS_LEFT_X;
            int boss_R_X = BOSS_RIGHT_X;
            int boss_T_Y = BOSS_TOP_Y;
            int boss_B_Y = 9;
            int bossCenter_X = BOSS_CENTER_X;
            int bossCenter_Y = BOSS_CENTER_Y;

            int leftArm_hp = 5000;
            int rightArm_hp = 5000;

            int leftArmTimer = 0;
            int leftArmCheck = 0;
            int rightArmTimer = 0;
            int rightArmCheck = 0;

            int randomEnemyMove = 0;


            const int ENEMY_WING = 555;

            int countEnemy = 45;
            List<Bullet> playerBulletList = new List<Bullet>();
            List<Enemy> enemyList = new List<Enemy>();
            List<Bullet> enemyBulletList = new List<Bullet>();
            List<Bomb> bombList = new List<Bomb>();
            List<PowerUP> powerList = new List<PowerUP>();
            List<Bullet> bossBulletList = new List<Bullet>();
            List<Bullet> leftArmBulletList = new List<Bullet>();
            List<Bullet> rightArmBulletlist = new List<Bullet>();
            Random rnd = new Random();


            int respawnTimeCheck;

            bool autoFire = false;
            Console.CursorVisible = false;
            ConsoleKeyInfo inputKey;

            while (true)
            {
                currentTick=System.Environment.TickCount;
                if (Title.isResetGame == true)
                {
                    break;
                }
                int shootCount = 0;
                int shootDelay = 0;
                ClearBuffer();
                //currentTick = System.Environment.TickCount;
                //if (currentTick - lastTick < tickRate)
                //{
                //    continue;
                //}
                //else
                
                
                
               


                DrawHp(playerHp);
                DrawBomb(bombCount);
                DrawScore(score);
                CursorPosition(0, 0);
                    for (int y = 0; y < 50; y++)
                    {
                        for (int x = 0; x < 32; x++)
                        {
                            if (x == 31 && y < 41)
                            {
                                Console.Write("│");
                            }
                            if (y == 41 && x < 31)
                            {
                                Console.Write("──");
                                continue;
                            }
                            if (y == 41 && x == 31)
                            {
                                Console.Write("┘");
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
                            if (enemy.enemyPos_Y > 1)
                            {
                                
                            board[enemy.enemyPos_Y - 1, enemy.enemyPos_X] = ENEMY_WING;

                            }
                            if (enemy.enemyPos_Y > 2)
                            {

                                board[enemy.enemyPos_Y - 2, enemy.enemyPos_X] = ENEMY_WING;

                            }
                            if (enemy.enemyPos_X>1)
                            {
                            board[enemy.enemyPos_Y - 1, enemy.enemyPos_X-1] = ENEMY_WING;

                            }
                            if(enemy.enemyPos_X<29)
                            {
                            board[enemy.enemyPos_Y - 1, enemy.enemyPos_X+1] = ENEMY_WING;

                            }
                        }
                        foreach (var boss in bossList)
                            {
                                board[boss.boss_Y, boss.boss_X] = BOSS;
                            }
                            foreach (var powerItem in powerList)
                            {
                                board[powerItem.item_Y, powerItem.item_X] = POWER;
                            }
                            foreach (var bossBullet in bossBulletList)
                            {
                                board[bossBullet.Y, bossBullet.X] = BOSS_BULLET;
                            }
                            foreach (var lArm in bossL_armList)
                            {
                                board[lArm.boss_Y, lArm.boss_X] = BOSS_LEFT_ARM;
                            }
                            foreach (var rArm in bossR_armList)
                            {
                                board[rArm.boss_Y, rArm.boss_X] = BOSS_RIGHT_ARM;
                            }
                            foreach(var lbullet in leftArmBulletList)
                            {
                                board[lbullet.Y, lbullet.X] = LEFT_ARM_BULLET;
                            }
                            foreach(var rbullet in rightArmBulletlist)
                            {
                                board[rbullet.Y,rbullet.X]= RIGHT_ARM_BULLET;
                            }

                            if (unitType == P_38)
                            {
                                board[pos_Y + 1, pos_X] = PLAYER_WING;
                                board[pos_Y + 1, pos_X - 1] = PLAYER_WING;
                                board[pos_Y + 1, pos_X + 1] = PLAYER_WING;
                                board[pos_Y + 2, pos_X] = PLAYER_WING;
                            }
                            else if (unitType == SPITFIRE)
                            {
                                board[pos_Y, pos_X - 1] = PLAYER_WING;
                                board[pos_Y, pos_X + 1] = PLAYER_WING;
                                board[pos_Y + 1, pos_X] = PLAYER_WING;
                                board[pos_Y + 2, pos_X] = PLAYER_WING;
                            }
                            else if (unitType == J7W_SHINDEN)
                            {
                                board[pos_Y + 2, pos_X - 1] = PLAYER_WING;
                                board[pos_Y + 2, pos_X + 1] = PLAYER_WING;
                                board[pos_Y + 1, pos_X] = PLAYER_WING;
                                board[pos_Y + 2, pos_X] = PLAYER_WING;
                            }

                            if (pos_X == x && pos_Y == y)
                            {
                                if (isGodMod == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                else if (unitType == P_38)
                                {

                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                else if (unitType == SPITFIRE)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                }
                                else if (unitType == J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                if (unitType == J7W_SHINDEN)
                                {
                                    Console.Write("∥");
                                }
                                else
                                {
                                    Console.Write("▲");

                                }
                                Console.ResetColor();


                            }
                            else if (board[y, x] == BULLET)
                            {
                                if (unitType == P_38)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                }
                                else if (unitType == SPITFIRE)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                else if (unitType == J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if (unitType == J7W_SHINDEN && powerCount >= 2)
                                {
                                    Console.Write("▲");
                                }
                                else
                                {

                                    Console.Write("§");
                                }
                                Console.ResetColor();
                            }
                            else if (board[y, x] == BOSS)
                            {

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("▣");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == BOSS_LEFT_ARM)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▩");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == BOSS_RIGHT_ARM)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▩");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == ENEMY)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("▼");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == POWER)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.BackgroundColor= ConsoleColor.Cyan;
                                Console.Write("Ｐ");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == BOMB)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor= ConsoleColor.Magenta;
                                Console.Write("Ｂ");
                                Console.ResetColor();
                            }
                            else if (board[y,x]==ENEMY_WING)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            Console.ResetColor();
                        }
                            else if (board[y, x] == PLAYER_WING)
                            {
                                if (isGodMod == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                else if (unitType == P_38)
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;

                                }
                                else if (unitType == SPITFIRE)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;

                                }
                                else if (unitType == J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;

                                }
                                if (board[pos_Y + 2, pos_X - 1] == PLAYER_WING && x < pos_X && unitType == J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("◀");
                                    Console.ResetColor();

                                }
                                else if (board[pos_Y + 2, pos_X + 1] == PLAYER_WING && x > pos_X && unitType == J7W_SHINDEN)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("▶");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("■");

                                }
                                Console.ResetColor();
                            }
                            else if (board[y, x] == ENEMY_BULLET)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("●");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == BOSS_BULLET)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("◆");
                                Console.ResetColor();
                            }
                            else if (board[y, x] == PLAYER_EXPLODE)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("※");
                                Console.ResetColor();
                            }
                            else if (board[y,x]==LEFT_ARM_BULLET)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("♨");
                                Console.ResetColor();

                            }
                            else if (board[y,x]==RIGHT_ARM_BULLET)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("♥");
                                Console.ResetColor();
                            }
                        //    else if(bossList.Count!=0&& y > 0 && y < 20 && x == 2 || bossList.Count != 0 && x == 28 && y > 0 && y < 20)
                        //{
                            
                        //        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        //        Console.Write("▤");
                        //        Console.ResetColor();

                        //}

                        //   else if (bossList.Count!=0&& y == 20 && x > 2 && x < 28)

                        //    {
                        //        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        //        Console.Write("▤");
                        //        Console.ResetColor();
                        //    }
                        else if (board[y, x] == 0)
                            {

                                Console.Write("  ");

                            }
                        }
                        Console.WriteLine();

                    }
                    //CursorPosition(0, 42);
                    //Console.Write("체력 {0} 폭탄 {1} 파워 {2}", playerHp, bombCount, powerCount);
                    //CursorPosition(0, 43);
                    //Console.Write("보스체력 {0}        ", bossHp);
                    

                    if (clearEnemy == true)
                    {
                     enemyPatern = rnd.Next(5);
                     if (enemyList.Count < 6)
                        {
                            if (enemySpawnTimer == 0 && enemyList.Count == 0)
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
                                enemyBulletList.Add(new Bullet(randE_X, randE_Y + 1));
                                enemySpawnTimer = 0;
                            }
                        }
                        else
                        {
                            clearEnemy = false;
                        }
                    }
                    for (int j = enemyBulletList.Count - 1; j >= 0; j--)
                    {

                        var eBullet = enemyBulletList[j];
                        if (eBullet.bulletTimer == 0)
                        {
                            eBullet.bulletTimer = System.Environment.TickCount;
                        }
                        eBullet.bulletCheck = System.Environment.TickCount;
                        if (eBullet.bulletCheck - eBullet.bulletTimer <= 30)
                        {

                        }
                        else
                        {
                        //if(enemyPatern==1||enemyPatern==2)
                        //{

                        ////총알이 따라다니는기믹
                        //if (eBullet.X > pos_X)
                        //{
                        //    eBullet.X -= 1;
                        //}
                        //else
                        //{
                        //    eBullet.X += 1;
                        //}
                        //}
                        // if(enemyPatern==3&&eBullet.Y>20)
                        //{
                        //    eBullet.X -= 1;
                        //}
                        //else if(enemyPatern==4)
                        //{
                        //    eBullet.X += 1;
                        //}
                        
                        eBullet.Y += 1;
                            
                        

                            eBullet.bulletTimer = 0;
                        }



                        if (board[eBullet.Y, eBullet.X] == PLAYER_WING || eBullet.X == pos_X && eBullet.Y == pos_Y)
                        {
                            enemyBulletList.RemoveAt(j);
                            if (isGodMod == false)
                            {
                                playerHp -= 1;
                                Console.Beep();
                                Console.Beep();
                                Console.Beep();

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
                        else if (eBullet.Y > 39 || eBullet.X < 1 || eBullet.X > 29)

                        {
                            enemyBulletList.RemoveAt(j);
                        }
                        
                    }

                    if (bossHp <= 0)
                    {
                        bossClear = true;
                        bossList.Clear();
                    }
                    if (leftArm_hp <= 0)
                    {
                    leftArm_hp = 0;
                        bossL_armList.Clear();
                    leftarmBreak = true;
                    leftarmcount += 1;
                     }
                    if (rightArm_hp <= 0)
                    {
                    rightArm_hp = 0;
                        bossR_armList.Clear();
                        rightarmBreak = true;
                    rightarmcount += 1;
                    }
                if (rightarmBreak == true&&rightarmcount==1)
                {
                    score += 15000;
                    rightarmBreak=false;

                }
                    if(leftarmBreak == true&&leftarmcount==1)
                { 
                    score += 15000;
                    leftarmBreak=false;
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
                            else
                        {
                            score += 1500;
                        }
                            bombList.RemoveAt(i);
                        }
                        if (itemTimer == 0)
                        {
                            itemTimer = System.Environment.TickCount;
                        }
                        currentTick = System.Environment.TickCount;
                        if (currentTick - itemTimer <= 100)
                        {

                        }
                        else
                        {

                            bomb.bomb_Y += 1;
                            itemTimer = 0;
                        }
                        if (bomb.bomb_Y > 39)
                        {
                            bombList.RemoveAt(i);

                        }
                    }

                    for (int k = bossBulletList.Count - 1; k >= 0; k--)//보스총움직임
                    {
                        var bossBullet = bossBulletList[k];
                        if (bossBullet.X > BOSS_CENTER_X)
                        {
                            if (bossBullet.Y % 4 == 0)
                            {
                                bossBullet.X += 1;

                            }
                        }
                        else if (bossBullet.X > BOSS_CENTER_X && bossBullet.Y >= bossCenter_Y)
                        {
                            bossBullet.X += 1;
                        }
                        if (bossBullet.X < BOSS_CENTER_X)
                        {

                            if (bossBullet.Y % 4 == 0)
                            {

                                bossBullet.X -= 1;
                            }
                        }
                        else if (bossBullet.X < BOSS_CENTER_X && bossBullet.Y >= bossCenter_Y)
                        {
                            bossBullet.X -= 1;
                        }

                        if (bossBullet.Y > BOSS_CENTER_Y)
                        {
                            bossBullet.Y += 1;
                        }
                        if (bossBullet.Y < BOSS_CENTER_Y)
                        {
                            bossBullet.Y -= 1;
                        }
                        if (bossBullet.X < 1 || bossBullet.X > 29 || bossBullet.Y < 1 || bossBullet.Y > 39)
                        {
                            bossBulletList.RemoveAt(k);
                        }


                        if (board[bossBullet.Y, bossBullet.X] == PLAYER_WING || bossBullet.X == pos_X && bossBullet.Y == pos_Y)
                        {
                            if (isGodMod == false)
                            {
                                playerHp -= 1;
                                Console.Beep();
                                Console.Beep();
                                Console.Beep();

                                powerCount = 0;
                                if (respawnTick == 0)
                                {
                                    respawnTick = System.Environment.TickCount;
                                }
                                currentTick = System.Environment.TickCount;
                                if (currentTick - respawnWaitTime <= 200)
                                {

                                }
                                else
                                {
                                    respawnTick = 0;


                                    pos_X = 15;
                                    pos_Y = 35;
                                    isGodMod = true;

                                }

                            }
                        }

                    }//보스총알 움직임
                    for (int i = leftArmBulletList.Count - 1; i >= 0; i--)
                    {
                        var leftbullet = leftArmBulletList[i];
                        if (leftbullet.Y > BOSS_L_ARM_CENTER_Y)
                        {
                            leftbullet.Y += 1;
                        }

                        if (leftbullet.Y > 39)
                        {
                            leftArmBulletList.RemoveAt(i);
                        }
                        if (board[leftbullet.Y, leftbullet.X] == PLAYER_WING || leftbullet.X == pos_X && leftbullet.Y == pos_Y)
                        {
                            if (isGodMod == false)
                            {
                                playerHp -= 1;
                                Console.Beep();
                                Console.Beep();
                                Console.Beep();

                                powerCount = 0;
                                if (respawnTick == 0)
                                {
                                    respawnTick = System.Environment.TickCount;
                                }
                                currentTick = System.Environment.TickCount;
                                if (currentTick - respawnWaitTime <= 200)
                                {

                                }
                                else
                                {
                                    respawnTick = 0;


                                    pos_X = 15;
                                    pos_Y = 35;
                                    isGodMod = true;

                                }

                            }
                        }
                    }
                    for(int i=rightArmBulletlist.Count-1; i>=0;i--)
                    {
                        var rightBullet = rightArmBulletlist[i];
                      if(rightBullet.Y>BOSS_R_ARM_Y_B)
                    {
                            rightBullet.Y += 1;

                    }
                        
                        if(rightBullet.Y>39)
                        {
                            rightArmBulletlist.RemoveAt(i);
                        }
                        if (board[rightBullet.Y, rightBullet.X] == PLAYER_WING || rightBullet.X == pos_X && rightBullet.Y == pos_Y)
                        {
                            if (isGodMod == false)
                            {
                                playerHp -= 1;
                                Console.Beep();
                                Console.Beep();
                                Console.Beep();

                                powerCount = 0;
                                if (respawnTick == 0)
                                {
                                    respawnTick = System.Environment.TickCount;
                                }
                               
                                if (currentTick - respawnWaitTime <= 200)
                                {

                                }
                                else
                                {
                                    respawnTick = 0;


                                    pos_X = 15;
                                    pos_Y = 35;
                                    isGodMod = true;

                                }

                            }
                        }


                    }

                    if (bossBulletList.Count == 0 && countEnemy >= 50)
                    {
                        if (bossBulletTimer == 0)
                        {
                            bossBulletTimer = System.Environment.TickCount;
                        }
                        //bossBulletCheck = System.Environment.TickCount;
                        if (currentTick - bossBulletTimer <= 500)
                        {

                        }
                        else
                        {
                            bossBulletTimer = 0;

                            bossBulletList.Add(new Bullet(BOSS_CENTER_X + 1, BOSS_CENTER_Y + 1));

                            bossBulletList.Add(new Bullet(BOSS_CENTER_X - 1, BOSS_CENTER_Y + 1));

                            bossBulletList.Add(new Bullet(BOSS_CENTER_X, BOSS_CENTER_Y + 1));
                        }

                    }
                    if (leftArmBulletList.Count == 0 && countEnemy >= 50&&leftArm_hp>0)
                    {
                        if (leftArmTimer == 0)
                        {
                            leftArmTimer = System.Environment.TickCount;
                        }
                        
                        if (currentTick - leftArmTimer <= 1000)
                        {

                        }
                        else
                        {
                            leftArmTimer = 0;
                            leftArmBulletList.Add(new Bullet(BOSS_L_ARM_CENTER_X, BOSS_L_ARM_Y_B + 1));
                            leftArmBulletList.Add(new Bullet(BOSS_L_ARM_CENTER_X, BOSS_L_ARM_Y_B + 2));
                        leftArmBulletList.Add(new Bullet(BOSS_L_ARM_CENTER_X-1, BOSS_L_ARM_Y_B + 1));
                        leftArmBulletList.Add(new Bullet(BOSS_L_ARM_CENTER_X-1, BOSS_L_ARM_Y_B + 2));


                    }
                }
                    if(rightArmBulletlist.Count== 0 && countEnemy >= 50&&rightArm_hp>0)
                    {
                        if(rightArmTimer == 0)
                        {
                            rightArmTimer = System.Environment.TickCount;
                        }
                       
                        if(currentTick - rightArmCheck <= 3000) 
                        {

                        }
                        else
                        {
                            rightArmTimer = 0;
                            rightArmBulletlist.Add(new Bullet(BOSS_R_ARM_CENTER_X, BOSS_R_ARM_Y_B + 1));
                            rightArmBulletlist.Add(new Bullet(BOSS_R_ARM_CENTER_X, BOSS_R_ARM_Y_B + 2));
                        rightArmBulletlist.Add(new Bullet(BOSS_R_ARM_CENTER_X, BOSS_R_ARM_Y_B + 3));
                        rightArmBulletlist.Add(new Bullet(BOSS_R_ARM_CENTER_X, BOSS_R_ARM_Y_B + 4));

                    }
                    }



                    if (playerHp == 0)
                    {

                        ClearBuffer();
                        gameOver.OverDisplay();
                        playerHp = 3;
                        score -= 10000;
                        bombCount = 2;
                        respawn = true;
                    }
                    if (respawn)
                    {
                        isGodMod = true;
                        respawn = false;
                    }
                    if (isGodMod == true)
                    {
                        if (respawnTick == 0) // 최초 무적 상태 진입 시간 설정
                        {
                            respawnTick = System.Environment.TickCount;
                        }
                        respawnTimeCheck = System.Environment.TickCount;
                        CursorPosition(0, 40);
                        if (respawnTimeCheck - respawnTick <= 3000)
                        {
                           

                        }
                        else
                        {

                            isGodMod = false;

                            respawnTick = 0;
                        }
                    }
                    for (int i = enemyList.Count - 1; i >= 0; i--)
                    {
                    
                    var enemy = enemyList[i];
                    if (board[enemy.enemyPos_Y, enemy.enemyPos_X] == PLAYER_WING || enemy.enemyPos_X == pos_X && enemy.enemyPos_Y == pos_Y)
                    {
                        if (isGodMod == false)
                        {
                            playerHp -= 1;
                            Console.Beep();
                            Console.Beep();
                            Console.Beep();

                            powerCount = 0;
                            if (respawnTick == 0)
                            {
                                respawnTick = System.Environment.TickCount;
                            }

                            if (currentTick - respawnWaitTime <= 200)
                            {

                            }
                            else
                            {
                                respawnTick = 0;


                                pos_X = 15;
                                pos_Y = 35;
                                isGodMod = true;

                            }
                        }
                    }
                        if (enemy.spawnTimer == 0)
                        {
                            enemy.spawnTimer = System.Environment.TickCount;
                        }
                        enemy.spawnCheck = System.Environment.TickCount;
                        if (enemy.spawnCheck - enemy.spawnTimer <= 100)
                        {

                        }
                        else
                        {
                            enemy.spawnTimer = 0;


                            
                            if(enemyPatern == 0)
                        {
                            enemyBottom = true;
                            enemyLeft = false;
                            enemyRight = false;
                        }
                            else if(enemyPatern==1)
                        {
                            enemyLeft = true;
                            enemyRight = false;
                            enemyBottom = false;
                        }
                            else if(enemyPatern==2)
                        {
                            enemyRight = true;
                            enemyBottom = false;
                            enemyLeft = false;
                        }
                            else if(enemyPatern==3)
                        {
                            enemyRight = true;
                            enemyBottom = true;
                            enemyLeft=false;
                        }
                            else if(enemyPatern==4)
                        {
                            enemyRight = false;
                            enemyBottom = true;
                            enemyLeft = true;
                        }
                            if(enemyBottom==true)
                        {
                            enemy.enemyPos_Y += 1;

                        }
                            if(enemyLeft==true)
                        {
                            enemy.enemyPos_X -= 1;
                        }
                            if(enemyRight==true)
                        {
                            enemy.enemyPos_X += 1;
                        }

                        }
                        if (hardMode == true)
                        {
                            enemy.enemyPos_X -= 1;
                        }
                        
                            for (int powerup = powerList.Count - 1; powerup >= 0; powerup--)
                            {
                                var dropItem = powerList[powerup];
                                if (powerTimer == 0)
                                {
                                    powerTimer = System.Environment.TickCount;

                                }
                                currentTick = System.Environment.TickCount;
                                if (currentTick - powerTimer <= 200)
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
                                    if(powerCount>=2)
                                {
                                    score += 4000;
                                }
                                else 
                                {
                                    score += 2000;
                                }
                                    powerList.RemoveAt(powerup);

                                }
                                if (dropItem.item_Y > 39)
                                {
                                    powerList.RemoveAt(powerup);
                                }

                            }
                        

                        if (enemy.enemyPos_X < 1 || enemy.enemyPos_X > 30 || enemy.enemyPos_Y > 39)
                        {
                            enemyList.RemoveAt(i);
                            enemySpawnTimer = 0;

                        }
                        if (enemy.enemyPos_X == pos_X)
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
                                enemyBulletList.Add(new Bullet(enemy.enemyPos_X, enemy.enemyPos_Y + 1));

                            }

                        }
                        else if (enemy.enemyPos_Y == pos_Y && enemy.enemyPos_X > pos_X)
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
                                enemyBulletList.Add(new Bullet(enemy.enemyPos_X - 1, enemy.enemyPos_Y));

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
                                enemyBulletList.Add(new Bullet(enemy.enemyPos_X + 1, enemy.enemyPos_Y));

                            }
                        }
                    }

                    for (int i = playerBulletList.Count - 1; i >= 0; i--)//플레이어 사격
                    {
                        if (autoFire == true)
                        {
                        currentTick= System.Environment.TickCount;  
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
                                                // playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
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
                        
                        

                        if (bullet.X < 1 || bullet.X > 30 || bullet.Y > 49 || bullet.Y < 1)
                        {
                            playerBulletList.RemoveAt(i);
                        }
                        if (bossList.Count != 0)
                        {
                            if (bullet.X > boss_L_X && bullet.X < boss_R_X && bullet.Y == boss_B_Y)
                            {

                                bossHp -= 50;
                                if (unitType == J7W_SHINDEN)
                                {
                                    bossHp -= 20;
                                }
                                playerBulletList.RemoveAt(i);

                            }
                            if (bullet.X > BOSS_L_ARM_X_L && bullet.X < BOSS_L_ARM_X_R && bullet.Y == BOSS_L_ARM_Y_B&&leftArm_hp>=0)
                            {
                                leftArm_hp -= 50;
                                if (unitType == J7W_SHINDEN)
                                {
                                    leftArm_hp -= 20;
                                }
                                playerBulletList.RemoveAt(i);
                            }
                            if (bullet.X > BOSS_R_ARM_X_L && bullet.X < BOSS_R_ARM_X_R && bullet.Y == BOSS_R_ARM_Y_B&&rightArm_hp>=0)
                            {
                                rightArm_hp -= 50;
                                if (unitType == J7W_SHINDEN)
                                {
                                    rightArm_hp -= 20;
                                }
                                playerBulletList.RemoveAt(i);
                            }



                        }

                        if (unitType == SPITFIRE && powerCount >= 1)
                        {
                            if (i == playerBulletList.Count - 5)
                            {
                                bullet.X -= 1;
                            }
                            if (i == playerBulletList.Count - 4)
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
                        if (unitType == SPITFIRE && powerCount >= 2)
                        {
                            if (bullet.Y == 20)
                            {
                                if (i == playerBulletList.Count - 5)
                                {
                                    bullet.X = pos_X;
                                }
                                if (i == playerBulletList.Count - 4)
                                {
                                    bullet.X = pos_X;
                                }
                                if (i == playerBulletList.Count - 6)
                                {
                                    bullet.X = pos_X;
                                }
                                if (i == playerBulletList.Count - 7)
                                {
                                    bullet.X = pos_X;
                                }
                            }
                        }
                        if (unitType == J7W_SHINDEN && powerCount >= 1&&isBomb_Explode==false)
                        {
                            if (bullet.Y % 2 == 0)
                            {
                                bullet.X -= 1;
                            }
                            if (bullet.Y % 2 == 1)
                            {
                                bullet.X += 1;
                            }
                        }
                        if (isBomb_Explode == true && unitType == P_38)
                        {

                            if (i % 2 == 0)
                            {
                                bullet.X += 1;
                            }
                            else if (i % 2 == 1)
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
                                    if (powerList.Count == 0)
                                    {
                                     randomPower=rnd.Next(1, 100);
                                    if(randomPower < 20)
                                    {
                                        powerList.Add(new PowerUP(enemy.enemyPos_X, enemy.enemyPos_Y + 1));

                                    }

                                    }
                                    //if (bombList.Count == 0)
                                    //{
                                    //    bombList.Add(new Bomb(enemy.enemyPos_X, enemy.enemyPos_Y + 2));

                                    //}
                                for (int k = 0; k < enemyList.Count; k++)
                                {
                                    if ( bombList.Count == 0&&enemyList[k].enemyHp<=0)
                                    {
                                        randomBomb=rnd.Next(1, 100);
                                        if (randomBomb<10)
                                        {
                                        bombList.Add(new Bomb(enemyList[k].enemyPos_X, enemyList[k].enemyPos_Y + 2));

                                        }
                                        break; 
                                    }
                                }
                                enemyList.RemoveAt(j);
                               
                                    countEnemy += 1;

                                
                                    enemySpawnTimer = 0;
                                    score += 1000;
                                    bombPer = rnd.Next(0, 100);
                                    if (bombPer > 0 && bombPer < 10)
                                    {
                                        bomb_X = enemy.enemyPos_X;
                                        bomb_Y = enemy.enemyPos_Y + 10;
                                    }

                                }

                            }
                        }



                    }
                    if (enemyList.Count == 0)
                    {
                        clearEnemy = true;
                    }
                    if (bossClear)
                    {

                        ranking.RecordRank(score);
                        enemyList.Clear();
                        playerBulletList.Clear();
                        enemyBulletList.Clear();
                        bossBulletList.Clear();
                        rightArmBulletlist.Clear();
                    leftArmBulletList.Clear();
                        bossR_armList.Clear();
                        bossL_armList.Clear();
                    
                        if (pos_X > 15)
                        {
                            pos_X -= 1;
                            Thread.Sleep(50);
                        }
                        else if (pos_X < 15)
                        {
                            pos_X += 1;
                            Thread.Sleep(50);
                        }
                        if (pos_X == 15)
                        {
                            pos_Y -= 1;
                            Thread.Sleep(50);

                        }
                        if (pos_Y == 1)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    if (countEnemy == 50)
                    {
                        bossOn = true;
                    }
                    if (bossOn == true)
                    {
                        for (int y = boss_T_Y; y < boss_B_Y; y++)
                        {
                            for (int x = boss_L_X; x < boss_R_X; x++)
                            {

                                bossList.Add(new Boss(x, y));


                            }

                        }
                        for (int y = BOSS_L_ARM_Y_T; y < BOSS_L_ARM_Y_B; y++)
                        {
                            for (int x = BOSS_L_ARM_X_L; x < BOSS_L_ARM_X_R; x++)
                            {
                            if(y<BOSS_L_ARM_Y_T + 2)
                            {

                            bossL_armList.Add(new Boss(x, y));
                            }

                            if (x>BOSS_L_ARM_X_L&&x<BOSS_L_ARM_X_R-1&&y>BOSS_L_ARM_Y_T+1)
                            {

                                bossL_armList.Add(new Boss(x, y));
                            }
                            }
                        }
                        for (int y = BOSS_R_ARM_Y_T; y < BOSS_R_ARM_Y_B; y++)
                        {
                            for (int x = BOSS_R_ARM_X_L; x < BOSS_R_ARM_X_R; x++)
                            {
                            if(y<BOSS_R_ARM_Y_T+2)
                            {
                                bossR_armList.Add(new Boss(x, y));

                            }
                            if(x>BOSS_R_ARM_X_L&&x< BOSS_R_ARM_X_R-1&&y> BOSS_R_ARM_Y_T+1)
                            {
                                bossR_armList.Add(new Boss(x, y));

                            }
                        }
                        }
                        bossOn = false;

                    }

                    //CursorPosition(60, 1);
                    //Console.Write("SCORE {0}         ", score);
                    //CursorPosition(0, 61);
                    //Console.WriteLine("BombCount {0}", bombCount);
                    //if (unitType == P_38)
                    //{
                    //    CursorPosition(0, 46);
                    //    Console.Write("유닛 타입 : P_38");

                    //}
                    //else if (unitType == SPITFIRE)
                    //{
                    //    CursorPosition(0, 46);
                    //    Console.Write("유닛 타입 : SPITFIRE");
                    //}
                    //else if (unitType == J7W_SHINDEN)
                    //{
                    //    CursorPosition(0, 46);
                    //    Console.Write("유닛 타입 : J7W_SHINDEN");
                    //}
                    //else
                    //{
                    //    CursorPosition(0, 46);

                    //    Console.Write("버그");
                    //}
                    //CursorPosition(0, 47);
                    //Console.Write("처치한 적 {0}", countEnemy);


                    //Thread.Sleep(10);
                    if (isBomb_Explode == true)
                    {

                        if (bombTimer == 0)
                        {
                            bombTimer = System.Environment.TickCount;

                        }
                        
                        if (currentTick - bombTimer <= 800)
                        {

                        }
                        else
                        {
                            isBomb_Explode = false;
                            playerBulletList.Clear();
                            bombTimer = 0;
                        }
                    }

                    if ((GetKeyState((int)ConsoleKey.LeftArrow) & 0x8000) != 0)
                    {
                        if (pos_X > 1)
                        {
                            move_X = -1;
                            pos_X += move_X;

                        }
                    CursorPosition(66, 4);
                    Console.Write("◀");
                }
                    else
                {
                    CursorPosition(66, 4);
                    Console.Write("  ");
                }
               
                if ((GetKeyState((int)ConsoleKey.RightArrow) & 0x8000) != 0)
                    {
                        if (pos_X < 29)
                        {
                            move_X = 1;
                            pos_X += move_X;

                        }
                    CursorPosition(74, 4);
                    Console.Write("▶");
                }
                else
                {
                    CursorPosition(74, 4);
                    Console.Write("  ");
                }
                
                if ((GetKeyState((int)ConsoleKey.UpArrow) & 0x8000) != 0)
                    {
                        if (pos_Y > 1)
                        {
                            move_Y = -1;
                            pos_Y += move_Y;

                        }
                    CursorPosition(70, 2);
                    Console.Write("▲");
                }
                else
                {
                    CursorPosition(70, 2);
                    Console.Write("  ");
                }
                
                if ((GetKeyState((int)ConsoleKey.DownArrow) & 0x8000) != 0)
                    {
                        if (pos_Y < 39)
                        {
                            move_Y = 1;
                            pos_Y += move_Y;

                        }
                    CursorPosition(70, 4);
                    Console.Write("▼");
                }
                else
                {
                    CursorPosition(70, 4);
                    Console.Write("  ");
                }
                if((GetKeyState((int)ConsoleKey.Z) &0x8000)!=0)
                {
                    CursorPosition(65, 9);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Ｚ");
                    Console.ResetColor();
                    
                }
                else
                {
                    CursorPosition(65, 9);
                    Console.ResetColor();
                    Console.Write("Ｚ");
                }
                if((GetKeyState((int)ConsoleKey.X) &0x8000)!=0)
                {
                    CursorPosition(65, 12);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Ｘ");
                    Console.ResetColor();
                }
                else
                {
                    CursorPosition(65, 12);
                    Console.ResetColor();
                    Console.Write("Ｘ");
                }
                    CursorPosition(69, 9);
                Console.Write("총알 발사");
                CursorPosition(69, 12);
                    Console.Write("폭탄 사용");
                if(autoFire)
                {
                    CursorPosition(65, 15);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Ａ  오토파이어");
                    Console.ResetColor();
                }
                else
                {
                    CursorPosition(65, 15);
                    Console.Write("Ａ  오토파이어");
                    Console.ResetColor();
                }
                
               




                if (!bossClear)
                    {

                        if (Console.KeyAvailable)
                        {

                            inputKey = Console.ReadKey(false);

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
                                    if (hardMode == false)
                                    {
                                        hardMode = true;

                                    }
                                    else
                                    {
                                        hardMode = false;
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
                                                    //playerBulletList.Add(new Bullet(pos_X, pos_Y - shootCount - shootDelay));
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
                                                if (powerCount >= 2 && unitType == J7W_SHINDEN)
                                                {
                                                    if (pos_X > 1)
                                                    {
                                                        playerBulletList.Add(new Bullet(pos_X - 1, pos_Y - shootCount - shootDelay - 1));

                                                    }
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
                                    if (isBomb_Explode == true && bombCount > 0 && unitType == SPITFIRE)
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
                                    playerBulletList.Clear();
                                    bombCount -= 1;
                                        if (pos_X > 5 && pos_Y > 5)
                                        {
                                            for (int y = pos_Y - 5; y < pos_Y + 5; y++)
                                            {
                                                for (int x = pos_X - 5; x < pos_X + 5; x++)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));
                                                }
                                            }

                                        }
                                        else if (pos_X > 0 && pos_Y > 5)
                                        {
                                            for (int y = pos_Y - 5; y < pos_Y + 5; y++)
                                            {
                                                for (int x = pos_X - pos_X; x < pos_X + 5; x++)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));
                                                }
                                            }

                                        }
                                        else if (pos_X > 35 && pos_Y > 5)
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
                                            for (int y = pos_Y - pos_Y; y < pos_Y + 5; y++)
                                            {
                                                for (int x = pos_X - 5; x < pos_X; x++)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));
                                                }
                                            }

                                        }
                                        else if (pos_X > 0 && pos_Y < 5)
                                        {
                                            for (int y = pos_Y - pos_Y; y < pos_Y + 5; y++)
                                            {
                                                for (int x = pos_X - pos_X; x < pos_X + 5; x++)
                                                {
                                                    playerBulletList.Add(new Bullet(x, y));
                                                }
                                            }

                                        }
                                    }
                                    if (isBomb_Explode == true && unitType == J7W_SHINDEN)
                                    {
                                        if (pos_Y > 9 && pos_X > 3)
                                        {
                                            for (int y = pos_Y - 9; y < pos_Y; y++)
                                            {
                                                for (int x = pos_X - 3; x < pos_X + 4; x++)
                                                {
                                                    if (y == pos_Y - 9 && x == pos_X)
                                                    {
                                                        playerBulletList.Add(new Bullet(x, y));

                                                    }
                                                    else if (y == pos_Y - 8 && x >= pos_X - 1 && x <= pos_X + 1)
                                                    {
                                                        playerBulletList.Add(new Bullet(x, y));

                                                    }
                                                    else if (y == pos_Y - 7 && x >= pos_X - 2 && x <= pos_X + 2)
                                                    {
                                                        playerBulletList.Add(new Bullet(x, y));

                                                    }
                                                    else if (y > pos_Y - 6)
                                                    {
                                                        playerBulletList.Add(new Bullet(x, y));

                                                    }
                                                    //playerBulletList.Add(new Bullet(x, y));
                                                }
                                            }

                                        }
                                        else if (pos_Y < 27)
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

               // }
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
        public void DrawHp(int hpC)
        {
            if(unitType==P_38)
            {
                DrawP38();
            }
            else if(unitType==SPITFIRE)
            {
                DrawSpitfire();
            }
            else if(unitType==J7W_SHINDEN)
            {
                Drawj7w();
            }
            CursorPosition(9, 44);
            Console.Write("Ｘ {0}",hpC);

        }
        public void DrawBomb(int bombC)
        {
            CursorPosition(15, 44);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ｂ");
            Console.ResetColor();
            CursorPosition(17, 44);
            Console.Write("Ｘ {0}",bombC);
        }
        public void DrawScore(int scoreC)
        {
            CursorPosition(25, 44);
                Console.Write("SCORE {0}",scoreC);
        }

        public void DrawMove()
        {

        }
        public void DrawP38()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            CursorPosition(3, 43);
            Console.Write("  ▲  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            CursorPosition(3, 44);

            Console.Write("■■■");
            CursorPosition(3, 45);

            Console.Write("  ■");
            Console.ResetColor();
        }
        public void DrawSpitfire()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            CursorPosition(3, 43);
            Console.Write("■");
            CursorPosition(5, 43);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("▲");
            CursorPosition(7, 43);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("■");
            CursorPosition(5, 44);
            Console.Write("■");
            CursorPosition(5, 45);
            Console.Write("■");
            Console.ResetColor();
        }
        public void Drawj7w()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CursorPosition(5, 43);
            Console.Write("∥");
            CursorPosition(5, 44);
            Console.Write("■");
            CursorPosition(3, 45);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("◀");
            CursorPosition(5, 45);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("■");

            CursorPosition(7, 45);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("▶");
            Console.ResetColor();

        }
    }


}


