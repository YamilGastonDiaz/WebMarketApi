using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;

var builder = WebApplication.CreateBuilder(args);

//Inicio del área de servicio

builder.Services.AddDbContext<DB_MiniMarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

//Inicio del área de los middlewares

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
