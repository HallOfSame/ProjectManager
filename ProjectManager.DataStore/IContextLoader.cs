using System.Threading.Tasks;

using ProjectManager.Models;

namespace ProjectManager.DataStore
{
    public interface IContextLoader
    {
        #region Instance Methods

        Task<Context> LoadLocalDataAsync();

        #endregion
    }
}