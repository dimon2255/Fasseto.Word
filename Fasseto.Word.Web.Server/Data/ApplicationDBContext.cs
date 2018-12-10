using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Database representational model
    /// </summary>
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties

        /// <summary>
        /// The settings of the application
        /// </summary>
        public DbSet<SettingsDataModel> Settings { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default Constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        #endregion

        #region DBContext Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API
            modelBuilder.Entity<SettingsDataModel>().HasIndex(a => a.Name);
        }

        #endregion

    }
}
