using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaverecka_Operak
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            timer1.Enabled = true;
            ResizeRedraw=true;
        }
       
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            Pen pen = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Blue, 3);
            Pen pen3 = new Pen(Color.Green, 5);

            // Draw minute ticks
            for (int i = 0; i < 60; i++)
            {
                graphics.DrawLine(pen, 0, -130, 0, -140);
                graphics.RotateTransform(6);
            }

            // Draw hour ticks
            for (int i = 0; i < 12; i++)
            {
                graphics.DrawLine(pen2, 0, -120, 0, -140);
                graphics.RotateTransform(30);
            }

            // Draw quarter ticks
            for (int i = 0; i < 4; i++)
            {
                graphics.DrawLine(pen3, 0, -110, 0, -140);
                graphics.RotateTransform(90);
            }

            DateTime now = DateTime.Now;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            // Adjust the hour to the 12-hour clock
            if (hour > 12)
            {
                hour -= 12;
            }

            float hourAngle = (hour * 30) + (minute * 0.5f);
            float minuteAngle = minute * 6;
            float secondAngle = second * 6;

            // Draw the clock hands
            graphics.ResetTransform();
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            // Draw hour hand
            graphics.RotateTransform(hourAngle);
            graphics.DrawLine(pen, 0, 0, 0, -50);

            // Draw minute hand
            graphics.ResetTransform();
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            graphics.RotateTransform(minuteAngle);
            graphics.DrawLine(pen, 0, 0, 0, -70);

            // Draw second hand
            graphics.ResetTransform();
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            graphics.RotateTransform(secondAngle);
            graphics.DrawLine(pen, 0, 0, 0, -90);
            label1.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
       
            pictureBox1.Invalidate();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
        }
    }
}
