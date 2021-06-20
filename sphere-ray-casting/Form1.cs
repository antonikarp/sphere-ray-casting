﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point4 cTarget = new Point4(0, 0, 0, 1);
            Point4 cUp = new Point4(0, 0, 1, 1);

            int distance = (int)numericUpDown1.Value;
            int alpha = (int)numericUpDown2.Value;
            int beta = (int)numericUpDown3.Value;

            Point4 cPos = new Point4(0, distance, 0, 1);
            Rotate rotate = new Rotate(0, beta, alpha);
            Point4 rot_cPos = rotate.DoRotate(cPos);
            Point4 rot_cUp = rotate.DoRotate(cUp);

            Scene scene = new Scene();
            scene.InitializeExampleScene(rot_cPos, cTarget, rot_cUp);

            Graphics g = e.Graphics;
            SolidBrush missBrush = new SolidBrush(Color.White);
            SolidBrush hitBrush = new SolidBrush(Color.Black);

            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    Point4 pixel = new Point4(x, y, 0, 0);
                    Ray ray = new Ray(pixel, pictureBox1.Width, pictureBox1.Height, scene);
                    if (ray.Cast() == true)
                    {
                        g.FillRectangle(hitBrush, x, y, 1, 1);
                        
                    }
                    else
                    {
                        g.FillRectangle(missBrush, x, y, 1, 1);
                    }
                }
            }
        }
    }
}
