USE [master]
GO
/****** Object:  Database [TakeAStep01]    Script Date: 27/04/2023 20:00:52 ******/
CREATE DATABASE [TakeAStep01]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TakeAStep01', FILENAME = N'/var/opt/mssql/data/TakeAStep01.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TakeAStep01_log', FILENAME = N'/var/opt/mssql/data/TakeAStep01_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TakeAStep01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TakeAStep01] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TakeAStep01] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TakeAStep01] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TakeAStep01] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TakeAStep01] SET ARITHABORT OFF 
GO

ALTER DATABASE [TakeAStep01] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TakeAStep01] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TakeAStep01] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TakeAStep01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TakeAStep01] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TakeAStep01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TakeAStep01] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TakeAStep01] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TakeAStep01] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TakeAStep01] SET  ENABLE_BROKER 
GO

ALTER DATABASE [TakeAStep01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TakeAStep01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TakeAStep01] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TakeAStep01] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TakeAStep01] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TakeAStep01] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [TakeAStep01] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TakeAStep01] SET RECOVERY FULL 
GO

ALTER DATABASE [TakeAStep01] SET  MULTI_USER 
GO

ALTER DATABASE [TakeAStep01] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TakeAStep01] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TakeAStep01] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TakeAStep01] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TakeAStep01] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TakeAStep01] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [TakeAStep01] SET QUERY_STORE = ON
GO

ALTER DATABASE [TakeAStep01] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO

ALTER DATABASE [TakeAStep01] SET  READ_WRITE 
GO

/*
    Fim de criação de base de dados, proximo passo é a criação das tabelas.
    Script de criação de tabelas retirado do commando -dotnet ef migrations-
*/

-- Não remover esta linha ao alterar os scripts.
USE [TakeAStep01]
GO
--

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



-- Insert dos dados
BEGIN 

    -- Insert as Scenes
    BEGIN
        INSERT INTO TakeAStep01.dbo.Scenes (_Id, storyId, Text, Type)
        VALUES 
        (
            1, 
            1, 
            'You wake up on a deserted island. You see smoke rising in the distance. What do you do?',
            'initial'
        ),
        (
            2, 
            1, 
            'You head towards the smoke and find a tribe of natives. They welcome you and offer to help you leave the island.',
            NULL
        ),
        (
            3,
            1,
            'You wait for rescue, but after several days, no one comes. You start to run out of food and water. What do you do?',
            NULL
        ),
        (
            4,
            1,
            'The natives help you build a raft and give you directions to the nearest inhabited island. You set out and eventually make it back home.',
            'end'
        ),
        (
            5,
            1,
            'You search for food and water, but end up getting lost in the wilderness. You eventually find your way back to your shelter, but you''''re weak and hungry.',
            NULL
        ),
        (
            6,
            1,
            'You build a shelter and wait for rescue. After several more days, you are finally rescued, but you are weak and dehydrated.',
            'end'
        ),
        (
            7,
            1,
            'You return home and resume your life, grateful for the experience and the lessons you learned.',
            'end'
        ),
        (
            8,
            2,
            'You come across a fork in the road. One path leads to a dark and ominous forest, while the other leads to a bustling town. Which way will you go?',
            'initial'
        ),
        (
            9,
            2,
            'As you make your way through the forest, you stumble upon a group of goblins. They attack you without warning, and you are forced to defend yourself.',
            NULL
        ),
        (
            10,
            2,
            "You arrive in the town, which is bustling with activity. You see a merchant selling goods on the side of the road. Do you want to buy something?",
            NULL
        ),
        (
            11,
            2,
            'After defeating the goblins, you notice a cave entrance nearby. Do you want to investigate?',
            NULL
        ),
        (
            12,
            2,
            'You buy something from the merchant, but it turns out to be a fake. You feel cheated, but you learn an important lesson about trusting strangers.',
            'end'
        ),
        (
            13,
            2,
            'You explore the town further and find a hidden alleyway. You notice a small, unassuming door. Do you want to investigate?',
            NULL
        ),
        (
            14, 
            2,
            'As you explore the cave, you encounter a pack of wolves. They are fierce and aggressive, and you must fight for your life.',
            NULL
        ),
        (
            15,
            2,
            'You fight and win against the wolfs! Time to take another step!',
            'end'
        )
    END

    -- Insert das SceneEffects
    BEGIN
        INSERT INTO TakeAStep01.dbo.SceneEffects(_Id, sceneId, goldChange, hpChange)
        VALUES
        (
            1, 1, 0, 0
        ),
        (
            2, 2, 0, 0
        ),
        (
            3, 3, 0, 0
        ),
        (
            4, 4, 0, 0
        ),
        (
            5, 5, 0, -10
        ),
        (
            6, 6, 0, -20
        ),
        (
            7, 7, 0, 0
        ),
        (
            8, 8, 0, 0
        ),
        (
            9, 9, -5, -20
        ),
        (
            10, 10, 10, 0
        ),
        (
            11, 11, -5, -10
        ),
        (
            12, 12, -20, 0
        ),
        (
            13, 13, 0, 5
        ),
        (
            14, 14, -10, -10
        ),
        (
            15, 15, 2, 0
        )
    END

    -- Insert das Choices
    BEGIN
        INSERT INTO TakeAStep01.dbo.Choices(_Id, OwnSceneId, NextSceneId, Text)
        VALUES 
        (
            1,
            1,
            2,
            "Head towards the smoke."
        ),
        (
            2,
            1,
            3,
            "Stay put and wait for rescue."
        ),
        (
            3,
            2,
            4,
            "Leave the island."
        ),
        (
            4,
            3,
            5,
            "Search for food and water."
        ),
        (
            5,
            3,
            6,
            "Build a shelter and wait for rescue."
        ),
        (
            6,
            5,
            6,
            "Wait."
        ),
        (
            7,
            8,
            9,
            "Take the path through the forest."
        ),
        (
            8,
            8,
            10,
            "Head to the town."
        ),
        (
            9,
            9,
            11,
            "Fight!"
        ),
        (
            10,
            10,
            12,
            "Buy something from the merchant."
        ),
        (
            11,
            10,
            13,
            "Ignore the merchant and keep exploring the town."
        ),
        (
            12,
            11,
            14,
            "Explore the cave."
        ),
        (
            13,
            11,
            15,
            "Continue on your way."
        ),
        (
            14,
            13,
            15,
            "Open the door and go inside"
        ),
        (
            15,
            13,
            15,
            "Leave the door alone and keep exploring."
        ),
        (
            16,
            14,
            15,
            "Take the path through the forest."
        )
    END
    -- Insert dos Items
    BEGIN
        INSERT INTO TakeAStep01.dbo.Item(Id, [unique], stackable, name, description)
        VALUES 
        (
            1,
            1,
            0,
            'This is a Item name.',
            'This is the item description.'
        )
    END
    -- Insert da ligaçao entre Scenes e os items.
    BEGIN
        INSERT INTO TakeAStep01.dbo.SceneItem(SceneId, ItemId, Scene_Id)
        VALUES 
        (
            1,
            1,
            1
        )
    END
END