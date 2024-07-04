-- Cria o banco de dados WeatherDb se não existir
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'WeatherDb')
BEGIN
    CREATE DATABASE WeatherDb;
END
GO

-- Usa o banco de dados WeatherDb
USE WeatherDb;
GO

-- Cria a tabela WeatherData se não existir
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeatherData]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[WeatherData](
        [Id] INT PRIMARY KEY IDENTITY,
        [Cidade] NVARCHAR(100),
        [Estado] NVARCHAR(100),
        [AtualizadoEm] DATETIME
    );
END
GO

-- Cria a tabela Clima se não existir
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clima]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Clima](
        [Id] INT PRIMARY KEY IDENTITY,
        [Data] DATETIME,
        [Condicao] NVARCHAR(100),
        [CondicaoDesc] NVARCHAR(100),
        [Min] INT,
        [Max] INT,
        [IndiceUv] INT,
        [WeatherDataId] INT,
        FOREIGN KEY (WeatherDataId) REFERENCES WeatherData(Id)
    );
END
GO

-- Cria a tabela LogEntries se não existir
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogEntries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[LogEntries](
        [Id] INT PRIMARY KEY IDENTITY,
        [Timestamp] DATETIME,
        [Level] NVARCHAR(50),
        [Message] NVARCHAR(500),
        [Exception] NVARCHAR(2000)
    );
END
GO

-- Cria a tabela WeatherAirport se não existir
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeatherAirport]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[WeatherAirport](
        [Id] INT PRIMARY KEY IDENTITY,
        [Umidade] INT,
        [Visibilidade] NVARCHAR(100),
        [CodigoIcao] NVARCHAR(4),
        [PressaoAtmosferica] INT,
        [Vento] INT,
        [DirecaoVento] INT,
        [Condicao] NVARCHAR(100),
        [CondicaoDesc] NVARCHAR(100),
        [Temp] INT,
        [AtualizadoEm] DATETIME
    );

    CREATE INDEX IX_CodigoIcao ON [dbo].[WeatherAirport](CodigoIcao);
END
GO
