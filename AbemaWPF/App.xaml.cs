using Aijkl.Abema.Apps.VideoViewer.ViewModels;
using Aijkl.Abema.Apps.VideoViewer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aijkl.Abema.Apps.VideoViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Main main = new Main();
            MainViewModel mainViewModel = new MainViewModel();
            main.DataContext = mainViewModel;
            main.Show();
            Task.Run(() =>
            {
                mainViewModel.Update();
            });
        }
    }
}
