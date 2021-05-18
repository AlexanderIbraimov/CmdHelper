using Cmd.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cmd
{
    class Program
    {
        static Program()
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        static void Main(string[] args)
        {
            var telegram = new TelegramBot();
            telegram.OnCommand += OnCommand;

            Console.ReadKey();
        }

        private static string OnCommand(string command)
        {
            return ExecuteCommandSync(command);
        }

        public static string ExecuteCommandSync(object command)
        {
            try
            {
                var procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                var proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
                return string.IsNullOrEmpty(result) ? "Invalid command" : result;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}
