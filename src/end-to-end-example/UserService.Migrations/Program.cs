// <copyright file="Program.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System;
using System.Data.SqlClient;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace UserService.Migrations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var csb = new SqlConnectionStringBuilder
            {
                ApplicationName = "UserService.Migrations",
                DataSource = "tts-userservice-sqlserver",
                InitialCatalog = "users",
                MultipleActiveResultSets = false,
                Password = "yourStrong(!)Password",
                UserID = "sa"
            };

            Console.WriteLine(csb.ConnectionString);

            // Get a connection string.
            if (!TryParseConnectionString(args, out var connectionString))
            {
                connectionString = csb.ConnectionString;

                // Console.ForegroundColor = ConsoleColor.Red;
                // Console.WriteLine("You must provide a valid SQL server connection string.");
                // Environment.Exit(-1);
            }

            // Build and run our upgrader.
            var result = PerformUpgrade(connectionString);

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                Environment.Exit(-1);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database Migrations Succeeded!");
            Console.ResetColor();
        }

        private static DatabaseUpgradeResult PerformUpgrade(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgradeEngine = DeployChanges
                .To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            return upgradeEngine.PerformUpgrade();
        }

        private static bool TryParseConnectionString(string[] args, out string connectionString)
        {
            try
            {
                var connectionStringFromArgs = args[1];
                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionStringFromArgs);
                connectionString = connectionStringBuilder.ConnectionString;
                return true;
            }
            catch (Exception)
            {
                connectionString = null;
                return false;
            }
        }
    }
}
