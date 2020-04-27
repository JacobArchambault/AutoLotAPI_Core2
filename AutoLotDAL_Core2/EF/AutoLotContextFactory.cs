using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoLotDAL_Core2.EF
{
    public class AutoLotContextFactory : IDesignTimeDbContextFactory<AutoLotContext>
    {
        public AutoLotContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutoLotContext>();
            var connectionString = @"server=(localdb)\mssqllocaldb;database=AutoLotCore2;integrated security=true; MultipleActiveResultSets=true;App=EntityFramework;";
            optionsBuilder.UseSqlServer(
                connectionString, options => options.EnableRetryOnFailure());
            return new AutoLotContext(optionsBuilder.Options);
        }
    }
}