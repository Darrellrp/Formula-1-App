#!/bin/bash

HOST=formula-1-db
read -e -p "Enter MySQL user: " USER
read -e -p "Enter MySQL password: " PASSWORD

echo "Opening Docker MySQL instance"
docker exec -it $HOST mysql -u $USER -p$PASSWORD Formula1App_Database
echo $HOST

