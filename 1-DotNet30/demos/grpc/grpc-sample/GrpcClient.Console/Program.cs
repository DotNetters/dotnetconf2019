using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Client";

            var shouldExit = false;

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            while (shouldExit == false)
            {
                Console.WriteLine("Press [c] to call the service, [q] to exit: ");
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.C:
                        var reply = await client.SayHelloAsync(new HelloRequest { Name = "Client" });
                        Console.WriteLine("Greeting: " + reply.Message);
                        break;
                    case ConsoleKey.Q:
                        shouldExit = true;
                        break;
                }
            }
        }
    }
}
