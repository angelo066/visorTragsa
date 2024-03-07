namespace visorParcelas_1.Geometry
{
    // FeatureCollection
    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    } 
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
    public class Crs
    {
        public string? type { get; set; }
        public Properties? properties { get; set; }
    }
   
    public class Geometry
    {
        public string type { get; set; }
        public Crs crs { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public int provincia { get; set; }
        public int municipio { get; set; }
        public int agregado { get; set; }
        public int zona { get; set; }
        public int poligono { get; set; }
        public int parcela { get; set; }
        public int recinto { get; set; }
        public int altitud { get; set; }
        public int pendiente_media { get; set; }
    }
}
