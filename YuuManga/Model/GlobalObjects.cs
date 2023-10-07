using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using YuuManga.View;
using YuuScrapeLib;

namespace YuuManga.Models
{
    public static class GlobalObjects
    {
        private static LoadingWindow loadingWindow = new LoadingWindow();
        private static ChromeDriver driver;
        private static Timer timer = new Timer
        {
            Interval = 500,
        };
        private static int elapsedTimerTime = 0;
        private static bool isSearching;
        private static List<Serie> serieList = new List<Serie>();
        private static bool isBackSpacePressed;

        public static LoadingWindow LoadingWindow { get => loadingWindow; set => loadingWindow = value; }
        public static ChromeDriver Driver { get => driver; set => driver = value; }
        public static Timer Timer { get => timer; set => timer = value; }
        public static int ElapsedTimerTime { get => elapsedTimerTime; set => elapsedTimerTime = value; }
        public static bool IsSearching { get => isSearching; set => isSearching = value; }
        public static List<Serie> SerieList { get => serieList; set => serieList = value; }
        public static bool IsBackSpacePressed { get => isBackSpacePressed; set => isBackSpacePressed = value; }

        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ElapsedTimerTime += 500;
            if (ElapsedTimerTime >= 1500)
            {
                Timer.Stop();
            }
        }
    }
}
