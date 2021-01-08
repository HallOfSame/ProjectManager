using System.Threading.Tasks;

using ProjectManager.Models;

namespace ProjectManager.DataStore
{
    public interface IContextPersister
    {
        #region Instance Methods

        Task PersistContextAsync(Context context);

        #endregion
    }
}