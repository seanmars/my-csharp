# my-csharp
Some utils for csharp

- .NET Core and C#

在 [The history of C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history) 中可以看到 `dotnet core sdk` 的版本可以對應用哪個版本的 C#


## csproj 格式

建置時複製檔案

```xml
  <ItemGroup>
    <Content Include="path_of_files\*.*">
      <!-- Always or PreserveNewest -->
      <CopyToOutputDirectory></CopyToOutputDirectory>
    </Content>
  </ItemGroup>
```

References:

- [適用於 .NET Core 之 csproj 格式的新增項目](https://docs.microsoft.com/zh-tw/dotnet/core/tools/csproj)
- [project.json 與 csproj 屬性的對應](https://docs.microsoft.com/zh-tw/dotnet/core/tools/project-json-to-csproj)

## .NET Standard/.NET Core/.NET Framework/C#

一些相關資訊以及表格。

- [The history of C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history)
- [Language Feature Status](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md)
- [-langversion](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/langversion-compiler-option)
- [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
- [Target frameworks](https://docs.microsoft.com/en-us/dotnet/standard/frameworks)
- [.NET Framework versions and dependencies](https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/versions-and-dependencies)
- [C# language versioning](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version)

| LangVersion | .NET Standard | .NET Core | .NET Framework |
| ----------- | ------------- | --------- | -------------- |
|             | 1.0           | 1.0       | 4.5            |
|             | 1.1           | 1.0       | 4.5            |
|             | 1.2           | 1.0       | 4.5.1          |
|             | 1.3           | 1.0       | 4.6            |
|             | 1.4           | 1.0       | 4.6            |
|             | 1.5           | 1.0       | 4.6            |
| C# 7.0      | 1.6           | 1.0       | 4.6            |
| C# 7.2      | 2.0           | 2.0       | 4.6.1          |
| C# 7.3      | 2.0           | 2.1       |                |
| C# 7.3      | 2.0           | 2.2       |                |
| C# 8.0      | 2.1           | 3.0       | 4.8            |


## Packages

[Packages](packages.md)
