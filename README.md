#Find duplicate files console app tool

Make sure you have dotnet 7 installed, then build and run the solution

```bash
~FindDuplicateFiles> dotnet build
MSBuild version 17.5.1+f6fdcf537 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  FindDuplicateFiles -> C:\workspace\FindDuplicateFiles\FindDuplicateFiles\bin\Debug\net7.0\FindDuplica
  teFiles.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.38
~FindDuplicateFiles>  cd .\FindDuplicateFiles\bin\Debug\net7.0\
~FindDuplicateFiles\FindDuplicateFiles\bin\Debug\net7.0>  .\FindDuplicateFiles.exe > result.txt
```

Then, you will see something like

```
Duplicate file size: 5,24 MB
	D:\OneDrive\Libros\tuxinfo65.zip
	D:\OneDrive\Libros\Manuales y Revistas\tuxinfo65.zip
```
