# Build Script

To use the Cake.Svn addin in your Cake file simply import it. Then define a task.

```csharp
#addin "Cake.Svn"

Task("get-svn-info").Does(() =>
{
    var localDirectoryInfo = GetSvnDirectoryInfo(@"C:\project\src\");

    foreach(var svnInfoResult in localDirectoryInfo)
    {
        Verbose("Path: {0}", svnInfoResult.Path);
    }
}
```

See [Cake Website](https://cakebuild.net/dsl/svn/) for examples how to use the different aliases.