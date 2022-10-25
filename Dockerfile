# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

# Restore stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS restore
WORKDIR /app

COPY Formula-1-App.csproj .

RUN dotnet restore Formula-1-App.csproj

# Build stage
FROM restore AS build
WORKDIR /app

COPY . .

RUN dotnet build Formula-1-App.csproj -c Release -o build

# Publish stage
FROM build AS publish
WORKDIR /app

RUN dotnet publish Formula-1-App.csproj -c Release -o publish

# Final stage
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formula-1-App.dll"]