using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProjectManager.Models;

namespace ProjectManager.DataStore.Json
{
    public class JsonAppDataContextLoader : IContextLoader
    {
        #region Fields

        private readonly AppDataFileManager appDataFileManager;

        #endregion

        #region Constructors

        public JsonAppDataContextLoader(AppDataFileManager appDataFileManager)
        {
            this.appDataFileManager = appDataFileManager ?? throw new ArgumentNullException(nameof(appDataFileManager));
        }

        #endregion

        #region Instance Methods

        public Context InitializeNewContext()
        {
            return new Context();
        }

        public async Task<Context> LoadLocalDataAsync()
        {
            try
            {
                string fileText;

                await using (var localFile = appDataFileManager.GetLocalDataFile())
                {
                    using var streamReader = new StreamReader(localFile);

                    fileText = await streamReader.ReadToEndAsync();
                }

                var context = JsonConvert.DeserializeObject<Context>(fileText,
                                                                     new JsonSerializerSettings
                                                                     {
                                                                         ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                                     });

                return context;
            }
            catch (FileNotFoundException)
            {
                return InitializeNewContext();
            }
        }

        #endregion
    }
}