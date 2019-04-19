# my-csharp
Some utils for csharp

- .NET Core and C#

在 [The history of C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history) 中可以看到 `dotnet core sdk` 的版本可以對應用哪個版本的 C#


## .csproj for .NET Core

建置時複製檔案


```xml
  <ItemGroup>
    <Content Include="path_of_files\*.*">
      <!-- Always or PreserveNewest -->
      <CopyToOutputDirectory></CopyToOutputDirectory>
    </Content>
  </ItemGroup>
```


## Packages

- [Hangfire](https://github.com/HangfireIO/Hangfire)
  An easy way to perform background job processing in your .NET and .NET Core applications. No Windows Service or separate process required
- [NodaTime](https://nodatime.org/)
  A better date and time API for .NET
- [CacheManager](https://github.com/MichaCo/CacheManager)
  CacheManager is an open source caching abstraction layer for .NET written in C#. It supports various cache providers and implements many advanced features.
- [AspNetCore.Diagnostics.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks)
  Enterprise HealthChecks for ASP.NET Core Diagnostics Package
- [FluentEmail](https://github.com/lukencode/FluentEmail)
  .NET Core email sending
- [FastReport](https://github.com/FastReports/FastReport)
  Reporting tool for .NET Core/.NET Framework that helps your application generate document-like reports
