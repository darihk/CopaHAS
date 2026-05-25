BEGIN TRANSACTION;
DECLARE @var nvarchar(max);
SELECT @var = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_JOGADORES]') AND [c].[name] = N'Posicao');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [TB_JOGADORES] DROP CONSTRAINT ' + @var + ';');
ALTER TABLE [TB_JOGADORES] ALTER COLUMN [Posicao] varchar(50) NULL;

DECLARE @var1 nvarchar(max);
SELECT @var1 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_JOGADORES]') AND [c].[name] = N'Nome');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_JOGADORES] DROP CONSTRAINT ' + @var1 + ';');
UPDATE [TB_JOGADORES] SET [Nome] = '' WHERE [Nome] IS NULL;
ALTER TABLE [TB_JOGADORES] ALTER COLUMN [Nome] varchar(100) NOT NULL;
ALTER TABLE [TB_JOGADORES] ADD DEFAULT '' FOR [Nome];

DECLARE @var2 nvarchar(max);
SELECT @var2 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ESTADIO]') AND [c].[name] = N'Nome');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TB_ESTADIO] DROP CONSTRAINT ' + @var2 + ';');
UPDATE [TB_ESTADIO] SET [Nome] = '' WHERE [Nome] IS NULL;
ALTER TABLE [TB_ESTADIO] ALTER COLUMN [Nome] varchar(150) NOT NULL;
ALTER TABLE [TB_ESTADIO] ADD DEFAULT '' FOR [Nome];

DECLARE @var3 nvarchar(max);
SELECT @var3 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ESTADIO]') AND [c].[name] = N'Cidade');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TB_ESTADIO] DROP CONSTRAINT ' + @var3 + ';');
ALTER TABLE [TB_ESTADIO] ALTER COLUMN [Cidade] varchar(100) NULL;

DECLARE @var4 nvarchar(max);
SELECT @var4 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ESTADIO]') AND [c].[name] = N'Capacidade');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TB_ESTADIO] DROP CONSTRAINT ' + @var4 + ';');
ALTER TABLE [TB_ESTADIO] ALTER COLUMN [Capacidade] decimal(18,2) NOT NULL;

CREATE TABLE [TB_JOGOS] (
    [Id] int NOT NULL IDENTITY,
    [DataHora] datetime2 NOT NULL,
    [EstadioId] int NOT NULL,
    CONSTRAINT [PK_TB_JOGOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_JOGOS_TB_ESTADIO_EstadioId] FOREIGN KEY ([EstadioId]) REFERENCES [TB_ESTADIO] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [TB_SELECOES] (
    [Id] int NOT NULL IDENTITY,
    [Pais] varchar(100) NOT NULL,
    CONSTRAINT [PK_TB_SELECOES] PRIMARY KEY ([Id])
);

CREATE TABLE [TB_JOGOS_SELECOES] (
    [JogoId] int NOT NULL,
    [SelecaoId] int NOT NULL,
    [Gols] int NOT NULL,
    [GolsProrrogacao] int NOT NULL,
    [GolsDecisaoPenaltis] int NOT NULL,
    CONSTRAINT [PK_TB_JOGOS_SELECOES] PRIMARY KEY ([JogoId], [SelecaoId]),
    CONSTRAINT [FK_TB_JOGOS_SELECOES_TB_JOGOS_JogoId] FOREIGN KEY ([JogoId]) REFERENCES [TB_JOGOS] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_JOGOS_SELECOES_TB_SELECOES_SelecaoId] FOREIGN KEY ([SelecaoId]) REFERENCES [TB_SELECOES] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [TB_TECNICOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [SelecaoId] int NOT NULL,
    CONSTRAINT [PK_TB_TECNICOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_TECNICOS_TB_SELECOES_SelecaoId] FOREIGN KEY ([SelecaoId]) REFERENCES [TB_SELECOES] ([Id]) ON DELETE CASCADE
);

UPDATE [TB_ESTADIO] SET [Capacidade] = 82500.0, [Cidade] = 'East Rutherford (NY/NJ)', [Nome] = 'MetLife Stadium'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_ESTADIO] SET [Capacidade] = 70240.0, [Cidade] = 'Los Angeles (CA)', [Nome] = 'SoFi Stadium'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_ESTADIO] SET [Capacidade] = 80000.0, [Cidade] = 'Arlington (TX)', [Nome] = 'AT&T Stadium'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_ESTADIO] SET [Capacidade] = 71000.0, [Cidade] = 'Atlanta (GA)', [Nome] = 'Mercedes-Benz Stadium'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_ESTADIO] SET [Capacidade] = 72220.0, [Cidade] = 'Houston (TX)', [Nome] = 'NRG Stadium'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_ESTADIO] SET [Capacidade] = 68500.0, [Cidade] = 'Santa Clara (CA)', [Nome] = 'Levi''s Stadium'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_ESTADIO] SET [Capacidade] = 68740.0, [Cidade] = 'Seattle (WA)', [Nome] = 'Lumen Field'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIO]'))
    SET IDENTITY_INSERT [TB_ESTADIO] ON;
INSERT INTO [TB_ESTADIO] ([Id], [Capacidade], [Cidade], [Nome])
VALUES (8, 69596.0, 'Philadelphia (PA)', 'Lincoln Financial Field'),
(9, 65326.0, 'Miami (FL)', 'Hard Rock Stadium'),
(10, 76416.0, 'Kansas City (MO)', 'GEHA Field at Arrowhead Stadium'),
(11, 65878.0, 'Foxborough (MA)', 'Gillette Stadium'),
(12, 54500.0, 'Vancouver', 'BC Place'),
(13, 30000.0, 'Toronto', 'BMO Field'),
(14, 87000.0, 'Cidade do México', 'Estadio Azteca'),
(15, 53500.0, 'Monterrey', 'Estadio BBVA'),
(16, 49850.0, 'Guadalajara', 'Estadio Akron');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIO]'))
    SET IDENTITY_INSERT [TB_ESTADIO] OFF;

CREATE INDEX [IX_TB_JOGADORES_SelecaoId] ON [TB_JOGADORES] ([SelecaoId]);

CREATE INDEX [IX_TB_JOGOS_EstadioId] ON [TB_JOGOS] ([EstadioId]);

CREATE INDEX [IX_TB_JOGOS_SELECOES_SelecaoId] ON [TB_JOGOS_SELECOES] ([SelecaoId]);

CREATE UNIQUE INDEX [IX_TB_TECNICOS_SelecaoId] ON [TB_TECNICOS] ([SelecaoId]);

ALTER TABLE [TB_JOGADORES] ADD CONSTRAINT [FK_TB_JOGADORES_TB_SELECOES_SelecaoId] FOREIGN KEY ([SelecaoId]) REFERENCES [TB_SELECOES] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260525114242_MigracaoEstadios', N'10.0.5');

COMMIT;
GO

