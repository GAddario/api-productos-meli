var builder = WebApplication.CreateBuilder(args);

// Integración con Sentry
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://d92ae720a85be5d8c42c6c58f0f9ba01@o4510127838068736.ingest.us.sentry.io/4510127872016384";
    o.Debug = true;              // logs internos de Sentry en consola
    o.TracesSampleRate = 1.0;    // captura el 100% de transacciones
});

// Escuchar en 0.0.0.0:5000
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API - Gestión de Productos",
        Version = "v1",
        Description = "Esta API permite realizar operaciones CRUD sobre productos dentro del sistema de compras de Mercado Libre. Soporta creación, consulta, actualización y eliminación de productos.",
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// (NUEVO) Bandera para habilitar Swagger también en prod
var enableSwagger = app.Configuration.GetValue<bool>("EnableSwagger", false);

// Swagger
if (app.Environment.IsDevelopment() || enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Gestión de Productos v1");
        c.DocumentTitle = "Documentación API - Gestión de Productos";
    });
}

// HTTPS redirection 

app.UseAuthorization();

// (NUEVO) Endpoint de health ANTES del Run
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapControllers();


app.Run();
