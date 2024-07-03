using AeCClima.Entities;
using AeCClima.Repositories;
using System.Threading.Tasks;

namespace AeCClima.Services
{
    public class WeatherService
    {
        
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public async Task Create(WeatherData weatherData)
        {
            await _weatherRepository.SaveAsync(weatherData);
        }
        public async Task CreateFromAirport(WeatherAirport weatherAirpot)
        {
            await _weatherRepository.SaveAsyncFromAirport(weatherAirpot);
        }

        // Outros métodos do serviço podem ser adicionados aqui
    }
}
