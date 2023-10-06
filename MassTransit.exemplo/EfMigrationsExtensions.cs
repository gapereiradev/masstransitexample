using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MassTransit.API
{
    public static class EfMigrationsExtensions
    {
        public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<CustomerContext>().Database.Migrate();
            }
        }
    }
}