using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YuuManga.Models;
using YuuScrapeLib;

namespace YuuManga
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Functions scrape = new Functions();
            GlobalObjects.Driver = scrape.startDriver();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Functions scrape = new Functions();
            scrape.driverDispose(GlobalObjects.Driver);
        }
    }
}
