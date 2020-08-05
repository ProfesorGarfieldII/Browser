using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
using CefSharp;
using CefSharp.WinForms; 

namespace ChromiumBrowser
{
    public partial class MainForm : Form
    {
        public ChromiumWebBrowser browser;
        List<BrowserForm> bookmarks = new List<BrowserForm>();
        static int bookmarkNum=1;

        public MainForm()
        {
            InitializeComponent();
            InitializeBrowser();
            InitializeForm();
        }
        private void InitializeForm() 
        {
            browser.Height = ClientRectangle.Height - 23;
        }

        private void InitializeBrowser() 
        {

            browser = new ChromiumWebBrowser("https://google.com");
            browser.Dock = DockStyle.Fill;
            pContainer.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;
            ButonGO.Image = Properties.Resources.Arrow_Go_icon;
            toolStripButtonBack.Image = Properties.Resources.Arrows_Left_Arrow_icon;
            toolStripButtonForward.Image = Properties.Resources.Arrows_Right_Arrow_icon;
            toolStripButtonHome.Image = Properties.Resources.home_icon;
            toolStripButtonReload.Image = Properties.Resources.refresh_icon;


        }

        private void butonGo_Click(object sender, EventArgs e)
        {
            browser.Load("https://www.google.com/search?q="+ SearchBox.Text + "&rlz=1C1CHBD_lvLV844LV844&oq="+ SearchBox.Text + "&aqs=chrome..69i57j0l5.12767j1j7&sourceid=chrome&ie=UTF-8");
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
            
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                selectedBrowser.Parent.Text = e.Title;
            }));
        }
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                SearchBox.Text = e.Address;
            }));
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            browser.Refresh();
        }


        private void toolStripButtonHome_Click(object sender, EventArgs e)
        {
            browser.Load("https://Google.com");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser(SearchBox.Text);
            browser.Dock = DockStyle.Fill;
            this.pContainer.Controls.Add(browser);
        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                browser.Load("https://www.google.com/search?q=" + SearchBox.Text + "&rlz=1C1CHBD_lvLV844LV844&oq=" + SearchBox.Text + "&aqs=chrome..69i57j0l5.12767j1j7&sourceid=chrome&ie=UTF-8");

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.Location = new Point(e.X, e.Y);
            
        }

        private void BookmarkThisPage_Click(object sender, EventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                //bookmarks.Add(new BrowserForm(e));
            }));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Bookamrks: " + bookmarkNum + bookmarks);
        }
    }
}