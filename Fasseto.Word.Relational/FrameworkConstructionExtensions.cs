using Dna;
using Fasseto.Word.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fasseto.Word.Relational
{
    /// <summary>
    /// Extension methods for <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction AddClientDataStore(this FrameworkConstruction construction)
        {
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                options.UseSqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection"));
            });

            //Add client Data Store for easy access of the backing data store
            //Make it scoped so we can inject scoped DbContext
            construction.Services.AddScoped<IClientDataStore>(
                                            provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            return construction;
        }
    }
}
