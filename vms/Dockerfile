# Base stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS sdk
WORKDIR /app

EXPOSE 80
EXPOSE 443

WORKDIR /app

RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

COPY Formula-1-Services/Formula-1-API/Formula-1-API.csproj .
COPY Formula-1-Services/Formula-1-API/ .

RUN dotnet restore Formula-1-API.csproj
RUN dotnet build Formula-1-API.csproj -c Release -o build
RUN dotnet publish Formula-1-API.csproj -c Release -o publish

# Final stage
FROM sdk AS final
WORKDIR /app

COPY --from=sdk /app/publish .
COPY --from=sdk /root/.dotnet/corefx/cryptography/x509stores/my /root/.dotnet/corefx/cryptography/x509stores/my
ENTRYPOINT ["tail", "-f", "/dev/null"]