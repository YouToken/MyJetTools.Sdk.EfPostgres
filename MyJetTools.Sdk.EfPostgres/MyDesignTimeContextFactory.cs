using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// ReSharper disable UnusedMember.Global

namespace MyJetTools.Sdk.EfPostgres
{
    public class MyDesignTimeContextFactory<T> : IDesignTimeDbContextFactory<T> where T : MyDbContext
    {
        private readonly Func<DbContextOptions, T> _contextFactory;

        public MyDesignTimeContextFactory(Func<DbContextOptions, T> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public T CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseNpgsql();

            return _contextFactory(optionsBuilder.Options);
        }
    }
}
