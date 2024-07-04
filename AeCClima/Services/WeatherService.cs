using AeCClima.Entities;
using AeCClima.Repositories;

namespace AeCClima.Services
{
    public class WeatherService
    {
        
        private readonly IWeatherRepository _weatherRepository;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(IWeatherRepository weatherRepository,  ILogger<WeatherService> logger)
        {
            _weatherRepository = weatherRepository;
             _logger = logger;
        }
        public async Task Create(WeatherData weatherData)
        {
           try
            {
                await _weatherRepository.SaveAsync(weatherData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save weather data");
                await _weatherRepository.SaveLogAsync(new LogEntry
                {
                    Timestamp = DateTime.UtcNow,
                    Level = "Error",
                    Message = "Failed to save weather data",
                    Exception = ex.ToString()
                });
            }
        }
        public async Task CreateFromAirport(WeatherAirport weatherAirport)
        {
            try
            {
                await _weatherRepository.SaveAsyncFromAirport(weatherAirport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save airport weather data");
                await _weatherRepository.SaveLogAsync(new LogEntry
                {
                    Timestamp = DateTime.UtcNow,
                    Level = "Error",
                    Message = "Failed to save airport weather data",
                    Exception = ex.ToString()
                });
            }
        }
         public async Task CreateLogAsync(LogEntry logEntry)
        {
            try
            {
                await _weatherRepository.SaveLogAsync(logEntry);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save log entry");
            }
        }
    }
}
