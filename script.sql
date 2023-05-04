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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
BEGIN
    CREATE INDEX [IX_Choices_NextSceneId] ON [Choices] ([NextSceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
BEGIN
    CREATE INDEX [IX_Choices_OwnSceneId] ON [Choices] ([OwnSceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
BEGIN
    CREATE UNIQUE INDEX [IX_SceneEffects_sceneId] ON [SceneEffects] ([sceneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427185837_InicialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230427185837_InicialMigration', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE TABLE [Item] (
        [Id] int NOT NULL,
        [unique] bit NOT NULL,
        [stackable] bit NULL,
        [name] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        CONSTRAINT [PK_Item] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE TABLE [Type] (
        [Id] int NOT NULL,
        [type] nvarchar(max) NULL,
        CONSTRAINT [PK_Type] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE TABLE [SceneItem] (
        [SceneId] int NOT NULL,
        [ItemId] int NOT NULL,
        [Scene_Id] int NOT NULL,
        CONSTRAINT [PK_SceneItem] PRIMARY KEY ([SceneId]),
        CONSTRAINT [FK_SceneItem_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SceneItem_Scenes_Scene_Id] FOREIGN KEY ([Scene_Id]) REFERENCES [Scenes] ([_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE TABLE [ItemType] (
        [ItemId] int NOT NULL,
        [TypeId] int NOT NULL,
        CONSTRAINT [PK_ItemType] PRIMARY KEY ([ItemId], [TypeId]),
        CONSTRAINT [FK_ItemType_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ItemType_Type_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [Type] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE INDEX [IX_ItemType_TypeId] ON [ItemType] ([TypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE INDEX [IX_SceneItem_ItemId] ON [SceneItem] ([ItemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    CREATE INDEX [IX_SceneItem_Scene_Id] ON [SceneItem] ([Scene_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230503224357_02')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230503224357_02', N'7.0.5');
END;
GO

COMMIT;
GO

