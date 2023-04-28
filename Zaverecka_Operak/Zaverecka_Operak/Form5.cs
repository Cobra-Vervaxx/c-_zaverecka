using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartArea = System.Windows.Forms.DataVisualization.Charting.ChartArea;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace Zaverecka_Operak
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        bool click=false;

        private void button1_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
            {
                // Stop the BackgroundWorker if it is running
                backgroundWorker1.CancelAsync();
                button1.Text = "Start system diagnostic";
                click = true;
              
            }
            else
            {
                // Start the BackgroundWorker if it is not running
                backgroundWorker1.RunWorkerAsync();
                button1.Text = "Stop System diagnostic";
                click = false;

            }
            
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {
                // Retrieve the CPU usage information
                float cpuUsage = performanceCounter1.NextValue();

                // Update the UI on the main thread using BeginInvoke
                this.BeginInvoke(new Action(() =>
                {
                    // Update the chart with the new CPU usage value
                    chart1.Series[0].Points.AddY(cpuUsage);

                    // If the chart has more than 60 points, remove the oldest point
                    if (chart1.Series[0].Points.Count > 60)
                    {
                        chart1.Series[0].Points.RemoveAt(0);
                    }
                }));
                backgroundWorker1.ReportProgress(Convert.ToInt32(cpuUsage));
          
                // Wait for 1 second before retrieving the next CPU usage value
                Thread.Sleep(1000);
            }
            
        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = "current CPU usage: "+e.ProgressPercentage.ToString() + " %";
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(click==false)
            {
                e.Cancel= true;
                MessageBox.Show("Stop the diagnostics first","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           else
            { e.Cancel= false; }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button1.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
        }
    }
}
