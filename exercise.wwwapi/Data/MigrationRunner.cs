using Microsoft.EntityFrameworkCore;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public static class MigrationRunner
    {
        public async static void ApplyProjectMigrations(this WebApplication app)
        {


            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }

        }
    }
}
