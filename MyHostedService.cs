using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyDotnet.Hosting
{
    public class MyHostedService : IHostedService
    {
        readonly ILogger<MyHostedService> _logger;

        double _interval { get; set; }

        Timer _timer { get; set; }

        public MyHostedService(ILogger<MyHostedService> logger, double interval = 3f)
        {
            _logger = logger;
            _interval = interval;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Start {nameof(MyHostedService)}");
            
            _timer = new Timer(OnUpdate, null, TimeSpan.Zero, TimeSpan.FromSeconds(_interval));
            return Task.CompletedTask;
        }

        void OnUpdate(object state)
        {
            // loop
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Stop {nameof(MyHostedService)}");
            
            return Task.CompletedTask;
        }
    }
}
