using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DatabaseConfiguration
{
    [Required]
    public string Server { get; set; } = "127.0.0.1";

    [Required]
    public string Port { get; set; } = "3306";

    [Required]
    public string Database { get; set; }

    [Required]
    public string User { get; set; }

    [Required]
    public string Password { get; set; }

    public string ConnectString()
    {
        return $"server={Server};port={Port};database={Database};user={User};password={Password}";
    }
}

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
            .UseMySQL(databaseConfig.ConnectString());

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
