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
