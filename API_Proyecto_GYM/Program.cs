using API_Proyecto_GYM.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_GYM.Domain.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ITbPersonaRepository, TbPersonaRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<GYMContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
