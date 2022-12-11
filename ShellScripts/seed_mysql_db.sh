#!/bin/bash

if [ $1 = "--env" ]; then
    export $(grep -v '^#' ../.env.dev | xargs)
else
    read -e -p "Enter MySQL database: " MYSQL_DATABASE
    read -e -p "Enter MySQL user: " MYSQL_USER
    read -e -p "Enter MySQL password: " MYSQL_ROOT_PASSWORD
fi

cd ../data/formula-1-race-data
for entry in *
do
    echo "Copying $entry to docker container"
    docker cp $entry formula-1-api:/app/data/$entry
done

echo ""

docker exec formula-1-api sh -c "export MYSQL_HOST=formula-1-db; export MYSQL_DATABASE=$MYSQL_DATABASE; export MYSQL_USER=$MYSQL_USER; export MYSQL_ROOT_PASSWORD=$MYSQL_ROOT_PASSWORD; dotnet Formula-1-API.dll -s 100"
