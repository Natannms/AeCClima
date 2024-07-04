# Use a imagem base do SDK .NET para compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /AeCClima

# Copiar tudo
COPY . ./
# Restaurar como camadas distintas
RUN dotnet restore

# Instalar o dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Compilar e publicar a versão de release
RUN dotnet publish -c Release -o out

# Construir imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /AeCClima
COPY --from=build-env /AeCClima/out .
COPY entrypoint.sh /AeCClima/entrypoint.sh
COPY wait-for-it.sh /AeCClima/wait-for-it.sh
COPY init.sql /AeCClima/init.sql

# Instalar ferramentas necessárias e SQLCMD
RUN apt-get update && \
    apt-get install -y curl gnupg2 apt-transport-https netcat-openbsd && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    /bin/bash -c "source ~/.bashrc"

RUN chmod +x /AeCClima/entrypoint.sh
RUN chmod +x /AeCClima/wait-for-it.sh

ENTRYPOINT ["./entrypoint.sh"]
