#!/bin/bash

if [ $1 = "--env" ]; then
    export $(grep -v '^#' ../.env.dev | xargs)
else
    read -e -p "Enter MySQL database: " MYSQL_DATABASE
    read -e -p "Enter MySQL user: " USER
    read -e -p "Enter MySQL password: " MYSQL_ROOT_PASSWORD
fi

echo "Applying Migrations"
cd ../Formula-1-API

dotnet ef database update --connection "server=localhost;database=${MYSQL_DATABASE};user=${MYSQL_USER};password=${MYSQL_ROOT_PASSWORD};" -v