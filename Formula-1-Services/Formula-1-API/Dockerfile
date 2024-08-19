# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

RUN mkdir /app/data

# Restore stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS sdk
WORKDIR /app

RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

COPY Formula-1-API.csproj .

RUN dotnet restore Formula-1-API.csproj

# Build stage
FROM sdk AS build
WORKDIR /app

COPY . .

RUN dotnet build Formula-1-API.csproj -c Release -o build

# Publish stage
FROM build AS publish
WORKDIR /app

RUN dotnet publish Formula-1-API.csproj -c Release -o publish

# Final stage
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
COPY --from=sdk /root/.dotnet/corefx/cryptography/x509stores/my /root/.dotnet/corefx/cryptography/x509stores/my
ENTRYPOINT ["dotnet", "Formula-1-API.dll"]