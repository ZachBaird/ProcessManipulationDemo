using System;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace ProcessManipulationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Cursor Left POS: {Console.CursorLeft}");
                Console.WriteLine($"Cursor Top POS: {Console.CursorTop}");
            }
        }

        private static void PrintRunningProcesses()
        {
            var processes = Process.GetProcesses();
            var orderedProcesses = processes.OrderBy(p => p.ProcessName);

            foreach (var process in orderedProcesses)
                Console.WriteLine(process.ProcessName);

            Console.WriteLine();
        }

        private static void KillMicrosoftEdge()
        {
            var edgeProcess = Process.GetProcessesByName("msedge");

            foreach (var process in edgeProcess)
                process.Kill();
        }

        private static void StartMicrosoftEdgeInstance()
        {
            Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge");
        }

        private static void PerformWebInstallsForVBoxAndXubuntu()
        {
            WebClient client = new WebClient();

            client.DownloadFile("https://download.virtualbox.org/virtualbox/6.1.6/VirtualBox-6.1.6-137129-Win.exe",
                                @"C:\Users\zdb19\Downloads\VirtualBox-6.1.6-137129-Win.exe");
            Console.WriteLine("Virtual Box installed..");

            client.DownloadFile("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/18.04/release/xubuntu-18.04-desktop-amd64.iso",
                                @"C:\Users\zdb19\Downloads\xubuntu-18.04-desktop-amd64.iso");
            Console.WriteLine("Xubuntu ISO installed..");
        }
    }
}
