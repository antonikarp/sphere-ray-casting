using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sphere_ray_casting
{
    public partial class Form1 : Form
    {
        public int alpha;
        public int beta;
        public int distance;
        public Point4 lightPos;
        public Form1()
        {
            InitializeComponent();
            alpha = 0;
            beta = 0;
            distance = 300;
            lightPos = new Point4(160, -210, -90, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void updateTextBoxes()
        {
            textBox1.Text = distance.ToString();
            textBox2.Text = alpha.ToString();
            textBox3.Text = beta.ToString();
            textBox4.Text = lightPos.x.ToString();
            textBox5.Text = lightPos.y.ToString();
            textBox6.Text = lightPos.z.ToString();


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            updateTextBoxes();

            Point4 cTarget = new Point4(0, 0, 0, 1);
            Point4 cUp = new Point4(0, 0, 1, 1);

            Point4 cPos = new Point4(0, distance / Math.Sqrt(2), distance / Math.Sqrt(2), 1);
            Rotate rotate = new Rotate(0, beta, alpha);
            Point4 rot_cPos = rotate.DoRotate(cPos);
            Point4 rot_cUp = rotate.DoRotate(cUp);

            Scene scene = new Scene();
            scene.InitializeExampleScene(rot_cPos, cTarget, rot_cUp, lightPos);

            Graphics g = e.Graphics;

            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    Point4 pixel = new Point4(x, y, 0, 0);
                    Ray ray = new Ray(pixel, pictureBox1.Width, pictureBox1.Height, scene);
                    Intensity resultIntensity = ray.Cast();
                    Color resultColor = Color.FromArgb((int)resultIntensity.r, (int)resultIntensity.g, (int)resultIntensity.b);
                    SolidBrush brush = new SolidBrush(resultColor);
                    g.FillRectangle(brush, x, y, 1, 1);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    alpha += 10;
                    pictureBox1.Refresh();
                    break;
                case Keys.Left:
                    alpha -= 10;
                    pictureBox1.Refresh();
                    break;
                case Keys.Up:
                    beta += 10;
                    pictureBox1.Refresh();
                    break;
                case Keys.Down:
                    beta -= 10;
                    pictureBox1.Refresh();
                    break;
                case Keys.W:
                    lightPos.x += 10.0;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.S:
                    lightPos.x -= 10.0;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.A:
                    lightPos.z -= 10.0;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D:
                    lightPos.z += 10.0;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Z:
                    lightPos.y += 10.0;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.X:
                    lightPos.y -= 10.0;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.NumPad2:
                    distance -= 10;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.NumPad8:
                    distance += 10;
                    pictureBox1.Refresh();
                    e.SuppressKeyPress = true;
                    break;


            }
        }
    }
}
