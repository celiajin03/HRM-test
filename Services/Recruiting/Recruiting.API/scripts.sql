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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [JobCode] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [StartDate] datetime2 NULL,
    [IsActive] bit NULL,
    [NumberOfPositions] int NOT NULL,
    [CloseOn] datetime2 NULL,
    [ClosedReason] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230510203611_InitialMigration', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Title');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Title] nvarchar(80) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Description');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Description] nvarchar(2048) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'ClosedReason');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [ClosedReason] nvarchar(1024) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230510212634_UpdatingJobsTable', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Candidates] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(512) NOT NULL,
    [ResumeURL] nvarchar(2048) NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511013812_CreatingCandidateTable', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Jobs] ADD [JobStatusLookUpId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [JobStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [JobStatusCode] nvarchar(max) NOT NULL,
    [JobStatusDescription] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_JobStatusLookUps] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Jobs_JobStatusLookUpId] ON [Jobs] ([JobStatusLookUpId]);
GO

ALTER TABLE [Jobs] ADD CONSTRAINT [FK_Jobs_JobStatusLookUps_JobStatusLookUpId] FOREIGN KEY ([JobStatusLookUpId]) REFERENCES [JobStatusLookUps] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511015240_JobStatusLookUpTable', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Submissions] (
    [Id] int NOT NULL IDENTITY,
    [JobId] int NOT NULL,
    [CandidateId] int NOT NULL,
    [SubmittedOn] datetime2 NULL,
    [SelectedForInterview] datetime2 NULL,
    [RejectedOn] datetime2 NULL,
    [RejectedReason] nvarchar(max) NULL,
    CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Submissions_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Submissions_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Submissions_CandidateId] ON [Submissions] ([CandidateId]);
GO

CREATE INDEX [IX_Submissions_JobId] ON [Submissions] ([JobId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511021444_SubmissionsTable', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'FirstName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [FirstName] nvarchar(100) NOT NULL;
GO

ALTER TABLE [Candidates] ADD [CreatedOn] datetime2 NOT NULL DEFAULT (getdate());
GO

CREATE UNIQUE INDEX [IX_Candidates_Email] ON [Candidates] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511023619_UpdatingCandidateTable', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOn', N'Email', N'FirstName', N'LastName', N'MiddleName', N'ResumeURL') AND [object_id] = OBJECT_ID(N'[Candidates]'))
    SET IDENTITY_INSERT [Candidates] ON;
INSERT INTO [Candidates] ([Id], [CreatedOn], [Email], [FirstName], [LastName], [MiddleName], [ResumeURL])
VALUES (1, '2023-05-16T17:13:14.5933333', N'emilytaylor@gmail.com', N'Emily', N'Taylor', NULL, N'https://example.com/resumes/emilytaylor'),
(2, '2023-05-16T17:14:35.9600000', N'michaeljohnson@gmail.com', N'Michael', N'Johnson', NULL, N'https://example.com/resumes/michaeljohnson'),
(3, '2023-05-17T01:41:50.7433333', N'john.smith@example.com', N'John', N'Smith', NULL, N'resume_url_1'),
(4, '2023-05-18T09:25:00.1234567', N'sarah.williams@example.com', N'Sarah', N'Williams', NULL, N'https://example.com/resumes/sarahwilliams'),
(5, '2023-05-19T14:30:45.9876543', N'david.wilson@example.com', N'David', N'Wilson', NULL, N'resume_url_2'),
(6, '2023-05-20T18:45:12.3456789', N'emma.brown@example.com', N'Emma', N'Brown', NULL, N'https://example.com/resumes/emmabrown'),
(7, '2023-05-31T16:55:00.0000000Z', N'danielmiller@example.com', N'Daniel', N'Miller', NULL, N'https://example.com/resumes/danielmiller.pdf'),
(8, '2023-05-31T17:10:00.0000000Z', N'oliviaanderson@example.com', N'Olivia', N'Anderson', NULL, N'https://example.com/resumes/oliviaanderson.pdf'),
(9, '2023-05-31T19:35:00.0000000Z', N'sophiaclark@example.com', N'Sophia', N'Clark', NULL, N'https://example.com/resumes/sophiaclark.pdf'),
(10, '2023-05-31T21:05:00.0000000Z', N'avahill@example.com', N'Ava', N'Hill', NULL, N'https://example.com/resumes/avahill.pdf'),
(11, '2023-05-31T22:20:00.0000000Z', N'christophergonzalez@example.com', N'Christopher', N'Gonzalez', NULL, N'https://example.com/resumes/christophergonzalez.pdf');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOn', N'Email', N'FirstName', N'LastName', N'MiddleName', N'ResumeURL') AND [object_id] = OBJECT_ID(N'[Candidates]'))
    SET IDENTITY_INSERT [Candidates] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'JobStatusCode', N'JobStatusDescription') AND [object_id] = OBJECT_ID(N'[JobStatusLookUps]'))
    SET IDENTITY_INSERT [JobStatusLookUps] ON;
INSERT INTO [JobStatusLookUps] ([Id], [JobStatusCode], [JobStatusDescription])
VALUES (1, N'Open', N'Job is Open'),
(2, N'Pending', N'Job is Pending'),
(3, N'Closed', N'Job is Closed');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'JobStatusCode', N'JobStatusDescription') AND [object_id] = OBJECT_ID(N'[JobStatusLookUps]'))
    SET IDENTITY_INSERT [JobStatusLookUps] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CloseOn', N'ClosedReason', N'CreatedOn', N'Description', N'IsActive', N'JobCode', N'JobStatusLookUpId', N'NumberOfPositions', N'StartDate', N'Title') AND [object_id] = OBJECT_ID(N'[Jobs]'))
    SET IDENTITY_INSERT [Jobs] ON;
INSERT INTO [Jobs] ([Id], [CloseOn], [ClosedReason], [CreatedOn], [Description], [IsActive], [JobCode], [JobStatusLookUpId], [NumberOfPositions], [StartDate], [Title])
VALUES (1, NULL, NULL, '2023-05-10T01:53:36.8335340', N'Need to be good with C#', CAST(1 AS bit), '9a8b615e-5ba5-4211-84a0-c8c4998549a1', 1, 2, '2023-04-04T00:00:00.0000000', N'.NET Developer'),
(2, NULL, NULL, '2023-05-10T15:25:39.0321810', N'Need to be good with Java', CAST(1 AS bit), 'f45e3dc6-7c56-4f6d-b74a-3d53c7f9dc60', 1, 4, '2023-04-05T00:00:00.0000000', N'Java Developer'),
(3, NULL, NULL, '2023-05-14T01:53:36.8335340', N'Good with C#', CAST(1 AS bit), 'aebb8a82-734b-4b47-9475-64e127e1f4a0', 1, 4, '2023-05-12T00:00:00.0000000', N'C# Dev'),
(4, NULL, NULL, '2023-05-15T16:55:18.4739500', N'Looking for a skilled frontend developer with experience in HTML, CSS, and JavaScript.', CAST(1 AS bit), 'b2d06b8e-9e15-4d13-a22e-f07c5e3f52cc', 1, 3, '2023-06-01T09:00:00.0000000', N'Frontend Developer'),
(5, NULL, NULL, '2023-05-30T13:45:00.0000000Z', N'Develop and maintain software applications.', CAST(1 AS bit), 'a6b8a2f4-8eae-4a82-9e99-3a3fd4960011', 1, 10, '2023-06-15T09:00:00.0000000Z', N'Software Developer'),
(6, NULL, NULL, '2023-05-28T10:30:00.0000000Z', N'Promote and sell products to customers.', CAST(1 AS bit), '03d19b10-579f-4b45-9461-8c7d1d06f092', 1, 2, '2023-07-01T09:00:00.0000000Z', N'Sales Representative'),
(7, NULL, NULL, '2023-05-25T16:20:00.0000000Z', N'Analyze and interpret complex data sets.', CAST(1 AS bit), 'e9e8192a-84c5-4a8a-940e-2e9793817d4f', 1, 5, '2023-06-20T09:00:00.0000000Z', N'Data Analyst'),
(8, NULL, NULL, '2023-05-23T09:15:00.0000000Z', N'Create visually appealing designs for marketing materials.', CAST(1 AS bit), 'c0571f0b-0e47-4181-89f6-82e3ae6a86c1', 1, 3, '2023-06-25T09:00:00.0000000Z', N'Graphic Designer'),
(9, NULL, NULL, '2023-05-19T03:28:00.0000000Z', N'Develop and implement marketing strategies.', CAST(1 AS bit), 'f03e9879-6ab1-4e4d-9ff9-81a9a5c218b8', 1, 2, '2023-07-10T09:00:00.0000000Z', N'Marketing Manager'),
(10, NULL, NULL, '2023-05-12T13:15:00.0000000Z', N'Lead and oversee project planning and execution.', CAST(1 AS bit), '7815d102-24d1-45fe-8b32-3e0e0d97e317', 1, 8, '2023-07-12T09:00:00.0000000Z', N'Project Manager'),
(1003, NULL, NULL, '2023-05-14T19:25:39.0321810', N'Good with Azure', CAST(1 AS bit), 'd67e8644-8a29-40a1-9d6f-1eae6cc7b29a', 1, 5, '2023-05-14T00:00:00.0000000', N'Azure Developer');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CloseOn', N'ClosedReason', N'CreatedOn', N'Description', N'IsActive', N'JobCode', N'JobStatusLookUpId', N'NumberOfPositions', N'StartDate', N'Title') AND [object_id] = OBJECT_ID(N'[Jobs]'))
    SET IDENTITY_INSERT [Jobs] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CandidateId', N'JobId', N'RejectedOn', N'RejectedReason', N'SelectedForInterview', N'SubmittedOn') AND [object_id] = OBJECT_ID(N'[Submissions]'))
    SET IDENTITY_INSERT [Submissions] ON;
INSERT INTO [Submissions] ([Id], [CandidateId], [JobId], [RejectedOn], [RejectedReason], [SelectedForInterview], [SubmittedOn])
VALUES (1, 1, 1, NULL, NULL, NULL, '2023-05-20T09:00:00.0000000Z'),
(2, 2, 2, NULL, NULL, NULL, '2023-05-21T10:30:00.0000000Z'),
(3, 3, 3, NULL, NULL, NULL, '2023-05-22T14:15:00.0000000Z'),
(4, 4, 1003, NULL, NULL, NULL, '2023-05-23T16:45:00.0000000Z'),
(5, 5, 5, NULL, NULL, NULL, '2023-05-24T11:00:00.0000000Z'),
(6, 6, 6, NULL, NULL, NULL, '2023-05-25T09:30:00.0000000Z'),
(7, 7, 7, NULL, NULL, NULL, '2023-05-26T13:20:00.0000000Z'),
(8, 8, 8, NULL, NULL, NULL, '2023-05-27T10:10:00.0000000Z');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CandidateId', N'JobId', N'RejectedOn', N'RejectedReason', N'SelectedForInterview', N'SubmittedOn') AND [object_id] = OBJECT_ID(N'[Submissions]'))
    SET IDENTITY_INSERT [Submissions] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230611232938_AddRecruitingMockData', N'8.0.0-preview.3.23174.2');
GO

COMMIT;
GO

