using System;
using System.IO;

namespace ProjectManager.DataStore.Json
{
    public class AppDataFileManager
    {
        #region Constants

        private const string FileName = "ProjectManagerData.json";

        #endregion

        #region Instance Methods

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

        #endregion
    }
}