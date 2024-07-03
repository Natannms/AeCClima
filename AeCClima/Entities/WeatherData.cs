namespace AeCClima.Entities
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<Clima> Clima { get; set; }
    }
}
