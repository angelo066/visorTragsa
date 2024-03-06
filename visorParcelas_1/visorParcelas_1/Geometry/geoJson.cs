namespace visorParcelas_1.Geometry
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Crs
    {
        public string? type { get; set; }
        public Properties? properties { get; set; }
    }

    public class Properties
    {
        public string? name { get; set; }
    }

    public class geoJson
    {
        public string? type { get; set; }
        public Crs? crs { get; set; }
        public int provincia { get; set; }
        public int municipio { get; set; }
        public int agregado { get; set; }
        public int zona { get; set; }
        public int polígono { get; set; }
        public int parcela { get; set; }
        public int recinto { get; set; }
        public int altitud { get; set; }
        public int pendiente_media { get; set; }
        public List<List<List<double>>>? coordinates { get; set; }

    }
}
