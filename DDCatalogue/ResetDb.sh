#! /bin/bash

rm -rf ./Migrations
docker-compose -f docker-compose-pg.yml down --rmi all -v
docker-compose -f docker-compose-pg.yml up -d
dotnet ef migrations add InitialMigration
dotnet ef database update
