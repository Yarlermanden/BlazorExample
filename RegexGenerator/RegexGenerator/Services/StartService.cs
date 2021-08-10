using System;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Serilog;
using Topshelf;
using Topshelf.Logging;

namespace RegexGenerator.Services
{
    public class StartService
    {
        private readonly IService _service;
        private readonly IMemoryCache _memoryCache;

        public StartService(IService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        public bool Start(HostControl hostControl)
        {
            var policy = Policy.Handle<Exception>().WaitAndRetryForeverAsync(
                attempt => TimeSpan.FromMilliseconds(2000),
                (exception, calculatedWaitDuration) =>
                {
                    Log.Error("Error starting the service, log and retry: ", exception.Message, ConsoleColor.Yellow);
                });

            policy.ExecuteAsync(async () =>
            {
                //var credentials = JsonSerializer.Deserialize<something>(WebRequestMethods.File.ReadAllText("credentials.json"));
                //_memoryCache.Set("credentials", credentials);

                _service.ServiceMethod("This is the hello world message");
            });

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}