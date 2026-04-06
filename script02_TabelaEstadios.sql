BEGIN TRANSACTION;
CREATE TABLE [TB_ESTADIO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NULL,
    [Cidade] varchar(200) NULL,
    [Capacidade] int NOT NULL,
    CONSTRAINT [PK_TB_ESTADIO] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIO]'))
    SET IDENTITY_INSERT [TB_ESTADIO] ON;
INSERT INTO [TB_ESTADIO] ([Id], [Capacidade], [Cidade], [Nome])
VALUES (1, 2000, 'Cidadezona', 'Estadio1'),
(2, 1200, 'Cidade', 'Estadio2'),
(3, 3100, 'Osasco', 'Estadio3'),
(4, 8000, 'Itaquaquecetuba', 'Estadio4'),
(5, 1300, 'Itapevi', 'Estadio5'),
(6, 6700, 'Guarulhos', 'Estadio6'),
(7, 12000, 'São Paulo', 'Estadio7');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIO]'))
    SET IDENTITY_INSERT [TB_ESTADIO] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406110258_MigracaoEstadios', N'10.0.5');

COMMIT;
GO

