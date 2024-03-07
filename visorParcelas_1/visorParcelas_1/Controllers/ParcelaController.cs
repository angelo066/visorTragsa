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
        [HttpGet]
        public async Task<ActionResult<Root>> Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1)
        {
            //Conexión a la base de datos
            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            //Creación del comando
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT json_build_object('type', 'FeatureCollection','features', json_agg(ST_AsGeoJSON(t.*)::json)) FROM public.\"t$recinto\" AS t WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
                $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela}";

            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Serialización del objeto GeoJSON
                var geoJsonString = JsonConvert.SerializeObject(reader.GetString(0));

                string deserializedString = JsonConvert.DeserializeObject<string>(geoJsonString);
                Root geoJson = JsonConvert.DeserializeObject<Root>(deserializedString);


                reader.Close();

                return geoJson;
            }
            return null;
        }

    }
}
