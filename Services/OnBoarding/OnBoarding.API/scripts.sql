IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [EmployeeStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeStatusCode] nvarchar(64) NOT NULL,
    [EmployeeStatusDescription] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_EmployeeStatusLookUps] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NULL,
    [Email] nvarchar(2048) NOT NULL,
    [EmployeeIdentityId] uniqueidentifier NOT NULL,
    [EmployeeStatusId] int NOT NULL,
    [EndDate] datetime2 NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [HireDate] datetime2 NULL,
    [LastName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [SSN] nvarchar(2048) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_EmployeeStatusLookUps_EmployeeStatusId] FOREIGN KEY ([EmployeeStatusId]) REFERENCES [EmployeeStatusLookUps] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Employees_EmployeeIdentityId] ON [Employees] ([EmployeeIdentityId]);
GO

CREATE INDEX [IX_Employees_EmployeeStatusId] ON [Employees] ([EmployeeStatusId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516145739_InitialMigration', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EmployeeStatusCode', N'EmployeeStatusDescription') AND [object_id] = OBJECT_ID(N'[EmployeeStatusLookUps]'))
    SET IDENTITY_INSERT [EmployeeStatusLookUps] ON;
INSERT INTO [EmployeeStatusLookUps] ([Id], [EmployeeStatusCode], [EmployeeStatusDescription])
VALUES (1, N'Active', N'The employee is currently employed'),
(2, N'On Leave', N'The employee is on an approved leave of absence'),
(3, N'Terminated', N'The employee''s employment has been terminated'),
(4, N'Onboarding', N'The employee is in the process of being onboarded');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EmployeeStatusCode', N'EmployeeStatusDescription') AND [object_id] = OBJECT_ID(N'[EmployeeStatusLookUps]'))
    SET IDENTITY_INSERT [EmployeeStatusLookUps] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Email', N'EmployeeIdentityId', N'EmployeeStatusId', N'EndDate', N'FirstName', N'HireDate', N'LastName', N'MiddleName', N'SSN') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] ON;
INSERT INTO [Employees] ([Id], [Address], [Email], [EmployeeIdentityId], [EmployeeStatusId], [EndDate], [FirstName], [HireDate], [LastName], [MiddleName], [SSN])
VALUES (1, N'123 Main St, City 1, Country 1', N'aries.mu@GoldSaints.com', '49d65189-9d93-4ba0-9a2e-6cd349a86c6a', 1, NULL, N'Aries', NULL, N'Mu', NULL, N'123-45-6789'),
(2, N'456 Oak St, City 2, Country 2', N'Taurus.Aldebaran@GoldSaints.com', '14467328-f534-4ad3-9eb7-614d33b2814a', 1, NULL, N'Taurus', NULL, N'Aldebaran', NULL, N'234-56-7890'),
(3, N'789 Elm St, City 3, Country 3', N'Gemini.Saga@GoldSaints.com', 'cfa82a5b-2e3c-42b9-ade0-4abda5914de6', 1, NULL, N'Gemini', NULL, N'Saga', NULL, N'345-67-8901'),
(4, N'234 Maple St, City 4, Country 4', N'Cancer.DeathMask@GoldSaints.com', '0009ced2-db4c-4e05-9459-e375bd2b06ff', 1, NULL, N'Cancer', NULL, N'DeathMask', NULL, N'456-78-9012'),
(5, N'567 Pine St, City 5, Country 5', N'Leo.Aiolia@GoldSaints.com', '8c9019dc-ea34-4b05-871a-bcc3ce01633f', 1, NULL, N'Leo', NULL, N'Aiolia', NULL, N'567-89-0123'),
(6, N'890 Cherry St, City 6, Country 6', N'Virgo.Shaka@GoldSaints.com', '2035b55f-2d17-4b86-b729-906a3113f4c3', 1, NULL, N'Virgo', NULL, N'Shaka', NULL, N'678-90-1234'),
(7, N'987 Walnut St, City 7, Country 7', N'Libra.Dohko@GoldSaints.com', 'd0b89c08-2bae-40af-9b50-f906cd7ddbdc', 1, NULL, N'Libra', NULL, N'Dohko', NULL, N'789-01-2345'),
(8, N'876 Cedar St, City 8, Country 8', N'Scorpio.Milo@GoldSaints.com', '81bc38d5-1bb1-4c61-bd9f-b074fcf50e74', 1, NULL, N'Scorpio', NULL, N'Milo', NULL, N'890-12-3456'),
(9, N'765 Birch St, City 9, Country 9', N'Sagittarius.Aiolos@GoldSaints.com', 'e6ba17d4-5712-418d-8e49-fe41ae74b043', 1, NULL, N'Sagittarius', NULL, N'Aiolos', NULL, N'901-23-4567'),
(10, N'654 Willow St, City 10, Country 10', N'Capricorn.Shura@GoldSaints.com', '4200a89b-2aad-4b94-bb65-d131fe5b4000', 1, NULL, N'Capricorn', NULL, N'Shura', NULL, N'012-34-5678'),
(11, N'543 Ash St, City 11, Country 11', N'Aquarius.Camus@GoldSaints.com', '1e0ca156-a75f-48aa-8262-82fc1461461c', 1, NULL, N'Aquarius', NULL, N'Camus', NULL, N'987-65-4321'),
(12, N'432 Cypress St, City 12, Country 12', N'Pisces.Aphrodite@GoldSaints.com', '2f793398-4c0c-4469-8002-a5905acd0136', 1, NULL, N'Pisces', NULL, N'Aphrodite', NULL, N'876-54-3210');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Email', N'EmployeeIdentityId', N'EmployeeStatusId', N'EndDate', N'FirstName', N'HireDate', N'LastName', N'MiddleName', N'SSN') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230601173855_AddOnBoardingMockData', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

