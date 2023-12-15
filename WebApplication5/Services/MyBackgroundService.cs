using WebApplication5.Services.Abstract;
using WebApplication5.Services.Concrete;

namespace WebApplication5.Services
{
    public class MyBackgroundService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private Timer? _timer = null;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public MyBackgroundService(IConfiguration configuration,IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider;
            _configuration = configuration;
        }

        public  Task StartAsync(CancellationToken stoppingToken)
        {
            int intervalMinute = int.Parse(_configuration["MyConfig:IntervalInMinute"]);

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(intervalMinute));

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _service = scope.ServiceProvider.GetRequiredService<IMovieService>();
                var _omdbService = scope.ServiceProvider.GetRequiredService<IOmdbService>();

                var film = await _omdbService.GetFilmAsync();
                _service.Add(film);
            }
            var count = Interlocked.Increment(ref executionCount);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}
