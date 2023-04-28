using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;


namespace Zaverecka_Operak
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            DateTime date = new DateTime(2023, 4, 13);
            string name = GetSvatekName(date);
            label1.Font= new Font("Arial", 12, FontStyle.Bold);
            label2.Font= new Font("Arial", 12, FontStyle.Bold);
            label1.Text = "Today "+name+" has nameday!";
            label2.Text = "If you are: " + name + " Happy name day!";
        }







        public static string GetSvatekName(DateTime date)
        {
            string url = "https://www.svatek.cz/" + date.ToString("dd-MM");
            string content = "";
            string name = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }

            if (!string.IsNullOrEmpty(content))
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(content);

                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//span[@class='hs-dnes']//a");
                if (nodes != null && nodes.Count > 0)
                {
                    name = nodes[0].InnerText.Trim();
                }
            }

            return name;
        }













    }
}
