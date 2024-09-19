using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System.Drawing;

namespace MazeGenerator
{
    class Cell
    {
        float[] vertices =
        {
            -0.5f,  0.5f, 0.0f,  0.0f, 1.0f,
             0.5f,  0.5f, 0.0f,  1.0f, 1.0f,
             0.5f, -0.5f, 0.0f,  1.0f, 0.0f,
            -0.5f, -0.5f, 0.0f,  0.0f, 0.0f
        };
        uint[] indices =
        {
            0, 1, 2,
            2, 3, 0
        };


        //Face Config
        public bool left = true;
        public bool right = true;
        public bool top = true;
        public bool bottom = true;

        //Transformation
        public Vector2 size = new Vector2(0.2f);
        public Vector2 position = new Vector2(0);
        public Color outlineColor = Color.Green;
        public Color backgroundColor = Color.Black;
        public float outlineWidth = 0.03f;

        int VBO = GL.GenBuffer();
        int EBO = GL.GenBuffer();
        int VAO = GL.GenVertexArray();

        Shader cellShader;
        public Cell()
        {
            cellShader = new Shader(Extension.GetRootFolderPath() + @"\MazeGenerator\Shaders\cellShader.vert", Extension.GetRootFolderPath() + @"\MazeGenerator\Shaders\cellShader.frag");
            GL.BindVertexArray(VAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

        }

        private void SetUniforms()
        {
            cellShader.SetUniformFloat("left", left ? 1.0f : 0.0f);
            cellShader.SetUniformFloat("right", right ? 1.0f : 0.0f);
            cellShader.SetUniformFloat("top", top ? 1.0f : 0.0f);
            cellShader.SetUniformFloat("bottom", bottom ? 1.0f : 0.0f);
            cellShader.SetUniformVector3("outlineColor", new Vector3(outlineColor.R, outlineColor.G, outlineColor.B));
            cellShader.SetUniformVector3("backgroundColor", new Vector3(backgroundColor.R, backgroundColor.G, backgroundColor.B));
            cellShader.SetUniformFloat("outlineWidth", outlineWidth);

            //Matrices
            cellShader.SetUniformMatrix4("model", Matrix4.CreateTranslation(new Vector3(position.X, position.Y, 0)) * Matrix4.CreateScale(new Vector3(size.X, size.Y, 0)));
        }

        public void Render(Camera2D camera)
        {
            cellShader.RunShader();

            SetUniforms();
            camera.SetCameraUniforms(cellShader);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
        }
    }
}
