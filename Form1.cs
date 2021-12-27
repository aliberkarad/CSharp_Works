using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using HtmlAgilityPack;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string WebAdresi, WebAdresi3, WebAdresi5;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe", WebAdresi);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe", WebAdresi3);
        }


        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe", WebAdresi5);
        }

  

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            string UrunAdi = textBox1.Text;
            string EditedUrun = UrunAdi.ToLower().Replace(" ", "%20");

            progressBar1.Value = 5;
            /*********************** TRENDYOL ***********************************/
            WebAdresi = "https://www.trendyol.com/sr?q=" + EditedUrun + "&qt=" + EditedUrun + "&st=" + EditedUrun + "&os=1&sst=PRICE_BY_ASC";
            WebRequest SiteyeBaglantiTalebi0 = WebRequest.Create(WebAdresi);
            WebResponse GelenCevap0 = SiteyeBaglantiTalebi0.GetResponse();
            StreamReader CevapOku0 = new StreamReader(GelenCevap0.GetResponseStream());
            string CevapText0 = CevapOku0.ReadToEnd();
            
            int IndexBaslangici0 = CevapText0.IndexOf("promotion");
            IndexBaslangici0 = CevapText0.IndexOf("sllng", IndexBaslangici0);
            IndexBaslangici0 = CevapText0.IndexOf(">", IndexBaslangici0)+1;
            int IndexBitisi0 = CevapText0.Substring(IndexBaslangici0).IndexOf("TL");
            label6.Text = CevapText0.Substring(IndexBaslangici0, IndexBitisi0);
            linkLabel1.Text = "link";
            GelenCevap0.Close();
            CevapOku0.Close();
            SiteyeBaglantiTalebi0.Abort();
            /*******************************************************************/
            progressBar1.Value = 17;
            /*********************** HepsiBurada ***********************************
                            HTTP REQUEST KISITLAMASI VAR(403)
            *******************************************************************/
            progressBar1.Value = 34;
            /********************************N11********************************/
            WebAdresi3 = "https://www.n11.com/arama?q=" + EditedUrun + "&srt=PRICE_LOW";
            WebRequest SiteyeBaglantiTalebi3 = WebRequest.Create(WebAdresi3);
            WebResponse GelenCevap3 = SiteyeBaglantiTalebi3.GetResponse();
            StreamReader CevapOku3 = new StreamReader(GelenCevap3.GetResponseStream());
            string CevapText3 = CevapOku3.ReadToEnd();

            int IndexBaslangici3 = CevapText3.IndexOf(@"<ins>") + 5;
            int IndexBitisi3 = CevapText3.Substring(IndexBaslangici3).IndexOf("<");
            label11.Text = CevapText3.Substring(IndexBaslangici3, IndexBitisi3);
            linkLabel3.Text = "link";
            GelenCevap3.Close();
            CevapOku3.Close();
            SiteyeBaglantiTalebi3.Abort();
            /*******************************************************************/
            progressBar1.Value = 51;
            /***********************GittiGidiyor********************************
                           HTTP REQUEST KISITLAMASI VAR(403)
            *******************************************************************/
            progressBar1.Value = 62;
            /***********************Amazon**************************************/
            WebAdresi5 = "https://www.amazon.com.tr/s?k=" + EditedUrun + "&s=price-asc-rank";
            WebRequest SiteyeBaglantiTalebi5 = WebRequest.Create(WebAdresi5);
            WebResponse GelenCevap5 = SiteyeBaglantiTalebi5.GetResponse();
            StreamReader CevapOku5 = new StreamReader(GelenCevap5.GetResponseStream());
            string CevapText5 = CevapOku5.ReadToEnd();

            int IndexBaslangici5 = CevapText5.IndexOf("a-offscreen") + 13;
            int IndexBitisi5 = CevapText5.Substring(IndexBaslangici5).IndexOf("TL");
            label8.Text = CevapText5.Substring(IndexBaslangici5, IndexBitisi5);
            linkLabel5.Text = "link";
            GelenCevap5.Close();
            CevapOku5.Close();
            SiteyeBaglantiTalebi5.Abort();
            /*******************************************************************/
            progressBar1.Value = 78;
            /***********************CicekSepeti*********************************
                        SİTE FİYATLARI İŞLEM İLE HESAPLIYOR
            *******************************************************************/
            progressBar1.Value = 100;       
            progressBar1.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




    }
}
