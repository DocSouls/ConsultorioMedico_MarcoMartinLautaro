using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConsultorioMedico2.Data;
using Microsoft.EntityFrameworkCore;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IDoctoresService, DoctoresService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ITurnosService, TurnosService>();

builder.Services.AddDbContext<ConsultorioDBcontext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ConsultorioDBcontext>();
        context.Database.CanConnect();
        Console.WriteLine("✅ Conexión a la base de datos exitosa.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Error al conectar con la base de datos:");
        Console.WriteLine(ex.Message);
    }
}


app.Run();
