using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace StarFleetBattles.Graphics.Shaders
{
    public class Shader : IDisposable
    {
        private bool disposed = false;

        private int Handle;

        private int VertexShader;
        private int FragmentShader;

        public Shader(string vertexPath, string fragmentPath)
        {
            // Load shaders
            VertexShader = GL.CreateShader(ShaderType.VertexShader);
            FragmentShader = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(VertexShader, File.ReadAllText(vertexPath, Encoding.UTF8));
            GL.ShaderSource(FragmentShader, File.ReadAllText(fragmentPath, Encoding.UTF8));

            // Compile shaders
            CompileShader(VertexShader);
            CompileShader(FragmentShader);

            // Link shaders
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, VertexShader);
            GL.AttachShader(Handle, FragmentShader);
            GL.LinkProgram(Handle);

            // Detach and delete shaders now we've created our linked program
            GL.DetachShader(Handle, VertexShader);
            GL.DetachShader(Handle, FragmentShader);
            GL.DeleteShader(FragmentShader);
            GL.DeleteShader(VertexShader);
        }

        public void Use()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("Cannot use shader program after disposal");
            }

            GL.UseProgram(Handle);
        }

        private void CompileShader(int shaderHandle)
        {
            GL.CompileShader(shaderHandle);

            // Check for errors
            var infoLog = GL.GetShaderInfoLog(VertexShader);
            if (!string.IsNullOrEmpty(infoLog))
            {
                Console.WriteLine(infoLog);
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                GL.DeleteProgram(Handle);
                disposed = true;
            }
        }
    }
}
