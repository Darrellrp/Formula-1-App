#!/bin/bash

echo "Generating SSL Certificate: localhost.key, localhost.crt";
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout Data/certs/localhost.key -out Data/certs/localhost.crt

echo "Generating SSL Certificate: localhost.key, localhost.crt";
dotnet dev-certs https -ep /Data/certs/aspnetapp.pfx -p $1
