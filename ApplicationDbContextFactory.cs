using System;
using System.IO;
using AdminCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AdminSite.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("database.json")
                .Build();
            var databaseConfig = configuration.Get<DatabaseConfiguration>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(databaseConfig.ConnectString(),
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8, 0), ServerType.MySql);
                    }
                );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
