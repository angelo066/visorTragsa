using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
//using Newtonsoft.Json;

namespace visorParcelas_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecintosController : ControllerBase
    {
        private readonly ILogger<RecintosController> _logger;


        public RecintosController(ILogger<RecintosController> logger)
        {
            _logger = logger;
        }

        private void TestMethod()
        {
            Console.WriteLine("This is a test");
        }

        //Código que hace que aparezca el controlador en pantalla
        [HttpGet("recinto/{provincia}/{municipio}/{agregado}/{zona}/{poligono}/{parcela}/{recinto}")]
        public async void Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1, int recinto = 8)
        {

            //Conexión con la base de datos
            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            //Creación del comando
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT ST_AsGeoJSON(dn_geom) FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
            $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela} AND recinto = {recinto}";


            NpgsqlDataReader reader = command.ExecuteReader();

            //try
            //{
            if (reader.Read())

                Console.WriteLine(reader.GetString(0));
            //var altitud = reader.GetDouble(reader.GetOrdinal("altitud"));
            //var pendiente_media = reader.GetDouble(reader.GetOrdinal("pendiente_media"));
            //var longitude = reader.GetDouble(reader.GetOrdinal("geocentro_x"));
            //var latitude = reader.GetDouble(reader.GetOrdinal("geocentro_y"));
            //// Creación del objeto GeoJSON
            //var geoJson = new
            //{
            //    type = "Feature",
            //    geometry = new
            //    {
            //        type = "Point",
            //        coordinates = new[] { longitude, latitude }
            //    },
            //    properties = new
            //    {
            //        provincia,
            //        municipio,
            //        agregado,
            //        zona,
            //        poligono,
            //        parcela,
            //        recinto,
            //        altitud,
            //        pendiente_media  // Cambia el nombre según tus necesidades
            //    }
            //};

            //// Serialización del objeto GeoJSON
            //var geoJsonString = JsonConvert.SerializeObject(geoJson);

        }
    }
}
