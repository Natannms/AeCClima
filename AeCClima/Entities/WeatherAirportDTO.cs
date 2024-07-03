using Newtonsoft.Json;


namespace AeCClima.Entities
{
    public class WeatherAirportDTO
    {
       [JsonProperty("umidade")]
        public string Umidade { get; set; }

        [JsonProperty("visibilidade")]
        public string Visibilidade { get; set; }

        [JsonProperty("codigo_icao")]
        public string CodigoIcao { get; set; }

        [JsonProperty("pressao_atmosferica")]
        public string PressaoAtmosferica { get; set; }

        [JsonProperty("vento")]
        public string Vento { get; set; }

        [JsonProperty("direcao_vento")]
        public string DirecaoVento { get; set; }

        [JsonProperty("condicao")]
        public string Condicao { get; set; }

        [JsonProperty("condicao_desc")]
        public string CondicaoDesc { get; set; }

        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("atualizado_em")]
        public string AtualizadoEm { get; set; }
    }
}
