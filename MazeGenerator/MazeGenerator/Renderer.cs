using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    class Renderer
    {
        Maze maze;
        Camera2D camera;
        public void Load()
        {
            maze = new Maze();
            camera = new Camera2D();
    
            maze.GenerateCells();
        }

        public void Render()
        {
            maze.RenderMaze(camera);
            camera.UpdateCamera();
        }
    }
}
