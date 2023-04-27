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

USE [TakeAStep01]
GO

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

BEGIN 
    -- Insert as Scenes
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
    )

    -- Insert das SceneEffects
    INSERT INTO TakeAStep01.dbo.SceneEffects(_Id, sceneId, goldChange, hpChange)
    VALUES
    (
        1, 1, 0, 0
    ),
    (
        2, 2, 0, 0
    )
END