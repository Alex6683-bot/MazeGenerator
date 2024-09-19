using System;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;


namespace MazeGenerator
{
    class Camera2D
    {
        public Vector3 position = new Vector3(0, 0, -15);

        private Matrix4 GetProjection() => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 1, 0.1f, 1000.0f);
        private Matrix4 GetView(Vector3 position) => Matrix4.CreateTranslation(position);

        public void SetCameraUniforms(Shader shader)
        {
            shader.SetUniformMatrix4("projection", GetProjection());
            shader.SetUniformMatrix4("view", GetView(position));
        }

        public void UpdateCamera()
        {
            //Zooming
            position.Z += Input.MouseCallBack().ScrollDelta.Y / 1.1f;
            position.Z = Math.Clamp(position.Z, -15, -2);

            //Panning
            if (Input.MouseCallBack().IsButtonDown(MouseButton.Button1))
            {
                position.X += Input.MouseCallBack().Delta.X / 100.0f;
                position.Y -= Input.MouseCallBack().Delta.Y / 100.0f;
                Console.WriteLine(Input.MouseCallBack().Delta);
            }
        }
    }
}