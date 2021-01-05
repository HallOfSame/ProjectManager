using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataStore.Json
{
    public class AppDataFileManager
    {
        private const string FileName = "ProjectManagerData.json";

        public FileStream GetLocalDataFile()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var fullFilePath = Path.Combine(appDataFolder, FileName);

            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException("Local file not found.");
            }

            return File.OpenRead(fullFilePath);
        }
    }
}
