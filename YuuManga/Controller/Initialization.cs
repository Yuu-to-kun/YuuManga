using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YuuManga.Models;
using YuuManga.View;

namespace YuuManga.Controller
{
    public class Initialization
    {
        public async Task Initialize()
        {
            await Task.Run(async () =>
            {
                await Application.Current.Dispatcher.Invoke(async() =>
                {
                    GlobalObjects.LoadingWindow.Show();
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    GlobalObjects.LoadingWindow.LoadingTextBlock.Text = "Done";
                    await Task.Delay(TimeSpan.FromSeconds(1));

                });
                
            });
        }
    }
}
