#! /bin/bash

rm -rf ./Migrations
docker-compose down --rmi all -v
docker-compose up -d
dotnet ef migrations add InitialMigration
dotnet ef database update
