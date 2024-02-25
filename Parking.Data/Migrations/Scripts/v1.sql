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

CREATE TABLE [Records] (
    [Id] uniqueidentifier NOT NULL,
    [In] datetime2 NOT NULL,
    [Out] datetime2 NULL,
    [Quantity] int NOT NULL,
    [Type] int NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Records] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240225052054_initial', N'7.0.16');
GO

COMMIT;
GO

