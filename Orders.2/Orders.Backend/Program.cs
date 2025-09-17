using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Implementations;
using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Implementations;
using Orders.Backend.UnitsOfWork.Interfaces;

//var: inferencia de tipo en C#. Aquí el tipo real es WebApplicationBuilder.
//WebApplication: Esta es la clase principal que se utiliza para inicializar y ejecutar la aplicación ASP.NET Core
//CreateBuilder(args): crea un WebApplicationBuilder usando los argumentos de línea de comandos (args) para configurar
//cosas (puerto, entorno, etc.).
//Este objeto builder contien Configuration(lee appsettings.json, variables de entorno, secretos, etc.).
//Services(el contenedor de inyección de dependencias). Logging(config de logs).
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// AddServices to the container: Aquí es donde registras servicios que tu aplicación va a usar, como controladores, bases de datos, autenticación, etc.
// Controllers: son clases que manejan las solicitudes HTTP y devuelven respuestas HTTP. En ASP.NET Core, los controladores suelen heredar de ControllerBase o Controller.
builder.Services.AddControllers();
//builder.Services: es un IServiceCollection. Aquí “anotas” o registras servicios que luego podrás inyectar en tus clases
builder.Services.AddEndpointsApiExplorer();
// Swagger: herramienta para documentar y probar APIs RESTful. Genera una UI interactiva para explorar y probar los endpoints de tu API.
builder.Services.AddSwaggerGen();
// Configuración de Entity Framework Core con SQL Server
// AddDbContext: registra el DataContext (tu DbContext personalizado) en el contenedor de DI.
//UseSqlServer: configura el DbContext para usar SQL Server como proveedor de base de datos.
//"name=LocalConnection": indica que la cadena de conexión se encuentra en el archivo de configuración (appsettings.json) bajo la clave "LocalConnection".
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<SeedDb>();
var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory.CreateScope();
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