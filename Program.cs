var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Agrega la generación y lectura de comentarios XML para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // ?? Información personalizada para Swagger UI
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API - Gestión de Productos",
        Version = "v1",
        Description = "Esta API permite realizar operaciones CRUD sobre productos dentro del sistema de compras de Mercado Libre. Soporta creación, consulta, actualización y eliminación de productos.",
    });

    // Incluir comentarios XML para documentación Swagger
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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Gestión de Productos v1");
        c.DocumentTitle = "Documentación API - Gestión de Productos";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
