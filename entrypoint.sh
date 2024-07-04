#!/bin/bash

# Esperar pelo SQL Server ficar disponível
echo "Waiting for SQL Server to be available..."
/AeCClima/wait-for-it.sh sqlserver:1433 --timeout=60 --strict -- echo "SQL Server is up"

# Criar o banco de dados e as tabelas se não existirem
echo "Creating database and tables if they do not exist..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P YourStrong!Passw0rd -d master -i /AeCClima/init.sql


# Rodar a aplicação
echo "Starting application..."
dotnet AeCClima.dll
