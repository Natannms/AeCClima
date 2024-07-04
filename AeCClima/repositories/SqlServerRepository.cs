using AeCClima.Data;
using AeCClima.Entities;

namespace AeCClima.Repositories
{
    public class SqlServerRepository(AppDbContext context) : IWeatherRepository
    {
        private readonly AppDbContext _context = context;

        public async Task SaveAsync(WeatherData weatherData)
        {
            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsyncFromAirport(WeatherAirport weatherAirpot)
        {
            _context.WeatherAirports.Add(weatherAirpot);
            await _context.SaveChangesAsync();
        }

        public async Task SaveLogAsync(LogEntry logEntry)
        {
            _context.LogEntries.Add(logEntry);
            await _context.SaveChangesAsync();
        }
    }
}
