using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    static class Extension
    {
        public static string GetRootFolderPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\");
        }
    }
}
