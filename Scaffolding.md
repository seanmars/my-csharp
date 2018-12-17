# Scaffolding

此文章以版本 2.1 為主。

利用官方 `scaffold` 透過 `Model`, `DbContext` 來產生 `Controller` 跟 `View`

Reference: [Add model](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model)

## Install

安裝時請確認版本

```sh
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.SQLite --version=2.1.4
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version=2.1.6
```

## Prepare

- `Model` Class
- `DbContext` Class
- Database 的 connection string

```csharp
// Models/Movie.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}

// Data/MovieContext.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Movie> Movie { get; set; }
    }
}

// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MvcMovieContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("Database")));

    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Database": "Data Source=Movie.db"
  }
}
```

## Generate

```sh
dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```
