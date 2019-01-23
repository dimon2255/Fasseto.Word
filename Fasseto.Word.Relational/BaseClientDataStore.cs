using Fasseto.Word.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fasseto.Word.Relational
{
    /// <summary>
    /// Stores and Retrieves information about the client application
    /// such as login credentials, messages, settings and so on
    /// </summary>
    public class BaseClientDataStore : IClientDataStore
    {
        #region Protected Properties

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext mDbContext;

        #endregion


        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dbContext">The database to use, will be injected by DI at runtime</param>
        public BaseClientDataStore(ClientDataStoreDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        #region Interface Implementation

        /// <summary>
        /// Determines if the current client has logged in credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        /// <summary>
        /// Ensures that the client data store is correctly setup
        /// </summary>
        /// <returns>Returns a Task that will finish once a setup completes</returns>
        public async Task EnsureDataStoreAsync()
        {
            await mDbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets Stored Login Credentials for the client
        /// </summary>
        /// <returns>Returns the login credentials f they exist, or null if none exists</returns>
        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            return Task.FromResult(mDbContext.LoginCredentails.FirstOrDefault());
        }

        /// <summary>
        /// Saves client's login credentials to local Data Store
        /// </summary>
        /// <param name="loginCredentials">Login Credentials to save</param>
        /// <returns>Returns a Task that will finish when Save completes</returns>
        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            //Clear rows
            mDbContext.LoginCredentails.RemoveRange(mDbContext.LoginCredentails);

            //Add new Entry
            mDbContext.LoginCredentails.Add(loginCredentials);

            //Commit to Database
            await mDbContext.SaveChangesAsync();
        }


        /// <summary>
        /// Clears all Credentials in the local data store
        /// </summary>
        /// <returns></returns>
        public async Task ClearAllLoginCredentialsAsync()
        {
            //Remove all entries from login credentials
            mDbContext.LoginCredentails.RemoveRange(mDbContext.LoginCredentails);

            //save changes
            await mDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
