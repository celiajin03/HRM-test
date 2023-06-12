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

CREATE TABLE [Interviewers] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [EmployeeIdentityId] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Interviewers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [InterviewTypeLookUps] (
    [Id] int NOT NULL IDENTITY,
    [InterviewTypeCode] nvarchar(50) NOT NULL,
    [InterviewTypeDescription] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_InterviewTypeLookUps] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Interviews] (
    [Id] int NOT NULL IDENTITY,
    [BeginTime] datetime2 NOT NULL,
    [CandidateEmail] nvarchar(max) NOT NULL,
    [CandidateFirstName] nvarchar(50) NOT NULL,
    [CandidateIdentityId] uniqueidentifier NOT NULL,
    [CandidateLastName] nvarchar(50) NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [Feedback] nvarchar(max) NULL,
    [InterviewerId] int NOT NULL,
    [InterviewTypeId] int NOT NULL,
    [Passed] bit NULL,
    [Rating] int NULL,
    [SubmissionId] int NOT NULL,
    CONSTRAINT [PK_Interviews] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Interviews_InterviewTypeLookUps_InterviewTypeId] FOREIGN KEY ([InterviewTypeId]) REFERENCES [InterviewTypeLookUps] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Interviews_Interviewers_InterviewerId] FOREIGN KEY ([InterviewerId]) REFERENCES [Interviewers] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Interviewers_EmployeeIdentityId] ON [Interviewers] ([EmployeeIdentityId]);
GO

CREATE UNIQUE INDEX [IX_Interviews_CandidateIdentityId] ON [Interviews] ([CandidateIdentityId]);
GO

CREATE INDEX [IX_Interviews_InterviewerId] ON [Interviews] ([InterviewerId]);
GO

CREATE INDEX [IX_Interviews_InterviewTypeId] ON [Interviews] ([InterviewTypeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516153155_InitialMigration', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InterviewTypeCode', N'InterviewTypeDescription') AND [object_id] = OBJECT_ID(N'[InterviewTypeLookUps]'))
    SET IDENTITY_INSERT [InterviewTypeLookUps] ON;
INSERT INTO [InterviewTypeLookUps] ([Id], [InterviewTypeCode], [InterviewTypeDescription])
VALUES (1, N'P', N'Phone Screen'),
(2, N'T', N'Technical Interview'),
(3, N'B', N'Behavioral Interview'),
(4, N'C', N'Case Interview'),
(5, N'S', N'Stress Interview'),
(6, N'O', N'On-site Interview');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InterviewTypeCode', N'InterviewTypeDescription') AND [object_id] = OBJECT_ID(N'[InterviewTypeLookUps]'))
    SET IDENTITY_INSERT [InterviewTypeLookUps] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'EmployeeIdentityId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Interviewers]'))
    SET IDENTITY_INSERT [Interviewers] ON;
INSERT INTO [Interviewers] ([Id], [Email], [EmployeeIdentityId], [FirstName], [LastName])
VALUES (1, N'aries.mu@GoldSaints.com', N'49d65189-9d93-4ba0-9a2e-6cd349a86c6a', N'Aries', N'Mu'),
(2, N'Taurus.Aldebaran@GoldSaints.com', N'14467328-f534-4ad3-9eb7-614d33b2814a', N'Taurus', N'Aldebaran'),
(3, N'Gemini.Saga@GoldSaints.com', N'cfa82a5b-2e3c-42b9-ade0-4abda5914de6', N'Gemini', N'Saga'),
(4, N'Cancer.DeathMask@GoldSaints.com', N'0009ced2-db4c-4e05-9459-e375bd2b06ff', N'Cancer', N'DeathMask'),
(5, N'Leo.Aiolia@GoldSaints.com', N'8c9019dc-ea34-4b05-871a-bcc3ce01633f', N'Leo', N'Aiolia'),
(6, N'Virgo.Shaka@GoldSaints.com', N'2035b55f-2d17-4b86-b729-906a3113f4c3', N'Virgo', N'Shaka'),
(7, N'Libra.Dohko@GoldSaints.com', N'd0b89c08-2bae-40af-9b50-f906cd7ddbdc', N'Libra', N'Dohko'),
(8, N'Scorpio.Milo@GoldSaints.com', N'81bc38d5-1bb1-4c61-bd9f-b074fcf50e74', N'Scorpio', N'Milo'),
(9, N'Sagittarius.Aiolos@GoldSaints.com', N'e6ba17d4-5712-418d-8e49-fe41ae74b043', N'Sagittarius', N'Aiolos'),
(10, N'Capricorn.Shura@GoldSaints.com', N'4200a89b-2aad-4b94-bb65-d131fe5b4000', N'Capricorn', N'Shura'),
(11, N'Aquarius.Camus@GoldSaints.com', N'1e0ca156-a75f-48aa-8262-82fc1461461c', N'Aquarius', N'Camus'),
(12, N'Pisces.Aphrodite@GoldSaints.com', N'2f793398-4c0c-4469-8002-a5905acd0136', N'Pisces', N'Aphrodite');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'EmployeeIdentityId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Interviewers]'))
    SET IDENTITY_INSERT [Interviewers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BeginTime', N'CandidateEmail', N'CandidateFirstName', N'CandidateIdentityId', N'CandidateLastName', N'EndTime', N'Feedback', N'InterviewTypeId', N'InterviewerId', N'Passed', N'Rating', N'SubmissionId') AND [object_id] = OBJECT_ID(N'[Interviews]'))
    SET IDENTITY_INSERT [Interviews] ON;
INSERT INTO [Interviews] ([Id], [BeginTime], [CandidateEmail], [CandidateFirstName], [CandidateIdentityId], [CandidateLastName], [EndTime], [Feedback], [InterviewTypeId], [InterviewerId], [Passed], [Rating], [SubmissionId])
VALUES (1, '2023-05-16T09:00:00.0000000', N'emilytaylor@gmail.com', N'Emily', '00000000-0000-0000-0000-000000000001', N'Taylor', '2023-05-16T09:30:00.0000000', N'Good communication skills', 1, 1, CAST(1 AS bit), 4, 1),
(2, '2023-05-17T14:00:00.0000000', N'michaeljohnson@gmail.com', N'Michael', '00000000-0000-0000-0000-000000000002', N'Johnson', '2023-05-17T15:00:00.0000000', N'Strong technical skills', 2, 2, CAST(1 AS bit), 5, 2),
(3, '2023-05-18T10:30:00.0000000', N'john.smith@example.com', N'John', '00000000-0000-0000-0000-000000000003', N'Smith', '2023-05-18T11:00:00.0000000', N'Struggled to articulate their thoughts coherently', 3, 3, CAST(0 AS bit), 2, 3),
(4, '2023-05-19T09:00:00.0000000', N'sarah.williams@example.com', N'Sarah', '00000000-0000-0000-0000-000000000004', N'Williams', '2023-05-19T09:30:00.0000000', NULL, 4, 4, NULL, NULL, 4),
(5, '2023-05-20T14:30:00.0000000', N'david.wilson@example.com', N'David', '00000000-0000-0000-0000-000000000005', N'Wilson', '2023-05-20T15:00:00.0000000', NULL, 5, 5, NULL, NULL, 5),
(6, '2023-05-21T18:00:00.0000000', N'emma.brown@example.com', N'Emma', '00000000-0000-0000-0000-000000000006', N'Brown', '2023-05-21T19:00:00.0000000', NULL, 6, 6, NULL, NULL, 6),
(7, '2023-05-31T12:00:00.0000000', N'danielmiller@example.com', N'Daniel', '00000000-0000-0000-0000-000000000007', N'Miller', '2023-05-31T12:30:00.0000000', NULL, 1, 7, NULL, NULL, 7),
(8, '2023-05-31T13:00:00.0000000', N'oliviaanderson@example.com', N'Olivia', '00000000-0000-0000-0000-000000000008', N'Anderson', '2023-05-31T13:30:00.0000000', NULL, 2, 8, NULL, NULL, 8);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BeginTime', N'CandidateEmail', N'CandidateFirstName', N'CandidateIdentityId', N'CandidateLastName', N'EndTime', N'Feedback', N'InterviewTypeId', N'InterviewerId', N'Passed', N'Rating', N'SubmissionId') AND [object_id] = OBJECT_ID(N'[Interviews]'))
    SET IDENTITY_INSERT [Interviews] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230601162750_AddInterviewsMockData', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

