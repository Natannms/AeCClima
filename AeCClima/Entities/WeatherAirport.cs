using System;
using Newtonsoft.Json;

namespace AeCClima.Entities
{
    public class WeatherAirport
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
       [JsonProperty("umidade")]
        public int Umidade { get; set; }

        [JsonProperty("visibilidade")]
        public string Visibilidade { get; set; }

        [JsonProperty("codigo_icao")]
        public string CodigoIcao { get; set; }

        [JsonProperty("pressao_atmosferica")]
        public int PressaoAtmosferica { get; set; }

        [JsonProperty("vento")]
        public int Vento { get; set; }

        [JsonProperty("direcao_vento")]
        public int DirecaoVento { get; set; }

        [JsonProperty("condicao")]
        public string Condicao { get; set; }

        [JsonProperty("condicao_desc")]
        public string CondicaoDesc { get; set; }

        [JsonProperty("temp")]
        public int Temp { get; set; }

        [JsonProperty("atualizado_em")]
        public DateTime AtualizadoEm { get; set; }
    }
}
