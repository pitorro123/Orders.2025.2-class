using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Implementations;
using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Implementations;
using Orders.Backend.UnitsOfWork.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// para evitar una redundancia ciclica en la serializacion de objetos JSON
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICountriesRepository, CountryRepository>();
builder.Services.AddScoped<IStatesRepository, StatesRepository>();

builder.Services.AddScoped<ICategoriesUnitOfWork, CategoriesUnitOfWork>();
builder.Services.AddScoped<ICitiesUnitOfWork, CitiesUnitOfWork>();
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();
builder.Services.AddScoped<IStatesUnitOfWork, StatesUnitOfWork>();

var app = builder.Build();

SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedAsync().Wait();
}

//que es var app = builder.Build();: Aquí es donde realmente construyes la aplicación a partir del builder que configuraste antes.
//Después de llamar a Build(), obtienes una instancia de WebApplication que representa tu aplicación configurada y lista para ejecutarse.
//que es app: es una instancia de WebApplication que representa la aplicación web configurada y lista para ejecutarse.

//
if (app.Environment.IsDevelopment())
{
    // Middleware para generar documentación Swagger en json
    app.UseSwagger();
    // Middleware para ver la UI de Swagger
    app.UseSwaggerUI();
}
// Middleware que redirige HTTP → HTTPS Si vino por http://, lo redirige a https://.
app.UseHttpsRedirection();
// Middleware que valida permisos de acceso Revisa si el usuario tiene permisos para acceder a ese endpoint
app.UseAuthorization();
// Middleware que enruta a los controladores (endpoints)Encuentra qué controller debe responder (ProductsController).
app.MapControllers();
app.Run();