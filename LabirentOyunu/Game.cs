using System;
using System.IO;
using System.Collections.Generic;
namespace MazeGame
{
    class Game
    {
        public static ConsoleKeyInfo ınfoUp;
        public static ConsoleKeyInfo ınfodown;
        public static ConsoleKeyInfo ınfoLeft;
        public static ConsoleKeyInfo ınfoRight;

        private Map myMap;
        private Player players;
        public void Start()
        {
            string[,] gameMap =
            {
                {"|","|","|","|","|","|","|","|","|","|","|" },
                {" "," ","|","|","|"," "," "," "," "," ","|" },
                {"|"," ","|","|","|","|"," ","|","|"," ","|" },
                {"|"," "," "," "," "," "," ","|","|"," ","|" },
                {"|"," ","|"," ","|","|"," ","|","|"," ","|" },
                {"|"," ","|"," ","|","|"," ","|","|","|","|" },
                {"|","|","|"," ","|","|"," "," "," "," ","|" },
                {"|","|","|"," "," ","|","|","|","|"," ","X" },
                {"|","|","|","|","|","|","|","|","|","|","|" },

            };
            myMap = new Map(gameMap);
            players = new Player(0, 1);
            GameLoop();
        }
        public void DrawFrame()
        {
            Console.Clear();
            myMap.Draw();
            players.Draw();
        }
        public void HandlePlayerInput()
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            ConsoleKey key = info.Key;
            ConsoleKey upKey = ınfoUp.Key;
            ConsoleKey downKey = ınfodown.Key;
            ConsoleKey leftKey = ınfoLeft.Key;
            ConsoleKey rightKey = ınfoRight.Key;

            if (info.Key == upKey || info.Key == ConsoleKey.UpArrow)
            {
                if(myMap.Walkable(players.X, players.Y - 1))
                    players.Y -= 1;
            }
            if (info.Key == downKey || info.Key == ConsoleKey.DownArrow)
            {
                if (myMap.Walkable(players.X, players.Y + 1))
                    players.Y += 1;
            }

            if (info.Key == leftKey || info.Key == ConsoleKey.LeftArrow)
            {
                if (myMap.Walkable(players.X - 1, players.Y ))
                    players.X -= 1;
            }

            if (info.Key == rightKey || info.Key == ConsoleKey.RightArrow)
            {
                if (myMap.Walkable(players.X + 1, players.Y))
                    players.X += 1;
            }
            
        }
        public void KeySettings()
        {
            Console.WriteLine("Ok yönleri hariç oyunu oynamak istediğiniz tuşları belirtiniz");
            Console.WriteLine("Üst tuşu giriniz.");
            ınfoUp = Console.ReadKey(true);
            ConsoleKey upkey = ınfoUp.Key;
            Console.WriteLine(upkey);

            Console.WriteLine("Alt tuşu giriniz.");
            ınfodown = Console.ReadKey(true);
            ConsoleKey downkey = ınfodown.Key;
            Console.WriteLine(downkey);

            Console.WriteLine("Sol tuşu giriniz.");
            ınfoLeft = Console.ReadKey(true);
            ConsoleKey leftkey = ınfoLeft.Key;
            Console.WriteLine(leftkey);

            Console.WriteLine("Üst tuşu giriniz.");
            ınfoRight = Console.ReadKey(true);
            ConsoleKey rightkey = ınfoRight.Key;
            Console.WriteLine(rightkey);
        }

   
       
        private void GameLoop()
        {
            while (true)
            {
                DrawFrame();

                HandlePlayerInput();
                
                string elementAtPlay = myMap.GetElementAt(players.X,players.Y);
                if (elementAtPlay == "X")
                {
                    Console.WriteLine("\n\nTebrikler kazandınız.");
                    break;
                    
                }

                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
