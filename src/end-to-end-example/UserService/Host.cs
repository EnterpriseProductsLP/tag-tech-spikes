using System;
using System.Threading.Tasks;

namespace UserService
{
    internal class Host
    {
        public string EndpointName => "UserService";


        public async Task Start()
        {
            await Console.Out.WriteLineAsync("Hello World!");
        }

        public async Task Stop()
        {
            await Console.Out.WriteLineAsync("Goodbye World!");
        }
    }
}