using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;

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
        public async Task<ActionResult<string>> Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1, int recinto = 8)
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

            if (reader.Read())
            {
                //Console.WriteLine(reader.GetString(0));
                //var geoJson = reader.GetStream(0);
                //Console.WriteLine(geoJson);
                // Serialización del objeto GeoJSON
                var geoJsonString = JsonConvert.SerializeObject(reader.GetString(0));
                Console.WriteLine(geoJsonString);
                return geoJsonString;
            }
            return null;
        }
    }
}
