using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ProjectManager.DataStore.Json;
using ProjectManager.Models;

namespace ProjectManager.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Context context;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var contextLoader = new JsonAppDataContextLoader(new AppDataFileManager());

            context = await contextLoader.LoadLocalDataAsync();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {

            base.OnExit(e);
        }
    }
}
