using System;
using System.Threading.Tasks;
using FooService;
using Grpc.Net.Client;
using GrpcService;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });

            var myClient = new MyService.MyServiceClient(channel);
            var currentData = await myClient.GetFoo(
                              new MyRequest { Name = "My Name" });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("MyService: " + currentData.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
