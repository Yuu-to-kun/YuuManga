using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YuuManga.Controller;
using YuuManga.Models;
using OpenQA.Selenium;


namespace YuuManga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            this.Hide();
            InitializeComponent();
           
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await LoadAsync();
        }
        public async Task LoadAsync()
        {
            Initialization initialization = new Initialization();
            await initialization.Initialize();
            GlobalObjects.LoadingWindow.Close();
            Functions functions = new Functions();
            this.Show();
            await functions.starterList(listView);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            Application.Current.Shutdown();
            
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (GlobalObjects.IsSearching)
            {
                GlobalObjects.IsSearching = false;
                GlobalObjects.Timer.Stop();
            }
            GlobalObjects.IsSearching = true;

            Functions functions = new Functions();
            var textbox = sender as TextBox;
            await functions.updateResults(textbox.Text,listView);
           
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        
    }
}
