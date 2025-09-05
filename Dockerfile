# Etapa 1: Construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copiar el proyecto principal y restaurar dependencias
COPY Api-Productos-MELI.csproj ./
RUN dotnet restore Api-Productos-MELI.csproj

# Copiar el resto del código
COPY . .

# Publicar solo el proyecto de la API
RUN dotnet publish Api-Productos-MELI.csproj -c Release -o out

# Etapa 2: Imagen para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app
COPY --from=build /app/out .

EXPOSE 5000
ENTRYPOINT ["dotnet", "Api_Productos_MELI.dll"]