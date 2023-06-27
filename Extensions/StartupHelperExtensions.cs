using Microsoft.EntityFrameworkCore;
using AllogProject2.Api.Contexts;

namespace Univali.Api.Extensions;

internal static class StartupHelperExtensions
{
   public static async Task ResetDatabaseAsync(this WebApplication app)
   {
       using (var scope = app.Services.CreateScope())
       {
           try
           {
               var context = scope.ServiceProvider.GetService<PublisherContext>();
               if (context != null)
               {
                   await context.Database.EnsureDeletedAsync();
                   await context.Database.MigrateAsync();
               }
           }
           catch (Exception ex)
           {
               var logger = scope.ServiceProvider.GetRequiredService<ILogger<IStartup>>();
               logger.LogError(ex, "An error occurred while migrating the database.");
           }
       }
   }
}
