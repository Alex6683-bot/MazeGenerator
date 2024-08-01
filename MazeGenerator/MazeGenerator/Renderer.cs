using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    class Renderer
    {
        Cell cell;
        public void Load()
        {
            cell = new Cell();
        }

        public void Render()
        {
            cell.Render();
        }
    }
}
