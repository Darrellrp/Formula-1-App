#!/bin/bash

echo "Start mysql ";

docker run --expose 8080 -p 8080:3306 -p 8081:33060 --name formula-1-mariadb -e MARIADB_ROOT_PASSWORD=password123 -d mariadb:latest
# docker run -v "$PWD/Data/mysql":/var/lib/mysql --expose 8080 -p 8080:3306 -p 8081:33060 --name formula-1-mysql -e MYSQL_ROOT_PASSWORD=password123 -d mysql:latest
