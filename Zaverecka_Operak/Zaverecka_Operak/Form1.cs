﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Zaverecka_Operak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string username = "";
        string password = "";
        bool create;

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked= true;
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
            label2.Font = new Font("Arial", 12, FontStyle.Bold);
            button1.Font = new Font("Arial", 12, FontStyle.Bold);
            button2.Font= new Font("Arial", 12, FontStyle.Bold);
            radioButton1.Font= new Font("Arial", 12, FontStyle.Bold);
            radioButton2.Font= new Font("Arial", 12, FontStyle.Bold);
            string filepath = "C:\\Users\\vrchl\\OneDrive\\Dokumenty\\prihlasenidlouhodobka.txt";
            if(File.Exists(filepath))
            {
                System.IO.StreamReader sr;
                sr = new System.IO.StreamReader(filepath);
                string radek;
                while((radek=sr.ReadLine())!=null)
                {
                    username = radek;
                    password = radek;
                }
            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                MessageBox.Show("Welcome to C# linux please create an account", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                create = true;
                
            }







        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (create == true)
            {
                System.IO.StreamWriter sw;
                sw = new System.IO.StreamWriter("C:\\Users\\vrchl\\OneDrive\\Dokumenty\\prihlasenidlouhodobka.txt");
                sw.WriteLine(tbUserName.Text);
                sw.WriteLine(tbPassword.Text);
                sw.Close();
                MessageBox.Show("Account has been created succesfully, now the system will restart","Congrats",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }









            if (radioButton1.Checked)
            {
                if (tbUserName.Text == "admin"&&tbPassword.Text=="admin") {

                    Form2 f2 = new Form2();
                    f2.TopLevel = true;
                    f2.Show();
                    
                    this.Hide();
                 
                
                  
                    

                   
                }
                else if (tbUserName.Text == string.Empty&&tbPassword.Text==string.Empty)
                {
                    MessageBox.Show("Enter Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(radioButton2.Checked)
            {
                if (tbUserName.Text == username&& tbPassword.Text == password)
                {
                    Form2 f2 = new Form2();
                    f2.TopLevel = true;
                    f2.Show();

                    this.Hide();
                }
                else if(tbUserName.Text == string.Empty && tbPassword.Text == string.Empty)
                {
                    MessageBox.Show("Enter Credentials","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong Credentials","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                pictureBox1.Image = imageList1.Images[0];
                tbUserName.Text = string.Empty;
                tbPassword.Text = string.Empty;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pictureBox1.Image = imageList1.Images[1];
                tbUserName.Text = string.Empty;
                tbPassword.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to turn off system", "Warning", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(result==DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
