# Imagen base para ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

# Render usará este puerto
ENV ASPNETCORE_URLS=http://+:10000

# Imagen para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia el archivo del proyecto
COPY ["Analisistarea/Analisistarea.csproj", "Analisistarea/"]

# Restaura dependencias
RUN dotnet restore "./Analisistarea/Analisistarea.csproj"

# Copia todo el código
COPY . .

# Entra a la carpeta del proyecto
WORKDIR "/src/Analisistarea"

# Compila el proyecto
RUN dotnet build "./Analisistarea.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica el proyecto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Analisistarea.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final para producción
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Analisistarea.dll"]