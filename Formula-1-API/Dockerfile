FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY Formula-1-API/Formula-1-API.csproj Formula-1-API/
RUN dotnet restore "Formula-1-API/Formula-1-API.csproj"
COPY . .
WORKDIR "/src/Formula-1-API"
RUN dotnet build "Formula-1-API.csproj" -c Release -o /app/build

ENV DOCKERIZE_VERSION v0.6.1
RUN wget https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && rm dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz
CMD dockerize -wait tcp://db:3306


FROM build AS publish
RUN dotnet publish "Formula-1-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formula-1-API.dll"]
