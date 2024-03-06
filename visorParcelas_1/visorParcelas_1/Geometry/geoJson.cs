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
        public List<List<List<double>>>? coordinates { get; set; }
    }
}
