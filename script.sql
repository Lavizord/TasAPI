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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [Items] (
        [Id] int NOT NULL,
        [unique] bit NOT NULL,
        [stackable] bit NULL,
        [name] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [Scenes] (
        [Id] int NOT NULL,
        [storyId] int NOT NULL,
        [Type] nvarchar(max) NULL,
        [Text] nvarchar(max) NULL,
        CONSTRAINT [PK_Scenes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [Types] (
        [Id] int NOT NULL,
        [type] nvarchar(max) NULL,
        CONSTRAINT [PK_Types] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [Choices] (
        [Id] int NOT NULL,
        [OwnSceneId] int NULL,
        [NextSceneId] int NULL,
        [Text] nvarchar(max) NULL,
        CONSTRAINT [PK_Choices] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Choices_Scenes_NextSceneId] FOREIGN KEY ([NextSceneId]) REFERENCES [Scenes] ([Id]),
        CONSTRAINT [FK_Choices_Scenes_OwnSceneId] FOREIGN KEY ([OwnSceneId]) REFERENCES [Scenes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [SceneEffects] (
        [Id] int NOT NULL,
        [sceneId] int NOT NULL,
        [hpChange] int NULL,
        [goldChange] int NULL,
        CONSTRAINT [PK_SceneEffects] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SceneEffects_Scenes_sceneId] FOREIGN KEY ([sceneId]) REFERENCES [Scenes] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [SceneItems] (
        [SceneId] int NOT NULL,
        [ItemId] int NOT NULL,
        CONSTRAINT [PK_SceneItems] PRIMARY KEY ([ItemId], [SceneId]),
        CONSTRAINT [FK_SceneItems_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SceneItems_Scenes_SceneId] FOREIGN KEY ([SceneId]) REFERENCES [Scenes] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [ItemTypes] (
        [ItemId] int NOT NULL,
        [TypeId] int NOT NULL,
        CONSTRAINT [PK_ItemTypes] PRIMARY KEY ([ItemId], [TypeId]),
        CONSTRAINT [FK_ItemTypes_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ItemTypes_Types_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [Types] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE TABLE [SceneTypes] (
        [SceneId] int NOT NULL,
        [TypeId] int NOT NULL,
        CONSTRAINT [PK_SceneTypes] PRIMARY KEY ([SceneId], [TypeId]),
        CONSTRAINT [FK_SceneTypes_Scenes_SceneId] FOREIGN KEY ([SceneId]) REFERENCES [Scenes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SceneTypes_Types_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [Types] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE INDEX [IX_Choices_NextSceneId] ON [Choices] ([NextSceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE INDEX [IX_Choices_OwnSceneId] ON [Choices] ([OwnSceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE INDEX [IX_ItemTypes_TypeId] ON [ItemTypes] ([TypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE UNIQUE INDEX [IX_SceneEffects_sceneId] ON [SceneEffects] ([sceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE INDEX [IX_SceneItems_SceneId] ON [SceneItems] ([SceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    CREATE INDEX [IX_SceneTypes_TypeId] ON [SceneTypes] ([TypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230508114034_01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230508114034_01', N'7.0.5');
END;
GO

COMMIT;
GO

