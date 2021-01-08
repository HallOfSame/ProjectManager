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

            context.Projects.Clear();

            context.Projects.Add(new Project("testOne"));
            context.Projects.Add(new Project("testTwo"));

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var contextPersister = new JsonAppDataContextPersister(new AppDataFileManager());

            await contextPersister.PersistContextAsync(context);

            base.OnExit(e);
        }
    }
}
