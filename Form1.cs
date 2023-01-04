using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace GazetteNotificationsFull
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            if (IsConnectedToInternet())
            {
                main();
            }
            else
            {
               while (IsConnectedToInternet() == false)
                {
                    Thread.Sleep(3);
                    if (IsConnectedToInternet()) { main(); }
                }   

            }
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var zoom = browser.ActiveXInstance as SHDocVw.InternetExplorer;
            zoom.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, 75, IntPtr.Zero);

            this.Width = browser.Document.Body.ScrollRectangle.Width + 40;//Border
            this.Height = browser.Document.Body.ScrollRectangle.Height + 40;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private bool IsConnectedToInternet()
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("8.8.8.8", 3000);

                if (reply.Status == IPStatus.Success) { return true; }
                else { return false; }
                
            }
            catch { return false; }
            
        }
        private void main()
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
            browser.Navigate(new Uri("https://docs.google.com/spreadsheets/d/e/2PACX-1vTib8OyUFKby5-vRkJHG3l5Ai9r0sC_NejOHHcnOQ498Tqx_q4BzqggD3L01IqZV41VYEg5zDAuNU8N/pubhtml?gid=1416997619&single=true&range=A8:J17&widget=false&headers=false&chrome=false"));
        }

    }


}

