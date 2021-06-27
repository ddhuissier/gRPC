using FooService;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService
{
    public class MyService : FooService.MyService.MyServiceBase
    {
        private readonly ILogger<MyService> _logger;
        public MyService(ILogger<MyService> logger)
        {
            _logger = logger;
        }

        public override Task<MyReply> GetFoo(MyRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MyReply
            {
                Message = "Get " + request.Name
            });
        }
    }
}
