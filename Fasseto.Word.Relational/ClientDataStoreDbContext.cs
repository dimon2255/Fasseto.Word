using Fasseto.Word.Core;
using Microsoft.EntityFrameworkCore;

namespace Fasseto.Word.Relational
{
    /// <summary>
    /// The database context for the ClientData store, using entity framework and sqlite
    /// </summary>
    public class ClientDataStoreDbContext : DbContext
    {
        #region DbSets

        /// <summary>
        /// The client login credentials
        /// </summary>
        public DbSet<LoginCredentialsDataModel> LoginCredentails { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options)
        {

        }

        #endregion

        #region Model Creating

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API

            //Configure LoginCredentials
            //----------------------------------
            //
            //Set Id as primary key
            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(a => a.Id);
             

            
            //TODO: set up limits
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.Firstname).HasMaxLength(50);


        }

        #endregion

    }
}
