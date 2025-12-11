# -----------------------------------------
# STAGE 1 — Build
# -----------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copiar sólo los archivos del proyecto para optimizar el caché
COPY Api-Productos-MELI.csproj ./
RUN dotnet restore Api-Productos-MELI.csproj

# Copiar el resto del código
COPY . .

# Publicación optimizada (imagen más chica)
RUN dotnet publish Api-Productos-MELI.csproj \
    -c Release \
    -o /app/publish \
    --no-restore \
    -p:PublishTrimmed=true \
    -p:TrimMode=Link \

# -----------------------------------------
# STAGE 2 — Runtime
# -----------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

# Crear usuario no-root por seguridad
RUN addgroup -S dotnet && adduser -S dotnet -G dotnet
USER dotnet

# Copiar el resultado de la publicación
COPY --from=build /app/publish .

EXPOSE 5000

# Usar el mismo nombre del DLL que ya tiene el proyecto
ENTRYPOINT ["dotnet", "Api-Productos-MELI.dll"]
