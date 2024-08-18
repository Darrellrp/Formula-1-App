#!/bin/bash

echo "Generating SSL Certificate: localhost.key, localhost.crt";
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout ../docker-volumes/certs/localhost.key -out ../docker-volumes/certs/localhost.crt

read -e -p "Enter a password for Formula-1-API.pfx: " PASSWORD

echo "Generating SSL Personal Certificate: Formula-1-API.pfx";
dotnet dev-certs https -ep ../docker-volumes/certs/Formula-1-API.pfx -p $PASSWORD
# dotnet dev-certs https -ep ${HOME}/.aspnet/https/Formula-1-API.pfx -p vDQr62VsmXNV6aMmy
dotnet dev-certs https --trust
