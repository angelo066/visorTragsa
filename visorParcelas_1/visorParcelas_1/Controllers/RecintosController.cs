using Microsoft.AspNetCore.Mvc;
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

            command.CommandText = $"SELECT * FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
                $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela} AND recinto = {recinto}";


            NpgsqlDataReader reader = command.ExecuteReader();

            //try
            //{
            if (reader.Read())
            {

                Console.WriteLine(reader.GetDouble(reader.GetOrdinal("provincia")));
                // pruebas para ver si encuentro el valos de la columna, solo he encontrado el nombre xd
                //var nombre = reader.GetColumnSchema()[0].ColumnName;
                //Console.WriteLine($"ColumnName: {nombre}");
                //var nombre2 = reader.GetColumnSchema()[0].ColumnOrdinal;
                //Console.WriteLine($"ColumnOrdinal: {nombre2}");
                //var nombre3 = reader.GetColumnSchema()[0].DefaultValue;
                //Console.WriteLine($"DefaultValue: {nombre3}" + nombre3.ToString());
                //var nombre4 = reader.GetColumnSchema()[0].ColumnAttributeNumber;
                //Console.WriteLine($"ColumnAttributeNumber: {nombre4}");
                //var nombre5 = reader.GetColumnSchema()[0].BaseColumnName;
                //Console.WriteLine($"BaseColumnName: {nombre5}" + nombre5.ToString());
                //var nombre6 = reader.GetColumnSchema()[0];
                //Console.WriteLine($".GetColumnSchema()[0]; a secas: {nombre6}" + nombre6);

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
                //        pendiente_media = pendienteMedia // Cambia el nombre según tus necesidades
                //    }
                //};

                //// Serialización del objeto GeoJSON
                //var geoJsonString = JsonConvert.SerializeObject(geoJson);

                // Ahora puedes usar 'geoJsonString' como respuesta en tu API REST

            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error al procesar la solicitud");
            //}
        }
    }
}
