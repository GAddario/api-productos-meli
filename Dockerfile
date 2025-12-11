# -----------------------------------------
# STAGE 1 — Build
# -----------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY Api-Productos-MELI.csproj ./
RUN dotnet restore Api-Productos-MELI.csproj -r linux-x64

COPY . .

RUN dotnet publish Api-Productos-MELI.csproj -c Release -o /app/publish \
    -r linux-x64 --self-contained false

# -----------------------------------------
# STAGE 2 — Runtime
# -----------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

RUN addgroup -S dotnet && adduser -S dotnet -G dotnet
USER dotnet

COPY --from=build /app/publish .

EXPOSE 5000

ENTRYPOINT ["dotnet", "Api_Productos_MELI.dll"]