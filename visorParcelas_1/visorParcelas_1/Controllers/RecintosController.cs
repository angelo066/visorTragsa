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
        [HttpGet("{Provinvia}/{Municipio}/{Agregado}/{Zona}/{Polígono}/{Parcela}/{Recinto}")]
        public async void Get() {

            //Conexión con la base de datos
            var connectionString = "Host = 172.17.11.154;Username=postgres;Password=postgres;DataBase=DATOS_PRUEBA";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            NpgsqlConnection connection = dataSource.OpenConnection();

            //Creación del comando
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM ccaa";

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["nombre"].ToString());
            }

            var name = this.Request.Form["name"];

            
        }

    }
}
