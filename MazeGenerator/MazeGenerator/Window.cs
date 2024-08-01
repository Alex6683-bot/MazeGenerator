using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.MazeGenerator
{
    class Window : GameWindow
    {
        Renderer renderer = new Renderer();
        public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings
        {
            Title = title,
            Size = (width, height)
        })
        { }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.5f, 0.05f, 0.05f, 1.0f);
            renderer.Load();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            renderer.Render();

            SwapBuffers();
        }

    }
}
