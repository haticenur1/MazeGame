using System;

namespace MazeGame
{
    class Map
    {
        private string [,] GameMap;
        private int Rows;
        private int Columns;

        public  Map(string[,] gameMap)
        {
            GameMap = gameMap;
            Rows = GameMap.GetLength(0);
            Columns = GameMap.GetLength(1);
        }
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string element = GameMap[y, x];
                    Console.SetCursorPosition(x, y);
                    if(element == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(element);
                }
            }
        }
        public string GetElementAt(int x,int y)
        {
            return GameMap[y, x];
        }
        public bool Walkable(int x , int y)
        {
            if(x < 0 || y < 0 || x >= Columns || y >= Rows)
            {
                return false;
            }

            return GameMap[y, x] == " " || GameMap[y, x] == "X";
        }
    }
}
