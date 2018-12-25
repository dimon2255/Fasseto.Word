using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Stores and Retrieves information about the client application
    /// such as login credentials, messages, settings and so on
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// Determines if the current client has logged in credentials
        /// </summary>
        Task<bool> HasCredentialsAsync();

        /// <summary>
        /// Ensures that the client data store is correctly setup
        /// </summary>
        /// <returns>Returns a Task that will finish once a setup completes</returns>
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Gets Stored Login Credentials for the client
        /// </summary>
        /// <returns>Returns the login credentials f they exist, or null if none exists</returns>
        Task<LoginCredentialsDataModel> GetLoginCredentialsAsync();

        /// <summary>
        /// Saves client's login credentials to local Data Store
        /// </summary>
        /// <param name="loginCredentials">Login Credentials to save</param>
        /// <returns>Returns a Task that will finish when Save completes</returns>
        Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials);

        /// <summary>
        /// Removes all Credentials stored in the local data store
        /// </summary>
        /// <returns></returns>
        Task ClearAllLoginCredentialsAsync();
    }
}
