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
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;


        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        private void TestMethod()
        {
            Console.WriteLine("This is a test");
        }

        [HttpGet(Name = "GetTest")]
        public async void Get() {

            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM ccaa";

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["nombre"].ToString());
            }

            //Este te devuelve el reader directamente
            //using NpgsqlDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            //ReadOnlyCollection<NpgsqlDbColumn> schema = reader.GetColumnSchema();
        }

    }
}
