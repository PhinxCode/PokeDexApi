using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

/** test DB */


app.MapGet(
    "PingDb",
    () =>
    {
        try
        {
            using (var connection = new SqlConnection(connectionString))

                connection.Open();
            return Results.Ok("Succefully");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Error, DB not found. - {ex.Message}");
        }
    }
);

// Configurar Swagger para que esté disponible en modo desarrollo y producción
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokémon API v1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger esté en la raíz (localhost:5000/)
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
