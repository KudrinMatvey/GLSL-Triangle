using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace GLSL_trangle
{
    public partial class Form1 : Form
    {
        private _trangle tr = new _trangle();
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            tr.InintShaders();
            while (true)
            {
                tr.Draw();
                simpleOpenGlControl1.SwapBuffers();
            }
            
        }
    }
}
