using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace beefamily.Models
{
    public class HiveContext : DbContext
    {
            public HiveContext(DbContextOptions<HiveContext> opt)
                : base(opt)
            {
                try
                {
                    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                    if (databaseCreator != null)
                    {
                        if (!databaseCreator.CanConnect()) databaseCreator.Create();
                        if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public DbSet<Hive> Hives { get; set; } = null!;

    }
}
