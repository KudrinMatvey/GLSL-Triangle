using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace GLSL_trangle
{
    class _trangle
    {
     //   string GLversion = GL.GetString(StringName.Version);
     //   string GLSL = GL.GetString(StringName.ShadingLanguageVersion);

        int BasicProgramID;
        int BasicVertexShader;
        int BasicFragmentShader;
        int vaoHandle;

        public void loadShader(String fileName,ShaderType type,int program, out int address)
        {
            address = GL.CreateShader(type);

            using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        public void InintShaders()
        {
            float[] positionData = { -0.8f, -0.8f, -0.0f, 0.8f, -0.8f, -0.0f, -0.0f, 0.8f, -0.0f };
            float[] colorData = { 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f };
            int[] vboHadnlers = new int[2];

          
            BasicProgramID = GL.CreateProgram();
            loadShader("C:\\Users\\Матвей\\Documents\\Visual Studio 2015\\Projects\\GLSL trangle\\GLSL trangle\\basic.vs", ShaderType.VertexShader, BasicProgramID, out BasicVertexShader);
            loadShader("C:\\Users\\Матвей\\Documents\\Visual Studio 2015\\Projects\\GLSL trangle\\GLSL trangle\\basic.fs", ShaderType.FragmentShader, BasicProgramID, out BasicVertexShader);
            GL.LinkProgram(BasicProgramID);
            Console.WriteLine(BasicProgramID);

            GL.GenBuffers(2, vboHadnlers);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHadnlers[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(sizeof(float) * positionData.Length),
                positionData, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHadnlers[1]);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(sizeof(float) * colorData.Length),
                colorData, BufferUsageHint.StaticDraw);

            vaoHandle = GL.GenVertexArray();
            GL.BindVertexArray(vaoHandle);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHadnlers[0]);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHadnlers[1]);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float,false, 0, 0);


        }

        public void Draw()
        {
            GL.UseProgram(BasicProgramID);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.UseProgram(0);
        }
    }
}
