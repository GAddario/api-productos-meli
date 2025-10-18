var builder = WebApplication.CreateBuilder(args);

// Integración con Sentry
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://d92ae720a85be5d8c42c6c58f0f9ba01@o4510127838068736.ingest.us.sentry.io/4510127872016384";
    o.Debug = true;              // logs internos de Sentry en consola
    o.TracesSampleRate = 1.0;    // captura el 100% de transacciones
});

builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Add services to the container.
builder.Services.AddControllers();

// Agrega la generaci�n y lectura de comentarios XML para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // ?? Informaci�n personalizada para Swagger UI
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API - Gesti�n de Productos",
        Version = "v1",
        Description = "Esta API permite realizar operaciones CRUD sobre productos dentro del sistema de compras de Mercado Libre. Soporta creaci�n, consulta, actualizaci�n y eliminaci�n de productos.",
    });

    // Incluir comentarios XML para documentaci�n Swagger
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Gesti�n de Productos v1");
        c.DocumentTitle = "Documentaci�n API - Gesti�n de Productos";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
