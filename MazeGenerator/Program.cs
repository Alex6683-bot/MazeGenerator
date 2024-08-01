using MazeGenerator.MazeGenerator;
using OpenTK;
using System;


namespace MazeGenerator
{
    class Program
    {
        public static void Main()
        {
            using (Window window = new Window(1000, 1000, "Maze Generator"))
            {
                window.Run();
            }
        }
    }
}