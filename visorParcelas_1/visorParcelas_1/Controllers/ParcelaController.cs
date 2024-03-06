using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using visorParcelas_1.Geometry;

namespace visorParcelas_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelaController
    {
        private readonly ILogger<ParcelaController> _logger;

        public ParcelaController(ILogger<ParcelaController> logger) { _logger = logger; }


        [HttpGet]
        public async Task<ActionResult<geoJson>> Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1)
        {
            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            //Petición del número de recintos y de sus respetívos índices
            int[] recintos;
            int N_recintos = getN_Recintos(provincia, municipio, agregado, zona, poligono, parcela,connection);

            //Creación del comando
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT ST_AsGeoJSON(dn_geom) FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
            $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela}";


            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Serialización del objeto GeoJSON
                var geoJsonString = JsonConvert.SerializeObject(reader.GetString(0));

                string deserializedString = JsonConvert.DeserializeObject<string>(geoJsonString);
                geoJson geoJson = JsonConvert.DeserializeObject<geoJson>(deserializedString);
                return geoJson;
            }

            return null;
        }

        private static int getN_Recintos(int provincia, int municipio, int agregado, int zona, int poligono, int parcela ,NpgsqlConnection connection, ref int[]recintos)
        {
            NpgsqlCommand recintoCommand = connection.CreateCommand();

            recintoCommand.CommandText = $"SELECT * FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
            $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela}";

            NpgsqlDataReader recintoReader = recintoCommand.ExecuteReader();

            int N_recintos = 0;

            while (recintoReader.Read())
            {
                N_recintos++;
            }

            return N_recintos;
        }
    }
}
