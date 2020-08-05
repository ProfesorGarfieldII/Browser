using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace ChromiumBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());

            BrowserForm container = new BrowserForm();

            //adds tab
            container.Tabs.Add(
                new EasyTabs.TitleBarTab(container) {
                Content= new MainForm 
                {
                    Text = "New Tab", Icon = Properties.Resources.TabIcon
                    
                }
            });
            container.SelectedTabIndex = 0;
            //TitleBarTabsApplicaionContext applicaionContext = new TitleBarTabsApplicaionContext();

            //applicaionContext.Start(container);
            //Application.Run(applicaionContext);

            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();

            applicationContext.Start(container);
            Application.Run(applicationContext);
        }
    }
}
