using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcHelloWorldClient.Protos;

namespace GrpcHelloWorldClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new HelloService.HelloServiceClient(channel);

            var reply = await client.SayHelloAsync(
                new HelloRequest
                {
                    Name = "Hello FSV Client"
                }
            );
            
            Console.WriteLine("Greetings: " + reply.Message);
            Console.ReadKey();
        }
    }
}