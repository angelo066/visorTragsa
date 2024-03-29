﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Security.Principal;
using visorParcelas_1.Config;
using visorParcelas_1.Geometry;

namespace visorParcelas_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecintosController : ControllerBase
    {

        //Código que hace que aparezca el controlador en pantalla
        [HttpGet("{provincia}/{municipio}/{agregado}/{zona}/{poligono}/{parcela}/{recinto}")]
        public async Task<ActionResult<Feature>> Get(int provincia = 28, int municipio = 85, int agregado = 0, int zona = 0, int poligono = 1, int parcela = 1, int recinto = 8)
        {
            //Conexión con la base de datos
            string connectionString = Information_Singleton.getInstance().getConnectionString();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT ST_AsGeoJSON(t.*) FROM public.\"t$recinto\" AS t WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
            $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela} AND recinto = {recinto}";

            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Serialización del objeto GeoJSON
                var geoJsonString = JsonConvert.SerializeObject(reader.GetString(0));

                string deserializedString = JsonConvert.DeserializeObject<string>(geoJsonString);
                Feature geoJson = JsonConvert.DeserializeObject<Feature>(deserializedString);
                reader.Close();
                connection.Close();
                return geoJson;
            }

            return null;
        }
    }
}
