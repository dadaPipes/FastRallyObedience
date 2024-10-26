# Use the ASP.NET Core runtime as the base image for the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FastRallyObedience.Server/FastRallyObedience.Server.csproj", "FastRallyObedience.Server/"]
RUN dotnet restore "./FastRallyObedience.Server/FastRallyObedience.Server.csproj"
COPY . .
WORKDIR "/src/FastRallyObedience.Server"
RUN dotnet build "./FastRallyObedience.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app in a separate stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FastRallyObedience.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: production or regular mode
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastRallyObedience.Server.dll"]
