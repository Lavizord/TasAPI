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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    CREATE TABLE [Scenes] (
        [_Id] int NOT NULL,
        [storyId] int NOT NULL,
        [Type] nvarchar(max) NULL,
        [Text] nvarchar(max) NULL,
        CONSTRAINT [PK_Scenes] PRIMARY KEY ([_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    CREATE TABLE [Choices] (
        [_Id] int NOT NULL,
        [OwnSceneId] int NULL,
        [NextSceneId] int NULL,
        [Text] nvarchar(max) NULL,
        CONSTRAINT [PK_Choices] PRIMARY KEY ([_Id]),
        CONSTRAINT [FK_Choices_Scenes_NextSceneId] FOREIGN KEY ([NextSceneId]) REFERENCES [Scenes] ([_Id]),
        CONSTRAINT [FK_Choices_Scenes_OwnSceneId] FOREIGN KEY ([OwnSceneId]) REFERENCES [Scenes] ([_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    CREATE TABLE [SceneEffects] (
        [_Id] int NOT NULL,
        [sceneId] int NOT NULL,
        [hpChange] int NULL,
        [goldChange] int NULL,
        CONSTRAINT [PK_SceneEffects] PRIMARY KEY ([_Id]),
        CONSTRAINT [FK_SceneEffects_Scenes_sceneId] FOREIGN KEY ([sceneId]) REFERENCES [Scenes] ([_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    CREATE INDEX [IX_Choices_NextSceneId] ON [Choices] ([NextSceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    CREATE INDEX [IX_Choices_OwnSceneId] ON [Choices] ([OwnSceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    CREATE UNIQUE INDEX [IX_SceneEffects_sceneId] ON [SceneEffects] ([sceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425091647_01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230425091647_01', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427135711_02')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230427135711_02', N'7.0.5');
END;
GO

COMMIT;
GO

