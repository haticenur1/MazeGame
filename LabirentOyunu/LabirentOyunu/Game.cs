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

        public static int endX = 0;
        public static int endY = 0;
        public static List<string> coordinatesList = new List<string>();

        private Map myMap;
        public static Player players = new Player(0, 1);

        public static string wall = "|";
        public static string path = " ";
        public static string finish = "X";
        public void Start()
        {
            
            string[,] gameMap =
            {
                {wall,wall,wall,wall,wall,wall,wall,wall,wall,wall,wall },
                {path,path,wall,wall,wall,path,path,path,path,path,wall },
                {wall,path,wall,wall,wall,wall,path,wall,wall,path,wall },
                {wall,path,path,path,path,path,path,wall,wall,path,wall },
                {wall,path,wall,path,wall,wall,path,wall,wall,path,wall },
                {wall,path,wall,path,wall,wall,path,wall,wall,wall,wall },
                {wall,wall,wall,path,wall,wall,path,path,path,path,wall },
                {wall,wall,wall,path,path,wall,wall,wall,wall,path,finish },
                {wall,wall,wall,wall,wall,wall,wall,wall,wall,wall,wall },

            };
            if (Program.menu == 1)
            {
                players = new Player(0, 1);
            }
            
            myMap = new Map(gameMap);
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
                { 
                    players.Y -= 1;
                    endY = players.Y;
                    Save();
                }
            }
            if (info.Key == downKey || info.Key == ConsoleKey.DownArrow)
            {
                if (myMap.Walkable(players.X, players.Y + 1))
                { 
                    players.Y += 1;
                    endY = players.Y;
                    Save();
                }
            }

            if (info.Key == leftKey || info.Key == ConsoleKey.LeftArrow)
            {
                if (myMap.Walkable(players.X - 1, players.Y))
                {
                    players.X -= 1;
                    endX = players.X;
                    Save();
                }
            }

            if (info.Key == rightKey || info.Key == ConsoleKey.RightArrow)
            {
                if (myMap.Walkable(players.X + 1, players.Y)) 
                { 
                    players.X += 1;
                    endX = players.X;
                    Save();
                }
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

        public void Save()
        {
            List<string> coordinates = new List<string>();
            coordinates.Add(Convert.ToString(endX));
            coordinates.Add(Convert.ToString(endY));
            File.WriteAllLines(@"C:\Users\cozum\Desktop\Oyun Kayıt\Kayıt1.txt", coordinates);
        }
        public void Load()
        {
            StreamReader reader = new StreamReader(@"C:\Users\cozum\Desktop\Oyun Kayıt\Kayıt1.txt");
            string cordinates ;
            try
            {
                while ((cordinates = reader.ReadLine()) != null)
                {
                    coordinatesList.Add(cordinates);
                }
                int x = Convert.ToInt32(coordinatesList[0]);
                int y = Convert.ToInt32(coordinatesList[1]);
                players.X = x;
                players.Y = y;
                reader.Close();
                Console.Clear();
                Start();
            }
            catch (Exception)
            {
                Console.WriteLine("Kayıtlı oyununuz yok.");
            }
           
        }
       
        private void GameLoop()
        {
            while (true)
            {
                DrawFrame();

                HandlePlayerInput();
                
                string elementAtPlay = myMap.GetElementAt(players.X,players.Y);
                if (elementAtPlay == finish)
                {
                    Console.WriteLine("\n\nTebrikler kazandınız.");
                    break;
                    
                }

                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
