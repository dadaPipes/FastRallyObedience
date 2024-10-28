# Use the ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore dependencies
COPY FastRallyObedience.Server.csproj ./
RUN dotnet restore "./FastRallyObedience.Server.csproj"

# Copy the entire source and build
COPY . .
RUN dotnet build "./FastRallyObedience.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app in a separate stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FastRallyObedience.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastRallyObedience.Server.dll"]
