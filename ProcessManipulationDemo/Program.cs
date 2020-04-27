using FlaUI.UIA3;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace ProcessManipulationDemo
{
    class Program
    {
        static void Main()
        {
            PerformWebInstallsForVBoxAndXubuntu();
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
            Process.Start(DirectoryHelpers.MSEdgePath);
        }

        private static void PerformWebInstallsForVBoxAndXubuntu()
        {
            WebClient client = new WebClient();

            client.DownloadFile("https://download.virtualbox.org/virtualbox/6.1.6/VirtualBox-6.1.6-137129-Win.exe",
                                @"C:\Users\zdb19\Downloads\VirtualBox-6.1.6-137129-Win.exe");
            Console.WriteLine("Virtual Box downloaded..");

            client.DownloadFile("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/18.04/release/xubuntu-18.04-desktop-amd64.iso",
                                @"C:\Users\zdb19\Downloads\xubuntu-18.04-desktop-amd64.iso");
            Console.WriteLine("Xubuntu ISO downloaded..");

            Process.Start(@"C:\Users\zdb19\Downloads\VirtualBox-6.1.6-137129-Win.exe");

            Console.WriteLine("Virtual Box installation started..\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void OpenNotepadAndAutomate()
        {
            var app = FlaUI.Core.Application.Launch("notepad.exe");

            using (var automation = new UIA3Automation())
            {
                var initialTimeSpan = new TimeSpan(0, 0, 3);
                var window = app.GetMainWindow(automation, initialTimeSpan);
                Console.WriteLine("Press any key once Notepad is open...");
                Console.ReadKey();
                Console.WriteLine(window.Title);
                window.RightClick();
                Console.ReadKey();
            }

            Console.WriteLine("Automation complete...");
        }
    }
}
