using System.Data.Entity;

namespace Fletnix.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<FletnixDbContext>
    {
        protected override void Seed(FletnixDbContext context)
        {
            //Todo add initial data
        }
    }
}