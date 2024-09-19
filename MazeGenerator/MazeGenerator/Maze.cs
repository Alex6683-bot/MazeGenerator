using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace MazeGenerator
{
    class Maze
    {
        public int resolution = 2;
        public readonly int baseSizeX = 7;
        public readonly int baseSizeY = 7;

        private Cell[,] _cells;

        public Cell[,] cells { get => _cells; }
        
        public void GenerateCells()
        {
            int sizeX = baseSizeX * resolution;
            int sizeY = baseSizeY * resolution;

            _cells = new Cell[sizeX, sizeY];    

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    _cells[y, x] = new Cell();
                    _cells[y, x].position = new Vector2(x - sizeX / 2, y - sizeY / 2);
                    _cells[y, x].size = new Vector2(baseSizeX / (float)sizeX, baseSizeY / (float)sizeY);
                    
                    //Setting outline to avoid overlapping
                    if (x != 0) _cells[y, x].left = false;
                    if (y != sizeY - 1) _cells[y, x].top = false;
                }
            }
        }

        public void RenderMaze(Camera2D camera)
        {
            for (int y = 0; y < baseSizeY * resolution; y++)
            {
                for (int x = 0; x < baseSizeX * resolution; x++)
                {
                    _cells[y, x].Render(camera);
                }
            }
        }
    }
}
