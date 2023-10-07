using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YuuManga.Models;

namespace YuuManga.Controller
{
    public class Functions
    {
        public async Task updateResults(string query, ListView listView)
        {
            YuuScrapeLib.Functions scrapeFunctions = new YuuScrapeLib.Functions();
            GlobalObjects.Timer.Elapsed += GlobalObjects.OnTimedEvent;
            GlobalObjects.Timer.Start();

            await Task.Run(() =>
            {
                while (true)
                {
                    var timer = GlobalObjects.Timer.Enabled;
                    var searching = GlobalObjects.IsSearching;

                    if (!searching)
                    {
                        return;
                    }
                    if (!timer)
                    {
                        break;
                    }
                }

                if (!GlobalObjects.Timer.Enabled)
                {
                    var series = scrapeFunctions.getSeries("https://mangasee123.com/search/?name=" + query, GlobalObjects.Driver);

                    if (series == null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            listView.Items.Clear();
                        });
                    }
                    else
                    {
                        GlobalObjects.SerieList = series;
                    }

                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    listView.Items.Clear();
                    for (int i = 0; i < GlobalObjects.SerieList.Count; i++)
                    {
                        listView.Items.Add(GlobalObjects.SerieList[i]);
                    }
                });
            });
            
            
        }
    }
}
