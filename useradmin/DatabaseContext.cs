using Microsoft.EntityFrameworkCore;

namespace useradmin
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) 
            : base(dbContextOptions) { 
        }
    }
}
