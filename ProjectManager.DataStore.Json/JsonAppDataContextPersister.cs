using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProjectManager.Models;

namespace ProjectManager.DataStore.Json
{
    public class JsonAppDataContextPersister : IContextPersister
    {
        #region Fields

        private readonly AppDataFileManager appDataFileManager;

        #endregion

        #region Constructors

        public JsonAppDataContextPersister(AppDataFileManager appDataFileManager)
        {
            this.appDataFileManager = appDataFileManager;
        }

        #endregion

        #region Instance Methods

        public async Task PersistContextAsync(Context context)
        {
            await using var localFile = appDataFileManager.GetOrCreateLocalDataFile();
            await using var writer = new StreamWriter(localFile);

            var serialContext = JsonConvert.SerializeObject(context,
                                                            new JsonSerializerSettings
                                                            {
                                                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                            });

            writer.BaseStream.Position = 0;
            await writer.WriteAsync(serialContext);
        }

        #endregion
    }
}