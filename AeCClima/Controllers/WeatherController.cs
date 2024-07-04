using Microsoft.AspNetCore.Mvc;

using AeCClima.Entities;
using AeCClima.Services;
using Newtonsoft.Json;

namespace AeCClima.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly HttpClient _httpClient;
        private readonly WeatherService _weatherService;
        public WeatherController(ILogger<WeatherController> logger, HttpClient httpClient, WeatherService weatherService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _weatherService = weatherService;
        }

        [HttpGet("city/{cityName}", Name = "GetWeatherByCity")]
        public async Task<IActionResult> GetWeatherByCity(string cityName)
        {
            _logger.LogInformation($"Recebido nome da cidade: {cityName}");
            try
            {
                var cityResponse = await _httpClient.GetFromJsonAsync<CityInfoDTO[]>($"https://brasilapi.com.br/api/cptec/v1/cidade/{cityName}");
                _logger.LogInformation("Resposta da cidade recebida da API externa");

                if (cityResponse == null || cityResponse.Length == 0)
                {
                    return NotFound(new { Message = "Cidade não encontrada" });
                }

                var cityInfo = cityResponse[0];

                var weatherResponse = await _httpClient.GetFromJsonAsync<WeatherData>($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityInfo.Id}");
                if (weatherResponse == null)
                {
                    return NotFound(new { Message = "Previsão do clima não encontrada" });
                }

                await _weatherService.Create(weatherResponse);

                return Ok(weatherResponse);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erro ao chamar a API externa");
                await _weatherService.CreateLogAsync(new LogEntry
                {
                    Timestamp = DateTime.UtcNow,
                    Level = "Error",
                    Message = "Erro ao chamar a API externa",
                    Exception = ex.ToString()
                });
                return StatusCode(500, new { Message = "Erro ao chamar a API externa", Details = ex.Message });
           }
        }

        [HttpGet("airport/{icao}", Name = "GetWeatherByAirpot")]
        public async Task<IActionResult> GetWeatherByAirpot(string icao)
        {
                
            try
            {
                var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/{icao}");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var weatherAirport = JsonConvert.DeserializeObject<WeatherAirport>(responseContent);

                if (weatherAirport == null)
                {
                    return NotFound(new { Message = "Aeroporto não encontrado" });
                }
                
                 await _weatherService.CreateFromAirport(weatherAirport);

                return Ok(weatherAirport);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erro ao chamar a API externa");
                await _weatherService.CreateLogAsync(new LogEntry
                {
                    Timestamp = DateTime.UtcNow,
                    Level = "Error",
                    Message = "Erro ao chamar a API externa",
                    Exception = ex.ToString()
                });
                return StatusCode(500, new { Message = "Erro ao chamar a API externa", Details = ex.Message });
           }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado");
                await _weatherService.CreateLogAsync(new LogEntry
                {
                    Timestamp = DateTime.UtcNow,
                    Level = "Error",
                    Message = "Erro inesperado",
                    Exception = ex.ToString()
                });
                return StatusCode(500, new { Message = "Erro inesperado", Details = ex.Message });
            }
        }
    }
}
