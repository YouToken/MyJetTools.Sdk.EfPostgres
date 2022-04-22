using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyJetTools.Sdk.EfPostgres
{
    public class JetToolsDbContext : DbContext
    {
        public static ILoggerFactory? LoggerFactory { get; set; }

        public JetToolsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected JetToolsDbContext()
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