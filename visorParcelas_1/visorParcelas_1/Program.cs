using Newtonsoft.Json;
using visorParcelas_1.Config;

var builder = WebApplication.CreateBuilder(args);

using (StreamReader readerJson = new StreamReader("./Config/config.json"))
{
    string prueba = readerJson.ReadToEnd();
    Connection items = JsonConvert.DeserializeObject<Connection>(prueba);
    Information_Singleton.getInstance().setConnection(items);
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
