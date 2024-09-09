using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Usar la política de CORS
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/clientes/{id}", async (int id, IDbConnection db) =>
{
    var cliente = await db.QuerySingleOrDefaultAsync<Cliente>("SELECT * FROM Clientes WHERE Id = @Id", new { Id = id });
    return cliente != null ? Results.Ok(cliente) : Results.NotFound();
});

app.Run();

public record Cliente(int Id, string Nombre, string Correo, string Telefono, string Direccion);

