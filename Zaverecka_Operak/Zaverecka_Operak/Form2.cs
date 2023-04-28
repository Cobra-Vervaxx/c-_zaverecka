using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaverecka_Operak
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int klik = 0;
     


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text=="Change taskbar color")
            {
                if(colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    panel1.BackColor = colorDialog1.Color;
                }
            }
            if(e.ClickedItem.Text=="hide the task bar")
            {
                panel1.Visible= false;
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Parent = panel1;
            button1.Height= panel1.Height;
            button1.Width = 60;
            panel2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            klik++;
            
            if (klik == 1)
            {
                panel2.Show();
         
            }
     
            if(klik==2)
            {
                panel2.Hide();
                klik = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4= new Form4();
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5= new Form5();
            f5.ShowDialog();    
        }
    }
}
