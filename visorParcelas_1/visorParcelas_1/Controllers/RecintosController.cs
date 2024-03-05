using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Npgsql.Schema;
using System.Buffers;
using System.Collections.ObjectModel;
using System.Data;

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
        public async void Get(string provincia, string municipio, int agregado, int zona, int poligono, int parcela, int recinto)
        {

            //Conexión con la base de datos
            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            //Creación del comando
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT * FROM recintos WHERE provincia = {provincia} AND municipio = {municipio} AND agregado = " +
                $"{agregado} AND zona = {zona} AND poligono = {poligono} AND parcela = {parcela} AND recinto = {recinto}";

            //NpgsqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["nombre"].ToString());
            //}
        }

    }
}
