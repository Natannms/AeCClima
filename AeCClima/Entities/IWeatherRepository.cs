using AeCClima.Entities;
using System.Threading.Tasks;

namespace AeCClima.Repositories
{
    public interface IWeatherRepository
    {
        Task SaveAsync(WeatherData weatherData);
        Task SaveAsyncFromAirport(WeatherAirport weatherAirpot);
    }
}
