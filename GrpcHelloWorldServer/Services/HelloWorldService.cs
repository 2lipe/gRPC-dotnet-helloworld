using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcHelloWorldServer.Protos;
using Microsoft.Extensions.Logging;

namespace GrpcHelloWorldServer.Services
{
    public class HelloWorldService : HelloService.HelloServiceBase
    {
        private readonly ILogger<HelloWorldService> _logger;

        public HelloWorldService(ILogger<HelloWorldService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override Task<HelloResponse> SayHello(HelloRequest request, ServerCallContext context)
        {
            string resultMessage = $"Hello {request.Name}";

            var response = new HelloResponse
            {
                Message = resultMessage
            };

            return Task.FromResult(response);
        }
    }
}