# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

RUN mkdir data

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS sdk
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

FROM sdk AS restore

COPY Formula-1-API.csproj .

RUN dotnet restore Formula-1-API.csproj

# Build stage
FROM restore AS build
WORKDIR /app

COPY . .

RUN dotnet build Formula-1-API.csproj -c Release -o build

# Publish stage
FROM build AS publish
WORKDIR /app

RUN dotnet publish Formula-1-API.csproj -c Release -o publish

# Restore stage
FROM publish AS ef
WORKDIR /app

# RUN dotnet new tool-manifest
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update

# Final stage
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formula-1-API.dll"]