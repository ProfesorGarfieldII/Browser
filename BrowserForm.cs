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

namespace ChromiumBrowser
{
    public partial class BrowserForm : TitleBarTabs
    {
        public BrowserForm()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
            

        }
        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new MainForm { Text = "New Tab", Icon = Properties.Resources.TabIcon }
            };
        }
    }
}