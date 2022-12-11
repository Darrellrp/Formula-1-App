#!/bin/bash

if [ $1 = "--env" ]; then
    export $(grep -v '^#' ../.env.dev | xargs)
else    
    read -e -p "Enter MySQL user: " MYSQL_USER
    read -e -p "Enter MySQL password: " MYSQL_ROOT_PASSWORD
fi

HOST=formula-1-db

echo "Opening Docker MySQL instance"
echo ""

docker exec -it $HOST mysql -u $MYSQL_USER -p$MYSQL_ROOT_PASSWORD
