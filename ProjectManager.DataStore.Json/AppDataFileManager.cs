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
            var fullFilePath = GetLocalFilePath();

            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException("Local file not found.");
            }

            return File.OpenRead(fullFilePath);
        }

        public FileStream GetOrCreateLocalDataFile()
        {
            try
            {
                return GetLocalDataFile();
            }
            catch (FileNotFoundException)
            {
                return File.Create(GetLocalFilePath());
            }
        }

        #endregion

        #region Class Methods

        private static string GetLocalFilePath()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var ourFolder = Path.Combine(appDataFolder, "ProjectManager");

            var fullFilePath = Path.Combine(ourFolder, FileName);
            return fullFilePath;
        }

        #endregion
    }
}