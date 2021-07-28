﻿using System;


namespace MazeGame
{
    class Program
    {     
        static void Main(string[] args)
        {
            Game currentGame = new Game();
            int menu;

            do {
                Console.WriteLine("\n1-Başla");
                Console.WriteLine("2-Yükle");
                Console.WriteLine("3-Ayarlar");
                Console.WriteLine("0-Çıkış");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:                        
                        currentGame.Start();
                        break;
                    case 2:
                        Console.WriteLine("Yükle");
                        break;
                    case 3:
                        Console.WriteLine("Ayarlar");
                        currentGame.KeySettings();
                        break;
                    case 0:
                        Console.WriteLine("Çıkış Yaptınız");
                        break;
                    default:
                        Console.WriteLine("Geçerli bir numara seçiniz.");
                        break;
                }
            }
            while (menu != 0);
        }
    }  
}
