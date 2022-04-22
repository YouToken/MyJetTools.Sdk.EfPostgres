using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyJetTools.Sdk.EfPostgres
{
    public class MyDbContext : DbContext
    {
        public static ILoggerFactory? LoggerFactory { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (LoggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging();
            }
        }
        
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveConversion<MyDateTimeConverterToUtc>();
        }

    }
}