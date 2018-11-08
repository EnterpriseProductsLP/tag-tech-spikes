﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace UserService
{
    internal class Program
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(0);

        public static async Task Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                SetConsoleCtrlHandler(ConsoleCtrlCheck, true);
            }
            else
            {
                Console.CancelKeyPress += CancelKeyPress;
                AppDomain.CurrentDomain.ProcessExit += ProcessExit;
            }

            var host = new Host();

            Console.Title = host.EndpointName;

            await host.Start();
            await Console.Out.WriteLineAsync("Press Ctrl+C to exit...");

            // wait until notified that the process should exit
            await semaphore.WaitAsync();

            await host.Stop();
        }

        private static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            semaphore.Release();
        }

        private static void ProcessExit(object sender, EventArgs e)
        {
            semaphore.Release();
        }

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            semaphore.Release();

            return true;
        }


        // imports required for a Windows container to successfully notice when a "docker stop" command
        // has been run and allow for a graceful shutdown of the endpoint
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(HandlerRoutine handler, bool add);

        private delegate bool HandlerRoutine(CtrlTypes ctrlType);

        private enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
    }
}