using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Enemy
    {
        public int enemyPos_X;
        public int enemyPos_Y;
        public int enemyHp;
        public Enemy(int x,int y)
        {
            enemyPos_X = x;
            enemyPos_Y = y;
        }
    }
}
