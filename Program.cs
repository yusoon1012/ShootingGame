using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 51);
            ChooseCharacter chooseCharacter = new ChooseCharacter();
            Ending ending = new Ending();
            Title title = new Title();
            Field myfield = new Field();
            Ranking ranking = new Ranking();
            while (true) 
            {

            title.gameTitle();
            chooseCharacter.Select();
            myfield.Play();
            ranking.RankBoard();
            }
            Console.Clear();
            
            Console.ReadLine();
        }
    }
}