using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Repository;
using WebMarketApi.Service;

var builder = WebApplication.CreateBuilder(args);

//Inicio del área de servicio

builder.Services.AddControllers();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddScoped<ITiposEmpaqueRepository, TiposEmpaqueRepository>();
builder.Services.AddScoped<ITiposEmpaqueService, TiposEmpaqueService>();

builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DB_MiniMarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen(opciones => 
{
    opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    {
       Title = "Web Market Api",
       Description = "Aprendiendo Web Api",
       Contact = new Microsoft.OpenApi.Models.OpenApiContact
       {
           Email = "yamiil.gaston.diaz@gmail.com",
           Name = "Yamil Gaston Diaz",
           Url = new Uri("https://www.linkedin.com/in/yamil-gaston-diaz/")  
       }
    });
});

var app = builder.Build();

//Inicio del área de los middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
