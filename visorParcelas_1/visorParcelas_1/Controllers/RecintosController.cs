using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Security.Principal;
using visorParcelas_1.Geometry;

namespace visorParcelas_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecintosController : ControllerBase
    {

        //Código que hace que aparezca el controlador en pantalla
        [HttpGet]
        public async Task<ActionResult<geoJson>> Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1, int recinto = 8)
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
                // Serialización del objeto GeoJSON
                var geoJsonString = JsonConvert.SerializeObject(reader.GetString(0));

                string deserializedString = JsonConvert.DeserializeObject<string>(geoJsonString);
                geoJson geoJson = JsonConvert.DeserializeObject<geoJson>(deserializedString);
                return geoJson;
            }

            return null;
        }
    }
}
