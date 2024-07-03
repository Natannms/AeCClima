# Aec ClimaApi

### Descrição do Projeto
O Aec ClimaApi é uma aplicação RESTful que consome dados da Brasil API para fornecer informações meteorológicas para cidades e aeroportos especificados nas rotas da API. A aplicação registra todas as requisições e persiste os dados no SQL Server, além de salvar logs no banco de dados em caso de erros de processamento. A API está documentada através do Swagger e a aplicação é containerizada usando Docker.

### Funcionalidades
1. **Obter clima de uma cidade**: Rota para obter informações meteorológicas de uma cidade específica.
2. **Obter clima de um aeroporto**: Rota para obter informações meteorológicas de um aeroporto específico.
3. **Persistência de dados**: Persiste os dados meteorológicos no SQL Server a cada requisição.
4. **Registro de logs**: Salva logs no SQL Server em caso de erros de processamento.
5. **Documentação da API**: A API é documentada utilizando o Swagger.
6. **Containerização**: A aplicação é executada em contêineres Docker.

### Pré-requisitos
- Docker
- Docker Compose

### Passo a Passo

#### Clonar o Repositório
Clone o repositório para sua máquina local usando o comando:
```sh
git clone https://github.com/Natannms/AeCClima.git
```

### Executar os Contêineres
Navegue até o diretório do projeto clonado e execute o Docker Compose para construir e iniciar os contêineres:

```sh
cd AeCClima
docker-compose up --build
```

### Acessar a Aplicação no Navegador
Depois que os contêineres estiverem em execução, você pode acessar a aplicação no navegador, Postman , insominia entre outros recursos para consumo de api:

```sh
http://localhost:5062
```

### Acessar o Adminer para Ver os Dados
Para acessar o Adminer e visualizar os dados no SQL Server, abra seu navegador acesse abaixo:
[ADMINER](http://localhost:8081)

Use as seguintes credenciais e opções:

1. **System**: MS SQL (Beta)
2. **Server** : sqlserver
3. **Username** : sa
4. **Password** : YourStrong!Passw0rd
5. **Database** : WeatherDb (opcional, pode ser deixado em branco para listar todas as bases de dados)

### Documentação da API
A documentação da API está disponível no Swagger. Acesse o link abaixo:
[SWAGGER](http://localhost:5062/swagger)

### Tecnologias Utilizadas
1. SQL Server
1. ASP.NET Core
1. Docker
1. Adminer
1. Swagger
1. Contribuição

Se você quiser contribuir com este projeto, sinta-se à vontade para abrir uma issue ou enviar um pull request.