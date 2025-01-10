# Usa la imagen oficial de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia los archivos de tu proyecto al contenedor
COPY . ./

# Restaura las dependencias y publica la aplicación
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Usa la imagen de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copia los archivos publicados al contenedor runtime
COPY --from=build /app/out .

# Expone el puerto 5000 para la aplicación
EXPOSE 5120

# Configura el comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "PetPalzAPI.dll"]
