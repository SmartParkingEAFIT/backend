# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["SmartParkingAppEAFIT.API/SmartParkingAppEAFIT.API.csproj", "SmartParkingAppEAFIT.API/"]
RUN dotnet restore "SmartParkingAppEAFIT.API/SmartParkingAppEAFIT.API.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/SmartParkingAppEAFIT.API"
RUN dotnet build "SmartParkingAppEAFIT.API.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "SmartParkingAppEAFIT.API.csproj" -c Release -o /app/publish --no-restore

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Create a non-root user for security
RUN useradd -m appuser && chown -R appuser /app
USER appuser

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080

ENTRYPOINT ["dotnet", "SmartParkingAppEAFIT.API.dll"]