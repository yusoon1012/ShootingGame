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
            Console.SetWindowSize(81, 51);
            ChooseCharacter chooseCharacter = new ChooseCharacter();
            Title title = new Title();
            Field myfield = new Field();
            title.gameTitle();
            chooseCharacter.Select();
            myfield.Play();
        }
    }
}