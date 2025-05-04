using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace PitchData.Database.Context
{
    public class PitchDataDatabaseContextFactory : IDesignTimeDbContextFactory<PitchDataDatabaseContext>
    {
        public PitchDataDatabaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddJsonFile("appsettings.json", optional: true); // fallback option

            var configuration = builder.Build();
            AppConfig.Init(configuration);

            var optionsBuilder = new DbContextOptionsBuilder<PitchDataDatabaseContext>();
            optionsBuilder.UseSqlServer(AppConfig.ConnectionStrings?.PitchDataDatabase);

            if (AppConfig.ConsoleLogQueries)
            {
                optionsBuilder.LogTo(Console.WriteLine);
            }

            return new PitchDataDatabaseContext(optionsBuilder.Options);
        }
    }

}
