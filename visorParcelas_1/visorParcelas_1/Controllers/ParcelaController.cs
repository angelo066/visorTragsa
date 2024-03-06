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
        public async Task<ActionResult<List<geoJson>>> Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1)
        {
            //Conexión a la base de datos
            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            //Petición del número de recintos y de sus respetívos índices
            List<int> recintos = new List<int>();
            int N_recintos = getN_Recintos(provincia, municipio, agregado, zona, poligono, parcela,connection,ref recintos);

            //Creación del comando
            NpgsqlCommand command = connection.CreateCommand();

            List<geoJson> data = new List<geoJson>();

            //Recorremos los recintos preguntando por su geoJson y lo añadimos a la lista
            for (int i = 0; i < recintos.Count; i++)
            {
                command.CommandText = $"SELECT ST_AsGeoJSON(dn_geom) FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
                $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela} AND recinto = {recintos[i]}";

                //Esperamos a que se ejecute el comando
                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Serialización del objeto GeoJSON
                    var geoJsonString = JsonConvert.SerializeObject(reader.GetString(0));

                    string deserializedString = JsonConvert.DeserializeObject<string>(geoJsonString);
                    geoJson geoJson = JsonConvert.DeserializeObject<geoJson>(deserializedString);

                    //Hasta que no se cierra el reader no se puede ejecutar otro comando
                    reader.Close();

                    command.CommandText = $"SELECT * FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
                    $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela} AND recinto = {recintos[i]}";

                    reader = command.ExecuteReader();

                    setProperties(provincia, municipio, agregado, zona, poligono, parcela, recintos[i], reader, geoJson);

                    data.Add(geoJson);

                    reader.Close();
                }
            }
            return data;
        }

        //En este método obtengo el número de recintos que hay en la parcela, además de sus respectivos identificadores
        private static int getN_Recintos(int provincia, int municipio, int agregado, int zona, int poligono, int parcela ,NpgsqlConnection connection, ref List<int>recintos)
        {
            NpgsqlCommand recintoCommand = connection.CreateCommand();

            recintoCommand.CommandText = $"SELECT * FROM public.\"t$recinto\" WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
            $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela}";

            NpgsqlDataReader recintoReader = recintoCommand.ExecuteReader();

            int N_recintos = 0;

            while (recintoReader.Read())
            {
                recintos.Add(recintoReader.GetInt32(recintoReader.GetOrdinal("recinto")));
                N_recintos++;
            }

            recintoReader.Close();

            return N_recintos;
        }

        private static void setProperties(int provincia, int municipio, int agregado, int zona, int poligono, int parcela, int recinto, NpgsqlDataReader reader, geoJson geoJson)
        {
            if (reader.Read())
            {
                geoJson.provincia = provincia;
                geoJson.municipio = municipio;
                geoJson.agregado = agregado;
                geoJson.zona = zona;
                geoJson.recinto = recinto;
                geoJson.polígono = poligono;
                geoJson.parcela = parcela;
                geoJson.altitud = reader.GetInt32(reader.GetOrdinal("altitud"));
                geoJson.pendiente_media = reader.GetInt32(reader.GetOrdinal("pendiente_media"));
            }
        }
    }
}
