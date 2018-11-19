// <copyright file="Program.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Common.Console;

namespace UserService
{
    public class Program
    {
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        public static async Task Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                DllImports.SetConsoleCtrlHandler(ConsoleCtrlCheck, true);
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
            await _semaphore.WaitAsync();

            await host.Stop();
        }

        private static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _semaphore.Release();
        }

        private static void ProcessExit(object sender, EventArgs e)
        {
            _semaphore.Release();
        }

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            _semaphore.Release();

            return true;
        }
    }
}
